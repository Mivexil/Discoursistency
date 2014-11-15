using System.Collections.Generic;
using System.Threading.Tasks;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.NotificationRetrieving;
using Discoursistency.Base.Models.PostRetrieving;
using Discoursistency.Base.Models.UserActionRetrieving;
using Discoursistency.Base.Models.UserRetrieving;

namespace Discoursistency.Base.PostRetrieving
{
    public interface IBasePostRetrievalService
    {
        Task<MultiplePostsModel> GetMultiplePosts(AuthenticationData authData,
            GetMultiplePostsRequest requestData);
        Task<PostModel> GetPost(AuthenticationData authData, GetPostRequest getPostData);
        Task<string> GetRawPost(AuthenticationData authData, GetPostByTopicRequest postData);
        Task<TopicModel> GetTopic(AuthenticationData authData, TopicRequest requestData);
        Task<TopicListResponse> GetLatest(AuthenticationData authData, TopicListRequest requestData);
        Task<TopicListResponse> GetNew(AuthenticationData authData, TopicListRequest requestData);
        Task<TopicListResponse> GetUnread(AuthenticationData authData, TopicListRequest requestData);
    }
}