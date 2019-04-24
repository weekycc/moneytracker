using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace weekysoft.store.Interfaces
{
    public interface ILocalSetting
    {
        T GetValue<T>(T defaultValue = default(T), [CallerMemberName] string memberName = "");
        void SetValue<T>(T value, [CallerMemberName] string memberName = "");
    }
}
