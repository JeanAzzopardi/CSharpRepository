using System;

namespace spoj
{
	class MainClass
	{
		public static void Main(string[] args)
		{			
			int i = Int32.Parse(System.Console.ReadLine());
			while ( i != 42)
			{
				System.Console.WriteLine(i);
				i = Int32.Parse(System.Console.ReadLine());
			}
		}
	}
}