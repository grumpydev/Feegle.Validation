namespace Feegle.Validation
{
    using System;

    public interface IValidationPair<out T>
    {
        Func<T> PropertyDelegate { get; }

        T PropertyValue { get; }
    }
}