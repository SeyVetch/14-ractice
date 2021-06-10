using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void bytesWrite(byte[] bytes)
        {
            string s;
            for (int i = 0; i < bytes.Length; i++)
            {
                s = Convert.ToString(bytes[i], toBase: 2);
                int l = 8 - s.Length;
                for (int j = 0; j < l; j++)
                {
                    s = "0" + s;
                }
                Console.Write(s + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < bytes.Length; i++)
            {
                Console.Write(bytes[i] + " ");
            }
            Console.WriteLine();
        }
        static public void prog2()
        {
            unsafe
            {
                Console.WriteLine("Прога 2");
                int n;
                byte* b = (byte*)&n;
                byte[] bytes = { (byte)1, (int)'A', (int)'A', 1};
                for (int i = 0; i < bytes.Length; i++)
                {
                    *(b + i) = bytes[i];
                }
                byte[] bytesN = BitConverter.GetBytes(n);
                Console.WriteLine("значение n");
                bytesWrite(bytesN);
            }
        }
        static public void prog3()
        {
            unsafe
            {
                Console.WriteLine("Прога 3");
                double d;
                byte* b = (byte*)&d;
                byte[] bytes = { (byte)1, (int)'A', (int)'A', 2, 2, 2, 2, 3 };
                for (int i = 0; i < bytes.Length; i++)
                {
                    *(b + i) = bytes[i];
                };
                byte[] bytesD = BitConverter.GetBytes(d);
                Console.WriteLine("значение d");
                bytesWrite(bytesD);
            }
        }
        static public void prog4()
        {
            unsafe
            {
                Console.WriteLine("Прога 4");
                Random rnd = new Random();
                int n1 = rnd.Next();
                int n2 = rnd.Next();
                int n3 = 0;
                byte[] bytesN1 = BitConverter.GetBytes(n1);
                Console.WriteLine("значение n1");
                bytesWrite(bytesN1);
                byte[] bytesN2 = BitConverter.GetBytes(n2);
                Console.WriteLine("значение n2");
                bytesWrite(bytesN2);
                byte[] bytesN3 = BitConverter.GetBytes(n3);
                Console.WriteLine("значение n3");
                bytesWrite(bytesN3);
                byte* b1 = (byte*)&n1;
                byte* b2 = (byte*)&n2;
                byte* b3 = (byte*)&n3;
                byte[] bytes = { *b1, *(b1+1), *(b2+2), *(b2+3) };
                for (int i = 0; i < bytes.Length; i++)
                {
                    *(b3 + i) = bytes[i];
                };
                bytesN3 = BitConverter.GetBytes(n3);
                Console.WriteLine("значение n3");
                bytesWrite(bytesN3);
            }
        }
        static public void prog5()
        {
            unsafe
            {
                Console.WriteLine("Прога 5");
                Random rnd = new Random();
                int n = rnd.Next();
                byte[] bytesN = BitConverter.GetBytes(n);
                byte* b = (byte*)&n;
                Console.WriteLine("значение n");
                bytesWrite(bytesN);
                for (int i = 0; i < 4; i++)
                {
                    *(b + i) <<= 4;
                }
                bytesN = BitConverter.GetBytes(n);
                Console.WriteLine("значение n");
                bytesWrite(bytesN);
            }
        }


        class prog6
        {
            public int x;
            public char s;
        }

        class prog7
        {
            public int x;
        }
        static void prog8()
        {
            unsafe
            {
                int[] n = new int[2];
                fixed (void* p = &n[0])
                {
                    byte* b = (byte*)p;
                    byte[] bytes = { 1, 2, 3, 4 };
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        *(b + i) = bytes[i];
                    }
                }
                fixed (void* p = &n[1])
                {
                    byte* b = (byte*)p;
                    byte[] bytes = { 5, 6, 7, 8 };
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        *(b + i) = bytes[i];
                    }
                }
                byte[] bytesN = BitConverter.GetBytes(n[0]);
                Console.WriteLine("значение n[0]");
                bytesWrite(bytesN);
                bytesN = BitConverter.GetBytes(n[1]);
                Console.WriteLine("значение n[1]");
                bytesWrite(bytesN);
            }
        }
        static void prog9()
        {
            unsafe
            {
                double d;
                byte* b = (byte*)&d;
                int[] values = { 1, 3, 5, 7, 2, 4, 6, 8 };
                byte*[] p = new byte*[8];
                for (int i = 0; i < 8; i++)
                {
                    p[i] = b + values[i] - 1;
                }
                for (int i = 0; i < 8; i++)
                {
                    *p[i] = (byte)values[i];
                }
                byte[] bytesD = BitConverter.GetBytes(d);
                Console.WriteLine("значение d");
                bytesWrite(bytesD);
            }
        }
        static void prog10()
        {
            unsafe
            {
                string s = "abcdefg12345678";
                string s1 = s;
                fixed (char* p = s)
                {
                    fixed (char* p1 = s1)
                    {
                        for (int k = 0; p[k] != '\0'; k++)
                        {
                            p[k] = p1[s.Length - k - 1];
                        }
                    }
                }
                Console.WriteLine(s1 + " " + s);
            }
        }
        static void prog11()
        {
            unsafe
            {
                Console.WriteLine("Прога 2");
                int n;
                char* c = (char*)&n;
                *c = 'A';
                *(c + 1) = 'B';
                byte[] bytesN = BitConverter.GetBytes(n);
                Console.WriteLine("значение n");
                bytesWrite(bytesN);
            }
        }

        static void Main(string[] args)
        {
            unsafe
            {
                prog2();
                prog3();
                prog4();
                prog5();
                prog6 p6 = new prog6();
                fixed (void* p = &p6.x)
                {
                    int* px = (int*)p;
                    *px = 5;
                }
                fixed (void* p = &p6.s)
                {
                    char* ps = (char*)p;
                    *ps = 'a';
                }
                prog7 p7 = new prog7();
                fixed (void* p = &p6.x)
                {
                    byte* b = (byte*)p;
                    byte[] bytes = { (int)'A', (int)'A', (int)'B', (int)'B' };
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        *(b + i) = bytes[i];
                    }
                }
                prog8();
                prog9();
                prog10();
                prog11();
                Console.ReadKey();
            }
        }
    }
}
