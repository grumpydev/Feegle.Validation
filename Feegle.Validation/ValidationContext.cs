namespace Feegle.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ValidationContext<T> : IValidationContext<T>
    {
        public ValidationContext(IEnumerable<Func<T>> validationTargets)
        {
            this.ValidationTargets = validationTargets.Select(t => new ValidationPair<T>(t));
        }

        public IEnumerable<IValidationPair<T>> ValidationTargets { get; private set; }
    }
}