using System;
using System.Linq;
using Xunit;

namespace Day07.Tests
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
        [InlineData("3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0", "43210", 43210)]
        [InlineData("3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0", "01234", 54321)]
        [InlineData("3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0", "10432", 65210)]
        public void Should_Calculate_Correctly_Part_One(string program, string phaseSetting, int expected)
        {
            var result = 0;

            for (var i = 0; i < 5; i++)
            {
                var computer = new IntcodeComputer(program);
                computer.RunProgram(int.Parse(phaseSetting[i].ToString()), result);
                result = computer._output[0];
            }

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5", 139629729)]
        //[InlineData("3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,55,26,1001,54,-5,54,1105,1,12,1,53,54,53,1008,54,0,55,1001,55,1,55,2,53,55,53,4,53,1001,56,-1,56,1005,56,6,99,0,0,0,0,10", 18216)]
        public void Should_Calculate_Correctly_Part_Two(string program, int expected)
        {
            IntcodeComputerArray ica = new();
            var result = ica.RunProgram(program);

            Assert.Equal(expected, result);
        }

        /*
        [Theory]
        [InlineData("3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,55,26,1001,54,-5,54,1105,1,12,1,53,54,53,1008,54,0,55,1001,55,1,55,2,53,55,53,4,53,1001,56,-1,56,1005,56,6,99,0,0,0,0,10", 18216)]
        public void Should_Calc_Correct_Testing(string program, int expected)
        {
            var input = 0;
            var result = 0;
            var phaseSettings = "97856";
            for (var ps = 0; ps < 5; ps++)
            {
                var phaseSetting = phaseSettings[ps];
                IntcodeComputer2 computer = new(program);
                computer.RunProgram(phaseSetting, input);
                input = computer._output[^1];
            }

            if (input > result)
                result = input;

            Assert.Equal(expected, result);
        }
        */
    }
}
