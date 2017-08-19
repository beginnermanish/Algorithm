using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithems
{
	class Icecream_parlor
	{
		public class Trip
		{
			public int Money;
			public int NoOfProducts;
			public int[] Prices;
		}

		public static void GetProducts(Trip trip)
		{
			int[] tempItems = (int[])trip.Prices.Clone();
			int[] sorted = tempItems.OrderBy(delegate (int x) { return x; }).ToArray();

			Dictionary<int, int> map = new Dictionary<int, int>();
			map.Add(trip.Prices[0], 1);

			for (int i = 1; i < trip.Prices.Length; i++)
			{
				if (!map.ContainsKey(trip.Money - trip.Prices[i]))
				{
					if (!map.ContainsKey(trip.Prices[i])) map.Add(trip.Prices[i], i + 1);
				}
				else
				{
					int minIdx = map[trip.Money - trip.Prices[i]];
					Console.WriteLine(minIdx + " " + (i + 1));
					break;
				}
			}
		}

		public static void Main(string[] args)
		{
			int noOfTrips = Int32.Parse(Console.ReadLine());
			List<Trip> trips = new List<Trip>();

			for (int i = 0; i < noOfTrips; i++)
			{
				int money = Int32.Parse(Console.ReadLine());
				int prodCount = Int32.Parse(Console.ReadLine());
				string[] temp = Console.ReadLine().Split(' ');
				int[] prices = Array.ConvertAll(temp, Int32.Parse);
				trips.Add(new Trip() { Money = money, NoOfProducts = prodCount, Prices = prices });
			}

			foreach (Trip trip in trips)
			{
				GetProducts(trip);
			}

			Console.Read();
		}
	}
}
