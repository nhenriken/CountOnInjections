namespace WindowCalculator.Tests
{
    public class RegularTests
    {
        [Theory]
        [InlineData("0", "0", "0")]
        [InlineData("1", "2", "3")]
        [InlineData("5", "10", "15")]
        [InlineData("24", "36", "60")]
        public void SumNumbers(string number1, string number2, string expected)
        {
            var actual = Calculator.Calculate(number1, number2);
            Assert.Equal(expected, actual);
        }
    }
}