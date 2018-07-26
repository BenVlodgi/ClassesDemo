using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesDemo
{
    /// <summary> Human class for defining human objects. </summary>
    class Human
    {
        public string Name;
        public int Age;
        public int Dollars;
        public bool IsAlive;
        public bool HasJob;


        // Generated from http://listofrandomnames.com/index.cfm
        private static string[] names = new string[]
        {
            "Jade Kyler",
            "Nada Maugeri",
            "Deana Cabe",
            "Dann Irwin",
            "Virgie Richard",
            "Emiko Bowlin",
            "Liane Militello",
            "Cicely Patty",
            "Magaly Zackery",
            "Jayson Levett",
            "Omar Zeller",
            "Darcey Monaco",
            "Calandra Eddinger",
            "Kenna Cabezas",
            "Cristine Gemmell",
            "Roxie Leffel",
            "Sharron Bator",
            "Leanne Irion",
            "Grover Palin",
            "Fermina Attebery",
            "Mario Brune",
            "Ava Cyphers",
            "Gaylene Bromley",
            "Nick Dunnington",
            "Jimmie Gracia",
            "Kala Dew",
            "Clinton Heilmann",
            "Trula Matteson",
            "Lizeth Sprowl",
            "Denae Zwick",
            "Betsey Bennington",
            "Timmy Hettinger",
            "Marisela Luther",
            "Pamelia Barefield",
            "Melia Heinecke",
            "Loris Deas",
            "Dessie Mayhan",
            "Cherrie Rakow",
            "Stephaine Paz",
            "Migdalia Badillo",
            "Minda Sponsler",
            "Mozell Zepp",
            "Leslee Rivett",
            "Karri Franko",
            "Nancey Mellott",
            "Loriann Klaus",
            "Rea Hoggan",
            "Torrie Estey",
            "Daina Sapien",
            "Coral Utsey",
        };

        private static Random r = new Random();

        public Human()
        {
            Name = Human.GetRandomName();
            Age = 0;
            Dollars = 0;
            IsAlive = true;
            HasJob = false;
        }

        /// <summary> Chooses a random name from the list of pregenerated names. </summary>
        /// <returns> Random first and fast name. </returns>
        public static string GetRandomName()
        {
            return names[r.Next(names.Length)];
        }

        /// <summary> Processes one year of life for this human. </summary>
        public void OneYearPasses()
        {
            // Random chance of the human dying (1/100)
            if (IsAlive)
            {
                IsAlive = r.Next(100) != 0;
            }

            // If the human is alive, increase their age. 
            if (IsAlive)
            {
                Age++;
            }

            // If the human is alive and has a job, give them money
            if (IsAlive && HasJob)
            {
                // Get a value between 10 & 99
                int jobEarnings = r.Next(10, 100);
                Dollars += jobEarnings;
            }

            // If the human is alive, doesn't have a job and is atleast 16, randomly choose if they get a job (1/4).
            if (IsAlive && !HasJob && Age >= 16)
            {
                // Get a random number between 0 & 3. If the value is 0, then our human gets a job.
                HasJob = r.Next(4) == 0;
            }
            else if (IsAlive && HasJob) // If the human is alive, has a job, then choose if they lose their job (1/10).
            {
                HasJob = r.Next(10) != 0;
            }
        }

        public void Kill()
        {
            IsAlive = false;
        }

        public string GetDetails()
        {
            return $"Name: {Name,18} | Living:{IsAlive,5} | Age: {Age,3} | Employed: {HasJob,5} | Cash: {Dollars,6}";
        }
    }
}
