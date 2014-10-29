using System;
using Discoursistency.HTTP.Client;
using Discoursistency.HTTP.Client.Models;

namespace Discoursistency.Base.Exceptions
{
    /// <summary>
    /// An exception that is thrown when the server returned a MIME type that is not valid in the context.
    /// </summary>
    public class UnsupportedTypeException : Exception
    {
        public UnsupportedTypeException(ResponseType type, ResponseType expectedType)
            : base("Retrieved request of type: " + type + ", expected: " + expectedType)
        {
            
        }

    }
}