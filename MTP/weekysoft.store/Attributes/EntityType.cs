using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekysoft.store.Attributes
{
    public class EntityType : Attribute
    {
        public Type ObjectType { get; private set; }
        public EntityType(Type t)
        {
            ObjectType = t;
        }
    }
}
