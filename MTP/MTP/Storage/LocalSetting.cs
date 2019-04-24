using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using weekysoft.store.Interfaces;
using weekysoft.store.Serializer;
using weekysoft.store.Storage;
using Xamarin.Forms;

namespace MTP.Storage
{
    public class LocalSetting : ILocalSetting
    {
        private bool _AlwaysUseDefault;
        private ISettings _settings;
        public LocalSetting(bool AlwaysUseDefault)
        {
            _settings = CrossSettings.Current;

            _AlwaysUseDefault = AlwaysUseDefault;
        }
        public T GetValue<T>(T defaultValue = default(T), [CallerMemberName] string memberName = "")
        {
            var v = defaultValue;
            if (!_AlwaysUseDefault)
            {
                if (_settings.Contains(memberName))
                {
                    if (!typeof(T).GetTypeInfo().IsPrimitive)
                    {
                        v = XmlSerialization.XmlToObject<T>(_settings.GetValueOrDefault(memberName, string.Empty));
                    }
                    else if (typeof(T) == typeof(Int32))
                    {
                        v = ConvertObjectType<T>(_settings.GetValueOrDefault(memberName, Convert.ToInt32(v)));
                    }
                    else if (typeof(T) == typeof(String))
                    {
                        v = ConvertObjectType<T>(_settings.GetValueOrDefault(memberName, Convert.ToString(v)));
                    }
                    else if (typeof(T) == typeof(Decimal))
                    {
                        v = ConvertObjectType<T>(_settings.GetValueOrDefault(memberName, Convert.ToDecimal(v)));
                    }
                    else if (typeof(T) == typeof(Boolean))
                    {
                        v = ConvertObjectType<T>(_settings.GetValueOrDefault(memberName, Convert.ToBoolean(v)));
                    }
                    else if (typeof(T) == typeof(DateTime))
                    {
                        v = ConvertObjectType<T>(_settings.GetValueOrDefault(memberName, Convert.ToDateTime(v)));
                    }
                    else if (typeof(T) == typeof(Double))
                    {
                        v = ConvertObjectType<T>(_settings.GetValueOrDefault(memberName, Convert.ToDouble(v)));
                    }
                    else if (typeof(T) == typeof(Single))
                    {
                        v = ConvertObjectType<T>(_settings.GetValueOrDefault(memberName, Convert.ToSingle(v)));
                    }
                    else if (typeof(T) == typeof(Guid))
                    {
                        v = ConvertObjectType<T>(_settings.GetValueOrDefault(memberName, Guid.Parse(v.ToString())));
                    }
                    else if (typeof(T) == typeof(Int16))
                    {
                        v = ConvertObjectType<T>(_settings.GetValueOrDefault(memberName, Convert.ToInt16(v)));
                    }
                    else
                    {
                        v = ConvertObjectType<T>(_settings.GetValueOrDefault(memberName, Convert.ToString(v)));
                    }
                }
                else
                {
                    SetValue(v, memberName);
                }
                //SetValue(v, memberName);
            }
            return v;
        }

        public void SetValue<T>(T value, [CallerMemberName] string memberName = "")
        {
            if (!typeof(T).GetTypeInfo().IsPrimitive)
            {
                _settings.AddOrUpdateValue(memberName, XmlSerialization.ObjectToXml(value));
            }
            else if (typeof(T) == typeof(Int32))
            {
                _settings.AddOrUpdateValue(memberName, Convert.ToInt32(value));
            }
            else if (typeof(T) == typeof(String))
            {
                _settings.AddOrUpdateValue(memberName, Convert.ToString(value));
            }
            else if (typeof(T) == typeof(Decimal))
            {
                _settings.AddOrUpdateValue(memberName, Convert.ToDecimal(value));
            }
            else if (typeof(T) == typeof(Boolean))
            {
                _settings.AddOrUpdateValue(memberName, Convert.ToBoolean(value));
            }
            else if (typeof(T) == typeof(DateTime))
            {
                _settings.AddOrUpdateValue(memberName, Convert.ToDateTime(value));
            }
            else if (typeof(T) == typeof(Double))
            {
                _settings.AddOrUpdateValue(memberName, Convert.ToDouble(value));
            }
            else if (typeof(T) == typeof(Single))
            {
                _settings.AddOrUpdateValue(memberName, Convert.ToSingle(value));
            }
            else if (typeof(T) == typeof(Guid))
            {
                _settings.AddOrUpdateValue(memberName, Guid.Parse(value.ToString()));
            }
            else if (typeof(T) == typeof(Int16))
            {
                _settings.AddOrUpdateValue(memberName, Convert.ToInt16(value));
            }
            else
            {
                _settings.AddOrUpdateValue(memberName, Convert.ToString(value));
            }
        }
        private static bool IsNullableType(Type theType)
        {
            return (theType.IsGenericType && theType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
        }
        public static T ConvertObjectType<T>(object obj)
        {
            Type type = typeof(T);
            try
            {
                if (IsNullableType(type))
                {
                    NullableConverter nc = new NullableConverter(type);
                    return (T)Convert.ChangeType(obj, nc.UnderlyingType);
                }
                else
                {
                    return (T)Convert.ChangeType(obj, type);
                }
            }
            catch (Exception ex)
            {
                if (String.IsNullOrEmpty(obj.ToString()))
                    return default(T);
                else
                    throw ex;
            }
        }
    }
}
