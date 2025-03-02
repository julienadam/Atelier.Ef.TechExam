using Atelier.Ef.TechExam.Domain;
using Atelier.Ef.TechExam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

// CreateQuestion();
// ModifySujet();
// AddReponseNoInclude();
// RemoveReponseById();
// RemoveReponseOnQuestion();
// ModifyAndAttach();
ReadChangeTracking();

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
