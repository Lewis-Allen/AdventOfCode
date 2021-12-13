using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Day13.Tests
{
    public class PaperFolderTests
    {
        private readonly ITestOutputHelper _output;

        public PaperFolderTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Should_Fold_Correctly()
        {
            var dots = new Dot[]
            {
                new(6,10),
                new(0,14),
                new(9,10),
                new(0,3),
                new(10,4),
                new(4,11),
                new(6,0),
                new(6,12),
                new(4,1),
                new(0,13),
                new(10,12),
                new(3,4),
                new(3,0),
                new(8,4),
                new(1,10),
                new(2,14),
                new(8,10),
                new(9,0)
            };

            var instruction = new Instruction(false, 7);
            dots = PaperFolder.Fold(instruction, dots);

            instruction = new Instruction(true, 5);
            dots = PaperFolder.Fold(instruction, dots);

            Assert.Equal(16, dots.Length);
        }
    }
}