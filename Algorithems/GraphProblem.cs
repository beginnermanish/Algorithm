using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithems
{
	class GraphProblem
	{
		public static class Graph
		{
			public static List<int> visited { get; set; }
			public static Dictionary<int, List<int>> AdjancyMatrics { get; set; }
			public static List<int> Cities { get; set; }



			public static void AddEdge(int v, int e)
			{
				//If V is not added as vertex then add in adjacency metrics
				if (!AdjancyMatrics.ContainsKey(v))
				{
					List<int> edges = new List<int>();
					AdjancyMatrics.Add(v, edges);
				}
				//If e is not added as vertex then add in adjacency metrics
				if (!AdjancyMatrics.ContainsKey(e))
				{
					List<int> edges = new List<int>();
					AdjancyMatrics.Add(e, edges);
				}

				AdjancyMatrics[v].Add(e);
				AdjancyMatrics[e].Add(v);

				//if (Cities.IndexOf(v) == -1) Cities.Add(v);
			}

			public static void DFSUtil(int vertex)
			{
				//connected.Add(vertex);
				visited.Add(vertex);

				if (AdjancyMatrics.ContainsKey(vertex))
				{
					int[] edges = AdjancyMatrics[vertex].ToArray();
					for (int i= 0; i < edges.Length; i++)
					{
						if (visited.IndexOf(edges[i]) == -1)
						{
							DFSUtil(edges[i]);
						}
					}
				}
				//return connected;
			}

			public static int GetConnectedComponent(int noOfNodes)
			{
				int componentCount = 0;
				for (int i = 1; i <= noOfNodes; i++)
				{
					if (visited.IndexOf(i) == -1)
					{
						//List<int> connected = new List<int>();
						DFSUtil(i);
						componentCount++;
					}
				}
				return componentCount;
			}

		}



		static void Main(String[] args)
		{
			int q = Convert.ToInt32(Console.ReadLine());
			List<long> outputs = new List<long>();

			for (int a0 = 0; a0 < q; a0++)
			{
				long totalCost = 0;

				string[] tokens_n = Console.ReadLine().Split(' ');
				int noOfCities = Convert.ToInt32(tokens_n[0]);
				int noOfRoads = Convert.ToInt32(tokens_n[1]);
				long costOfLib = Convert.ToInt64(tokens_n[2]);
				long costOfRoad = Convert.ToInt64(tokens_n[3]);

				//Initalize items
				Graph.visited = new List<int>();
				Graph.AdjancyMatrics = new Dictionary<int, List<int>>();


				for (int a1 = 0; a1 < noOfRoads; a1++)
				{
					string[] tokens_city_1 = Console.ReadLine().Split(' ');
					int city_1 = Convert.ToInt32(tokens_city_1[0]);
					int city_2 = Convert.ToInt32(tokens_city_1[1]);
					if(costOfRoad < costOfLib)
					{
						Graph.AddEdge(city_1, city_2);
					}
				}

				if (costOfRoad > costOfLib)
				{
					totalCost = noOfCities * costOfLib;
				}
				else
				{
					int componentcount = Graph.GetConnectedComponent(noOfCities);
					totalCost = (costOfRoad * (noOfCities - componentcount) + costOfLib * componentcount);
				}
				outputs.Add(totalCost);

			}
			foreach (long e in outputs)
			{
				Console.WriteLine(e);
			}
			Console.ReadLine();
		}
	}
}
