using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if VALUE_IS_DOUBLE
	using ValueType = System.Double;
#else
#if VALUE_IS_SHORT
	using ValueType = System.Int16;
#else
#if VALUE_IS_LONG
	using ValueType = System.Int64;
#else
using ValueType = System.Int32;
#endif
#endif
#endif

namespace SortTest
{
    class StudSort
    {
      
        static void Heapify(ValueType[] arr, int heapSize, int heapRoot)
        {
            int max = heapRoot;
            
            int leftChildIndex = 2 * heapRoot + 1; 
            int rightChildIndex = 2 * heapRoot + 2; 

            
            if (leftChildIndex < heapSize && arr[leftChildIndex] > arr[max])
                max = leftChildIndex;

            
            if (rightChildIndex < heapSize && arr[rightChildIndex] > arr[max])
                max = rightChildIndex;

            
            if (max != heapRoot)
            {
                ValueType swap = arr[heapRoot];
                arr[heapRoot] = arr[max];
                arr[max] = swap;

                Heapify(arr, heapSize, max);
            }
        }
        public static ValueType[] Sort(ValueType[] data) // DON'T CHANGE this line!!!
        {
            for (int i = data.Length / 2 - 1; i >= 0; i--)
                Heapify(data, data.Length, i);

            for (int i = data.Length - 1; i >= 0; i--)
            {
                ValueType temp = data[0];
                data[0] = data[i];
                data[i] = temp;
                Heapify(data, i, 0);
            }
            return data;
        }
    }
}
