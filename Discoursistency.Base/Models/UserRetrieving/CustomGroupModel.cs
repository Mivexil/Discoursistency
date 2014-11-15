namespace Discoursistency.Base.Models.UserRetrieving
{
    /// <summary>
    /// A model for custom group information in <see cref="UserSubmodel"/>
    /// </summary>
    public class CustomGroupModel
    {
        public int? alias_level { get; set; }
        public bool automatic { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int user_count { get; set; }
        public bool visible { get; set; }
    }
}
