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

            TranslateWord(word);

            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }
        
        public static string TranslateWord(string word)
        {
            // your code goes here
            char[] vowel = {'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y'};
            String newWord = "";
            bool startsWithVowel;
            bool startsWithY;
            bool hasAY;
            bool haAVowel;
            int location = 0;

            location = word.IndexOfAny(vowel);
            newWord = word.Substring(location);
            Console.WriteLine("The first vowel is {0} in {1}.",location, word);
            Console.WriteLine(newWord);

            return word;
        }
    }
}
