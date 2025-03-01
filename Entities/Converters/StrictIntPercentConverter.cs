using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Atelier.Ef.TechExam.Domain;

namespace Atelier.Ef.TechExam.Entities.Converters
{
    public class StrictIntPercentConverter : ValueConverter<StrictIntPercent, int>
    {
        public StrictIntPercentConverter() : base(
          v => v.Percentage, v => new StrictIntPercent(v))
        { }
    }
}
