using System;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.Commands
{
    public abstract class Command : IExecutable
    {
        private string input;
        private string[] data;
      
        protected Command(string input, string[] data)
        {
            this.Input = input;
            this.Data = data;
        }

        public string Input
        {
            get { return this.input; }

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        public string[] Data
        {
            get { return this.data; }

            protected set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }
                this.data = value;
            }
        }
        
        public abstract void Execute();
    }
}