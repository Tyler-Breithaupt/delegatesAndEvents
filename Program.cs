using System;

namespace delegatesAndEvents
{
    // create a delegate
    public delegate void RaceEventHandler(int winner);

    public class Race
    {
        // create a delegate event object
        public event RaceEventHandler RaceCompleted;

        public void Racing(int contestants, int laps)
        {
            Console.WriteLine("Ready\nSet\nGo!");
            Random r = new Random();
            int[] participants = new int[contestants];
            bool done = false;
            int champ = -1;
            while (!done)
            {
                for (int i = 0; i < contestants; i++)
                {
                    if (participants[i] <= laps)
                    {
                        participants[i] += r.Next(1, 5);
                    }
                    else
                    {
                        champ = i;
                        done = true;
                        continue;
                    }
                }
            }
            TheWinner(champ);
        }

        private void TheWinner(int champ)
        {
            Console.WriteLine("We have a winner!");
            // Invoking the event and passing the winner
            RaceCompleted?.Invoke(champ);
        }
    }

    class Program
    {
        public static void Main()
        {
            Race round1 = new Race();

            // Registering event handlers
            round1.RaceCompleted += footRace; 
            round1.RaceCompleted += carRace; 

            // Registering a lambda expression for a bike race
            round1.RaceCompleted += winner => Console.WriteLine($"Biker number {winner} is the winner.");

            // Triggering the events
            round1.Racing(5, 10); // Example: 5 contestants, 10 laps
        }

        // Event handlers
        public static void carRace(int winner)
        {
            Console.WriteLine($"Car number {winner} is the winner.");
        }

        public static void footRace(int winner)
        {
            Console.WriteLine($"Racer number {winner} is the winner.");
        }
    }
}