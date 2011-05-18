namespace Feegle.Validation.Tests
{
    using System;

    using Xunit;

    public class ValidateTests
    {
        [Fact]
        public void Should_allow_multiple_parameters_of_same_reference_type()
        {
            Validate.Arguments(() => "one", () => "two", () => "three");
        }

        [Fact]
        public void Should_allow_multiple_parameters_of_same_value_type()
        {
            Validate.Arguments(() => 1, () => 2, () => 3);
        }

        [Fact]
        public void Should_allow_multiple_parameters_of_different_types()
        {
            Validate.Arguments(() => "one", () => 1, () => 4);
        }

        [Fact]
        public void Should_allow_chaining_of_validations()
        {
            var result = Record.Exception(() => Validate.Arguments(() => "one", () => "two", () => "three").NotNull().StartsWith("o"));

            Assert.IsType(typeof(ArgumentException), result);
        }
    }
}