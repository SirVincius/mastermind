using Xunit;

namespace mastermind.tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Game game1 = new Game(4, 5);
        game1.Solution = new int[] { 1, 2, 3, 4, 1, 2, 3, 4 };
        Attempt attempt1 = new Attempt("12345678", 8);
        for (int i = 0; i < attempt1.Digits.Length; i++)
        {
            Console.WriteLine(attempt1.Digits[i]);
            Console.WriteLine(game1.Solution[i]);
        }
        Assert.Equal(4, game1.GetNumberOfPerfectMatches(attempt1));
    }
}