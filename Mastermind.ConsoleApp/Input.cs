using System;

namespace Mastermind
{
    public static class UI
    {
        public static ParseResult ParseInput(string input)
        {
            return new FailedParseResult(input: input);
        }        
    }

    public class SuccessfulParseResult : ParseResult
    {
        public readonly Colours[] ParsedInput;

        public SuccessfulParseResult(Colours[] parsedInput)
            : base()
        {
            ParsedInput = parsedInput;
        }
    }

    public class FailedParseResult : ParseResult
    {
        public readonly string InvalidInput;

        public FailedParseResult(string input)
        : base()
        {
            InvalidInput = input;
        }
    }

    public abstract class ParseResult
    {
        public ParseResult() {}
    }
}