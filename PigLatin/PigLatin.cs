using System;
using System.Threading;

namespace PigLatin
{
    class Program
    {
        public static void Main()
        {
            String word = "";
            
            // Clears the screen to begin
            Console.Clear();

            if(tests()){
                Console.WriteLine("Tests passed.");
            } else {
                Console.WriteLine("Tests failed.");
            }
            
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Elcomeway otay ethay igpay atinlay anslatortray!");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Please enter a word to translate. Type 'QUIT' to exit.");
            Thread.Sleep(500);
            word = Console.ReadLine();

            // While the user doesn't enter quit, keeps running and directing the user to enter words
            while (word.ToUpper() != "QUIT")
            {
                // Passes the users entry to the TranslateWord method
                word = TranslateWord(word);

                Console.WriteLine("Your translated word is {0}", word);

                Console.WriteLine("Please enter a word to translate. Type 'QUIT' to exit.");
                word = Console.ReadLine();
            }

            // Runs after the user quits. Displays Goodbye! and then clears the console after 3/4 second
            Console.WriteLine("Goodbye!");
            Thread.Sleep(750);
            Console.Clear();
        }
        
        /*  public static string TranslateWord(string word)
        {
            char[] vowel = {'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y'};
            int firstVowelLocation;
            string firstVowel;

            // Parses the word and locates the first vowel. If one does not exist, returns -1
            firstVowelLocation = word.IndexOfAny(vowel);

            // If the value is -1, meaning now vowels, the add yay to end of the word
            if (firstVowelLocation < 0)
            {
                word += "yay";
            }  // If the vowel is the first letter...
            else if (firstVowelLocation == 0)
            {
                // assigns the vowel to variable
                firstVowel = word.Substring(firstVowelLocation,1);

                // If it's not a Y, run this and check if it is not a 
                // Y and adds yay to the end of the word
                if (firstVowel.ToUpper() != "Y")
                {
                    word += "yay";
                } //else, removes that Y, places at the end of the word as it it treated as a consonant and adds ay
                else
                {
                    word = word.Substring(firstVowelLocation + 1) + word.Substring(firstVowelLocation, 1) + "ay";
                }
            }   // Takes the value from first vowel on, adds everything before the vowel, and adds ay
            else
            {
                word = word.Substring(firstVowelLocation) + word.Substring(0, firstVowelLocation) + "ay";
            }

            return word;
        }   */

        public static string TranslateWord(string word)
        {
            char[] vowel = {'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y'};
            int firstVowelLocation;
            String firstVowel;

            // Parses the word and locates the first vowel. If one does not exist, returns -1
            firstVowelLocation = word.IndexOfAny(vowel);

            // If the value is -1, meaning no vowels, then add yay to end of the word
            if (firstVowelLocation < 0)
            {
                word += "ay";
            }  // If the vowel is the first letter...
            else if (firstVowelLocation == 0)
            {
                // assigns the vowel to variable
                firstVowel = word.Substring(firstVowelLocation,1);

                // If it's not a Y, run this and check if it is not a 
                if (firstVowel.ToUpper() != "Y")
                {
                    word += "yay";
                } 
                else if (firstVowel.ToUpper() == "Y")
                {
                    // If the first letter is a Y, reinitiallize the vowel array without Y char
                    vowel = new char[] {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
                    
                    // Find the first non-Y vowel and store to firstVowelLoaction
                    firstVowelLocation = word.IndexOfAny(vowel);
                    // firstVowel = word.Substring(firstVowelLocation,1);

                    word = word.Substring(firstVowelLocation) + word.Substring(0, firstVowelLocation) + "ay";
                }
            }   // Takes the value from first vowel on, adds everything before the vowel, and adds ay
            else
            {
                word = word.Substring(firstVowelLocation) + word.Substring(0, firstVowelLocation) + "ay";
            }

            return word;
        }

        public static bool tests(){
            return 
                TranslateWord("elephant") == "elephantyay" &&
                TranslateWord("fox") == "oxfay" &&
                TranslateWord("choice") == "oicechay" && 
                TranslateWord("dye") == "yeday" && 
                TranslateWord("bystander") == "ystanderbay" &&
                TranslateWord("yellow") == "ellowyay" &&
                TranslateWord("tsktsk") == "tsktskay";
        }
    }
}