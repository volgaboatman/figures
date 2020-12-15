using System;

namespace ru.figure.handlers
{
    public class BusinessLogicException: Exception
    {
        public BusinessLogicException(string message) : base(message)
        {
        }
    }
}
