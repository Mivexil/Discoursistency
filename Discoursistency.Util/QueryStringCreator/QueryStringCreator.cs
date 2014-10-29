using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Discoursistency.Util.QueryStringCreator
{
    /// <summary>
    /// Utility class which replicates the functionality of jQuery's $.param() method
    /// </summary>
    public static class QueryStringCreator
    {
        private static string NameValueToQueryParameter(string name, string value)
        {
            return String.Format("{0}={1}", HttpUtility.UrlEncode(name), HttpUtility.UrlEncode(value));
        }

        private static IEnumerable<string> InnerObjectToQueryParameters(string name, object o)
        {
            var result = new List<string>();
            if (o == null) return result;
            if (o.GetType().IsPrimitive || o is string)
            {
                result.Add(NameValueToQueryParameter(name, (o is bool ? ((bool) o ? "true" : "false") : o.ToString())));
            }
            else if (o is IEnumerable && !(o is IDictionary))
            {
                if (name.EndsWith("[]"))
                {
                    result.AddRange(((IEnumerable) o)
                        .Cast<object>()
                        .Select(x => NameValueToQueryParameter(name, x.ToString())));
                }
                else
                {
                    for (int i = 0; i < ((IEnumerable) o).Cast<object>().Count(); i++)
                    {
                        var prefix = name;
                        var item = ((IEnumerable) o).Cast<object>().ElementAt(i);
                        if ((item is IEnumerable || !item.GetType().IsPrimitive) && item.GetType() != "".GetType())
                        {
                            prefix += ("[" + i + "]");
                        }
                        else
                        {
                            prefix += "[]";
                        }
                        result.AddRange(InnerObjectToQueryParameters(prefix, item).Where(x => x != null));
                    }
                }
            }
            else
            {
                var dictionary = (o is IDictionary
                ? ((IDictionary)o).Cast<dynamic>().ToDictionary(x => (string)x.Key.ToString(), x => (object)x.Value)
                : (IDictionary<string, object>)new RouteValueDictionary(o));
                foreach (var key in dictionary.Keys)
                {
                    var prefix = name + "[" + key + "]";
                    result.AddRange(InnerObjectToQueryParameters(prefix, dictionary[key]).Where(x => x != null));
                }
            }
            return result;
        }

        /// <summary>
        /// Returns a query string representing a given object.
        /// </summary>
        /// <param name="inObject">Object to represent as a query string.
        /// Object must not be a primitive or string type, 
        /// and object properties must be IEnumerables, IDictionaries,
        /// primitives, strings or nested objects (for which the same rules apply)</param>
        /// <returns>A query string (not prepended by "?").</returns>
        public static string ToQueryParameters(object inObject)
        {
            if (inObject == null) throw new ArgumentNullException("inObject");
            if (inObject.GetType().IsPrimitive || inObject is string)
            {
                throw new ArgumentException("Cannot convert a primitive or string type. " +
                                            "To pass a primitive or string type, wrap it in " +
                                            "a dictionary or an object.");
            }
            if (inObject is IEnumerable && !(inObject is IDictionary))
            {
                throw new ArgumentException("Cannot convert a non-dictionary IEnumerable. " +
                                            "To pass a non-dictionary IEnumerable, wrap it in " +
                                            "a dictionary or an object.");
            }
            var results = new List<string>();
            var dictionary = (inObject is IDictionary
                ? ((IDictionary)inObject).Cast<dynamic>().ToDictionary(x => (string)x.Key.ToString(), x => (object)x.Value)
                : (IDictionary<string, object>)new RouteValueDictionary(inObject));
            foreach (var key in dictionary.Keys)
            {
                results.AddRange(InnerObjectToQueryParameters(key, dictionary[key]).Where(x => x != null));
            }
            if (!results.Any()) return "";
            return results.Aggregate((x, y) => x + "&" + y).Replace(" ", "+");
        }
    }
}
