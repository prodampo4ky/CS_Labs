using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace lab1._2

{
    class Program
    {
        static void Main(string[] args)
        {

            bool err = true;
            var str = "";
            try
            {
                do
                {
                    string path = Input();
                    if (File.Exists(path))
                    {
                        str = File.ReadAllText(path);
                        byte[] data = Encoding.Default.GetBytes(str);
                        char[] value = Base64Encoding(data);
                        Output(str, value);
                        err = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Something went wrong, try again");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("------------------------------------------------------");
                    }
                } while (err == true);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        public static void Output(string str, char[] value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nEncrypted file text: ");
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Not yet encrypted file length: ");
            Console.WriteLine(str.Length);
            Console.Write("\nEncrypted file length: ");
            Console.WriteLine(value.Length);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------------------------------");

        }

        public static string Input()
        {
            string nameF;
            string path = @"C:\Users\artem\Desktop\CompSys\lab1\";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Введите название файла: ");
            nameF = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------------------------------");
            path += nameF + ".txt";

            return path;
        }

        private static char SixBitToChar(byte b)
        {
            char[] lookupTable = new char[64] {
            'A','B','C','D','E','F','G','H','I','J','K','L','M',
            'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m',
            'n','o','p','q','r','s','t','u','v','w','x','y','z',
            '0','1','2','3','4','5','6','7','8','9','+','/'
            };
            if ((b >= 0) && (b <= 63)) return lookupTable[(int)b];
            else return ' ';
        }

        public static char[] Base64Encoding(byte[] data)
        {
            int length = data.Length;
            int length2, blockCount, paddingCount;

            if ((length % 3) == 0)
            {
                paddingCount = 0;
                blockCount = length / 3;
            }
            else
            {
                paddingCount = 3 - (length % 3);
                blockCount = (length + paddingCount) / 3;
            }

            length2 = length + paddingCount;
            byte[] source2 = new byte[length2];

            for (int x = 0; x < length2; x++)
            {
                if (x < length) source2[x] = data[x];
                else source2[x] = 0;
            }

            byte b1, b2, b3;
            byte t, t1, t2, t3, t4;
            byte[] temp = new byte[blockCount * 4];
            char[] result = new char[blockCount * 4];

            for (int x = 0; x < blockCount; x++)
            {
                b1 = source2[x * 3];
                b2 = source2[x * 3 + 1];
                b3 = source2[x * 3 + 2];

                t = (byte)((b1 & 3) << 4);
                t1 = (byte)((b1 & 252) >> 2);
                t2 = (byte)((b2 & 240) >> 4);
                t2 += t;

                t = (byte)((b2 & 15) << 2);
                t3 = (byte)((b3 & 192) >> 6);
                t3 += t;
                t4 = (byte)(b3 & 63);

                temp[x * 4] = t1;
                temp[x * 4 + 1] = t2;
                temp[x * 4 + 2] = t3;
                temp[x * 4 + 3] = t4;
            }

            for (int x = 0; x < blockCount * 4; x++)
            {
                result[x] = SixBitToChar(temp[x]);
            }

            switch (paddingCount)
            {
                case 0:
                    break;
                case 1:
                    result[blockCount * 4 - 1] = '=';
                    break;
                case 2:
                    result[blockCount * 4 - 1] = '=';
                    result[blockCount * 4 - 2] = '=';
                    break;
            }
            return result;
        }

    }
}