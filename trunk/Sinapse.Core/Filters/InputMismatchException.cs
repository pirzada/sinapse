using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Core.Filters
{
    public class InputMismatchException : Exception
    {

        string typeExcepected;
        string typeReceived;

        public InputMismatchException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public InputMismatchException(string message)
            : base(message)
        {

        }
    }
}
