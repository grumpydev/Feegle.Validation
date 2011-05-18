namespace Feegle.Validation.Tests.Fakes
{
    public class FakeClassWithCtorValidation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public FakeClassWithCtorValidation(string stringProperty, string anotherStringProperty)
        {
            Validate.Arguments(() => stringProperty, () => anotherStringProperty).NotNull().StartsWith("Valid");
        }
    }
}