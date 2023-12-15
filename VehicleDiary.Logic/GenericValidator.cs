using System.Collections.Generic;
using System.Linq;

namespace VehiclesDiary.Logic
{
    public class GenericValidator<T> : IValidator<T>
    {
        private readonly IEnumerable<IValidationRule<T>> _rules;

        public GenericValidator(IEnumerable<IValidationRule<T>> rules)
        {
            _rules = rules;
        }

        public bool Validate(T input)
        {
            return !_rules.Any(r => r.NotBroken(input) == false);
        }
    }
}