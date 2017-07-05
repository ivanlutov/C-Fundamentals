namespace _04.OnlineRadioDatabase
{
    public class InvalidSongNameException : InvalidSongException
    {
        public const string Message = "Song name should be between 3 and 30 symbols.";

        public InvalidSongNameException()
            : base(Message)
        {
        }

        public InvalidSongNameException(string message)
            : base(message)
        {
        }
    }
}