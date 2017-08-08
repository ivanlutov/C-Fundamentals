using System.Linq;
using System.Text;

namespace _03.Detail_Printer
{
    using System.Collections.Generic;

    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Documents:");
            this.Documents.ToList().ForEach(d => sb.AppendLine(d));

            return sb.ToString().Trim();
        }
    }
}
