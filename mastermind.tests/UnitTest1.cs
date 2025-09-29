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

    [Fact]
    public void GetHintGivenDigitCountTest()
    {
        int maxDigit = 8;
        int numberOfDigits = 8;
        Game game1 = new Game(maxDigit, numberOfDigits);
        game1.Solution = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        Game game2 = new Game(maxDigit, numberOfDigits);
        game2.Solution = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
        Game game3 = new Game(maxDigit, numberOfDigits);
        game3.Solution = new int[] { 8, 8, 8, 8, 8, 8, 8, 8 };

        Assert.Equal("There is 1 x '1'.", game1.GetHintGivenDigitCount(1));
        Assert.Equal("There are 8 x '1'.", game2.GetHintGivenDigitCount(1));
        Assert.Equal("There are no '1'.", game3.GetHintGivenDigitCount(1));
    }

    [Fact]
    public void GetFreePerfectMatchTest()
    {
        int maxDigit = 8;
        int numberOfDigits = 8;
        Game game1 = new Game(maxDigit, numberOfDigits);
        game1.Solution = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        Assert.Equal("Fourth digit is '4'.", game1.GetFreePerfectMatch(3));
        Assert.Equal("First digit is '1'.", game1.GetFreePerfectMatch(0));
        Assert.Equal("Eighth digit is '8'.", game1.GetFreePerfectMatch(7));
    }

    [Fact]
    public void GetHintRelativeIndexesTest()
    {
        int maxDigit = 8;
        int numberOfDigits = 8;
        Game game1 = new Game(maxDigit, numberOfDigits);
        game1.Solution = new int[] { 1, 2, 3, 4, 1, 2, 3, 4 };

        Assert.Equal("First digit < Fourth digit.", game1.GetHintRelativeIndexes([0, 3]));
        Assert.Equal("Eighth digit > Third digit.", game1.GetHintRelativeIndexes([7, 2]));
        Assert.Equal("Fourth digit = Eighth digit.", game1.GetHintRelativeIndexes([3, 7]));
    }
}