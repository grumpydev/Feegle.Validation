namespace Feegle.Validation
{
    using System;

    public class ValidationPair<T> : IValidationPair<T>
    {
        public Func<T> PropertyDelegate { get; private set; }

        public T PropertyValue { get; private set; }

        public ValidationPair(Func<T> propertyDelegate)
        {
            this.PropertyDelegate = propertyDelegate;
            this.PropertyValue = propertyDelegate.Invoke();
        }
    }
}