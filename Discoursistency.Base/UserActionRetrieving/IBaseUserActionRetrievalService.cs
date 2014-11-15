using System.Collections.Generic;
using System.Threading.Tasks;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.UserActionRetrieving;

namespace Discoursistency.Base.UserActionRetrieving
{
    public interface IBaseUserActionRetrievalService
    {
        Task<IEnumerable<UserActionModel>> GetUserActions(AuthenticationData authData, UserActionRequest actionData);
    }
}