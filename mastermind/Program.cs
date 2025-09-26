using System.Dynamic;
public class Attempt
{
    int[] Digits;
    public int DigitMatches;
    public int PerfectMatches;
}
public class Game
{
    public int HighestDigit { get; set; } = 4;
    public int NumberOfDigits = 5;
    public int[] Solution { get; set; } = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
    public Attempt[] Attempts { get; set; }

    public Game(int highestDigit, int numberOfDigits)
    {
        HighestDigit = highestDigit;
        NumberOfDigits = numberOfDigits;
    }

    public void PrintMenu()
    {
        Console.WriteLine(Message.Menu);
    }

    public void PrintBig(int[] arr)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int digit = 0; digit < arr.Length - 2; digit++)
            {
                Console.Write(StringDigits.DigitLayers[i][digit]);
            }
            Console.Write("   ||     ");
            for (int digit = arr.Length - 2; digit < arr.Length; digit++)
            {
                Console.Write(StringDigits.DigitLayers[i][digit]);
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        Game game = new Game();
        game.PrintMenu();
        game.PrintBig([0, 1, 2, 3, 4, 5, 6, 7, 8, 9]);
    }
}
/*

########################################################################    
##                                                                    ##
##   #    #   ##   ##### ##### ##### ####  #    # ##### #   # ####    ##
##   ##  ## ##  ## ##      #   ##    ## ## ##  ##   #   ##  # ## ##   ##
##   ###### ###### #####   #   ##### ##### ######   #   # # # ## ##   ##
##   ##  ## ##  ##     #   #   ##    ## #  ##  ##   #   #  ## ## ##   ##
##   ##  ## ##  ## #####   #   ##### ## ## ##  ## ##### #   # ####    ##
##                                                                    ##
########################################################################

1. New Game
2. See Records
3. Quit

*/