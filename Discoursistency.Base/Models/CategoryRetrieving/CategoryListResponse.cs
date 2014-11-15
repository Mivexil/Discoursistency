using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.CategoryRetrieving
{
    public class CategoryListResponse
    {
        public CategoryList category_list { get; set; }
        public IEnumerable<UserRetrieving.SmallUserModel> featured_users { get; set; }
    }
}
