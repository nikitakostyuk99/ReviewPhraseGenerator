using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReviewSystem
{
    [DataContract]
    class ChildEntity
    {
        [DataMember]
        int[] keys = new int[0];
        [DataMember]
        public WordInf word;

        public int GetKey(int index)
        {
            return keys[index];
        }

        public void AddKey(int key) {
            int[] arr = new int[keys.Length + 1];
            for (var i = 0; i < keys.Length; i++)
                arr[i] = keys[i];
            arr[arr.Length - 1] = key;
            keys = arr;
        }

        public void AddKey(int[] keyGroup)
        {
            int[] arr = new int[keys.Length + keyGroup.Length];
            for (var i = 0; i < keys.Length; i++)
                arr[i] = keys[i];
            for (var i = keys.Length; i< arr.Length; i++) {
                arr[i] = keyGroup[i - keys.Length];
            }
            keys = arr;
        }

        public ChildEntity(WordInf word) {
            this.word = word;
        }

        public int KeysLength {
            get { return keys.Length; }
        }

        public bool IsKeysEmpty {
            get { return (keys.Length == 0 ? true : false); }
        }
    }
}
