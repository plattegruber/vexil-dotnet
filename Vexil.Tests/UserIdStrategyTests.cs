using Moq;
using System.Collections.Generic;
using Vexil.Aggregate;
using Vexil.Strategies;
using Xunit;

namespace Vexil.Tests
{
    public class UserIdStrategyTests
    {
        private readonly UserIdStrategy _sut;
        private readonly Mock<IVexilContext> _vexilContextMock;

        public UserIdStrategyTests()
        {
            _sut = new UserIdStrategy()
            {
                AllowedUserIds = new List<string>() { "123", "234" }
            };
            _vexilContextMock = new Mock<IVexilContext>();
        }

        [Theory]
        [InlineData("123")]
        [InlineData("234")]
        public void Test(string validUserId)
        {
            var userId = new UserId(validUserId);
            _vexilContextMock.SetupGet(m => m.UserId).Returns(userId);

            var isCriteriaMet = _sut.IsCriteriaMet(_vexilContextMock.Object);

            Assert.True(isCriteriaMet);
        }
    }
}
