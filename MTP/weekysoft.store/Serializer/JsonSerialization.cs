using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace weekysoft.store.Serializer
{
    public class JsonSerialization
    {
        public static string ObjectToJson<T>(T objectToSerialise)
        {
            MemoryStream st = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            ser.WriteObject(st, objectToSerialise);
            byte[] json = st.ToArray();
            st.Dispose();
            return Encoding.UTF8.GetString(json, 0, json.Length);
        }

        /// <summary>
        /// deserialize xml string to object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string json)
        {
            if (!String.IsNullOrEmpty(json))
            {
                json = RemoveInvalidCharacters(json);
                MemoryStream st = new MemoryStream(Encoding.UTF8.GetBytes(json));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                var deserialized = (T)ser.ReadObject(st);
                st.Dispose();
                return deserialized;

            }
            else
            {
                return default(T);
            }
        }

        private static string RemoveInvalidCharacters(string json)
        {
            return json.Replace("\0","").Replace("\f","").Replace("\v", "").Replace("\a", "");
        }
    }
}
