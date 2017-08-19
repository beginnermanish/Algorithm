using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithems
{
	class Gridland_Metro
	{
		public struct Intervel
		{
			public long start;
			public long end;
		}

		public static List<Intervel> MergeIntervel(List<Intervel> intervels)
		{
			List<Intervel> merged_intervel = new List<Intervel>();

			intervels.Sort(delegate (Intervel x, Intervel y) { return x.start.CompareTo(y.start); });

			merged_intervel.Add(intervels[0]);

			for (int i = 1; i < intervels.Count; i++)
			{
				Intervel top = merged_intervel.Last();

				if (top.end < intervels[i].start)
				{
					merged_intervel.Add(intervels[i]);
				}

				else if (top.end < intervels[i].end)
				{
					top.end = intervels[i].end;
					merged_intervel.RemoveAt(merged_intervel.Count - 1);
					merged_intervel.Add(top);
				}
			}

			return merged_intervel;
		}

		static long GetRouteOccupiedCellCount(List<Intervel> routes)
		{
			long co = 0;
			foreach (Intervel intvl in routes)
			{
				co += (intvl.end - intvl.start) + 1;
			}

			return co;
		}

		public static void Main(string[] args)
		{
			string[] arr_temp = Console.ReadLine().Split(' ');
			int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
			int rows = arr[0], cols = arr[1], trains = arr[2]; long occupiedCells = 0;

			Dictionary<int, List<Intervel>> route_list = new Dictionary<int, List<Intervel>>();

			for (int i = 0; i < trains; i++)
			{
				string[] temp_route_arr = Console.ReadLine().Split(' ');
				int[] route_arr = Array.ConvertAll(temp_route_arr, Int32.Parse);

				int row = route_arr[0];
				if (!route_list.ContainsKey(row))
				{
					route_list.Add(row, new List<Intervel>());
				}

				route_list[row].Add(new Intervel() { start = route_arr[1], end = route_arr[2] });
			}

			foreach (int k in route_list.Keys)
			{
				var merged_route = MergeIntervel(route_list[k]);

				foreach (Intervel i in merged_route)
				{
					//Console.WriteLine(string.Format("row - {0} start - {1}  end - {2}", k, i.start, i.end));
				}
				long diff = GetRouteOccupiedCellCount(merged_route);
				if (diff > cols) Console.WriteLine(diff);
				occupiedCells += diff;

				if(((long)rows * (long)cols) < occupiedCells)
				{
					Console.WriteLine("This is error {0} - {1}", occupiedCells, k);
				}
			}

			long availableCells = ((long)rows * (long)cols) - occupiedCells;
			Console.WriteLine(availableCells);

			Console.ReadLine();
		}
	}
}
