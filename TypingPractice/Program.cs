// TODO: Difficulty modifies word selection
//       Refactor/Clean up restart function


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;



namespace TypingPractice
{
    class Program
    {
        // List of words to be typed
        public static string[] words = { "some", "side", "add", "another", "would", "book" ,"water", "came" ,"your" ,"big","both", "from", "learn", "been", "me" ,"school" ,"land", "took", "place",
                "try", "line", "tell", "earth", "can", "do","children", "without", "my", "must", "take", "follow", "year", "is", "being", "different", "miss", "could", "on", "he", "open", "night", "were",
                "line","said", "around", "an", "plant", "know", "set","been", "life","young","of", "face", "we", "hand", "while", "is", "white", "call", "live","may", "study","after" ,"down", "him", "now", "different",
                "could", "over", "work","all", "mean","begin","go","fall", "really", "oil", "before","into","one","name","has","a", "well", "got","something","turn" };
        // Keeps track of words array
        public static int numWords = 88;
        public static int correctWords = 0;
        // Initialize our random number generator
        public static Random rand = new Random();
        // Handles user input
        public static string userInput = "";
        public static string endGameChoice = "";
        // Handles gamestate variables
        public static bool gameActive = false;
        public static int numLives = 0;
        public static int timeLeft = 0;
        public static System.Threading.Timer time;
        public System.Threading.Timer updateTimer;
        // Handles difficulties
        public static int HARD = 10;
        public static int MEDIUM = 20;
        public static int EASY = 30;
        public static int selectedDifficulty;


        // Entry Point
        static void Main(string[] args)
        {
            // Start the game
            Start();
        }

        // Handles gameplay
        static void Play()
        {
            
            if ( timeLeft <= 0 )
            {
                outOfTime();
            }
            // Assigns the current word to any random word in
            // the words array
            string currentWord = words[rand.Next(0, 88)];
            // Print the current word separated by lines
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("**************************");
            Console.WriteLine("***  Time Remaining: " + timeLeft + " ***");
            Console.WriteLine("**************************");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("************************");
            Console.WriteLine("** Lives Remaining: " + numLives + " **");
            Console.WriteLine("************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Score: " + correctWords + " words!");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("********");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(currentWord);
            Console.ResetColor();
            Console.WriteLine("********");
          

            while (timeLeft != 0)
            {
                // While the answser is incorrect/empty
                while (!userInput.Equals("exit"))
                {

                    // Reads user input
                    userInput = Console.ReadLine();
                    if (userInput.Equals(""))
                    {
                        Play();
                    }
                    // Checks if userInput is equal to current word
                    if (!(userInput.Equals(currentWord)))
                    {
                        // If incorrect, display loss of life
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect!!!");
                        Console.WriteLine("Lives: " + numLives);
                        numLives--; // Take a life away
                        Console.ResetColor();

                    }

                    if (numLives == -1)
                    {
                        outOfLives();
                    }


                    if (userInput.Equals(currentWord))
                    {
                        correctWords++;
                        Play();
                    }

                }
                if (userInput.Equals("exit"))
                {
                    Environment.Exit(0);
                }
            }
        }
        // Function for running out of lives
        static void outOfLives()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("************************** ");
            Console.WriteLine("******* Game over! ******* ");
            Console.WriteLine("************************** ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You typed " + correctWords + " words correctly!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press enter to retry, Press Escape to Quit!");
            Console.ResetColor();

            var endGameKey = Console.ReadKey();

            if (endGameKey.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            if (endGameKey.Key == ConsoleKey.Enter)
            {
                restartGame();
            }
            else
            {
                outOfLives();
            }

        }
        // Function for running out of time
        static void outOfTime()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("************************** ");
            Console.WriteLine("******* Game over! ******* ");
            Console.WriteLine("************************** ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You typed " + correctWords + " words correctly!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press enter to retry, Press Escape to Quit!");
            Console.ResetColor();

            var endGameKey = Console.ReadKey();

            if (endGameKey.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            if (endGameKey.Key == ConsoleKey.Enter)
            {
                restartGame();
            }
            else
            {
                outOfTime();
            }
        }

