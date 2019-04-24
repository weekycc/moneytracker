using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekysoft.store.Enums
{
    public class EnumHelper
    {
        public static T GetByKey<T>(string value)
        {
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                if (item.GetKey().ToLower().Equals(value.Trim().ToLower())) 
                    return item;
            }
            return default(T);
        }

        public static IEnumerable<T> Members<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
