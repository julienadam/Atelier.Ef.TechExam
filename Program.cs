using Atelier.Ef.TechExam.Domain;
using Atelier.Ef.TechExam.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

// CreateQuestion();
// ModifySujet();
// AddReponseNoInclude();
// RemoveReponseById();
// RemoveReponseOnQuestion();
// ModifyAndAttach();
// ReadChangeTracking();
// CascadeDelete();
// ProblematicCascadeDelete();
// NonProblematicCascadeDelete();
// ManualCascadeDelete();
// TxEnChaine();
// TxExterne(true);
// TxExterne(false);

PasDeConcurrence();

static void PasDeConcurrence()
{
    int passageId = CreatePassage();
    Task.WaitAll(
        AnnulerPassage(passageId, "Le candidat a trouvé un poste ailleurs."), 
        PrendreRendezVous(passageId, DateTime.Now.AddDays(1)));
}

static async Task AnnulerPassage(int passageId, string raison)
{
    Console.WriteLine("Démarrage de l'annulation");
    using var context = new TechExamContext();
    var passage = await context.Passages.SingleAsync(p => p.PassageId == passageId);

    if (passage.Statut != StatutPassage.Annule)
    {
        passage.Statut = StatutPassage.Annule;
        passage.RendezVous = null;
        passage.RaisonAnnulation = raison;
    }

    await Task.Delay(TimeSpan.FromSeconds(3));
    await context.SaveChangesAsync();
    Console.WriteLine("Annulation enregistrée");
}

static async Task PrendreRendezVous(int passageId, DateTime dateRendezVous)
{
    Console.WriteLine("Démarrage du rendez-vous");
    using var context = new TechExamContext();
    var passage = await context.Passages.SingleAsync(p => p.PassageId == passageId);

    if (passage.Statut == StatutPassage.NonPlanifie)
    {
        passage.RendezVous = dateRendezVous;
        passage.Statut = StatutPassage.Planifie;
    }

    await Task.Delay(TimeSpan.FromSeconds(6));
    await context.SaveChangesAsync();
    Console.WriteLine("Rendez-vous pris");
}

static void TxExterne(bool commit)
{
    using var conn = new SqlConnection(TechExamContext.CONN_STR);
    conn.Open();
    using var tx = conn.BeginTransaction();

    var titre = $"TxExterne{Guid.NewGuid()}";

    conn.Execute(
        "INSERT INTO Sujets (Titre) VALUES (@titre)", 
        new { titre }, transaction: tx);

    using(var context = new TechExamContext())
    {
        context.Database.SetDbConnection(conn);
        context.Database.UseTransaction(tx);

        var sujet = context.Sujets.Single(s => s.Titre == titre);
        var q = new QuestionChoixMultiple
        {
            Sujets = [sujet],
            Contenu = "Question Tx Externe " + titre,
            Niveau = Niveau.Debutant,
            Reponses = []
        };
        context.Questions.Add(q);
        context.SaveChanges();
    }
    if (commit)
    {
        tx.Commit();
    }
    else
    {
        tx.Rollback();
    }
    
}

static void TxEnChaine()
{
    using (var context = new TechExamContext())
    {
        context.Sujets.Add(new Sujet { Titre = "TxEnChaine" });
        context.SaveChanges();

        context.Sujets.Add(new Sujet { Titre = "TxEnChaine2" });
        context.SaveChanges();

        context.Sujets.Add(new Sujet { Titre = "TxEnChaine" });
        context.SaveChanges();
    }
}

static void ManualCascadeDelete()
{
    // Attention: nécessite d'avoir exécuté NonProblematicCascadeDelete avant
    using (var context = new TechExamContext())
    {
        var sujet = context.Sujets
            .Single(s => s.Titre == "ProblematicCascadeDelete");
        
        var parametrages = context.ParametragesExamen
            .Where(p => p.SujetId == sujet.SujetId);

        context.ParametragesExamen.RemoveRange(parametrages);
        context.Sujets.Remove(sujet);
        context.SaveChanges();
    }
}

