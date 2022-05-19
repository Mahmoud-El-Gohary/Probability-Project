using System;
using System.Collections.Generic;

namespace MyApp {
	class App {
		public static void getData() {
			Console.Clear();
			string userInput = "";
			// sort array
			List<double> data = new List<double>();
			while(true) {
				Console.Write("Enter a number <q to exit>: ");
				userInput = Console.ReadLine();
				if(userInput == "q") {
					Console.WriteLine("\nThis is the values you entered...");
					Console.Write("data = { ");
					Console.Write(String.Join(", ", data));
					Console.WriteLine(" }");
					break;
				}else{
					double SingleValue;
					bool   checkValue = double.TryParse(userInput,out SingleValue);
					if(checkValue){
						data.Add(SingleValue);
					}else{
						Console.WriteLine("\n\t*** [ERROR] Please Enter a valid decimal number ****\n");
					}	
				}
			} 
		}
		public static void Main(string[] args) {
			while(true){
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
				if(Choice == 1){
					getData();
					break;
				}else if(Choice == 2){
					getData();
					break;
				}else if(Choice == 3){
					getData();
					break;
				}else if(Choice == 4){
					getData();
					break;
				}else if(Choice == 5){
					getData();
					break;
				}else if(Choice == 6){
					getData();
					break;
				}else if(Choice == 7){
					getData();
					break;
				}else if(Choice == 8){
					getData();
					break;
				}else if(Choice == 9){
					getData();
					break;
				}else{
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
		- Q1
		- Q2
		- Q3
		- P20
		- Range
*/