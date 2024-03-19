using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp.Model
{
    public class DataStructureClass
    {
        public void ArrayMethod()
        {
            string[] strArray = { "apple", "orange", "banana", "watermellon", "grapes" };

            Console.WriteLine($"Length of array is {strArray.Length} ");
            foreach (string str in strArray)
            {
                Console.WriteLine(str);
            }

            strArray[0] = null;

            foreach (string str in strArray)
            {
                Console.WriteLine(str);
            }

        }

        public void ArrayList()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Insert(0, 1);
            arrayList.Insert(1, 2);
            arrayList.Insert(2, 3);
            arrayList.Insert(3, 4);

            foreach (int val in arrayList)
            {
                Console.WriteLine(val);
            }

            arrayList.RemoveAt(0);
            arrayList.Insert(3, 5);


            foreach (int val in arrayList)
            {
                Console.WriteLine(val);
            }

        }

        public void LinearSearch()
        {
            int[] arrNumbers = { 1, 2, 3, 4, 5 };
            int result = 4;

            for(int i = 0; i <arrNumbers.Length; i++)
            {
                if (arrNumbers[i] == result)
                {
                    Console.WriteLine($"Result match was found at index {i}");
                }
            }

        }

        public void BinarySearch()
        {
            int[] arrNumbers = { 1, 2, 3, 4, 5 };
            int result = 4;
            int start = 0;
            int end = arrNumbers.Length;
            int middle = 0;

            while (start <= end)
            {
                middle = (start + end) / 2;

                if (arrNumbers[middle] == result)
                {
                    Console.WriteLine($"Result match was found at index {middle}");
                    return;
                }
                else if (arrNumbers[middle] < result)
                {
                    start = middle + 1;
                }
                else 
                {
                    end = middle - 1;
                }
            }

            Console.WriteLine("Result not found in array");
        }
    }
}
