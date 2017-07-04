using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.TruckTour
{
    public class PetrolStation
    {
        public int AmountOfGas { get; set; }

        public int DistanceToNext { get; set; }

        public int IndexOfPump { get; set; }

        public PetrolStation(int amountOfGas, int distanceToNext, int indexOfPump)
        {
            this.AmountOfGas = amountOfGas;
            this.DistanceToNext = distanceToNext;
            this.IndexOfPump = indexOfPump;
        }
    }

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<PetrolStation> stations = new Queue<PetrolStation>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var currentGas = tokens[0];
                var distanceToNextStation = tokens[1];

                PetrolStation currentPetrolStation = new PetrolStation(currentGas, distanceToNextStation, i);
                stations.Enqueue(currentPetrolStation);
            }

            PetrolStation startPump = null;
            bool completeJourney = false;
            while (true)
            {
                PetrolStation currentPump = stations.Dequeue();
                stations.Enqueue(currentPump);

                startPump = currentPump;
                int gasInTank = currentPump.AmountOfGas;

                while (gasInTank >= currentPump.DistanceToNext)
                {
                    gasInTank -= currentPump.DistanceToNext;

                    currentPump = stations.Dequeue();
                    stations.Enqueue(currentPump);

                    if (currentPump == startPump)
                    {
                        completeJourney = true;
                        break;
                    }
                    gasInTank += currentPump.AmountOfGas;
                }

                if (completeJourney)
                {
                    Console.WriteLine(startPump.IndexOfPump);
                    break;
                }
            }
        }
    }
}