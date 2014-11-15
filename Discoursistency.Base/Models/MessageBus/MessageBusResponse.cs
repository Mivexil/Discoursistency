using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.MessageBus
{
    /// <summary>
    /// A model representing a single response to a message bus request.
    /// </summary>
    public class MessageBusResponse
    {
        /// <summary>
        /// A channel this response belongs to.
        /// </summary>
        public string channel { get; set; }
        /// <summary>
        /// Additional channel-specific data for the message.
        /// </summary>
        public dynamic data { get; set; }
        /// <summary>
        /// Global ID of the received message.
        /// </summary>
        public int global_id { get; set; }
        /// <summary>
        /// Number of the message in this channel.
        /// </summary>
        public int message_id { get; set; }
    }
}
