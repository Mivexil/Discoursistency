using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.MessageBus
{
    /// <summary>
    /// A model representing a request to the message bus.
    /// </summary>
    public class MessageBusRequest
    {
        /// <summary>
        /// A GUID uniquely identifying the message bus being listened to.
        /// </summary>
        public Guid busID { get; set; }
        /// <summary>
        /// A list of channels and current message numbers to be sent to the message bus.
        /// </summary>
        public IDictionary<string, int> channels { get; set; }
        /// <summary>
        /// If true, the request will not be long-polled.
        /// </summary>
        public bool? dlp { get; set; }
    }
}
