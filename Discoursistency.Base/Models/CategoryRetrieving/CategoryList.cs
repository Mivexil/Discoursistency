using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.CategoryRetrieving
{
    public class CategoryList
    {
        public bool can_create_category { get; set; }
        public bool can_create_topic { get; set; }
        public IEnumerable<CategoryModel> categories { get; set; }
        public string draft { get; set; }
        public string draft_key { get; set; }
        public int draft_sequence { get; set; }
    }
}
