using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekysoft.store.Serializer
{
    public class BinarySerialization
    {
        /// <summary>
        /// serialize object into byte array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialise"></param>
        /// <returns></returns>
        //public static byte[] ObjectToBinary<T>(T objectToSerialise)
        //{
        //    MemoryStream Output = new MemoryStream();
        //    BinaryFormatter bf = new BinaryFormatter();
        //    bf.Serialize(Output, objectToSerialise);
        //    return Output.ToArray();
        //}

        ///// <summary>
        ///// deserialize byte array to object
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="binary"></param>
        ///// <returns></returns>
        //public static T BinaryToObject<T>(byte[] binary)
        //{
        //    MemoryStream input = new MemoryStream(binary);
        //    BinaryFormatter bf = new BinaryFormatter();
        //    return (T)bf.Deserialize(input);
        //}
    }
}
