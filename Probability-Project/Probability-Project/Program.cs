using System;
using System.Collections.Generic;

namespace MyApp
{
	class App
	{
		public static List<double> data = new List<double>();

		public static double Range(List<double> arr) {
			double range = data[arr.Count-1] - data[0];
			return range; 

		}

		public static double P20(List<double> arr) {
			double _20P = arr.Count *.20;
			int index   = (int)Math.Round(_20P);
			return arr[index-1];
		}

		public static double Q1(List<double> arr) {
			double Q1 = (arr.Count + 1) * .25;
			int index = (int)Math.Round(Q1);
			return arr[index-1];
		}

		public static double Q2(List<double> arr) {
			double Q2 = (arr.Count + 1) * .50;
			int index = (int)Math.Round(Q2);
			return arr[index-1];
		}

		public static double Q3(List<double> arr) {
			double Q3 = (arr.Count + 1) * .75;
			int index = (int)Math.Round(Q3);
			return arr[index-1];
		}

		public static void getData()
		{
			Console.Clear();
			string userInput = "";
			while (true)
			{
				Console.Write("Enter a number <q to exit>: ");
				userInput = Console.ReadLine();
				if (userInput == "q")
				{
					data.Sort();
					Console.WriteLine("\nThis is the values you entered...");
					Console.Write("data = { ");
					Console.Write(String.Join(", ", data));
					Console.WriteLine(" }");
					break;
				}
				else
				{
					double SingleValue;
					bool checkValue = double.TryParse(userInput, out SingleValue);
					if (checkValue)
					{
						data.Add(SingleValue);
					}
					else
					{
						Console.WriteLine("\n\t*** [ERROR] Please Enter a valid decimal number ****\n");
					}
				}
			}
		}
		public static void Main(string[] args)
		{
			while (true)
			{
				Console.WriteLine("List of Choices..");
				Console.WriteLine("\t[1]Median");
				Console.WriteLine("\t[2]Mode");
				Console.WriteLine("\t[3]P20");
				Console.WriteLine("\t[4]Q1");
				Console.WriteLine("\t[5]Q2");
				Console.WriteLine("\t[6]Q3");
				Console.WriteLine("\t[7]Range");
				Console.WriteLine("\t[8]Standard Division");
				Console.WriteLine("\t[9]Summation of Divisions");
				Console.Write("Please Choose your operation form 1 to 9: ");
				int Choice;
				bool ChoiceSuccess = int.TryParse(Console.ReadLine(), out Choice);
				if (Choice == 1)
				{
					getData();
					Console.WriteLine(data.Count);
					break;
				}
				else if (Choice == 2)
				{
					getData();
					break;
				}
				else if (Choice == 3)
				{
					getData();
					Console.WriteLine("P20: {0}",P20(data));
					break;
				}
				else if (Choice == 4)
				{
					getData();
					Console.WriteLine("Q1: {0}",Q1(data));
					break;
				}
				else if (Choice == 5)
				{
					getData();
					Console.WriteLine("Q2: {0}",Q2(data));
					break;
				}
				else if (Choice == 6)
				{
					getData();
					Console.WriteLine("Q3: {0}",Q3(data));
					break;
				}
				else if (Choice == 7)
				{
					getData();
					Console.WriteLine("Range: {0}", Range(data));
					break;
				}
				else if (Choice == 8)
				{
					getData();
					break;
				}
				else if (Choice == 9)
				{
					getData();
					break;
				}
				else
				{
					Console.WriteLine("[WARNING] this isn't a valid input.");
					Console.WriteLine("Intgers form 1 to 9 is a valid inputs");
				}
			}
		}
	}
}


/*
	Ahmed Alaa:
		- outlier
		- Medean
		- Mode

	Nabil Salah:
		- Standard Division
		- Summation of Divisions

	Mahmoud El Gohary:
		- Q1     ----> <DONE>
		- Q2     ----> <DONE>
		- Q3     ----> <DONE>
		- P20    ----> <DONE>
		- Range  ----> <DONE>
*/
