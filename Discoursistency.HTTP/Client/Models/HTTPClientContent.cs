using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Discoursistency.HTTP.Client.Models
{
    /// <summary>
    /// A class representing content received from the server.
    /// </summary>
    public class HTTPClientContent
    {
        private HTTPClientContentType _contentType = HTTPClientContentType.EmptyType;
        /// <summary>
        /// Type of the received content.
        /// </summary>
        public HTTPClientContentType ContentType { get { return _contentType; } }
        private string _stringContent;
        /// <summary>
        /// Text content received from the server.
        /// </summary>
        public string StringContent
        {
            get { return _stringContent; }
            set 
            { 
                _contentType = HTTPClientContentType.StringType;
                _byteContent = null;
                _jsonStringContent = null;
                _stringContent = value;
            }
        }

        private byte[] _byteContent;
        /// <summary>
        /// Binary content received from the server.
        /// </summary>
        public byte[] ByteContent
        {
            get { return _byteContent; }
            set
            {
                _contentType = HTTPClientContentType.ByteType;
                _jsonStringContent = null;
                _stringContent = null;
                _byteContent = value;
            }
        }

        private string _jsonStringContent;
        /// <summary>
        /// Object content received from the server.
        /// </summary>
        public string JSONStringContent
        {
            get { return _jsonStringContent; }
            set
            {
                _contentType = HTTPClientContentType.ObjectType;
                _stringContent = null;
                _byteContent = null;
                _jsonStringContent = value;
            }
        }

        /// <summary>
        /// Creates a new content object from a string.
        /// </summary>
        /// <param name="s">A string to be turned into a content object.</param>
        /// <returns>A new content object of textual type.</returns>
        public static implicit operator HTTPClientContent(string s)
        {
            return new HTTPClientContent { StringContent = s };
        }

        /// <summary>
        /// Creates a new content object from a byte array.
        /// </summary>
        /// <param name="b">A byte array to be turned into a content object.</param>
        /// <returns>A new content object of binary type.</returns>
        public static implicit operator HTTPClientContent(byte[] b)
        {
            return new HTTPClientContent { ByteContent = b };
        }

        /// <summary>
        /// Creates a new content object from a dynamic object.
        /// </summary>
        /// <param name="o">A dynamic object to be turned into a content object.</param>
        /// <returns>A new content object of object type.</returns>
        public static HTTPClientContent FromObject(dynamic o)
        {
            return o != null 
                ? new HTTPClientContent { JSONStringContent = JsonConvert.SerializeObject(o) } 
                : new HTTPClientContent();
        }

        /// <summary>
        /// Creates a new content object from a JSON string.
        /// </summary>
        /// <param name="j">A JSON string to be turned into a content object.</param>
        /// <returns>A new content object of object type.</returns>
        public static HTTPClientContent FromJSONString(string j)
        {
            return j != null
                ? new HTTPClientContent { JSONStringContent = j }
                : new HTTPClientContent();
        }

        /// <summary>
        /// Converts the underlying content to its string representation.
        /// </summary>
        /// <returns>String representation of the underlying content.</returns>
        public override string ToString()
        {
            switch (_contentType)
            {
                case HTTPClientContentType.EmptyType:
                    return String.Empty;
                case HTTPClientContentType.StringType:
                    return StringContent;
                case HTTPClientContentType.ByteType:
                    return Convert.ToBase64String(ByteContent);
                case HTTPClientContentType.ObjectType:
                    return _jsonStringContent;
            }
            throw new InvalidEnumArgumentException("Unsupported content type.");
        }

        /// <summary>
        /// Retrieves the underlying string content.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns>String content represented by the content object.</returns>
        public static implicit operator string(HTTPClientContent instance)
        {
            if (instance.ContentType == HTTPClientContentType.StringType)
            {
                return instance.StringContent;
            }
            else
            {
                throw new InvalidCastException("Response is of type: " + instance.ContentType + 
                    ", expected StringContent. Use .ToString() to obtain string representations " +
                    "of other content types.");
            }
        }

        /// <summary>
        /// Retrieves the underlying binary content.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns>Binary content represented by the content object.</returns>
        public static implicit operator byte[](HTTPClientContent instance)
        {
            if (instance.ContentType == HTTPClientContentType.ByteType)
            {
                return instance.ByteContent;
            }
            throw new InvalidCastException("Response is of type: " + instance.ContentType + ", expected ByteContent");
        }

        /// <summary>
        /// Retrieves the underlying object content.
        /// </summary>
        /// <returns>Object content represented by the content object.</returns>
        public T GetObject<T>()
        {
            if (_contentType == HTTPClientContentType.ObjectType)
            {
                return JsonConvert.DeserializeObject<T>(_jsonStringContent);
            }
            throw new InvalidCastException("Response is of type: " + ContentType + ", expected ObjectContent");
        }
    }
}
