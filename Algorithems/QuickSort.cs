using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithems
{
	// Java program for implementation of QuickSort
	class QuickSort
	{
		/* This function takes last element as pivot,
		   places the pivot element at its correct
		   position in sorted array, and places all
		   smaller (smaller than pivot) to left of
		   pivot and all greater elements to right
		   of pivot */
		int partition(int[] arr, int low, int high)
		{
			Random rand = new Random();
			int p = rand.Next(low, high);

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

		int[] Swap(int[] arr, int sTo, int sWith)
		{
			int t = arr[sTo];
			arr[sTo] = arr[sWith];
			arr[sWith] = t;
			return arr;
		}

		/* The main function that implements QuickSort()
		  arr[] --> Array to be sorted,
		  low  --> Starting index,
		  high  --> Ending index */
		public void sort(int[] arr, int low, int high)
		{
			if (low < high)
			{
				/* pi is partitioning index, arr[pi] is 
				  now at right place */
				int pi = partition(arr, low, high);

				// Recursively sort elements before
				// partition and after partition
				sort(arr, low, pi - 1);
				sort(arr, pi + 1, high);
			}
		}

		public void qSort(int[] a, int fromInclusive, int toInclusive)
		{
			int i = fromInclusive;
			int j = toInclusive;
			if (i >= j) return;

			Random rand = new Random();
			int p = rand.Next(i, j);
			int separator = a[p];
			do
			{
				while (a[i] < separator) ++i;
				while (a[j] > separator) --j;
				if (i > j) break;
				int t = a[i];
				a[i] = a[j];
				a[j] = t;
				++i;
				--j;
			} while (i <= j);
			qSort(a, fromInclusive, j);
			qSort(a, i, toInclusive);
		}
	}
}
