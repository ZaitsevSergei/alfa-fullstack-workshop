using Server.Exceptions;
using Server.Models;
using System;
using Xunit;

namespace ServerTest
{
    public class UserTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CreateUserEceptionTest(string value)
        {
            Assert.Throws<Exception>(() => new User(value));
        }
    }
}