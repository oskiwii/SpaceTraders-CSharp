using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetraders.Exceptions
{
    public class APIException : Exception
    {
        string data;

        public APIException() { }

        public APIException(string message) : base(message) 
        {
            data = message;
            Console.Error.WriteLine(message);
        }

        public APIException(string message, Exception inner) : base(message, inner)
        {
            data = message;
            Console.Error.WriteLine(message);
        }
    }
}
