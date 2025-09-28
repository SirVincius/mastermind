using System.ComponentModel;
using System.Dynamic;
using System.Globalization;
using System.Reflection.Metadata;

public class Attempt
{
    public int[] Digits;
    public int DigitMatches;
    public int PerfectMatches;

    public Attempt(string sequence, int numberOfDigits)
    {
        Digits = new int[numberOfDigits];
        for (int i = 0; i < sequence.Length; i++)
        {
            Digits[i] = (int)char.GetNumericValue(sequence[i]);
        }
    }

    public void PrintAttempt()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int digit = 0; digit < Digits.Length; digit++)
            {
                Console.Write(StringDigits.DigitLayers[i][Digits[digit]]);
            }
            Console.Write("   ||     ");
            Console.Write(StringDigits.DigitLayers[i][DigitMatches]);
            Console.Write(StringDigits.DigitLayers[i][PerfectMatches]);
            Console.WriteLine();
        }
        Console.WriteLine("");
    }
}
public class Game
{
    private Random random = new Random();
    public int HighestDigit { get; set; }
    public int NumberOfDigits;
    public int[] Solution { get; set; } = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
    public List<Attempt> Attempts { get; set; } = new List<Attempt>();

    public int[] GenerateSolution()
    {
        int[] solution = new int[NumberOfDigits];
        for (int i = 0; i < NumberOfDigits; i++)
        {
            solution[i] = random.Next(0, HighestDigit + 1);
        }
        return solution;
    }

    public void ChooseMenuOption()
    {
        while (true)
        {
            Console.WriteLine(Message.Menu);
            while (true)
            {
                Console.Write("Choose an option : ");
                string choice = Console.ReadLine();
                if (int.TryParse(choice, out int number))
                {
                    if (number == 1)
                    {
                        HighestDigit = ChooseHighestDigits();
                        NumberOfDigits = ChooseNumberOfDigits();
                        Solution = GenerateSolution();
                        StartGame();
                        break;
                    }
                    else if (number == 2)
                    {
                        Console.WriteLine("Implementation to come");
                    }
                    else if (number == 3)
                    {
                        Console.WriteLine("Goodbye");
                        return;
                    }
                    else
                    {
                        Console.Write("Invalid choice.\n");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("Invalid choice.\n\n");
                }
            }
        }
    }

    public int ChooseHighestDigits()
    {
        while (true)
        {
            Console.Write("Choose the highest digit that can appear in the solution (1-9): ");
            string highestDigit = Console.ReadLine();
            if (int.TryParse(highestDigit, out int choice))
            {
                if (choice >= 1 && choice <= 9)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                Console.WriteLine();
            }
        }
    }

     public int ChooseNumberOfDigits()
    {
        while (true)
        {
            Console.Write("Choose how many digits the solution should contain (2-9): ");
            string numberOfDigits = Console.ReadLine();
            if (int.TryParse(numberOfDigits, out int choice))
            {
                if (choice >= 2 && choice <= 9)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    Console.WriteLine();
                }
            }
            else
            { 
                Console.WriteLine("Invalid choice.");
                Console.WriteLine();
            }
        }
    }
    public int GetNumberOfPerfectMatches(Attempt attempt)
    {
        int numberOfPerfectMatches = 0;
        for (int i = 0; i < attempt.Digits.Length; i++)
        {
            if (attempt.Digits[i] == Solution[i])
                numberOfPerfectMatches++;
        }
        return numberOfPerfectMatches;
    }

    public int GetNumberOfCorrectDigits(Attempt attempt)
    {
        int[] attemptDigits = new int[HighestDigit + 1];
        int[] solutionDigits = new int[HighestDigit + 1];
        for (int i = 0; i < Solution.Length; i++)
        {
            attemptDigits[attempt.Digits[i]]++;
            solutionDigits[Solution[i]]++;
        }
        int numberOfCorrectDigits = 0;
        for (int d = 0; d <= HighestDigit; d++)
        {
            numberOfCorrectDigits += Math.Min(attemptDigits[d], solutionDigits[d]);
        }

        return numberOfCorrectDigits;
    }

    public void StartGame()
    {
        while (true)
        {
            Console.Write($"Enter {NumberOfDigits} digits between 0-{HighestDigit} : ");
            string sequence = Console.ReadLine();
            if (int.TryParse(sequence, out int choice))
            {
                bool isValid = true;
                if (sequence.Length != NumberOfDigits)
                    isValid = false;
                foreach (char c in sequence)
                {
                    int digitValue = (int)char.GetNumericValue(c);
                    if (digitValue < 0 || digitValue > HighestDigit)
                        isValid = false;
                }
                if (isValid)
                {
                    Attempt attempt = new Attempt(sequence, NumberOfDigits);
                    attempt.DigitMatches = GetNumberOfCorrectDigits(attempt);
                    attempt.PerfectMatches = GetNumberOfPerfectMatches(attempt);
                    Attempts.Add(attempt);
                    Console.Clear();
                    for (int i = 0; i < Attempts.Count; i++)
                    {
                        Attempts[i].PrintAttempt();
                    }
                    if (attempt.PerfectMatches == NumberOfDigits)
                    {
                        Console.WriteLine("CONGRATULATIONS!\n");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                    
                }
                else
                    Console.WriteLine("Invalid");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        Game game = new Game();
        game.ChooseMenuOption();
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