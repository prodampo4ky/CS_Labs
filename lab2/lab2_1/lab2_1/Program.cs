using System;

namespace lab2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool minus = false;
            Console.WriteLine("Input multiplicand");
            int multiplicand = Int32.Parse(Console.ReadLine());
            Console.WriteLine(" Input multiplier ");
            int multiplier = Int32.Parse(Console.ReadLine());
            if (multiplier < 0)
            {
                minus = true;
                multiplier = Math.Abs(multiplier);
            }
            Int32 result = 0;
            for (int i = 0; i < 16; i++)
            {
                int register_multiplier_least = multiplier & 1;
                if (register_multiplier_least == 1)
                {
                    result += multiplicand;
                    Console.WriteLine(" Register result : " + ToBinary(result));
                    Console.WriteLine(" Register multiplicand : " + ToBinary(multiplicand));
                    Console.WriteLine(" Register multiplier : " + ToBinary(multiplier));
                    Console.WriteLine("\n");
                }
                if (register_multiplier_least == 0)
                {
                    Console.WriteLine(" Register multiplicand : " + ToBinary(multiplicand));
                    Console.WriteLine(" Register multiplier : " + ToBinary(multiplier));
                    Console.WriteLine("\n");
                }
                multiplicand <<= 1;
                Console.WriteLine(" Register multiplicand sheft left : " + ToBinary(multiplicand));
                multiplier >>= 1;
                Console.WriteLine(" Register multiplier sheft right : " + ToBinary(multiplier));
                Console.WriteLine("\n");
            }
            if (minus == true)
            {
                result = ~result + 1;
            }
            Console.WriteLine(" Result in binary = " + ToBinary(result));
            Console.WriteLine(" Result in decemal = " + result);

        }
        public static string ToBinary(Int32 number)
        {
            string binary = string.Empty;
            for (int i = 1; i < 33; ++i)
            {
                binary = (i % 4 == 0 ? " " : "") + (number & 1) + binary;
                number >>= 1;
            }
            return binary;
        }
    }
}
