using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base
{
    interface IDiscourseBaseServiceManager : IDisposable
    {
        IDiscourseBaseService ServiceFor(string targetURL);
    }
}
