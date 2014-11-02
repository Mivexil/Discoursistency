using System.Threading.Tasks;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.Retrieving;

namespace Discoursistency.Base.Retrieving
{
    public interface IDiscoursePostRetrievalService
    {
        Task<MultiplePostsModel> GetMultiplePosts(AuthenticationData authData,
            GetMultiplePostsRequest requestData);

        Task<PostModel> GetPost(AuthenticationData authData, GetPostRequest getPostData);
    }
}