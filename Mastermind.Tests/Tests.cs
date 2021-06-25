using Xunit;
using System.Collections.Generic;
using System.Linq;
using Mastermind.Core;

namespace Mastermind.Tests
{
    public class Tests
    {
        [Fact]
        public void Evaluate_ShouldReturnNoWellPlacedOrMisplacedColours_WhenNoCorrectColoursAreGuessed()
        {
            //Arrange
            var secret = new List<Colours> { Colours.Pink, Colours.Red, Colours.Orange, Colours.Green };
            var input = new List<Colours> { Colours.Blue, Colours.Yellow, Colours.Yellow, Colours.Blue };

            //Act
            GuessResult result = App.Eval(secret, input);

            //Assert
            Assert.Equal(0, result.WellPlaced);
            Assert.Equal(0, result.Misplaced);
        }

        [Fact]
        public void Evaluate_ShouldReturnOneMisplacedColour_WhenOneMisplacedColourIsGuessed()
        {
            //Arrange
            var secret = new List<Colours> { Colours.Pink, Colours.Red, Colours.Orange, Colours.Green };
            var input = new List<Colours> { Colours.Blue, Colours.Pink, Colours.Yellow, Colours.Blue };

            //Act
            GuessResult result = App.Eval(secret, input);

            //Assert
            Assert.Equal(0, result.WellPlaced);
            Assert.Equal(1, result.Misplaced);
        }

        [Fact]
        public void Evaluate_ShouldReturnAllMisplacedColours_WhenAllMisplacedColoursAreGuessed()
        {
            //Arrange
            var secret = new List<Colours> { Colours.Pink, Colours.Red, Colours.Orange, Colours.Green };
            var input = new List<Colours> { Colours.Red, Colours.Orange, Colours.Green, Colours.Pink };

            //Act
            GuessResult result = App.Eval(secret, input);

            //Assert
            Assert.Equal(0, result.WellPlaced);
            Assert.Equal(4, result.Misplaced);
        }

        [Fact]
        public void Evaluate_ShouldReturnOneWellPlacedColour_WhenOneWellPlacedColourIsGuessed()
        {
            //Arrange
            var secret = new List<Colours> { Colours.Pink, Colours.Red, Colours.Orange, Colours.Green };
            var input = new List<Colours> { Colours.Blue, Colours.Red, Colours.Yellow, Colours.Blue };

            //Act
            GuessResult result = App.Eval(secret, input);

            //Assert
            Assert.Equal(1, result.WellPlaced);
            Assert.Equal(0, result.Misplaced);
        }

        [Fact]
        public void Evaluate_ShouldReturnAllWellPlacedColours_WhenAllWellPlacedColoursAreGuessed()
        {
            //Arrange
            var secret = new List<Colours> { Colours.Pink, Colours.Red, Colours.Orange, Colours.Green };

            //Act
            GuessResult result = App.Eval(secret, new List<Colours> { Colours.Pink, Colours.Red, Colours.Orange, Colours.Green });

            //Assert
            Assert.Equal(4, result.WellPlaced);
            Assert.Equal(0, result.Misplaced);
        }

        [Fact]
        public void Evaluate_ShouldReturnOneMisplacedColour_WhenThatColourOccursTwiceInTheSecret_AndOneMisplacedColourIsGuessed()
        {
            //Arrange
            var secret = new List<Colours> { Colours.Pink, Colours.Pink, Colours.Orange, Colours.Green };
            var input = new List<Colours> { Colours.Blue, Colours.Yellow, Colours.Pink, Colours.Blue };

            //Act
            GuessResult result = App.Eval(secret, input);

            //Assert
            Assert.Equal(0, result.WellPlaced);
            Assert.Equal(1, result.Misplaced);
        }

        [Fact]
        public void Evaluate_ShouldReturnOneMisplacedColour_WhenThatColourOccursOnceInTheSecret_AndItIsGuessedTwice()
        {
            //Arrange
            var secret = new List<Colours> { Colours.Pink, Colours.Red, Colours.Orange, Colours.Green };
            var input = new List<Colours> { Colours.Blue, Colours.Pink, Colours.Pink, Colours.Blue };

            //Act
            GuessResult result = App.Eval(secret, input);

            //Assert
            Assert.Equal(0, result.WellPlaced);
            Assert.Equal(1, result.Misplaced);
        }

