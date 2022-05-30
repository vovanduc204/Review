using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Exceptions
{
    [Serializable]
    public class BusinessRuleBrokenException : ApplicationException
    {
        public BusinessRuleBrokenException()
        {

        }

        public BusinessRuleBrokenException(string message) : base(message)
        {

        }

        public BusinessRuleBrokenException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
