namespace Discoursistency.Base.Models.UserRetrieving
{
    /// <summary>
    /// A lightweight user information model in <see cref="UserModel"/>
    /// </summary>
    public class SmallUserModel
    {
        public string avatar_template { get; set; }
        public int id { get; set; }
        public int? post_count { get; set; }
        public int uploaded_avatar_id { get; set; }
        public string username { get; set; }
    }
}
