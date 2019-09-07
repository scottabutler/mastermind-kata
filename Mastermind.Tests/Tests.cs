using Xunit;

namespace Mastermind.Tests
{
    public class Tests
    {
        [Fact]
        public void Evaluate_ShouldReturnNoWellPlacedOrMisplacedColours_WhenNoCorrectColoursAreGuessed()
        {
            //Arrange
            var secret = new Colours[] { Colours.Pink, Colours.Red, Colours.Orange, Colours.Green };
            var input = new Colours[] { Colours.Blue, Colours.Yellow, Colours.Yellow, Colours.Blue };

            //Act
            GuessResult result = Mastermind.Core.Evaluate(secret, input);

            //Assert
            Assert.Equal(0, result.WellPlaced);
            Assert.Equal(0, result.Misplaced);
        }
        
        [Fact]
        public void Evaluate_ShouldReturnOneMisplacedColour_WhenOneMisplacedColourIsGuessed()
        {
            //Arrange
            var secret = new Colours[] { Colours.Pink, Colours.Red, Colours.Orange, Colours.Green };
            var input = new Colours[] { Colours.Blue, Colours.Pink, Colours.Yellow, Colours.Blue };

            //Act
            GuessResult result = Mastermind.Core.Evaluate(secret, input);

            //Assert
            Assert.Equal(0, result.WellPlaced);
            Assert.Equal(1, result.Misplaced);
        }
        
        [Fact]
        public void Evaluate_ShouldReturnAllMisplacedColours_WhenAllMisplacedColoursAreGuessed()
        {
            //Arrange
            var secret = new Colours[] { Colours.Pink, Colours.Red, Colours.Orange, Colours.Green };
            var input = new Colours[] { Colours.Red, Colours.Orange, Colours.Green, Colours.Pink };

            //Act
            GuessResult result = Mastermind.Core.Evaluate(secret, input);

            //Assert
            Assert.Equal(0, result.WellPlaced);
            Assert.Equal(4, result.Misplaced);
        }
        
        [Fact]
        public void Evaluate_ShouldReturnOneWellPlacedColour_WhenOneWellPlacedColourIsGuessed()
        {
            //Arrange
            var secret = new Colours[] { Colours.Pink, Colours.Red, Colours.Orange, Colours.Green };
            var input = new Colours[] { Colours.Blue, Colours.Red, Colours.Yellow, Colours.Blue };

            //Act
            GuessResult result = Mastermind.Core.Evaluate(secret, input);

            //Assert
            Assert.Equal(1, result.WellPlaced);
            Assert.Equal(0, result.Misplaced);
        }
        
        [Fact]
        public void Evaluate_ShouldReturnAllWellPlacedColours_WhenAllWellPlacedColoursAreGuessed()
        {
            //Arrange
            var secret = new Colours[] { Colours.Pink, Colours.Red, Colours.Orange, Colours.Green };

            //Act
            GuessResult result = Mastermind.Core.Evaluate(secret, secret);

            //Assert
            Assert.Equal(4, result.WellPlaced);
            Assert.Equal(0, result.Misplaced);
        }

        [Fact]
        public void Evaluate_ShouldReturnOneMisplacedColour_WhenThatColourOccursTwiceInTheSecret_AndOneMisplacedColourIsGuessed()
        {
            //Arrange
            var secret = new Colours[] { Colours.Pink, Colours.Pink, Colours.Orange, Colours.Green };
            var input = new Colours[] { Colours.Blue, Colours.Yellow, Colours.Pink, Colours.Blue };

            //Act
            GuessResult result = Mastermind.Core.Evaluate(secret, input);

            //Assert
            Assert.Equal(0, result.WellPlaced);
            Assert.Equal(1, result.Misplaced);
        }

        [Fact]
        public void Evaluate_ShouldReturnOneMisplacedColour_WhenThatColourOccursOnceInTheSecret_AndItIsGuessedTwice()
        {
            //Arrange
            var secret = new Colours[] { Colours.Pink, Colours.Red, Colours.Orange, Colours.Green };
            var input = new Colours[] { Colours.Blue, Colours.Pink, Colours.Pink, Colours.Blue };

            //Act
            GuessResult result = Mastermind.Core.Evaluate(secret, input);

            //Assert
            Assert.Equal(0, result.WellPlaced);
            Assert.Equal(1, result.Misplaced);
        }

        [Fact]
        public void Evaluate_ShouldReturnTwoWellPlacedAndTwoMisplacedColours_WhenTwoPositionsAreCorrect_AndTheOtherTwoAreReversed()
        {
            //Arrange
            var secret = new Colours[] { Colours.Pink, Colours.Red, Colours.Orange, Colours.Green };
            var input = new Colours[] { Colours.Pink, Colours.Red, Colours.Green, Colours.Orange };

            //Act
            GuessResult result = Mastermind.Core.Evaluate(secret, input);

            //Assert
            Assert.Equal(2, result.WellPlaced);
            Assert.Equal(2, result.Misplaced);
        }
    }
}
