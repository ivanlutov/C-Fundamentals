using System;

namespace _05.GenericCountMethodString
{
    public class Box<T>
        where T : IComparable<T>
    {
        public T Value { get; set; }

        public Box(T value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{this.Value.GetType().FullName}: {this.Value}";
        }
    }
}