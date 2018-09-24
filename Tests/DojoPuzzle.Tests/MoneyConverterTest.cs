using DojoPuzze.Application;
using DojoPuzze.Application.Extensions;
using Moq;
using System;
using Xunit;

namespace DojoPuzzle.Tests
{
    public class MoneyConverterTest
    {
        //private readonly Mock<IMoneyConverter> _moneyConverter = new Mock<IMoneyConverter>();

        [Fact]
        public void Should_convert_to_monetary()
        {
            var moneyConverter = new MoneyConverter();

            var result = moneyConverter.ConvertToMonetary("234");

            Assert.Equal(234, result);
        }

        [Fact]
        public void Should_convert_with_comma_on_cents_house()
        {
            var moneyConverter = new MoneyConverter();

            var result = moneyConverter.ConvertToMonetary("234.4");

            Assert.Equal(234.4m, result);
        }
    }
}
