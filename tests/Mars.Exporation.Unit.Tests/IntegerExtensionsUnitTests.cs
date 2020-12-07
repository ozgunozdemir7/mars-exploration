using System;
using System.Collections.Generic;
using System.Text;
using Mars.Exploration;
using Xunit;

namespace Mars.Exporation.Unit.Tests
{
    public class IntegerExtensionsUnitTests
    {
        [Fact]
        public void To_Int_Should_Return_Integer_Value_Of_String()
        {
            var input = "7";
            var output = input.ToInt();

            Assert.Equal(7,output);
        }

        [Fact]
        public void To_Int_Should_Throw_Argument_Exception_When_Input_Is_Invalid()
        {
            var input = "invalidInt";

            Assert.Throws<ArgumentException>(() => input.ToInt());
        }
    }
}
