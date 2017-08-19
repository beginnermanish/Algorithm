using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithems
{
	class KnightBFS
	{
		public class Cell
		{
			public int X { get; set; }
			public int Y { get; set; }
			public int Step { get; set; }
			public Cell(int x, int y, int step)
			{
				X = x;
				Y = y;
				Step = step;
			}
		}

		public static List<Cell> GetNeighbourCell(Cell cell, int a, int b, int n, List<Cell> visited)
		{
			List<Cell> neighbours = new List<Cell>();

			int step = ++cell.Step;

			Cell[] cells = new Cell[] {
				new Cell((cell.X + a), (cell.Y + b), step),
				new Cell((cell.X - a), (cell.Y + b), step),
				new Cell((cell.X + a), (cell.Y - b), step),
				new Cell((cell.X + b), (cell.Y + a), step),
				new Cell((cell.X - b), (cell.Y + a), step),
				new Cell((cell.X + b), (cell.Y - a), step),
				new Cell((cell.X - a), (cell.Y - b), step),
				new Cell((cell.X - b), (cell.Y - a), step),
			};

			for (int i = 0; i < cells.Length; i++)
			{
				Cell cel = cells[i];
				if (cel.X < n && cel.Y < n &&
					cel.X > -1 && cel.Y > -1 &&
					visited.FindIndex((e) => { return e.X == cel.X && e.Y == cel.Y; }) == -1 &&
					neighbours.FindIndex((e) => { return e.X == cel.X && e.Y == cel.Y; }) == -1)
				{
					neighbours.Add(cel);
				}
			}

			return neighbours;
		}

		public static void DoBFS(int a, int b, int limit)
		{
			List<Cell> visited = new List<Cell>();
			bool[,] visit = new bool[limit, limit];

			List<Cell> queued = new List<Cell>();

			Cell cell = new Cell(0, 0, 0);
			queued.Add(cell);
			visit[0, 0] = true;

			int steps = -1;

			while (queued.Count > 0)
			{
				Cell cl = queued[0];
				queued.RemoveAt(0);
				visited.Add(cl);
				//Console.WriteLine(cl.X + " " + cl.Y);

				if (cl.X == (limit - 1) && cl.Y == (limit - 1))
				{
					steps = cl.Step;
					break;
				}

				List<Cell> nc = GetNeighbourCell(cl, a, b, limit, visited);
				if (nc.Count > 0)
				{
					queued.AddRange(nc);
				}
			}

			Console.Write(steps);
			Console.Write(" ");

		}

		static void Main(String[] args)
		{
			int n = Convert.ToInt32(Console.ReadLine());

			for (int i = 1; i < n; i++)
			{
				for (int j = 1; j < n; j++)
				{
					DoBFS(i, j, n);
				}
				Console.Write(Environment.NewLine);
			}
			//DoBFS(2, 5, n);
			Console.ReadLine();
		}
	}
}
