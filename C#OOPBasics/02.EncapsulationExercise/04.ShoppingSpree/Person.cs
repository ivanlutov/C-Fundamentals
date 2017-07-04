using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullReferenceException($"{nameof(this.Name)} cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(this.Money)} cannot be negative");
                }

                this.money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            if (this.Money < product.Money)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }

            this.Money -= product.Money;
            products.Add(product);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (this.products.Any())
            {
                sb.Append($"{this.Name} - {string.Join(", ", this.products)}");
            }
            else
            {
                sb.Append($"{this.Name} - Nothing bought");
            }

            return sb.ToString();
        }
    }
}