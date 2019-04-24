using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using weekysoft.store.Attributes;

namespace weekysoft.store.Enums
{
    public static class EnumExt
    {
        //public static string GetCriteriaKey(this Enum enumValue)
        //{
        //    string output = string.Empty;
        //    var type = enumValue.GetType();

        //    //Look for our 'StringValueAttribute' 
        //    //in the field's custom attributes
        //    var fieldInfo = type.GetField(enumValue.ToString());
        //    var attributes =
        //        fieldInfo.GetCustomAttributes(typeof(CriteriaKey),
        //                                false) as CriteriaKey[];
        //    if (attributes != null)
        //    {
        //        if (attributes.Length > 0)
        //        {
        //            output = attributes[0].Key ;
        //        }
        //    }
        //    Debug.Assert(output != string.Empty);
        //    return output;
        //}
        public static string GetKey(this object enumValue)
        {
            string output = string.Empty;
            var type = enumValue.GetType();

            //Look for our 'StringValueAttribute' 
            //in the field's custom attributes

            var fieldInfo = type.GetRuntimeField(enumValue.ToString());
            var attributes =
                fieldInfo.GetCustomAttributes(typeof(EntityKey),
                                        false) as EntityKey[];
            if (attributes != null)
            {
                if (attributes.Length > 0)
                {
                    output = attributes[0].Key;
                }
            }
            return output;
        }
        public static string GetName(this Enum enumValue)
        {
            string output = string.Empty;
            var type = enumValue.GetType();

            //Look for our 'StringValueAttribute' 
            //in the field's custom attributes
            var fieldInfo = type.GetRuntimeField(enumValue.ToString());
            var attributes =
                fieldInfo.GetCustomAttributes(typeof(EntityName),
                                        false) as EntityName[];
            if (attributes != null)
            {
                if (attributes.Length > 0)
                {
                    output = attributes[0].Name;
                }
            }
            return output;
        }
        public static string GetDisplayName(this Enum enumValue)
        {
            string output = string.Empty;
            var type = enumValue.GetType();

            //Look for our 'StringValueAttribute' 
            //in the field's custom attributes
            var fieldInfo = type.GetRuntimeField(enumValue.ToString());
            var attributes =
                fieldInfo.GetCustomAttributes(typeof(DisplayName),
                                        false) as DisplayName[];
            if (attributes != null)
            {
                if (attributes.Length > 0)
                {
                    output = attributes[0].Name;
                }
            }
            return output;
        }
        public static Type GetEntityType(this Enum enumValue)
        {
            Type output = null;
            var type = enumValue.GetType();

            //Look for our 'StringValueAttribute' 
            //in the field's custom attributes
            var fieldInfo = type.GetRuntimeField(enumValue.ToString());
            var attributes =
                fieldInfo.GetCustomAttributes(typeof(EntityType),
                                        false) as EntityType[];
            if (attributes != null)
            {
                if (attributes.Length > 0)
                {
                    output = attributes[0].ObjectType;
                }
            }
            return output;
        }
    }
}
