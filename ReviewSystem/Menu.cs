using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewSystem
{
    static class Menu
    {
        private static Dictionary<int, string> _callToActionDictionary;
        private static Dictionary<int, string> dic;
        private static List<MainTag> tags;

        public static void Initialize() {
            dic = File<Dictionary<int, string>>.Load("adjectivesDictionary");
            _callToActionDictionary = File<Dictionary<int, string>>.Load("actions");
            tags = File<MainTag[]>.Load("tags").ToList();
        }


        public static void AddTag(MainTag tag) {
            tags.Add(tag);
            tags.Last().AddSynonym(new ChildEntity(tags.Last().word));
        }
        public static void ViewTags() {
            int k = 0;
            foreach (var tag in tags) {
                Console.ForegroundColor = ConsoleColor.DarkGreen; // устанавливаем цвет
                Console.WriteLine(k + ") " + tag.word.Word + "(" + tag.word.WordSpeechPart + ", " + tag.word.WordGender + ", " + (tag.word.IsSingleDigit ? "одиночное" : "множественное") + ", " + (tag.word.IsPositiveMeaning ? "позитивное" : "негативное") + ")");
                Console.ResetColor(); // сбрасываем в стандартный

                for (var i = 0; i < tag.SynonymsCount; i++) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("   " + tag.GetSynonym(i).word.Word);
                    Console.ResetColor();
                    for (var j = 0; j < tag.GetSynonym(i).KeysLength; j++)
                        Console.WriteLine("      " + dic[tag.GetSynonym(i).GetKey(j)]);
                }
                k++;
            }
        }
        public static void AddSynonym(int tagIndex, ChildEntity synonym) {
            tags[tagIndex].AddSynonym(synonym);
        }
        public static void AddKeys(int tagIndex, int synonymIndex) {
            List<int> keys = new List<int>();
            foreach (KeyValuePair<int, string> val in dic) {
                Console.Write("\n"+val.Value+"\t");
                if (Console.ReadKey().Key == ConsoleKey.Y) {
                    keys.Add(val.Key);
                }
            }
            tags[tagIndex].GetSynonym(synonymIndex).AddKey(keys.ToArray());
            Console.WriteLine("\nВсе успешно добавлено");
        }

        public static void Save() {
            File<MainTag>.Save(tags.ToArray(), "tags");
        }

        public static void PrintBtns() {
            Console.WriteLine("0 - AddTag  |  1 - AddSynonym  |  2 - AddKeys  |  3 - ViewTags  |  4 - Save  |  5 - Generate  |  else - Exit");
        }

        public static void Generete()
        {
            StringBuilder mainPhrase = new StringBuilder();
            GeneratePhrase(tags[0], dic,ref mainPhrase);
            mainPhrase.Append("! ");
            //Console.Write("! ");
            tags.RemoveAt(0);
            GeneratePhrase(tags, dic, true,ref mainPhrase);
            mainPhrase.Append(", ");
            //Console.Write(", ");
            GeneratePhrase(tags, dic, false, ref mainPhrase);
            mainPhrase.Append(", ");
            //Console.Write(", ");
            //Console.Write(", а так же ");
            GeneratePhrase(tags.Last(), dic,ref mainPhrase);
            mainPhrase.Append(" ");
            GeneratePhrase(_callToActionDictionary,ref mainPhrase);

            Console.Write(mainPhrase.ToString());
            Console.Write("\n");
        }

        static void GeneratePhrase(List<MainTag> tags, Dictionary<int, string> dic, bool isDirectWordsOrder, ref StringBuilder mainPhrase)
        {

            Random r = new Random((int)DateTime.Now.Ticks);
            int w = r.Next(tags.Count-1);
            int q = r.Next(tags[w].SynonymsCount);//3
            int m = r.Next(tags[w].GetSynonym(q).KeysLength);

            if (isDirectWordsOrder)
                DirectWordsOrderOutput(tags[w], dic, q, m,ref mainPhrase);
            else
                NonDirectWordsOrderOutput(tags[w], dic, q, m, ref mainPhrase);

            tags.RemoveAt(w);
        }
        static void GeneratePhrase(MainTag tag, Dictionary<int, string> dic, ref StringBuilder mainPhrase)
        {

            Random r = new Random((int)DateTime.Now.Ticks);
            int q = r.Next(tag.SynonymsCount);//3
            int m = r.Next(tag.GetSynonym(q).KeysLength);

            NonDirectWordsOrderOutput(tag, dic, q, m, ref mainPhrase);
        }

        static void GeneratePhrase(Dictionary<int, string> dictionary, ref StringBuilder mainPhrase)
        {
            Random r = new Random((int)DateTime.Now.Ticks);
            mainPhrase.Append(dictionary[r.Next(dictionary.Count)]);
        }

        static void NonDirectWordsOrderOutput(MainTag tag, Dictionary<int, string> dic, int q, int m, ref StringBuilder mainPhrase)
        {

            mainPhrase.Append(tag.GetSynonym(q).IsKeysEmpty ? "" : dic[tag.GetSynonym(q).GetKey(m)]);
            mainPhrase.Append(tag.GetSynonym(q).IsKeysEmpty ? "" : WordEnding.Checker(dic[tag.GetSynonym(q).GetKey(m)].Last(), tag.GetSynonym(q).word.WordGender, tag.GetSynonym(q).word.WordSpeechPart));
            mainPhrase.Append(" ");
            mainPhrase.Append(tag.GetSynonym(q).word.Word);
                           
            /*Console.Write((tag.GetSynonym(q).IsKeysEmpty?"": dic[tag.GetSynonym(q).GetKey(m)])
                + (tag.GetSynonym(q).IsKeysEmpty ? "" : WordEnding.Checker(dic[tag.GetSynonym(q).GetKey(m)].Last(), tag.GetSynonym(q).word.WordGender, tag.GetSynonym(q).word.WordSpeechPart) + " ") +
                 tag.GetSynonym(q).word.Word);*/
        }

        static void DirectWordsOrderOutput(MainTag tag, Dictionary<int, string> dic, int q, int m, ref StringBuilder mainPhrase)
        {
            mainPhrase.Append(tag.GetSynonym(q).word.Word);
            mainPhrase.Append(" ");

            mainPhrase.Append(tag.GetSynonym(q).IsKeysEmpty ? "" : dic[tag.GetSynonym(q).GetKey(m)]);
            mainPhrase.Append(tag.GetSynonym(q).IsKeysEmpty ? "" : WordEnding.Checker(dic[tag.GetSynonym(q).GetKey(m)].Last(), tag.GetSynonym(q).word.WordGender, tag.GetSynonym(q).word.WordSpeechPart));
           /* Console.Write(tag.GetSynonym(q).word.Word + " " + (tag.GetSynonym(q).IsKeysEmpty ? "" : dic[tag.GetSynonym(q).GetKey(m)])
                + (tag.GetSynonym(q).IsKeysEmpty ? "" : WordEnding.Checker(dic[tag.GetSynonym(q).GetKey(m)].Last(), tag.GetSynonym(q).word.WordGender, tag.GetSynonym(q).word.WordSpeechPart)));
        */}

    }
}
