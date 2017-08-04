using System;
using System.Linq;
using System.Reflection;

namespace _02BlackBoxInteger
{
    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInt);
            var constructor = type
                .GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic
                , null, new Type[] { typeof(int) }, null);
            var instance = constructor.Invoke(new object[] { 0 });

            var input = Console.ReadLine();
            while (input != "END")
            {
                var cmdArgs = input.Split('_');
                var cmd = cmdArgs[0];
                var value = int.Parse(cmdArgs[1]);

                var method = type.GetMethod(cmd, BindingFlags.NonPublic | BindingFlags.Instance);
                method.Invoke(instance, new object[] { value });

                var field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First();
                Console.WriteLine(field.GetValue(instance));

                input = Console.ReadLine();
            }
        }
    }
}
