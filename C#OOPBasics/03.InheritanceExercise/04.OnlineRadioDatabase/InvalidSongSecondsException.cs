using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.OnlineRadioDatabase
{
    public class InvalidSongSecondsException : InvalidSongLengthException
    {
        public const string Message = "Song seconds should be between 0 and 59.";

        public InvalidSongSecondsException()
            : base(Message)
        {

        }

        public InvalidSongSecondsException(string message)
            : base(message)
        {

        }

    }
}
