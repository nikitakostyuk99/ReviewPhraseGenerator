using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReviewSystem
{
    [DataContract]
    class MainTag
    {
        [DataMember]
        ChildEntity[] synonyms = new ChildEntity[0];

        [DataMember]
        public WordInf word;
        public ChildEntity GetSynonym(int index) {
            return synonyms[index];
        }
        public void AddSynonym(ChildEntity synonym) {
            ChildEntity[] arr = new ChildEntity[synonyms.Length+1];
            for (var i = 0; i < synonyms.Length; i++)
                arr[i] = synonyms[i];
            arr[arr.Length - 1] = synonym;
            synonyms = arr;
        }
        public MainTag(WordInf word) {
            this.word = new WordInf(word.Word,word.WordSpeechPart,word.WordGender,word.IsSingleDigit,word.IsPositiveMeaning);
        }
        public int SynonymsCount {
            get { return synonyms.Length; }
        }
    }
}
