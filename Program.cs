using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ExceptionsTest
{
    class Program
    {
        public class MyException : Exception
        {
            public string message;
            public MyException (string message)
            {
                this.message = message;
            }
        }

        static void Main(string[] args)
        {
            int number = 0;
            bool success = false;
            do
            {
                try
                {
                    number = int.Parse(ReadLine());
                    if(number == 100)
                    {
                        throw new MyException("Wrong in all senses!");
                    }
                    success = true;
                }

                catch (ArgumentNullException)
                {
                    WriteLine("You didn't enter any value");
                }

                catch (OverflowException)
                {
                    WriteLine("You entered a too high a number");
                }

                catch (FormatException)
                {
                    WriteLine("You have to enter a number");
                }
                catch (MyException error)
                {
                    WriteLine(error.message);
                    WriteLine("Custom exception");
                }

            } while (success == false);
            
        }

        public static void StringBuilderDemo()
        {
            string testString = "Lexicon";
            DateTime startString = DateTime.Now;
            WriteLine("Starttid för string: " + startString);

            for (int i = 0; i < 800000; i++)
            {
                testString += "!";
            }

            DateTime stopString = DateTime.Now;
            WriteLine("Sluttid för string: " + stopString);
            WriteLine("Skillnad: " + (stopString - startString));

            WriteLine();

            StringBuilder testStringBuilder = new StringBuilder("Lexicon");
            DateTime startStringBuilder = DateTime.Now;
            WriteLine("Starttid flr StringBuilder: " + startStringBuilder);

            for (int s = 0; s < 800000; s++)
            {
                testStringBuilder.Append("!");
            }

            DateTime stopStringBuilder = DateTime.Now;
            WriteLine("Sluttid för StringBuilder: " + stopStringBuilder);
            WriteLine("Skillnad: " + (stopStringBuilder - startStringBuilder));
            ReadKey();
        }

        public static void TeamPresenter()
        {
            string player1 = "Lisbeth";
            string player2 = "Anneli";

            string[] allPlayers = GetAllPlayers();

            string[] selectedPlayers1 = ReturnRandomPlayers(2, allPlayers);
            WriteLine($"I dagens match möts {selectedPlayers1[0]} och {selectedPlayers1[1]}");
            WriteLine();

            string opponents1a = "Fredrik";
            string opponents1b = "Daniel";
            string opponents2a = "Alex";
            string opponents2b = "Johan";

            string[] selectedPlayers2 = ReturnRandomPlayers(4, allPlayers);
            WriteLine($"I dagens match möts {selectedPlayers2[0]}/{selectedPlayers2[1]} och {selectedPlayers2[2]}/{selectedPlayers2[3]}");

            WriteLine();

            string[] selectedPlayers3 = ReturnRandomPlayers(11, allPlayers);
            Console.WriteLine("Tölltorps laguppställning:");
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine($"{i + 1}. {selectedPlayers3[i]}");
            }
        }

        // indexValue[0] == 0;
        // indexValue[1] == 1;
        //                                          indexValue[2] == 2;
        // indexValue[2] == 3;                                       indexValue[3] == 3;

        // selectedPlayers[0] = 2;

        public static string[] ReturnRandomPlayers(int amountOfPlayers, string[] allPlayers)
        {
            string[] selectedPlayers = new string[amountOfPlayers];
            Random random = new Random();       
            List<int> fullPlayerRange = new List<int>();
            for(int i = 0; i < allPlayers.Length; i++)
            {
                fullPlayerRange.Add(i);
            }
            for(int p = 0; p < amountOfPlayers; p++)
            {
                int getIndex = random.Next(0, fullPlayerRange.Count);
                int uniquePlayerIndex = fullPlayerRange[getIndex];
                selectedPlayers[p] = allPlayers[uniquePlayerIndex];
                fullPlayerRange.RemoveAt(getIndex);
            }
            return selectedPlayers;
        }

        public static string[] GetAllPlayers()
        {
            string[] allPlayers =        {
                "Fredrik", "Lars", "Håkan", "Stefan", "Anders", "Göran", "Tim",
                "Marcus", "Johan", "Jan", "Gert", "Magnus", "Tomas", "Christer",
                "Mikael", "Linus", "Måns", "Torsten", "Wiktor", "Alf"
            };
            return allPlayers;
        }
    }
}
