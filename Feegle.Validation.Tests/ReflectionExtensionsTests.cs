namespace Feegle.Validation.Tests
{
    using Feegle.Validation.Tests.Fakes;

    using Xunit;

    public class ReflectionExtensionsTests
    {
        [Fact]
        public void Should_get_parameter_names_for_ctor_validations()
        {
            var result = Record.Exception(() => new FakeClassWithCtorValidation("Invalid", "Invalid"));

            Assert.Contains("stringProperty", result.Message);
            Assert.Contains("anotherStringProperty", result.Message);
        }
    }
}