using DemoConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DemoConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CodingExampleClass objClass = new CodingExampleClass();
            //objClass.SampleCheck();

            int i = 10;
            double d = 34.340;
            fun(i);
            fun(d);

            Console.ReadLine();
        }
        static void fun(double d)
        {
            Console.WriteLine(d + " ");
        }
        public static void FindGreaterNumber()
        {
            int a = 155;
            int b = 45;
            int c = 87;

            Console.WriteLine((a > b) ? (a > c ? a : c) : (b > c ? b : c));
            Console.ReadLine();
        }
        public static void NewMethod()
        {
            while (true)
            {
                Console.WriteLine("Input Value");
                int i = Convert.ToInt16(Console.ReadLine());
                SwitchCaseforMonths(i);
            }
            Console.ReadLine();
        }

        public static void SwitchCaseforMonths(int monthValue)
        {
            switch(monthValue)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    Console.WriteLine("31 days");
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    Console.WriteLine("30 days");
                    break;
                case 2:
                    Console.WriteLine("28/29 days");
                    break;
            }
        }

        public static void AsyncMethod()
        {
            Console.WriteLine("Async execution started");
            CallMethod();
            Method2();
            Console.WriteLine("Main method end reached");
            Console.ReadLine();
        }
        public static async void CallMethod()
        {
            var count = await Method1();
        }
        public static async Task<int> Method1()
        {
            int cnt = 0;

            await Task.Run(() =>
            {
                for (int i = 0; i < 200000; i++)
                {
                    if (i == 10000)
                    {
                        Console.WriteLine($"Async execution end and value of i is {i}");
                    }
                    cnt += 1;
                }
            });

            return cnt;
        }

        public static void Method2()
        {
            Console.WriteLine("Method 2 reached");

        }
    }


}
