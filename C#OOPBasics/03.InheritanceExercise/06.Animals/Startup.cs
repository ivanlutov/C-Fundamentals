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
                int age = int.Parse(tokens[1]);
                //int age;
                //if (!int.TryParse(tokens[1], out age))
                //{
                //    throw new ArgumentException("Invalid input!");
                //}

                var gender = tokens[2];

                try
                {
                    Animal animal;
                    switch (type)
                    {
                        case "Cat":
                            animal = new Cat(name, age, gender);
                            break;

                        case "Dog":
                            animal = new Dog(name, age, gender);
                            break;

                        case "Frog":
                            animal = new Frog(name, age, gender);
                            break;

                        case "Kitten":
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

                type = Console.ReadLine();
            }
        }
    }
}