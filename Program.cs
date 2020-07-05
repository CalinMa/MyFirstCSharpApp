using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace Programming
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Please specify the file path");
			List<int> list = new List<int>();
			var sr = new StreamReader(Console.ReadLine());
			long[] data = ExtractData(sr).ToArray();

		}

		private static IEnumerable<long> ExtractData(StreamReader sr)
		{
			string line;
			List<int> list = new List<int>();
			while ((line = sr.ReadLine()) != null)
			{
				var items = line.Split(", ");
				foreach (var item in items)
				{
					yield return (Convert.ToInt64(item));
					list.Add((int)Convert.ToInt64(item));

				}
				Console.WriteLine("																				");
				Console.WriteLine("Please choose one of the following options, by pressing a number from 1 to 5:");
				Console.WriteLine("------------------------------------------------------------------------------");
				Console.WriteLine("1.Sort order/ascending  2.Sort order/descending  3.Number sort  4.String sort  5.Hybrid sort: ");

				string userInput = Console.ReadLine();
				Console.WriteLine("------------------------------------------------------------------------------");

				int numberOfElements = list.Count();
				int j = 0;
				list.Sort();

				if (userInput == "1")
				{
					foreach (int i in list)
						Console.WriteLine(i);
				}
				else if (userInput == "2")
				{
					list.Reverse();
					foreach (int i in list)
						Console.WriteLine(i);
				}
				else if (userInput == "3")
				{
					foreach (int i in list)
					{
						Console.Write(i);
						j++;
						if (j < numberOfElements)
							Console.Write(" < ");
					}
				}
				else if (userInput == "4")
				{
					for (int k = 0; k <= 9; k++)
					{
						foreach (int i in list)
						{
							int firstDigit = Math.Abs(i);
							while (firstDigit >= 10)
								firstDigit /= 10;
							if (k == firstDigit)
							{
								Console.Write(i);
								j++;
								if (j < numberOfElements)
									Console.Write(" < ");
							}
						}
					}
				}
				else if (userInput == "5")
				{
					list.Reverse();
					foreach (int i in list)
					{
						if (i % 2 == 0)
						{
							Console.Write(i);
							j++;
							if (j < numberOfElements)
								Console.Write(" < ");
						}
					}
					list.Sort();
					foreach (int i in list)
					{
						if (i % 2 != 0)
						{
							Console.Write(i);
							j++;
							if (j < numberOfElements)
								Console.Write(" < ");
						}
					}
				}
			}
		}
	}
}


