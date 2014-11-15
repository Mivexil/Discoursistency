using System.Threading.Tasks;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.CategoryRetrieving;

namespace Discoursistency.Base.CategoryRetrieving
{
    public interface IBaseCategoryRetrievalService
    {
        Task<CategoryListResponse> GetCategories(AuthenticationData authData);
    }
}