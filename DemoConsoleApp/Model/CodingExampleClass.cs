using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp.Model
{
    public class CodingExampleClass
    {
        public void ReverseStringWithFunction()
        {
            string strReverse = "abcdef";
            char[] arrReverse = strReverse.ToCharArray();

            Console.WriteLine(strReverse);

            Array.Reverse(arrReverse);

            Console.WriteLine(arrReverse);
        }
        public void ReverseString()
        {
            string strValue = "abcdef";
            string strReverse = "";
            int lenString = strValue.Length - 1;

            while (lenString >= 0)
            {
                strReverse = strReverse + strValue[lenString];
                lenString--;
            }

            Console.WriteLine(strReverse);

        }

        public void PallindromeCheck()
        {
            string strValue = "madam";
            string strReverse = "";
            int lenString = strValue.Length - 1;

            while (lenString >= 0)
            {
                strReverse = strReverse + strValue[lenString];
                lenString--;
            }
            Console.WriteLine(strValue);
            Console.WriteLine(strReverse);

            if (strReverse == strValue)
                Console.WriteLine("It is pallindrome");
            else
                Console.WriteLine("It is not pallindrome");

        }

        public void SubstringCheck()
        {
            string str = "abcd";
            for (int i = 0; i < str.Length; ++i)
            {
                StringBuilder subString = new StringBuilder(str.Length - i);
                for (int j = i; j < str.Length; ++j)
                {
                    subString.Append(str[j]);
                    Console.Write(subString + " ");
                }
            }
        }

        public void IsEven()
        {
            int num = 5;

            if (num % 2 == 0)
                Console.Write("Number is even");
            else
                Console.Write("Number is odd");
        }

        public void IsPrime()
        {
            int num = 4;
            bool flag = true;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    Console.Write("Number is not prime");
                    flag = false;
                }
            }

            if (flag)
                Console.Write("Number is prime");
        }

        public void SampleCheck()
        {
            int d;
            d = Convert.ToInt32(!(30 < 20));
            Console.Write(d);
        }
    }
}
