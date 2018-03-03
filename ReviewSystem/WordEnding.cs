using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewSystem
{
    class WordEnding
    {
        static char[] firstLettersGroup = new char[] { 'б', 'в', 'д', 'л', 'м', 'н', 'п', 'р', 'т' };
        static char[] secondLettersGroup = new char[] { 'г', 'к'};
        static char[] thirdLettersGroup = new char[] { 'ж', 'ш', 'ч', 'щ'};

        public static string Checker(char lastLetter, char wordGender, string wordSpeechPart) {
            
            if (wordSpeechPart.Equals("сущ")) {
                if (wordGender.Equals('ж')) {
                    return "ая";
                }
                else {
                    foreach(char letter in firstLettersGroup)
                    {
                        if (letter.Equals(lastLetter))
                        {
                            if (wordGender.Equals('м')) return "ый"; else return "ое";
                        }
                    }
                    foreach (char letter in secondLettersGroup)
                    {
                        if (letter.Equals(lastLetter))
                        {
                            if (wordGender.Equals('м')) return "ий"; else return "ое";
                        }
                    }
                    foreach (char letter in thirdLettersGroup)
                    {
                        if (letter.Equals(lastLetter))
                        {
                            if (wordGender.Equals('м')) return "ий"; else return "ее";
                        }
                    }

                    return "";
                }

            }
            else {
                for(var i =2;i<thirdLettersGroup.Length;i++)
                {
                    if (thirdLettersGroup[i].Equals(lastLetter))
                    {
                        return "e";
                    }
                }
                return "о";
            }
        }
        /*bool CheckLettersGroup(char[] letters, char mainLetter)
        {
            foreach (char letter in letters) {
                if (letter.Equals(mainLetter)) {

                }
            }
        }*/
    }
    
    
}
