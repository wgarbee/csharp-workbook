using System;

namespace week8_practice11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi");
            String junk = CombineColors("Fuschia", "Tangerine");
            String primaryCombined = CombinePrimaryColors(PrimaryColors.RED, PrimaryColors.BLUE);
            Console.WriteLine(primaryCombined);
        }

        static String CombineColors(String color1, String color2)
        {
            if (color1 == "RED")
            {
                if (color2 == "YELLOW")
                {
                    return "ORANGE";
                }
                else if (color2 == "BLUE")
                {
                    return "PURPLE";
                }
                else
                {
                    return "RED";
                }
            }
            return null;
        }

        public static String CombinePrimaryColors(PrimaryColors color1, PrimaryColors color2)
        {
            if (color1 == PrimaryColors.RED)
            {
                if (color2 == PrimaryColors.BLUE)
                {
                    return "PURPLE";
                }
                else if (color2 == PrimaryColors.YELLOW)
                {
                    return "ORANGE";
                }
                else
                {
                    return "RED";
                }
            }
            else if (color1 == PrimaryColors.YELLOW)
            {
                // all checks
            }
            else if (color1 == PrimaryColors.BLUE)
            {
                // all checks
            }

            return null;
        }
    }

    enum PrimaryColors
    {
        RED, BLUE, YELLOW
    }
}
