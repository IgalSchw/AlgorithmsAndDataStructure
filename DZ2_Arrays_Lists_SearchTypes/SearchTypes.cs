using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataSructure.Lesson2
{
    class SearchTypes
    {

        // Binary search
        // = O(log n + 1 + 1)
        // = O(log n)
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;

                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }


        // Interpolation search
        public static int InterpolationSearch(int[] a, int length, int value)
        {
            int min = 0;
            int max = length - 1;
            while (min <= max)
            {
                // Находим разделяющий элемент
                int mid = min + (max - min) * (value - a[min]) / (a[max] - a[min]);
                if (a[mid] == value)
                    return mid;
                else if (a[mid] < value)
                    min = mid + 1;
                else if (a[mid] > value)
                    max = mid - 1;
            }
            return -1; // Элемент не найден
        }




    }
}
