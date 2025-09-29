using System.ComponentModel;
using System.Dynamic;
using System.Globalization;
using System.Reflection.Metadata;
public enum Position
{
    First = 0,
    Second = 1,
    Third = 2,
    Fourth = 3,
    Fifth = 4,
    Sixth = 5,
    Seventh = 6,
    Eighth = 7,
}

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
    public List<string> Hints { get; set; } = new List<string>();
    public Game(){} // For testing purpose only
    public Game(int highestDigit, int numberOfDigits)
    {
        HighestDigit = highestDigit;
        NumberOfDigits = numberOfDigits;
    }

    public int[] GenerateSolution()
    {
        int[] solution = new int[NumberOfDigits];
        for (int i = 0; i < NumberOfDigits; i++)
        {
            solution[i] = random.Next(0, HighestDigit + 1);
        }
        return solution;
    }

    public void GenerateHint()
    {
            string hint;
        while (true)
        {
            int randomHintType = random.Next(1, 4);
            if (randomHintType == 1)
            {
                hint = GetHintGivenDigitCount(GetRandomDigitInGame());
            }
            else if (randomHintType == 2)
            {
                hint = GetFreePerfectMatch(GetRandomDSolutionIndex());
            }
            else
            {
                hint = GetHintRelativeIndexes(Get2DifferentSolutionIndexes());
            }
            if (!Hints.Contains(hint))
            break;
        }
        Hints.Add(hint);
    }

    public int GetRandomDigitInGame()
    {
        int randomDigit = random.Next(0, HighestDigit + 1);
        return randomDigit;
    }

    public int GetRandomDSolutionIndex()
    {
        int randomIndex = random.Next(0, Solution.Length - 1);
        return randomIndex;
    }

    public int[] Get2DifferentSolutionIndexes()
    {
        List<int> solutionIndexes = new List<int>();
        for (int i = 0; i < Solution.Length; i++)
        {
            solutionIndexes.Add(i);
        }
        int randomIndex1 = solutionIndexes[random.Next(0, solutionIndexes.Count)];
        solutionIndexes.Remove(randomIndex1);
        int randomIndex2 = solutionIndexes[random.Next(0, solutionIndexes.Count)];
        return [randomIndex1, randomIndex2];
    }

    public string GetHintRelativeIndexes(int[] solutionIndexes)
    {
        int digit1 = Solution[solutionIndexes[0]];
        int digit2 = Solution[solutionIndexes[1]];
        string? positionIndex1 = Enum.GetName(typeof(Position), solutionIndexes[0]);
        string? positionIndex2 = Enum.GetName(typeof(Position), solutionIndexes[1]);
        return digit1 > digit2 ? $"{positionIndex1} digit > {positionIndex2} digit." :
        digit1 < digit2 ? $"{positionIndex1} digit < {positionIndex2} digit." :
        $"{positionIndex1} digit = {positionIndex2} digit.";
    }
    public string GetHintGivenDigitCount(int randomDigitInGame)
    {
        int digitCount = 0;
        foreach (int digit in Solution)
        {
            if (digit == randomDigitInGame)
                digitCount++;
        }
        return digitCount == 0 ? $"There are no '{randomDigitInGame}'." :
            digitCount == 1 ? $"There is 1 x '{randomDigitInGame}'." :
            $"There are {digitCount} x '{randomDigitInGame}'.";
    }

    public string GetFreePerfectMatch(int randomIndex)
    {
        string? position = Enum.GetName(typeof(Position), randomIndex);
        return $"{position} digit is '{Solution[randomIndex]}'.";
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
            sequence = sequence.ToLower();
            if ("hint".Equals(sequence) && Hints.Count < NumberOfDigits)
            {
                GenerateHint();
                Console.WriteLine($"--> {Hints[Hints.Count - 1]}\n");
            }
            else if (int.TryParse(sequence, out int choice))
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
                    for (int i = 0; i < Hints.Count; i++)
                    {
                        Console.WriteLine(Hints[i]);
                    }
                    Console.WriteLine();
                    if (attempt.PerfectMatches == NumberOfDigits)
                    {
                        Console.WriteLine(Message.Congratulaions);
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