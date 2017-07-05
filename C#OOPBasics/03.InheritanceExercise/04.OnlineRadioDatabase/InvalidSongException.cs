using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.OnlineRadioDatabase
{
    public class InvalidSongException : Exception
    {
        private const string Message = "Invalid song.";
        public InvalidSongException() 
            : base(Message)
        {
            
        }
        public InvalidSongException(string message)
            : base(message)
        {

        }
    }
}
