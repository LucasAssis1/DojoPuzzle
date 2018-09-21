using DojoPuzze.Application.Extensions.Core;
using Moq;
using System;
using Xunit;

namespace DojoPuzzle.Tests
{
    public class CashierTest
    {
        private readonly Mock<IMoneyConverter> _moneyConverter = new Mock<IMoneyConverter>();

        [Fact]
        public void Should_return_234_written()
        {
            _moneyConverter.Setup(x => x.ConvertToMonetary(It.IsAny<string>())).Returns(234);


        }
    }
}
