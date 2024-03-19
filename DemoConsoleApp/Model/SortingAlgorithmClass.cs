using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp.Model
{
    public class SortingAlgorithmClass
    {
        public void SelectionSort()
        {
            int[] arraySort = {40,10,30,20,50};
            var arrayLength = arraySort.Length;

            for (int i = 0; i < arrayLength; i++)
            {
                var smallestVal = i;

                for (int j = i+1;j < arrayLength; j++) 
                {
                    if (arraySort[j] < arraySort[smallestVal])
                    {
                        smallestVal = j;
                    }
                }

                var tempVal = arraySort[smallestVal];
                arraySort[smallestVal] = arraySort[i]; 
                arraySort[i] = tempVal;

                foreach (var item in arraySort)
                {
                    Console.Write(item);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public void BubbleSort()
        {
            int[] arrayBubbleSort = { 73, 57, 49, 99, 133, 20, 1 };
            var n = arrayBubbleSort.Length;

            for (int i = 0;i < n - 1;i++)
            {
                for (int j = 0; j < n -i - 1; j++)
                {
                    if (arrayBubbleSort[j] > arrayBubbleSort[j + 1])
                    {
                        var temp = arrayBubbleSort[j];
                        arrayBubbleSort[j] = arrayBubbleSort[j + 1];
                        arrayBubbleSort[j+1] = temp;
                    }
                }

                foreach (var item in arrayBubbleSort)
                {
                    Console.Write(item);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

        }
    }
}
