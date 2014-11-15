namespace Discoursistency.Base.Models.PostRetrieving
{
    /// <summary>
    /// A request to obtain a post based on its global ID.
    /// </summary>
    public class GetPostRequest
    {
        public int? id { get; set; }
    }
}
