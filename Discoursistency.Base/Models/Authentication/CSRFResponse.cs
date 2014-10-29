using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discoursistency.Base.Exceptions;
using Microsoft.CSharp.RuntimeBinder;

namespace Discoursistency.Base.Models.Authentication
{
    /// <summary>
    /// A model representing a response from CSRF token issuing controller.
    /// </summary>
    public class CSRFResponse
    {
        public string csrf { get; set; }

        /// <summary>
        /// A factory method converting a dynamic response to the model.
        /// </summary>
        /// <param name="d">Dynamic response obtained from the web client.</param>
        /// <returns>Strongly-typed model.</returns>
        public static CSRFResponse FromDynamic(dynamic d)
        {
            try
            {
                var response = new CSRFResponse
                {
                    csrf = d.csrf
                };
                return response;
            }
            catch (RuntimeBinderException e)
            {
                throw new UnexpectedResponseException(e);
            }
        }
    }
}
