using System;

namespace week8_practice11
{
    class Program
    {
        static void Main(string[] args)
        {
            String primaryCombined = "";
            
            primaryCombined = CombinePrimaryColors(PrimaryColors.RED, PrimaryColors.BLUE);
            Console.WriteLine($"{ PrimaryColors.RED } and { PrimaryColors.BLUE } is { primaryCombined }");

            primaryCombined = CombinePrimaryColors(PrimaryColors.YELLOW, PrimaryColors.RED);
            Console.WriteLine($"{ PrimaryColors.YELLOW } and { PrimaryColors.RED } is { primaryCombined }");

            primaryCombined = CombinePrimaryColors(PrimaryColors.BLUE, PrimaryColors.YELLOW);
            Console.WriteLine($"{ PrimaryColors.BLUE } and { PrimaryColors.YELLOW } is { primaryCombined }");
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
                if (color2 == PrimaryColors.BLUE)
                {
                    return "GREEN";
                }
                else if (color2 == PrimaryColors.RED)
                {
                    return "ORANGE";
                }
                else
                {
                    return "YELLOW";
                }
            }
            else if (color1 == PrimaryColors.BLUE)
            {
                if (color2 == PrimaryColors.RED)
                {
                    return "PURPLE";
                }
                else if (color2 == PrimaryColors.YELLOW)
                {
                    return "GREEN";
                }
                else
                {
                    return "BLUE";
                }
            }

            return null;
        }
    }

    enum PrimaryColors
    {
        RED, BLUE, YELLOW
    }
}
