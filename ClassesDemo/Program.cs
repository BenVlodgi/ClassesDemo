using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesDemo
{
    class Program
    {
        private static Random rand = new Random();

        static void Main(string[] args)
        {
            // Create empty list of human objects
            List<Human> humans = new List<Human>();
            string alert = "";

            bool playGame = true;
            while (playGame)
            {
                #region Console Outputs
                // Clear the console
                Console.Clear();

                // Write instructions
                Console.WriteLine(
                    "Things you can do:\n" +
                    " - (c)reate - spawns a new human\n" +
                    " - (k)ill   - kills a human\n" +
                    " - (y)ear   - causes a year to passby\n" +
                    " - (q)uit   - leave application"
                    );

                // Write out alert
                Console.WriteLine(alert);

                // clear alert
                alert = "";

                // Print Humans
                Console.WriteLine(string.Join(Environment.NewLine, humans.Select(human => human.GetDetails())));

                // Write prompt
                Console.Write(">: ");

                #endregion

                // Get user input
                string userInput = Console.ReadLine().Trim().ToLower();


                #region This handles the different user inputs
                if (userInput == "c" || userInput == "create")
                {
                    Human newHuman = new Human();
                    humans.Add(newHuman);

                    alert = $"{newHuman.Name} was born!";
                }
                else if (userInput == "k" || userInput == "kill")
                {
                    if (humans.Count == 0)
                    {
                        alert = "No humans to kill.";
                    }
                    else
                    {
                        int humanIndexToKill = rand.Next(humans.Count);
                        Human killedHuman = humans[humanIndexToKill];
                        killedHuman.Kill();

                        alert = $"{killedHuman.Name} was killed!";
                    }
                }
                else if (userInput == "y" || userInput == "year")
                {
                    foreach (var human in humans)
                    {
                        human.OneYearPasses();
                    }

                    alert = "One year has now passed.";
                }
                else if (userInput == "q" || userInput == "quit")
                {
                    playGame = false;
                }
                else
                {
                    alert = "your command \"" + userInput + "\" was invalid.";
                }
                #endregion


            }

            Console.WriteLine();
            Console.WriteLine("Goodbye!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
