using Xunit;

namespace mastermind.tests;

public class UnitTest1
{
    [Fact]
    public void GetNumberOfPerfectMatchesTests()
    {
        Game game1 = new Game(8, 8);
        game1.Solution = new int[] { 1, 2, 3, 4, 1, 2, 3, 4 };
        Attempt attempt1 = new Attempt("12341234", 8);
        Attempt attempt2 = new Attempt("12345678", 8);
        Attempt attempt3 = new Attempt("12344321", 8);

        Assert.Equal(8, game1.GetNumberOfPerfectMatches(attempt1));
        Assert.Equal(4, game1.GetNumberOfPerfectMatches(attempt2));
        Assert.Equal(4, game1.GetNumberOfPerfectMatches(attempt3));
    }

    [Fact]
    public void GetNumberOfCorrectDigitsTests()
    {
        Game game1 = new Game(8, 8);
        game1.Solution = new int[] { 1, 2, 3, 4, 1, 2, 3, 4 };
        Attempt attempt1 = new Attempt("12341234", 8);
        Attempt attempt2 = new Attempt("12345678", 8);
        Attempt attempt3 = new Attempt("12344321", 8);
        Attempt attempt4 = new Attempt("88888888", 8);

        Assert.Equal(8, game1.GetNumberOfCorrectDigits(attempt1));
        Assert.Equal(4, game1.GetNumberOfCorrectDigits(attempt2));
        Assert.Equal(8, game1.GetNumberOfCorrectDigits(attempt3));
        Assert.Equal(0, game1.GetNumberOfCorrectDigits(attempt4));
    }

    [Fact]
    public void GenerateSolution()
    {
        int maxDigit = 8;
        int numberOfDigits = 8;
        Game game1 = new Game(maxDigit, numberOfDigits);
        int[] solution1 = game1.GenerateSolution();
        int[] solution2 = game1.GenerateSolution();
        int[] solution3 = game1.GenerateSolution();
        int[] solution4 = game1.GenerateSolution();

        Assert.Equal(8, solution1.Length);
        Assert.Equal(8, solution2.Length);
        Assert.Equal(8, solution3.Length);
        Assert.Equal(8, solution4.Length);

        bool s1 = true, s2 = true, s3 = true, s4 = true;
        for (int i = 0; i < numberOfDigits; i++)
        {
            if (solution1[i] < 0 || solution1[i] > numberOfDigits)
                s1 = false;
            if (solution2[i] < 0 || solution2[i] > numberOfDigits)
                s2 = false;
            if (solution3[i] < 0 || solution3[i] > numberOfDigits)
                s3 = false;
            if (solution4[i] < 0 || solution4[i] > numberOfDigits)
                s4 = false;
        }
        Assert.True(s1);
        Assert.True(s2);
        Assert.True(s3);
        Assert.True(s4);
    }
}