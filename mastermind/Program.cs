public class Game
{
    public void PrintMenu()
    {
        Console.WriteLine(Message.Menu);
    }

    public void PrintBig(int[] arr)
    {
        for (int i = 0; i < 5; i++)
        {
            foreach (int digit in arr)
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