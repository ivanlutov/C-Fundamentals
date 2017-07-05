using System;

namespace _06.Animals
{
    public class Startup
    {
        public static void Main()
        {
            var type = Console.ReadLine();

            while (type != "Beast!")
            {
                var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    Animal animal = null;

                    switch (type)
                    {
                        case "Cat":
                            animal = new Cat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            break;

                        case "Dog":
                            animal = new Dog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            break;

                        case "Frog":
                            animal = new Frog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            break;

                        case "Kittens":
                            animal = new Kitten(tokens[0], int.Parse(tokens[1]));
                            break;

                        case "Tomcat":
                            animal = new Tomcat(tokens[0], int.Parse(tokens[1]));
                            break;

                        default:
                            throw new ArgumentException("Invalid input!");
                    }

                    Console.WriteLine(animal);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Invalid input!");
                }

                type = Console.ReadLine();
            }
        }
    }
}