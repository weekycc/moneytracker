using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekysoft.store.Attributes
{
    public class EntityKey : Attribute
    {
        public string Key { get; private set; }
        public EntityKey(string key)
        {
            Key = key;
        }
    }
}
