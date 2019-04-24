using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekysoft.store.Interfaces
{
    public interface IVersion
    {
        string Version { get; }
        string GetVersion();
    }
}
