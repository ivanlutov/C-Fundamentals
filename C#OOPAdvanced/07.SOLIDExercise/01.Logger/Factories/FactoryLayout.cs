namespace _01.Logger.Factories
{
    using System;
    using _01.Logger.Interfaces;
    using _01.Logger.Models.LayoutModels;

    public class FactoryLayout
    {
        public ILayout Create(string layoutType)
        {
            if (layoutType == "SimpleLayout")
            {
                return new SimpleLayout();
            }
            else if (layoutType == "XmlLayout")
            {
                return new XmlLayout();
            }

            throw new ArgumentException("The type is not valid!");
        }
    }
}