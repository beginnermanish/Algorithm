using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithems
{
	class Program
	{
		static void Main(string[] args)
		{
			//string array = Console.ReadLine();
			int[] inputArrray = { 10, 80, 30, 90, 40, 50, 70 };
			 
			int n = inputArrray.Length;

			QuickSort ob = new QuickSort();
			ob.qSort(inputArrray, 0, n - 1);

			Console.Write(string.Join(",", inputArrray.Select(item => item.ToString())).ToArray());
			Console.ReadLine();
			//QuickSort(inputArrray, 0, inputArrray.Length - 1);
		}

		static void QuickSort(int[] arr, int low, int high)
		{
			if (low < high)
			{
				int pivotIdx = Partition(arr, low, high);

				QuickSort(arr, low, pivotIdx - 1);
				QuickSort(arr, pivotIdx + 1, high);
			}
			Console.Write(string.Join("," ,arr.Select(item => item.ToString())).ToArray());
			Console.ReadLine();
		}

		static int Partition(int[] arr, int low, int high)
		{
			int pivot = arr[high];

			int i = low - 1;

			for (int j = low; j <= high - 1; j++)
			{

				if (arr[j] <= pivot)
				{
					i++;
					Swap(arr, i, j);
				}
			}

			Swap(arr, i + 1, high);
			return i + 1;
		}

		static int[] Swap(int[] arr, int sTo, int sWith)
		{
			int t = arr[sTo];
			arr[sTo] = arr[sWith];
			arr[sWith] = t;
			return arr;
		}
	}

}
