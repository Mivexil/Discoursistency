namespace Discoursistency.Base.Models.PostRetrieving
{
    /// <summary>
    /// A model of an action that can be taken on a post in <see cref="PostModel"/>
    /// </summary>
    public class ActionSummaryItem
    {
        public bool can_act { get; set; }
        public bool? can_defer_flags { get; set; }
        public int count { get; set; }
        public bool hidden { get; set; }
        public int id { get; set; }
    }
}
