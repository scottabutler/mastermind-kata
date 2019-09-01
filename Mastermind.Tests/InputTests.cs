using Xunit;

namespace Mastermind.Tests
{
    public class InputTests
    {
        [Theory]
        [InlineData("137")]
        [InlineData("012")]
        public void ParseInput_ShouldRejectOutOfRangeInput(string input)
        {
            //Arrange

            //Act
            ParseResult result = Mastermind.UI.ParseInput(input);

            //Assert
            Assert.IsType<FailedParseResult>(result);
        }
        
        [Fact]
        public void ParseInput_ShouldAcceptInRangeInput()
        {
            //Arrange
            var input = "613";

            //Act
            ParseResult result = Mastermind.UI.ParseInput(input);

            //Assert
            Assert.IsType<SuccessfulParseResult>(result);
            Assert.Equal(new Colours[] {Colours.Blue, Colours.Red, Colours.Orange}, ((SuccessfulParseResult)result).ParsedInput);
        }
    }
}
