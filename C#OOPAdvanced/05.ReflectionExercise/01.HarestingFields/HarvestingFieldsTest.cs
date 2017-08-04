using System.Linq;
using System.Reflection;
using System.Text;

namespace _01HarestingFields
{
    using System;

    class HarvestingFieldsTest
    {
        static void Main()
        {
            var sb = new StringBuilder();
            var typeOfCmd = Console.ReadLine();
            Type classType = typeof(HarvestingFields);
            while (typeOfCmd != "HARVEST")
            {
                var fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                switch (typeOfCmd)
                {
                    case "private":
                        fields
                            .Where(f => f.IsPrivate)
                            .ToList()
                            .ForEach(f => sb.AppendLine($"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}"));
                        break;
                    case "protected":
                        fields
                            .Where(f => f.IsFamily)
                            .ToList()
                            .ForEach(f => sb.AppendLine($"protected {f.FieldType.Name} {f.Name}"));
                        break;
                    case "public":
                        fields
                            .Where(f => f.IsPublic)
                            .ToList()
                            .ForEach(f => sb.AppendLine($"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}"));
                        break;
                    case "all":
                        foreach (var f in fields)
                        {
                            if (f.IsFamily)
                            {
                                sb.AppendLine($"protected {f.FieldType.Name} {f.Name}");
                            }
                            else
                            {
                                sb.AppendLine($"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}");
                            }
                        }
                        break;
                }

                Console.WriteLine(sb.ToString().Trim());
                sb.Clear();
                typeOfCmd = Console.ReadLine();
            }
        }
    }
}
