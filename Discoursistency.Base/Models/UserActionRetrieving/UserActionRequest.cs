namespace Discoursistency.Base.Models.UserActionRetrieving
{
    /// <summary>
    /// A request for a list of actions taken by user.
    /// </summary>
    public class UserActionRequest
    {
        public string username { get; set; }
        public int? offset { get; set; }
        public string filter { get; set; }
    }
}
