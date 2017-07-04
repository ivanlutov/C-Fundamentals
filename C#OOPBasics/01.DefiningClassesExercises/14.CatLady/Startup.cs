using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.CatLady
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var cats = new List<Cat>();
            while (input != "End")
            {
                var tokens = input.Split();
                var breedType = tokens[0];
                var name = tokens[1];
                var spec = double.Parse(tokens[2]);
                Breed breed = null;

                if (breedType == "Siamese")
                {
                    breed = new Siamese(breedType, spec);
                }
                else if (breedType == "Cymric")
                {
                    breed = new Cymric(breedType, spec);
                }
                else if (breedType == "StreetExtraordinaire")
                {
                    breed = new StreetExtraordinaire(breedType, spec);
                }

                var cat = new Cat(name, breed);
                cats.Add(cat);

                input = Console.ReadLine();
            }

            var catName = Console.ReadLine();
            var catForPrint = cats.First(c => c.Name == catName);

            Console.WriteLine($"{catForPrint.Breed.Type} {catForPrint.Name} {catForPrint.Breed}");
        }
    }
}