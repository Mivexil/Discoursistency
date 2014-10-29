using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base
{
    /// <summary>
    /// A class which manages multiple base services. Useful when handling multiple sites.
    /// </summary>
    public class DiscourseBaseServiceManager : IDiscourseBaseServiceManager
    {
        private readonly Dictionary<string, IDiscourseBaseService> _services 
            = new Dictionary<string, IDiscourseBaseService>();

        public void Dispose()
        {
            foreach (var service in _services.Values)
            {
                service.Dispose();
            }
        }
        /// <summary>
        /// Creates or retrieves a base service for given URL.
        /// </summary>
        /// <param name="targetSite">URL of the target website.</param>
        /// <returns>Base service for the target website.</returns>
        public IDiscourseBaseService ServiceFor(string targetSite)
        {
            if (_services.ContainsKey(targetSite))
            {
                return _services[targetSite];
            }
            else
            {
                var service = new DiscourseBaseService(targetSite);
                _services[targetSite] = service;
                return service;
            }
        }
    }
}
