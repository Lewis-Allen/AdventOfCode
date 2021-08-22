using System;
using System.Linq;
using Xunit;

namespace Day02.Tests
{
    public class IntcodeComputerTests
    {
        [Fact]
        public void Should_Get_Value_At_Position()
        {
            var computer = new IntcodeComputer("1,0,0,0,99");

            Assert.Equal(1, computer[0]);
            Assert.Equal(0, computer[1]);
            Assert.Equal(0, computer[2]);
            Assert.Equal(0, computer[3]);
            Assert.Equal(99, computer[4]);
        }

        [Fact]
        public void Should_Set_Value_At_Position()
        {
            var computer = new IntcodeComputer("1,0,0,0,99");

            computer[0] = 5;

            Assert.Equal(5, computer[0]);
        }

        [Theory]
        [InlineData("1,0,0,0,99", "2,0,0,0,99")]
        [InlineData("2,3,0,3,99", "2,3,0,6,99")]
        [InlineData("2,4,4,5,99,0", "2,4,4,5,99,9801")]
        [InlineData("1,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99")]
        public void Should_Calculate_Correctly_Part_One(string program, string result)
        {
            var computer = new IntcodeComputer(program);
            computer.RunProgramPartOne();
            var output = computer.RetrieveProgramState();
            Assert.Equal(result, output);
        }


    }
}
