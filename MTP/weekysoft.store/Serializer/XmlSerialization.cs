using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace weekysoft.store.Serializer
{
    public class XmlSerialization
    {
        public static string ObjectToXml<T>(T objectToSerialise)
        {
            StringWriter Output = new StringWriter(new StringBuilder());
            XmlSerializer xs = new XmlSerializer(objectToSerialise.GetType());
            xs.Serialize(Output, objectToSerialise);

            return Output.ToString();
        }

        /// <summary>
        /// deserialize xml string to object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T XmlToObject<T>(string xml)
        {
            if (!String.IsNullOrEmpty(xml))
            {
                TextReader input = new StringReader(RemoveInvalidCharacters(xml));
                XmlSerializer xs = new XmlSerializer(typeof(T));
                return (T)xs.Deserialize(input);
            }
            else
            {
                return default(T);
            }
        }
        private static string RemoveInvalidCharacters(string json)
        {
            return json.Replace("\0", "").Replace("\f", "").Replace("\v", "").Replace("\a", "");
        }

    }
}
