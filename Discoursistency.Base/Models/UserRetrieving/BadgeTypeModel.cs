namespace Discoursistency.Base.Models.UserRetrieving
{
    /// <summary>
    /// A model representing badge types in <see cref="UserModel"/>
    /// </summary>
    public class BadgeTypeModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int sort_order { get; set; }
    }
}
