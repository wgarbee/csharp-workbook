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

            while (word != "QUIT")
            {
                word = TranslateWord(word);

                Console.WriteLine("Your translated word is {0}", word);

                // leave this command at the end so your program does not close automatically
                word = Console.ReadLine();
            }
        }
        
        public static string TranslateWord(string word)
        {
            // your code goes here
            char[] vowel = {'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y'};
            int firstVowelLocation;
            string beforeVowel;
            string vowelAndBeyond;
            string firstVowel;

            firstVowelLocation = word.IndexOfAny(vowel);
            firstVowel = word.Substring(firstVowelLocation,1);
            beforeVowel = word.Substring(0, firstVowelLocation);
            vowelAndBeyond = word.Substring(firstVowelLocation);

            if (firstVowelLocation < 0)
            {
                word = word + "yay";
            }

            return word;
        }
    }
}


