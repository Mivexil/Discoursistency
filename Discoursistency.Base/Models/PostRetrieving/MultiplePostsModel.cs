namespace Discoursistency.Base.Models.PostRetrieving
{
    /// <summary>
    /// A model representing a stream of multiple posts.
    /// </summary>
    public class MultiplePostsModel
    {
        public int id { get; set; }
        public PostStreamModel post_stream { get; set; }
    }
}
