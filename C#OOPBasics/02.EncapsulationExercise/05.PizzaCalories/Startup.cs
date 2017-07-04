using System;

namespace _05.PizzaCalories
{
    public class Startup
    {
        public static void Main()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] tokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Dough")
                {
                    try
                    {
                        Dough dough = new Dough(tokens[1], tokens[2], int.Parse(tokens[3]));
                        Console.WriteLine($"{dough.CalculateCalories():F2}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
                else if (tokens[0] == "Topping")
                {
                    try
                    {
                        Topping topping = new Topping(tokens[1], int.Parse(tokens[2]));
                        Console.WriteLine($"{topping.CalculateCalories():F2}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
                else
                {
                    string name = tokens[1];
                    int numberOfToppings = int.Parse(tokens[2]);

                    command = Console.ReadLine();
                    tokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Pizza pizza;
                    try
                    {
                        Dough dough = new Dough(tokens[1], tokens[2], int.Parse(tokens[3]));
                        pizza = new Pizza(name, dough);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }

                    for (int i = 0; i < numberOfToppings; i++)
                    {
                        command = Console.ReadLine();
                        tokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            Topping topping = new Topping(tokens[1], int.Parse(tokens[2]));
                            pizza.AddTopping(topping);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return;
                        }
                    }
                    Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():F2} Calories.");
                    return;
                }
                command = Console.ReadLine();
            }
        }
    }
}