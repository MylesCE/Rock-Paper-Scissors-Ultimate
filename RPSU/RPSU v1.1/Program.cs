using System;
using System.IO;

class Program
{
    static int wins = 0;
    static int losses = 0;
    static int ties = 0;
    static int money = 0;
    static string DPath;

    static void Main()
    {
        string AppDat = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string RPSUdir = Path.Combine(AppDat, "RPSU");
        Directory.CreateDirectory(RPSUdir);
        DPath = Path.Combine(RPSUdir, "stats.txt");


        LoadStats(DPath);

        while (true)
        {

            Console.WriteLine("Welcome to Rock, Paper, Scissors Ultimate");
            Console.WriteLine();
            Console.WriteLine("Please type your desired option:");
            Console.WriteLine();
            Console.WriteLine("Battle");
            Console.WriteLine("Ultra Battle");
            Console.WriteLine("Stats");
            Console.WriteLine("Backstory");
            Console.WriteLine("Exit");
            Console.WriteLine();
            String Selection = Console.ReadLine();
            Console.Clear();

            if (Selection.Equals("Exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Thanks for Playing! Press Enter to close application.");
                Console.ReadLine();
                return;
            }
            else if (Selection.Equals("Ultra Battle", StringComparison.OrdinalIgnoreCase))
            {
                UltraBattle();
            }
            else if (Selection.Equals("Stats", StringComparison.OrdinalIgnoreCase))
            {
                DisplayStats();
            }
            else if (Selection.Equals("Backstory", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Your name is Rocky, you love rock paper scissors, and that is all you know");
                Console.WriteLine("2 years ago is the farthest in your mind that you can remember, and its a fond memory of playing rock paper scissors");
                Console.WriteLine("While you are confused what happened in your life before the ring, you know that it could never be as satisfying as where you are now");
                Console.WriteLine("You have been steadily climbing up the ladder, and now this is it, the championship match against Ivan Drockgo");
                Console.WriteLine("The match is about to start, your vision is blurry from anxiety, hands shaking from the fear, but you beleive you can prevail");
                Console.WriteLine("Because your name is Rocky, you love rock paper scissors, and that is all you know");
                Console.WriteLine();
                Console.WriteLine("Press Enter to Return to the Main Menu");
                Console.ReadLine();
                Console.Clear();
            }
            else if (Selection.Equals("Battle", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("It's time for the Rock Paper Scissors Championship!");
                Console.WriteLine("Please type Rock, Paper, or Scissors!");
                Console.WriteLine();
                while (true)
                {
                    string Choice = Console.ReadLine();
                    Console.WriteLine();
                    int P1;
                    if (Choice.Equals("Rock", StringComparison.OrdinalIgnoreCase))
                    {
                        P1 = 2;
                        Console.Clear();
                    }
                    else if (Choice.Equals("Paper", StringComparison.OrdinalIgnoreCase))
                    {
                        P1 = 3;
                        Console.Clear();
                    }
                    else if (Choice.Equals("Scissors", StringComparison.OrdinalIgnoreCase))
                    {
                        P1 = 4;
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("That is not a choice, please try again");
                        Console.WriteLine("Please type Rock, Paper, or Scissors!");
                        continue;
                    }
                    Random RNG = new Random();
                    int CPU = RNG.Next(2, 5);
                    if (CPU == 2)
                    {
                        Console.WriteLine("Drockgo chose Rock!");
                    }
                    else if (CPU == 3)
                    {
                        Console.WriteLine("Drockgo chose Paper!");
                    }
                    else if (CPU == 4)
                    {
                        Console.WriteLine("Drockgo chose Scissors!");
                    }
                    if (P1 == CPU)
                    {
                        Console.WriteLine("You picked the same thing! Choose again!");
                        ++ties;
                        Console.WriteLine("Please type Rock, Paper, or Scissors!");
                        continue;
                    }
                    else if (P1 - CPU == 2)
                    {
                        Console.WriteLine("You Lost! Try again next time!");
                        ++losses;
                        Console.WriteLine();
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                    else if (CPU > P1)
                    {
                        Console.WriteLine("You Lost! Try again next time!");
                        ++losses;
                        Console.WriteLine();
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                    else if (CPU - P1 == 2)
                    {
                        Console.WriteLine("You won! You get the grand prize of $30! Congrats!");
                        money += 30;
                        ++wins;
                        Console.WriteLine();
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }

                    else
                    {
                        Console.WriteLine("You won! You get the grand prize of $30! Congrats!");
                        money += 30;
                        ++wins;
                        Console.WriteLine();
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }

                }
                SaveStats(DPath);
            }
            else
            {
                Console.WriteLine("That isn't an option. Please type a menu option");
                Console.WriteLine();
                continue;
            }
        }

    }
    static void LoadStats(string DPath)
    {
        if (File.Exists(DPath))
        {
            string[] lines = File.ReadAllLines(DPath);
            foreach (string line in lines)
            {

                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {

                    string key = parts[0];
                    int value = int.Parse(parts[1]);

                    if (key == "Wins") wins = value;
                    else if (key == "Losses") losses = value;
                    else if (key == "Ties") ties = value;
                    else if (key == "Money") money = value;
                }
            }
        }
        else
        {
            SaveStats(DPath);
        }
    }
    static void SaveStats(string DPath)
    {
        string[] currentstats =
        {
            $"Wins:{wins}",
            $"Losses:{losses}",
            $"Ties:{ties}",
            $"Money:{money}"
        };
        File.WriteAllLines(DPath, currentstats);
    }
    static void DisplayStats()
    {
        Console.WriteLine($"Wins = {wins}");
        Console.WriteLine($"Losses = {losses}");
        Console.WriteLine($"Ties = {ties}");
        Console.WriteLine($"Money = ${money}");
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the Main Menu");
        Console.ReadLine();
        Console.Clear();
    }
    static void UltraBattle()
    {
        if (money <= 1)
        {
            Console.WriteLine("You don't have enough money! come back when you aren't broke!");
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
        else if (money >= 2)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Ultra Battle!");
                Console.WriteLine("Please type leave if you want to return to the menu");
                Console.WriteLine("Please type start to begin the Ultra Battle");
                Console.WriteLine();
                String Selection = Console.ReadLine();
                Console.Clear();
                if (Selection.Equals("Start", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("How much money would you like to bet?");
                    int bet = int.Parse(Console.ReadLine());
                    if (bet >= 2 && bet <= money)
                    {
                        Console.WriteLine("Start the Ultra Battle!");
                        Console.WriteLine("Please type Rock, Paper, or Scissors!");
                        Console.WriteLine();
                        while (true)
                        {
                            string Choice = Console.ReadLine();
                            Console.WriteLine();
                            int P1;
                            if (Choice.Equals("Rock", StringComparison.OrdinalIgnoreCase))
                            {
                                P1 = 2;
                                Console.Clear();
                            }
                            else if (Choice.Equals("Paper", StringComparison.OrdinalIgnoreCase))
                            {
                                P1 = 3;
                                Console.Clear();
                            }
                            else if (Choice.Equals("Scissors", StringComparison.OrdinalIgnoreCase))
                            {
                                P1 = 4;
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("That is not a choice, please try again");
                                Console.WriteLine("Please type Rock, Paper, or Scissors!");
                                continue;
                            }
                            Random RNG = new Random();
                            int CPU = RNG.Next(2, 5);
                            if (CPU == 2)
                            {
                                Console.WriteLine("Opponent chose Rock!");
                            }
                            else if (CPU == 3)
                            {
                                Console.WriteLine("Opponent chose Paper!");
                            }
                            else if (CPU == 4)
                            {
                                Console.WriteLine("Opponent chose Scissors!");
                            }
                            if (P1 == CPU)
                            {
                                Console.WriteLine("You picked the same thing! Choose again!");
                                ++ties;
                                Console.WriteLine("Please type Rock, Paper, or Scissors!");
                                continue;
                            }
                            else if (P1 - CPU == 2)
                            {
                                Console.WriteLine($"You Lost! You lose ${bet}! Try again next time!");
                                money = money - bet;
                                ++losses;
                                Console.WriteLine();
                                Console.WriteLine("Press Enter to Continue");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else if (CPU > P1)
                            {
                                Console.WriteLine($"You Lost! You lose ${bet}! Try again next time!");
                                money = money - bet;
                                ++losses;
                                Console.WriteLine();
                                Console.WriteLine("Press Enter to Continue");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                            else if (CPU - P1 == 2)
                            {
                                Console.WriteLine($"You won! You received ${bet * 2}! Congrats!");
                                bet = bet * 2;
                                money = money + bet;
                                ++wins;
                                Console.WriteLine();
                                Console.WriteLine("Press Enter to Continue");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }

                            else
                            {
                                Console.WriteLine($"You won! You received ${bet * 2}! Congrats!");
                                bet = bet * 2;
                                money = money + bet;
                                ++wins;
                                Console.WriteLine();
                                Console.WriteLine("Press Enter to Continue");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                        }
                    }
                    SaveStats(DPath);
                }
                else if (Selection.Equals("Leave", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }
        }
    }
}
