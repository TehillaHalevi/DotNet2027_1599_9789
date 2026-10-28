using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ExistsIDException : Exception
    {
        public ExistsIDException(string message) : base(message) { }
        public ExistsIDException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class NotExistException : Exception
    {
        public NotExistException(string message) : base(message) { }
        public NotExistException(string message, Exception innerException) : base(message, innerException) { }
    }
}