        [Fact]
        public void Evaluate_ShouldReturnTwoWellPlacedAndTwoMisplacedColours_WhenTwoPositionsAreCorrect_AndTheOtherTwoAreReversed()
        {
            //Arrange
            var secret = new List<Colours> { Colours.Pink, Colours.Red, Colours.Orange, Colours.Green };
            var input = new List<Colours> { Colours.Pink, Colours.Red, Colours.Green, Colours.Orange };

            //Act
            GuessResult result = App.Eval(secret, input);

            //Assert
            Assert.Equal(2, result.WellPlaced);
            Assert.Equal(2, result.Misplaced);
        }

        [Fact]
        public void Evaluate_ShouldReturnOneWellPlacedAndNoMisplacedColours_WhenColourOccursOnceInSecret_AndIsGuessedTwice_AndOneGuessIsWellPlaced()
        {
            //Arrange
            var secret = new List<Colours> { Colours.Pink, Colours.Red, Colours.Orange, Colours.Green };
            var input = new List<Colours> { Colours.Pink, Colours.Pink, Colours.Yellow, Colours.Blue };

            //Act
            GuessResult result = App.Eval(secret, input);

            //Assert
            Assert.Equal(1, result.WellPlaced);
            Assert.Equal(0, result.Misplaced);
        }

        [Fact]
        public void Evaluate_ShouldReturnCorrectResult_WhenWellPlacedCountExceedsMisplacedCountForSameColour()
        {
            //Arrange
            var secret = new List<Colours> { Colours.Red, Colours.Red, Colours.Yellow, Colours.Red };
            var input = new List<Colours> { Colours.Red, Colours.Red, Colours.Red, Colours.Green };

            //Act
            GuessResult result = App.Eval(secret, input);

            //Assert
            Assert.Equal(2, result.WellPlaced);
            Assert.Equal(1, result.Misplaced);
        }

        [Fact]
        public void Evaluate_ShouldHandleSevenPositionSecret()
        {
            //Arrange
            var secret = new List<Colours> { Colours.Red, Colours.Green, Colours.Yellow, Colours.Red, Colours.Blue, Colours.Pink, Colours.Orange };
            var input = new List<Colours> { Colours.Red, Colours.Yellow, Colours.Red, Colours.Green, Colours.Orange, Colours.Blue, Colours.Blue };

            //Act
            GuessResult result = App.Eval(secret, input);

            //Assert
            Assert.Equal(1, result.WellPlaced);
            Assert.Equal(5, result.Misplaced);
        }

        [Theory]
        [InlineData("RRGR", "RRRG", 2, 2)]
        [InlineData("RRGR", "RRRB", 2, 1)]
        [InlineData("RRGR", "RBRB", 1, 1)]
        [InlineData("RRGR", "GGRG", 0, 2)]
        [InlineData("RRGR", "RBGB", 2, 0)]
        [InlineData("RRGR", "RRGR", 4, 0)]
        public void Evaluate_ShouldPassTestCases(string secret, string input, int expectedWellPlaced, int expectedMisplaced)
        {
            GuessResult result = App.Eval(StringToColours(secret), StringToColours(input));

            //Assert
            Assert.Equal(expectedWellPlaced, result.WellPlaced);
            Assert.Equal(expectedMisplaced, result.Misplaced);
        }

        private List<Colours> StringToColours(string input)
        {
            var result = new List<Colours>();
            foreach (var item in input.ToUpper().ToCharArray())
            {
                switch (item)
                {
                    case 'R':
                        result.Add(Colours.Red);
                        break;
                    case 'G':
                        result.Add(Colours.Green);
                        break;
                    case 'B':
                        result.Add(Colours.Blue);
                        break;
                    case 'Y':
                        result.Add(Colours.Yellow);
                        break;
                    case 'O':
                        result.Add(Colours.Orange);
                        break;
                    case 'P':
                        result.Add(Colours.Pink);
                        break;
                }
            }

            return result;
        }
    }
}
