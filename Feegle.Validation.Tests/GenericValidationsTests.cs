namespace Feegle.Validation.Tests
{
    using System;

    using Xunit;

    public class GenericValidationsTests
    {
        [Fact]
        public void Should_not_throw_if_notnull_called_and_all_parameters_non_null()
        {
            var result = Record.Exception(() => Validate.Arguments(() => "one", () => "two", () => "three").NotNull());

            Assert.Null(result);
        }

        [Fact]
        public void Should_throw_if_not_null_called_and_a_parameter_is_null()
        {
            var result = Record.Exception(() => Validate.Arguments(() => "one", () => null, () => "three").NotNull());

            Assert.IsType(typeof(ArgumentNullException), result);
        }
    }
}