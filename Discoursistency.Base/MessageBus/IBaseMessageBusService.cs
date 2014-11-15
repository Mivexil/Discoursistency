using System.Collections.Generic;
using System.Threading.Tasks;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.MessageBus;

namespace Discoursistency.Base.MessageBus
{
    public interface IBaseMessageBusService
    {
        Task<IEnumerable<MessageBusResponse>> PollMessageBus(AuthenticationData authData, MessageBusRequest msgData);
    }
}