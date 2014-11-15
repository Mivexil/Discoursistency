using System.Threading.Tasks;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.UserRetrieving;

namespace Discoursistency.Base.UserRetrieving
{
    public interface IBaseUserRetrievalService
    {
        Task<UserModel> GetUserData(AuthenticationData authData, UserRequest userData);
    }
}