using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekysoft.store.Attributes
{
    public class EntityName : Attribute
    {
        public string Name { get; private set; }
        public EntityName(string name)
        {
            Name = name;
        }
    }
}
