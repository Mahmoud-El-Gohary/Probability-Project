using System;
using System.Collections.Generic;

namespace MyApp
{
	class App
	{
		public static List<double> data = new List<double>();
		public static List<double> freq = new List<double>();
		public static List<double> tempData = new List<double>();

		public static void clearLists() {
			data.Clear();
			tempData.Clear();
		}


		public static void Median(List<double> arr) {
			Q2(arr);
		}

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
			double arrMedian = Q2(arr);
			foreach (double element in data){
				if(element < arrMedian)
					tempData.Add(element);
				else
					break;
			} 
			return Q2(tempData);
		}

		public static double Q2(List<double> arr) {
			if(arr.Count % 2 == 0) {	
				double _50P = arr.Count *.50;
				int index   = (int)Math.Round(_50P, MidpointRounding.AwayFromZero);
				 return (arr[index-1]+arr[index])/2;

			}else{
				double _50P = arr.Count *.50;
				int index   = (int)Math.Round(_50P, MidpointRounding.AwayFromZero);
				return arr[index-1];
			}
		}

		public static double Q3(List<double> arr) {
			double arrMedian = Q2(arr);
			foreach (double element in data){
				if(element > arrMedian){
					tempData.Add(element);
				}
				else
					continue;
			} 
			return Q2(tempData);
		}
		public static double popStandardDeviation(List<double> arr)
        {
			double sum = 0;
			foreach (double element in data) { 
				sum +=element;
			}
			double mean = sum/arr.Count;
			sum = 0;
			foreach (double element in arr) { 
				sum += (element - mean)* (element-mean);
			}
			double variance = sum/arr.Count;
			return Math.Sqrt(variance);
		}
		public static double samStandardDeviation(List<double> arr, List<double> freq)
		{
			double n = 0;
			foreach (double f in freq) { n += f; }
			double sum = 0;
			for (int i =0;i<arr.Count;++i )
			{
				sum += arr[i] * freq[i];
			}
			double mean = sum / n;
			sum = 0;
			for (int i = 0; i < arr.Count; ++i)
			{
				sum += ((arr[i] - mean) * (arr[i] - mean)) * freq[i];
			}
			double variance = sum / (n-1);
			return Math.Sqrt(variance);
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
			Console.WriteLine("Do you want to enter data frequency? (y for yes else for no)");
			string ans = Console.ReadLine();
			if(ans == "y")
            {
				for (int i = 0; i < data.Count; )
				{
					Console.WriteLine("Enter Frequency of: {0}", data[i]);
					userInput = Console.ReadLine();
					double SingleValue;
					bool checkValue = double.TryParse(userInput, out SingleValue);
					if (checkValue)
					{
						++i;
						freq.Add(SingleValue);
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
					Median(data);
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
					if(freq.Count == 0)
						Console.WriteLine("Standard Division: {0}", popStandardDeviation(data));
					else
						Console.WriteLine("Standard Division: {0}", samStandardDeviation(data,freq));
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
