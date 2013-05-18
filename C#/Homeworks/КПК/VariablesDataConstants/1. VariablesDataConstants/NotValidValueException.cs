using System;

namespace VariablesDataConstants
{
    class NotValidValueException : Exception
    {
        public NotValidValueException()
            : base()
        {
        }
        public NotValidValueException(string message)
            : base(message)
        {
        }
        public NotValidValueException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