static void NonProblematicCascadeDelete()
{
    // ATTENTION: vérifier le comportement de cascading avant de lancer
    // Vérifier qu'on a bien un OnDelete(NoAction) sur Sujet <-> ParametrageExamen
    ProblematicCascadeDelete();
}

static void ProblematicCascadeDelete()
{
    // ATTENTION: vérifier le comportement de cascading avant de lancer
    // Vérifier qu'on a pas de OnDelete Sujet <-> ParametrageExamen
    var sujetId = 0;
    using (var context = new TechExamContext())
    {
        var sujet = new Sujet { Titre = "ProblematicCascadeDelete" };
        var p = new ParametrageExamen
        {
            ParametrageExamenId = Guid.NewGuid(),
            Sujet = sujet,
            VentilationParNiveaux = new VentilationParNiveaux
            {
                PourcentageDebutant = (StrictIntPercent)1,
                PourcentageIntermediaire = (StrictIntPercent) 1,
                PourcentageAvance = (StrictIntPercent)98,
            }
        };
        context.ParametragesExamen.Add(p);
        context.SaveChanges();
        sujetId = sujet.SujetId;
    }

    using (var context = new TechExamContext())
    {
        var sujet = context
            .Sujets
            .Single(q => q.SujetId == sujetId);

        context.Remove(sujet);
        context.SaveChanges();
    }
}

static void CascadeDelete()
{
    var qId = 0;
    using (var context = new TechExamContext())
    {
        var sujet = new Sujet { Titre = "Java" };
        var question = new QuestionChoixMultiple
        {
            Sujets = [sujet],
            Contenu = "Which of the following is a correct variable declaration in Java?",
            Niveau = Niveau.Debutant,
            Reponses =
            [
                new Reponse { Contenu = "int number = 5;", Correcte = true },
                new Reponse { Contenu = "integer number = 5;", Correcte = false },
                new Reponse { Contenu = "num number = 5;", Correcte = false },
                new Reponse { Contenu = "number: int = 5;", Correcte = false },
            ]
        };

        context.Questions.Add(question);
        context.SaveChanges();
        qId = question.QuestionId;
    }

    using (var context = new TechExamContext())
    {
        var question = context.Questions.Single(q => q.QuestionId == qId);
        context.Remove(question);
        context.SaveChanges();
    }
}

static void ValidatePercents(EntityEntry<VentilationParNiveaux> entry)
{
    switch(entry.State)
    {
        case EntityState.Added:
        case EntityState.Modified:
            var pDeb = entry.CurrentValues.GetValue<StrictIntPercent>(
                nameof(VentilationParNiveaux.PourcentageDebutant));
            var pInter = entry.CurrentValues.GetValue<StrictIntPercent>(
                nameof(VentilationParNiveaux.PourcentageIntermediaire));
            var pAvance = entry.CurrentValues.GetValue<StrictIntPercent>(
                nameof(VentilationParNiveaux.PourcentageAvance));

            if((int) pDeb+ (int)pInter + (int)pAvance != 100)
            {
                throw new InvalidDataException("La somme des pourcentages doit valoir 100");
            }

            break;
    }
}

static void ReadChangeTracking()
{
    var id = Guid.NewGuid();
    using (var context = new TechExamContext())
    {
        var parametrage = new ParametrageExamen
        {
            ParametrageExamenId = id,
            SujetId = 5,
            VentilationParNiveaux = new VentilationParNiveaux
            {
                PourcentageDebutant = (StrictIntPercent)33,
                PourcentageAvance = (StrictIntPercent)33,
                PourcentageIntermediaire = (StrictIntPercent)34,
            },
            QuestionsLibres = 0,
            DureeMinutes = 60
        };

        context.ParametragesExamen.Add(parametrage);
        ValidatePercents(context.Entry(parametrage.VentilationParNiveaux));
        context.SaveChanges();
    }

    using (var context = new TechExamContext())
    {
        var parametrage = context.ParametragesExamen.Single(p => p.ParametrageExamenId == id);
        parametrage.VentilationParNiveaux.PourcentageDebutant = (StrictIntPercent)50;
        ValidatePercents(context.Entry(parametrage.VentilationParNiveaux));
        context.SaveChanges();
    }
}

