namespace Feegle.Validation.Tests
{
    using System;

    using Xunit;

    public class NumericValidationsTests
    {
        [Fact]
        public void Should_not_throw_if_lessthan_called_and_all_parameters_less_than_value()
        {
            var result = Record.Exception(() => Validate.Arguments(() => 10, () => 11, () => 12).LessThan(13));

            Assert.Null(result);
        }

        [Fact]
        public void Should_throw_if_lessthan_called_and_a_parameter_is_not_less_than_value()
        {
            var result = Record.Exception(() => Validate.Arguments(() => 10, () => 14, () => 12).LessThan(13));

            Assert.IsType(typeof(ArgumentException), result);
        }

    }
}