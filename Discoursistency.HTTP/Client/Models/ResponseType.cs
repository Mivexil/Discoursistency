namespace Discoursistency.HTTP.Client.Models
{
    /// <summary>
    /// Type of the response from the server.
    /// </summary>
    public enum ResponseType
    {
        JSON,
        HTML,
        Text,
        UnknownText,
        Unknown,
        Empty,
        MalformedJSON
    }
}
