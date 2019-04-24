using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekysoft.store.Attributes
{
    public class DisplayName : Attribute
    {
        public string Name { get; private set; }
        public DisplayName(string name)
        {
            Name = name;
        }
    }
}
