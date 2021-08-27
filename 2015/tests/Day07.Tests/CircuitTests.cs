using System;
using Xunit;

namespace Day07.Tests
{
    public class CircuitTests
    {
        [Fact]
        public void Circuit_Should_Build_Correctly()
        {
            var instructions = @"123 -> x
456 -> y
x AND y -> d
x OR y -> e
x LSHIFT 2 -> f
y RSHIFT 2 -> g
NOT x -> h
NOT y -> i";

            var ciruit = new Circuit(instructions);

            Assert.Equal(72, ciruit.GetValueOf("d"));
            Assert.Equal(507, ciruit.GetValueOf("e"));
            Assert.Equal(492, ciruit.GetValueOf("f"));
            Assert.Equal(114, ciruit.GetValueOf("g"));
            Assert.Equal(65412, ciruit.GetValueOf("h"));
            Assert.Equal(65079, ciruit.GetValueOf("i"));
            Assert.Equal(123, ciruit.GetValueOf("x"));
            Assert.Equal(456, ciruit.GetValueOf("y"));
        }
    }
}
