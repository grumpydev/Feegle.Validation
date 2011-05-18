namespace Feegle.Validation.Tests
{
    using System;

    using Xunit;

    public class StringValidationsTests
    {
        [Fact]
        public void Should_not_throw_if_startswith_called_and_all_strings_start_with_string()
        {
            var result = Record.Exception(() => Validate.Arguments(() => "Testone", () => "Testtwo", () => "Testthree").StartsWith("Test"));

            Assert.Null(result);
        }

        [Fact]
        public void Should_throw_if_startswith_called_and_a_string_does_not_start_with_string()
        {
            var result = Record.Exception(() => Validate.Arguments(() => "Testone", () => "Tes.two", () => "Testthree").StartsWith("Test"));

            Assert.IsType(typeof(ArgumentException), result);
        }

        [Fact]
        public void Should_allow_case_sensitivity()
        {
            var result = Record.Exception(() => Validate.Arguments(() => "Testone", () => "testtwo", () => "Testthree").StartsWith("Test", StringComparison.InvariantCultureIgnoreCase));

            Assert.Null(result);
        }

        [Fact]
        public void Should_allow_case_insensitivity()
        {
            var result = Record.Exception(() => Validate.Arguments(() => "Testone", () => "testtwo", () => "Testthree").StartsWith("Test"));

            Assert.IsType(typeof(ArgumentException), result);
        }
    }
}