using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mango.Core.Entities;

namespace Mango.Core.Infrastructure
{
    /// <summary>
    /// Database factory interface
    /// </summary>
    public interface IDatabaseFactory : IDisposable
    {
        MangoContext Get();
    }
}
