using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ShoppingSpree
{
    public class Startup
    {
        private static List<Person> peoples;
        private static List<Product> products;

        public static void Main()
        {
            var personInput = Console.ReadLine();
            var productInput = Console.ReadLine();
            peoples = new List<Person>();
            products = new List<Product>();

            try
            {
                CreatePersons(personInput);
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine(nre.Message);
                return;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            try
            {
                CreateProducts(productInput);
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine(nre.Message);
                return;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            var input = Console.ReadLine();
            while (input != "END")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];
                var prod = tokens[1];

                var person = peoples.FirstOrDefault(p => p.Name == name);
                var product = products.FirstOrDefault(p => p.Name == prod);

                try
                {
                    person.BuyProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                input = Console.ReadLine();
            }

            peoples.ForEach(p => Console.WriteLine(p));
        }

        private static void CreateProducts(string productInput)
        {
            var productsInput = productInput.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var prod in productsInput)
            {
                var tokens = prod.Split('=');
                var name = tokens[0];
                var cost = decimal.Parse(tokens[1]);

                var product = new Product(name, cost);
                products.Add(product);
            }
        }

        private static void CreatePersons(string personInput)
        {
            var peopleInput = personInput.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var person in peopleInput)
            {
                var tokens = person.Split('=');
                var name = tokens[0];
                var money = decimal.Parse(tokens[1]);

                var people = new Person(name, money);
                peoples.Add(people);
            }
        }
    }
}