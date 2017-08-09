namespace _01.Logger
{
    using System;
    using System.Security.Principal;
    using _01.Logger.Engine;
    using _01.Logger.Interfaces;
    using _01.Logger.Models;
    using _01.Logger.Models.AppenderModels;
    using _01.Logger.Models.LayoutModels;
    using _01.Logger.Models.LoggerModels;

    public class Startup
    {
        public static void Main()
        {
            var controller = new Controller();
            controller.Run();
        }
    }
}
