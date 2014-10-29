using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the response received from the server cannot be bound to the expected model.
    /// </summary>
    public class UnexpectedResponseException : Exception
    {

        public UnexpectedResponseException() 
            : base("Received response was not in the correct format.")
        {
            
        }

        public UnexpectedResponseException(Exception e)
            : base("Received response was not in the correct format.", e)
        {

        }
    }
}
