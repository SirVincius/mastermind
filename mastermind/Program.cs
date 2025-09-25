public class Game
{
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
        game.PrintBig([1,5,4,3,6,7,2,3,4,5]);
    }
}