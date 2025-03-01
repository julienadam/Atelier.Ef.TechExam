using Atelier.Ef.TechExam.Domain.SeedWork;

namespace Atelier.Ef.TechExam.Domain
{
    public class StrictIntPercent : ValueObject, IComparable<StrictIntPercent>, IComparable<int>
    {
        public int Percentage { get; }

        public StrictIntPercent(int percentage)
        {
            if(percentage < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(percentage), "Strict int precent cannot be less than zero, it must be between 0 and 100");
            }
            if (percentage > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(percentage), "Strict int precent cannot be more than 100, it must be between 0 and 100");
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Percentage;
        }

        public int CompareTo(StrictIntPercent? other)
        {
            return this.Percentage.CompareTo(other?.Percentage);
        }

        public int CompareTo(int other)
        {
            return this.Percentage.CompareTo(other);
        }

        public static explicit operator int(StrictIntPercent self)
        {
            return self.Percentage;
        }

        public static explicit operator StrictIntPercent(int p)
        {
            return new StrictIntPercent(p);
        }
    }
}
