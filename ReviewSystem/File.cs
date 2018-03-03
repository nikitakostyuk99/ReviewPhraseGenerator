using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

namespace ReviewSystem
{
    static class File<T>
    {
        public static void Save(T[] tags,string filePath)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(T[]));
            using (FileStream fs = new FileStream(filePath+".json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, tags);
            }
        }

        /*public static void Save()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(MainTag[]));
            using (FileStream fs = new FileStream("tags.json", FileMode.OpenOrCreate))
            {
                MainTag[] tags = (MainTag[])jsonFormatter.ReadObject(fs);
            }

        }*/

        public static void Save(T tag, string filePath)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(T));
            using (FileStream fs = new FileStream(filePath+".json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, tag);
            }
        }

        public static T Load(string filePath)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(T));
            using (FileStream fs = new FileStream(filePath+".json", FileMode.OpenOrCreate))
            {
                return (T)jsonFormatter.ReadObject(fs);
            }
        }

    }
}
