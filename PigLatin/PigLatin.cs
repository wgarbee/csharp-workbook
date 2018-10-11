using System;
using System.Threading;

namespace PigLatin
{
    class Program
    {
        public static void Main()
        {
            String word = "";

            Console.Clear();
            Thread.Sleep(2000);
            
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Elcomeway otay ethay igpay atinlay anslatortray!");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Please enter a word to translate");
            word = Console.ReadLine();

            while (word.ToUpper() != "QUIT")
            {
                word = TranslateWord(word);

                Console.WriteLine("Your translated word is {0}", word);

                word = Console.ReadLine();
            }
        }
        
        public static string TranslateWord(string word)
        {
            // your code goes here
            char[] vowel = {'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y'};
            int firstVowelLocation;
            string firstVowel;

            firstVowelLocation = word.IndexOfAny(vowel);

            if (firstVowelLocation < 0)
            {
                word = word + "yay";
            }
            else if (firstVowelLocation == 0)
            {
                firstVowel = word.Substring(firstVowelLocation,1);

                if (firstVowel.ToUpper() != "Y")
                {
                    word = word + "yay";
                }
                else
                {
                    word = word.Substring(firstVowelLocation + 1) + word.Substring(firstVowelLocation, 1) + "ay";
                }
            }
            else
            {
                word = word.Substring(firstVowelLocation) + word.Substring(0, firstVowelLocation) + "ay";
            }


            return word;
        }
    }
}