static void AttachAndModify()
{
    Sujet? sujet = new Sujet { Titre = "AttachAndModify" };
    using (var context1 = new TechExamContext())
    {
        context1.Sujets.Add(sujet);
        context1.SaveChanges();
    }

    using (var context2 = new TechExamContext())
    {
        context2.Attach(sujet);
        sujet.Titre = "Foo";
        context2.SaveChanges();
    }
}

static void ModifyAndAttach()
{
    Sujet? sujet = new Sujet { Titre = "ModifyAndAttach" };
    using (var context1 = new TechExamContext())
    {
        context1.Sujets.Add(sujet);
        context1.SaveChanges();
    }

    using (var context2 = new TechExamContext())
    {
        sujet.Titre = "Foo";
        context2.Attach(sujet);
        context2.SaveChanges();
    }
}

static void RemoveReponseById()
{
    using var context = new TechExamContext();
    context.Reponses.Remove(new Reponse { ReponseId = 5, Contenu = "" }); 
    context.SaveChanges();
}

static void RemoveReponseOnQuestion()
{
    using var context = new TechExamContext();
    var q = (QuestionChoixMultiple)context.Questions
        .Include(r => (r as QuestionChoixMultiple).Reponses)
        .Single(c => c.Contenu.Contains("variable declaration"));

    q.Reponses.Remove(q.Reponses.Single(r => r.ReponseId == 3));
    context.SaveChanges();
}

static void AddReponseNoInclude()
{
    using var context = new TechExamContext();
    var q = (QuestionChoixMultiple)context.Questions
        .Single(c => c.Contenu.Contains("variable declaration"));

    q.Reponses.Add(new Reponse { Contenu = "let x = 42;", Correcte = false });
    context.SaveChanges();
}
static void ModifySujet()
{
    using var context = new TechExamContext();
    context.Update(new Sujet { SujetId = 5, Titre = "CSharp (C#)" });
    context.SaveChanges();
}

static void CreateQuestion()
{
    using var context = new TechExamContext();

    var sujet = new Sujet { Titre = "C#" };
    var question = new QuestionChoixMultiple
    {
        Sujets = [sujet],
        Contenu = "Which of the following is a correct variable declaration in C#?",
        Niveau = Niveau.Debutant,
        Reponses =
        [
            new Reponse { Contenu = "int number = 5;", Correcte = true },
        new Reponse { Contenu = "integer number = 5;", Correcte = false },
        new Reponse { Contenu = "num number = 5;", Correcte = false },
        new Reponse { Contenu = "number: int = 5;", Correcte = false },
    ]
    };

    context.Questions.Add(question);

    context.SaveChanges();
}

static int CreatePassage()
{
    using var context = new TechExamContext();
    var parametrage = new ParametrageExamen
    {
        ParametrageExamenId = Guid.NewGuid(),
        VentilationParNiveaux = new VentilationParNiveaux
        {
            PourcentageDebutant = (StrictIntPercent)60,
            PourcentageIntermediaire = (StrictIntPercent)30,
            PourcentageAvance = (StrictIntPercent)10,
        },
        Sujet = context.Sujets.First()
    };

    var passage = new Passage
    {
        CandidatId = Guid.NewGuid(),
        ParametrageExamen = parametrage,
        Statut = StatutPassage.NonPlanifie
    };

    context.Add(passage);
    context.SaveChanges();
    return passage.PassageId;
}