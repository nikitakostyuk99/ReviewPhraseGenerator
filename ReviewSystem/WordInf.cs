using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReviewSystem
{
    [DataContract]
    class WordInf
    {

        [DataMember]
        string word;
        [DataMember]
        string speechPart;
        [DataMember]
        char gender;
        [DataMember]
        bool singleDigit;
        [DataMember]
        bool positiveMeaning;


        public WordInf(string str, string speechPart, char gender, bool isSingleDigit, bool positiveMeaning)
        {
            this.word = str;
            this.speechPart = speechPart;
            this.gender = gender;
            this.singleDigit = isSingleDigit;
            this.positiveMeaning = positiveMeaning;
        }
        public string Word {
            get { return word; }
            set { word = value; }
        }
        public string WordSpeechPart {
            get { return speechPart; }
            set { speechPart = value; }
        }
        public char WordGender {
            get { return gender; }
            set { gender = value; }
        }
        public bool IsSingleDigit {
            get { return singleDigit; }
            set { singleDigit = value; }
        }
        public bool IsPositiveMeaning {
            get { return positiveMeaning; }
            set { positiveMeaning = value; }
        }

    }
}