        // Prompts user for input for difficulty along with game instructions
        static void StartMessage()
        {
            Console.WriteLine("Welcome to my Typing Practice App!");
            Console.WriteLine("Type the word displayed as fast as you can");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Difficulties are listed from hardest to easiest");
            Console.WriteLine();
            Console.WriteLine("Select a difficulty( 1 ,2 , or 3 ): ");
            Console.WriteLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-- Type 1 --");
            Console.WriteLine("***  Software Engineer  ***");
            Console.WriteLine("##############################");
            Console.WriteLine("### Game Timer: 10 Seconds ###");
            Console.WriteLine("##############################");
            Console.WriteLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-- Type 2 --");
            Console.WriteLine("***  Social Media Fanatic  ***");
            Console.WriteLine("##############################");
            Console.WriteLine("### Game Timer: 20 Seconds ###");
            Console.WriteLine("##############################");
            Console.WriteLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-- Type 3 --");
            Console.WriteLine("*** Filthy Peasant ***");
            Console.WriteLine("##############################");
            Console.WriteLine("### Game Timer: 30 Seconds ###");
            Console.WriteLine("##############################");
            Console.WriteLine();
            Console.ResetColor();

            var difficultyKey = Console.ReadKey();

            switch (difficultyKey.Key)
            {
                case ConsoleKey.D1:
                    numLives = 1;
                    Console.WriteLine("You have 2 lives! Good luck!");
                    selectedDifficulty = HARD;
                    break;
                case ConsoleKey.NumPad1:
                    numLives = 1;
                    Console.WriteLine("You have 2 lives! Good luck!");
                    selectedDifficulty = HARD;
                    break;
                case ConsoleKey.D2:
                    numLives = 3;
                    Console.WriteLine("You have 4 lives! Good luck!");
                    selectedDifficulty = MEDIUM;
                    break;
                case ConsoleKey.NumPad2:
                    numLives = 3;
                    Console.WriteLine("You have 4 lives! Good luck!");
                    selectedDifficulty = MEDIUM;
                    break;
                case ConsoleKey.D3:
                    numLives = 5;
                    Console.WriteLine("You have 6 lives! Good luck!");
                    selectedDifficulty = EASY;
                    break;
                case ConsoleKey.NumPad3:
                    numLives = 5;
                    Console.WriteLine("You have 6 lives! Good luck!");
                    selectedDifficulty = EASY;
                    break;
                default:
                    Console.Clear();
                    StartMessage();
                    break;
            }
           
            //string difficultyChoice = Console.ReadLine();
            //switch (difficultyChoice)
            //{
            //    case "1":
            //        numLives = 1;
            //        Console.WriteLine("You have 2 lives! Good luck!");
            //        selectedDifficulty = HARD;
            //        break;
            //    case "2":
            //        numLives = 3;
            //        Console.WriteLine("You have 4 lives! Good luck!");
            //        selectedDifficulty = MEDIUM;
            //        break;
            //    case "3":
            //        numLives = 5;
            //        Console.WriteLine("You have 6 lives! Good luck!");
            //        selectedDifficulty = EASY;
            //        break;

            //    default:
            //        numLives = 0;
            //        Console.ForegroundColor = ConsoleColor.DarkRed;
            //        Console.WriteLine("Miss one and you're done!!!!!");
            //        Console.ResetColor();
            //        selectedDifficulty = 3;
            //        break;
            //}
        }
        public static void restartGame()
        {
            Console.Clear();
            //numLives = 5;
            numWords = words.Length;
            correctWords = 0;
            Start();
        }

        public static void SetTimer(Object o)
        {
            timeLeft--;
            //Console.WriteLine(timeLeft);
            if ( timeLeft == 0 )
            {
                time.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }

        public static void Start()
        {
            // Display start message
            StartMessage();
            gameActive = true;
            time = new System.Threading.Timer(SetTimer, null, 0, 1250);
            timeLeft = selectedDifficulty;
            
            // While user wants to play
            while (!userInput.Equals("exit"))
            {
                // While the game is active
                while (gameActive == true)
                {
                    // Start the game
                    Play();
                }
            }
            if (userInput.Equals("exit"))
            {
                Environment.Exit(0);
            }

        }
    }
}
