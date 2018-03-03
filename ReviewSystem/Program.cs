using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
namespace ReviewSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            //Dictionary<int, string> dic = File<Dictionary<int, string>>.Load("adjectivesDictionary");
            //List<MainTag> tags = File<MainTag[]>.Load("tags").ToList();


            //File<Dictionary<int,string>>.Save(dic,"adjectivesDictionary");

            //List<MainTag> tags = new List<MainTag>();
            //tags.Add(new MainTag(new WordInf("Графика", "сущ", 'ж', true, true)));
            //tags.Add(new MainTag(new WordInf("Играть", "глаг", '-', false, true)));
            //tags.Add(new MainTag(new WordInf("Геймплей", "сущ", 'м', true, true)));
            //tags.Add(new MainTag(new WordInf("Игра", "сущ", 'ж', true, true)));
            //tags.Add(new MainTag(new WordInf("Оптимизация", "сущ", 'ж', true, true)));

            //tags[0].AddSynonym(new ChildEntity(new WordInf("Стиль", "сущ", 'м', true, true)));
            //tags[0].AddSynonym(new ChildEntity(new WordInf("Графика", "сущ", 'ж', true, true)));
            //tags[0].AddSynonym(new ChildEntity(new WordInf("Интерфейс", "сущ", 'м', true, true)));


            //int[] K = dic.Keys.ToArray();
            //tags[0].GetSynonym(0).AddKey(K);
            //tags[0].GetSynonym(1).AddKey(K[0]);
            //tags[0].GetSynonym(2).AddKey(K[1]);
            //tags[0].GetSynonym(2).AddKey(K[2]);

            //tags[1].AddSynonym(new ChildEntity(new WordInf("Играть", "глаг", '-', false, true)));
            //tags[1].GetSynonym(0).AddKey(K[0]);

            //tags[2].AddSynonym(new ChildEntity(new WordInf("Геймплей", "сущ", 'м', true, true)));
            //tags[2].GetSynonym(0).AddKey(new int[] { K[4], K[5], K[6] });

            //tags[3].AddSynonym(new ChildEntity(new WordInf("Игра", "сущ", 'ж', true, true)));
            //tags[3].GetSynonym(0).AddKey(K);

            //tags[4].AddSynonym(new ChildEntity(new WordInf("Оптимизация", "сущ", 'ж', true, true)));
            //tags[4].GetSynonym(0).AddKey(K[1]);

            /*MainTag tag1 = new MainTag();
            tag.word = new WordInf("Играть", "глаг", '-', false, true);

            tag1.AddSynonym(new ChildEntity(new WordInf("Играть", "глаг", '-', false, true)));
            tag1.GetSynonym(0).AddKey(K[0]);*/

            //Random r = new Random();
            //int q = r.Next(3);//3
            //int m = r.Next(tag.GetSynonym(q).KeysLength);
            //Console.WriteLine(dic[tag.GetSynonym(q).GetKey(m)] +"    "+ dic[tag.GetSynonym(q).GetKey(m)].Last());
            //Console.Write(tag.GetSynonym(q).word.Word +" "+ dic[ tag.GetSynonym(q).GetKey(m)]+ WordEnding.Checker(dic[tag.GetSynonym(q).GetKey(m)].Last(), tag.GetSynonym(q).word.WordGender, tag.GetSynonym(q).word.WordSpeechPart));
            // Console.Write(tag1.GetSynonym(q).word.Word +" "+ dic[ tag1.GetSynonym(q).GetKey(m)]+ WordEnding.Checker(dic[tag1.GetSynonym(q).GetKey(m)].Last(), tag1.GetSynonym(q).word.WordGender, tag1.GetSynonym(q).word.WordSpeechPart));


            //GeneratePhrase(tags[0], dic);
            //Console.Write(", ");
            //tags.RemoveAt(0);
            //GeneratePhrase(tags, dic,true);
            //Console.Write(", а так же ");
            //GeneratePhrase(tags, dic,false);



            //File<MainTag>.Save(tags.ToArray(),"tags");
            // Console.WriteLine("Saving to file is complite");



            bool exit = false;
            Menu.Initialize();
            do {
                Menu.PrintBtns();
                switch (Console.ReadKey().Key) {
                    case ConsoleKey.NumPad0:
                        Console.Write("\n");
                        Menu.AddTag(new MainTag(CreateTag()));
                        break;

                    case ConsoleKey.NumPad3:
                        Console.Write("\n");
                        Menu.ViewTags();
                        break;
                    case ConsoleKey.NumPad4:
                        Console.Write("\n");
                        Menu.Save();
                        break;
                    case ConsoleKey.NumPad5:
                        Console.Write("\n");
                        Menu.Generete();
                        break;
                    case ConsoleKey.NumPad1:
                        Console.Write("\n");
                        ConsoleKey key = Console.ReadKey().Key;
                        Console.Write("\n");

                        Menu.AddSynonym((int)key-2*48,new ChildEntity(CreateTag()));
                        break;

                    case ConsoleKey.NumPad2:
                        Console.Write("\nВведите номер ТЭГА и номер СИНОНИМА");
                        Menu.AddKeys((int)Console.ReadKey().Key - 2*48, (int)Console.ReadKey().Key - 2 * 48);
                        break;
                    default:
                        exit = true;
                        break;
                        
                }

            } while (!exit);






            Console.Read();
        }

        static WordInf CreateTag() {
            Console.WriteLine("Word");
            string word = Console.ReadLine();
            Console.WriteLine("Word Speech part");
            string speech = Console.ReadLine();
            Console.WriteLine("Word gender");
            char gender;
            if (Console.ReadKey().Key == ConsoleKey.V)
            {
                gender = 'м';
            }
            else if (Console.ReadKey().Key == ConsoleKey.C)
            {
                gender = 'с';
            }
            else
                gender = 'ж';

            Console.WriteLine("Is the single digit?");
            bool single;
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                single = true;
            }
            else single = false;
            Console.WriteLine("Is the positive meaning?");
            bool meaning;
            if (Console.ReadKey().Key == ConsoleKey.P)
            {
                meaning = true;
            }
            else meaning = false;


            return new WordInf(word, speech, gender, single, meaning);
        }

        
    }
}
