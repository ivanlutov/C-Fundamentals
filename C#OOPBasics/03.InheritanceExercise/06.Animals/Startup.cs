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
                var name = tokens[0];
                int age;
                if (Int32.TryParse(tokens[1], out age))
                {
                }

                try
                {
                    Animal animal = null;

                    switch (type)
                    {
                        case "Cat":
                            animal = new Cat(name, age, tokens[2]);
                            break;

                        case "Dog":
                            animal = new Dog(name, age, tokens[2]);
                            break;

                        case "Frog":
                            animal = new Frog(name, age, tokens[2]);
                            break;

                        case "Kittens":
                            animal = new Kitten(name, age);
                            break;

                        case "Tomcat":
                            animal = new Tomcat(name, age);
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