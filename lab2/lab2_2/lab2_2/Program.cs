using System;

namespace lab2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input dividend");
            Int16 dividend = Int16.Parse(Console.ReadLine());
            Console.WriteLine(" Input divisor ");
            Int16 divisor = Int16.Parse(Console.ReadLine());
            Int64 register_result = 0 | dividend;
            int register_remainder = Convert.ToInt32("11111111111111110000000000000000", 2);
            int register_quotient = Convert.ToInt32("1111111111111111", 2);
            Console.WriteLine(" Register : " + ToBinary(register_result, 33));
            for (int i = 0; i < 16; i++)
            {
                register_result <<= 1;
                Console.WriteLine(" Register shifted left : " + ToBinary(register_result, 33));
                if ((register_result >> 32 & 1) == 0)
                {
                    register_result += -divisor << 16;
                    Console.WriteLine(" Register : " + ToBinary(register_result, 33));
                    Console.WriteLine(" \n ");
                }
                else
                {
                    register_result += divisor << 16;
                    Console.WriteLine(" Register : " + ToBinary(register_result, 33));
                    Console.WriteLine(" \n ");
                }
                if ((register_result >> 32 & 1) == 0)
                {
                    register_result |= 1;
                    Console.WriteLine("Set last bit to 1:" + ToBinary(register_result, 33));
                    Console.WriteLine(" \n ");
                }

            }
            if ((register_result >> 32 & 1) == 1)
            {
                register_result += divisor << 16;
                Console.WriteLine(" Register : " + ToBinary(register_result, 33));
                Console.WriteLine(" \n ");
            }
            Console.WriteLine("Remainder in binary:" + ToBinary(register_result & register_remainder, 17, true));
            Console.WriteLine("Quotient in binary :" + ToBinary(register_result & register_quotient, 16));
            Console.WriteLine(" \n ");
            Console.WriteLine(" Remainder in decemal {0}", (register_result & register_remainder) >> 16);
            Console.WriteLine(" Quotient in decemal {0}", register_result & register_quotient);


        }
        static string ToBinary(Int64 register, byte bits_amount, bool is_divisor = false)
        {
            string result = string.Empty;

            int last_index = is_divisor ? 15 : -1;
            for (int i = bits_amount - 1 + (is_divisor ? 16 : 0); i > last_index; --i)
                result += (register >> i & 1) + (i % 4 == 0 && i != 0 ? " " : "");

            return result;
        }

    }
}