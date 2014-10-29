namespace Discoursistency.HTTP.Client.Models
{
    /// <summary>
    /// A class representing client's authentication data.
    /// </summary>
    public class AuthData
    {
        /// <summary>
        /// A cookie authenticating the user.
        /// </summary>
        public string CookieString { get; set; }
        /// <summary>
        /// A CSRF token required to validate the request.
        /// </summary>
        public string XSRFString { get; set; }
    }
}
