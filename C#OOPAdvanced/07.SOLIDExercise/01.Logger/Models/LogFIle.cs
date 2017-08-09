namespace _01.Logger.Models
{
    using System.Text;

    public class LogFile
    {
        private StringBuilder sb;

        public LogFile()
        {
            this.sb = new StringBuilder();
        }

        public int Size { get; set; }

        public void Write(string formattedMsg)
        {
            this.sb.AppendLine(formattedMsg);
            foreach (var character in formattedMsg)
            {
                if (char.IsLetter(character))
                {
                    Size += character;
                }
            }
        }
    }
}