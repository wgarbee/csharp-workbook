using System;

namespace PigLatin
{
    class Program
    {
        public static void Main()
        {
            // run tests and print out if tests passed or not
            if(tests()){
                Console.WriteLine("Tests passed.");
            } else {
                Console.WriteLine("Tests failed.");
            }

            //your code to get user input and call TranslateWord method here

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

        /**
            This method tests some examples against the 5 following rules,
            and returns true if all tests pass, otherwise returns false.

            rule 1: if it starts with a vowel add "yay" to the end
            rule 2: move all letter before the first vowel to the end, then add "ay" to the end
            rule 3: if it starts with a "y", treat the "y" as a consonant
            rule 4: if it does not start with a "y", treat the "y" as a vowel
            rule 5: if there are no vowels, add "ay" to the end (this is the same as rule 2) 
         */
        public static bool tests(){
            return 
                // TranslateWord("elephant") == "elephantyay" &&
                // TranslateWord("fox") == "oxfay" &&
                // TranslateWord("choice") == "oicechay" && 
                // TranslateWord("dye") == "yeday" && 
                // TranslateWord("bystander") == "ystanderbay" &&
                // TranslateWord("yellow") == "ellowyay" &&
                TranslateWord("tsktsk") == "tsktskay";
        }

    }
}
