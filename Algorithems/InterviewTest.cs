using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithems
{
	class InterviewTest
	{
		static void Algo()
		{
			
		}
		public static void Main(string[] args)
		{
			A a = new B();
			a.Hello();
			//a.Bye();
			Console.ReadLine();
		}
	}

	class A
	{
		public void Hello()
		{
			Console.WriteLine("Hello a");
		}
	}

	class B : A
	{
		public void Hello()
		{
			Console.WriteLine("hello B");
		}

		public void Bye()
		{
			Console.WriteLine("Bye");
		}
	}
}
