namespace Feegle.Validation
{
    using System.Collections.Generic;

    public interface IValidationContext
    {
    }

    public interface IValidationContext<out T> : IValidationContext
    {
        IEnumerable<IValidationPair<T>> ValidationTargets { get; }
    }
}