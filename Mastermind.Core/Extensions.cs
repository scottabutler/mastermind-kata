using System.Collections.Generic;
using Mastermind.Core;
using System.Linq;

public static class ListExtensions
{
    public static string Print(this List<Colours> input)
    {
        return string.Join(", ", input.Select(x => x.ToString()));
    }
}