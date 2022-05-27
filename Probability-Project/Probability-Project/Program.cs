using System;
using System.Windows.Forms;
using System.Collections.Generic;



namespace MyApp
{
	class App
	{
		public static List<double> data = new List<double>();
		public static List<double> freq = new List<double>();
		public static List<double> tempData = new List<double>();

		public static double Median(List<double> arr) {
			return Q2(arr);
		}

		public static SortedSet<double> Mode(List<double> arr)
		{
			SortedSet<double> list = new SortedSet<double>();
			double freqI = 0;
			for (int i = 0; i < arr.Count; i++)
			{
				int counter = 0;

                for (int j = 0; j < arr.Count; j++)
                { 
				  if (arr[i] == arr[j])
                  {
						counter++;
                  }
                }
				if (counter > freqI)
                {
					list.Clear();
                    list.Add(arr[i]);
					freqI = counter;
                }else if(counter == freqI)
                {
                    list.Add(arr[i]);
                }
			}
			return list;
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
			tempData.Clear();
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
			tempData.Clear();
			double arrMedian = Q2(arr);
			foreach (double element in arr){
				if(element > arrMedian){
					tempData.Add(element);
				}
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
		public static double summationDeviation(List<double> arr)
        {
			
			double sum = 0;
			foreach (double element in data) { 
				sum +=element;
			}
			double mean = sum/arr.Count;
			sum = 0;
			foreach (double element in arr) { 
				sum += (element - mean);
			}
			return sum;
		}
		public static double samStandardDeviation(List<double> arr, List<double> freq)
		{
			Console.Write("Do you want to enter data frequency? (y for yes else for no) ");
			string userInput;
			string ans = Console.ReadLine();
			if (ans == "y")
			{
				for (int i = 0; i < data.Count;)
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
				double n = 0;
				foreach (double f in freq) { n += f; }
				double sum = 0;
				for (int i = 0; i < arr.Count; ++i)
				{
					sum += arr[i] * freq[i];
				}
				double mean = sum / n;
				sum = 0;
				for (int i = 0; i < arr.Count; ++i)
				{
					sum += ((arr[i] - mean) * (arr[i] - mean)) * freq[i];
				}
				double variance = sum / (n - 1);
				return Math.Sqrt(variance);
            }
            else { return popStandardDeviation(arr); }
			
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
		public static void GetOutlier(List<double> arr)
		{
			bool found = false;
			// Q1 Formula
			double MQ1 = Q1(arr);

			// Q3 Formula
			double MQ3 = Q3(arr);

			// IQR (Interquartile range) Formula
			double IQR = MQ3 - MQ1;

			// High / Low Outlier
			double Upperfence = MQ3 + (1.5 * IQR);
			double Lowerfence = MQ1 - (1.5 * IQR);

			foreach (double element in data)
			{
				if (element > Upperfence || element < Lowerfence)
				{
					Console.WriteLine("Outlier: {0}", element);
					found = true;
				}
			}
			if (found == false)
			{
				Console.WriteLine("No outlier");
			}
		}
		public static void In_or_out(){
			Console.WriteLine();
			Console.WriteLine("Please Choose what do you want to do....");
			Console.WriteLine("\t[1]proceed With the same data set");
			Console.WriteLine("\t[2]proceed With a new data set");
			Console.WriteLine("\t[3]exit software");
			Console.Write("Please Choose 1, 2 or 3: ");
			int Choice;
			bool ChoiceSuccess = int.TryParse(Console.ReadLine(), out Choice);
			if(ChoiceSuccess){
				while(true){
					if(Choice == 1){
						Main();
					}else if(Choice == 2){
						data.Clear();
						getData();
						Main();
					}else if(Choice == 3){
						Environment.Exit(0);
					}else{
						Console.WriteLine("Please enter 1 or 2 or 3");
					}
				}
			}else{
				Console.WriteLine("Please enter a valid input");
				In_or_out();
			}
		}
		public static void printData(List<double> arr){
			Console.WriteLine("\nThis is the values you entered...");
			Console.Write("data = { ");
			Console.Write(String.Join(", ", arr));
			Console.WriteLine(" }");
		}
		public static void Main()
		{
			Console.Clear();
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
				Console.WriteLine("\t[8]Standard Deviation");
				Console.WriteLine("\t[9]Summation of Deviation");
				Console.WriteLine("\t[10]Outlier");
				Console.Write("Please Choose your operation form 1 to 10: ");
				int Choice;
				bool ChoiceSuccess = int.TryParse(Console.ReadLine(), out Choice);
				if (Choice == 1)
				{
					if (data.Count == 0){
						getData();
 					}
 					printData(data);
					Console.WriteLine("\n\t==> Median: {0}",Median(data));
					In_or_out();	
				}
				else if (Choice == 2)
				{
					if (data.Count == 0){
						getData();
 					}
 					printData(data);
					Console.WriteLine("\n\t==> Mode: {0}",String.Join(", ", Mode(data)));
					In_or_out();				}
				else if (Choice == 3)
				{
					if (data.Count == 0){
						getData();
 					}
 					printData(data);
					Console.WriteLine("\n\t==> P20: {0}",P20(data));
					In_or_out();
				}
				else if (Choice == 4)
				{
					if (data.Count == 0){
						getData();
 					}
 					printData(data);
					Console.WriteLine("\n\t==> Q1: {0}",Q1(data));
					In_or_out();
				}
				else if (Choice == 5)
				{
					if (data.Count == 0){
						getData();
 					}
 					printData(data);
					Console.WriteLine("\n\t==> Q2: {0}",Q2(data));
					In_or_out();
				}
				else if (Choice == 6)
				{
					if (data.Count == 0){
						getData();
 					}
 					printData(data);
					Console.WriteLine("\n\t==> Q3: {0}",Q3(data));
					In_or_out();
				}
				else if (Choice == 7)
				{
					if (data.Count == 0){
						getData();
 					}
 					printData(data);
					Console.WriteLine("\n\t==> Range: {0}", Range(data));
					In_or_out();
				}
				else if (Choice == 8)
				{
					if (data.Count == 0){
						getData();
 					}
					Console.Write("Do You Want it Sample or Population (1 for Sample, 2 Population,otherwise Exit) ");
					int num;
					bool tr = int.TryParse(Console.ReadLine(), out num);
					if(num == 2)
						Console.WriteLine("\n\t==> Population Standard Deviation: {0}", popStandardDeviation(data));
					else if(num == 1)
						Console.WriteLine("\n\t==> Sample Standard Deviation: {0}", samStandardDeviation(data,freq));
					In_or_out();
				}
				else if (Choice == 9)
				{
					if (data.Count == 0){
						getData();
 					}
 					printData(data);
					Console.WriteLine("\n\t==> Summation of Deviation: {0}", summationDeviation(data));
					In_or_out();
				}
				else if (Choice == 10)
				{
					if (data.Count == 0){
						getData();
 					}
 					printData(data);
					GetOutlier(data);
					In_or_out();
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
