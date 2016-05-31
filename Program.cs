using System;

namespace CodeBrowser
{
	class Program //main program class
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("This program tests code to" +  //explain functionality
								" analyse its structure");

			for (;;) 
			{
				Text.GetFile ();//get file

				//Console.WriteLine (Analysis.results); //print the results of the analysis
				//once program modified to include results variable

				Console.WriteLine ("Press 1 to repeat process, " + 
					"or any other key to terminate...");//let user acknowledge results

				string cont = Console.ReadLine ();
				if ( cont != "1") 
				{
					break;
				}
			}
		}
	}
	class Text //basically the functions and variables
	{
		public static string input { get; set; }
		public static string address { get; set; }

		public static void GetFile()//completes full access of file
		{
			GetAddress ();
			GetInput ();
		}

		public static void GetAddress()//provides validated address
		{
			for(;;)
			{
				Console.WriteLine ("Please enter the address and name " + 
				                   "of the text file you want to analyse" +
				                   "\nPlease Note: enter the adress in the fromat " +
				                   " path/file.txt starting at the bin folder of program");
				String Path = Console.ReadLine ();
				bool pathStatus = PathCheck (Path);
				if ( pathStatus == true) //set address and exit if valid
				{
					address = Path;
					return;
				}
				else
				{
					Console.WriteLine("Please try again");
				}
			}
		}

		public static bool PathCheck (string path) //check if a path exists
		{
			string curFile = @path; //
			return (System.IO.File.Exists (curFile) ? true : false);//return if file is available & exists
		}

		public static void GetInput()//provides final checked text
		{
			bool pathStatus = PathCheck (address);
			if (pathStatus == true) //gets file if location is valid
			{
				input = System.IO.File.ReadAllText (address);
			} 
			else 
			{
				PathInvalid ();
				Console.WriteLine ("An error has occurred");
			}
		}

		public static void PathInvalid()//prints error message about invalid path
		{
			Console.WriteLine("File not found or invalid path" +
			                  " \n or no permission to view file");
		}
	}

	class Analysis //contains all processes for analysis
	{
		public static string results { get; set; }
		public static string text { get; set; }

		public static void PrintAns(string file)
		{
			foreach ( var c in Text.input)
			{
				if (c == ';' || c == '{' || c == '}')
				{
					//results = String.Concat (results, element);
					results += c.ToString();
					Console.WriteLine (c);
				}
				Console.WriteLine ("This is for debugging");
				Console.Write (c); //comment out in release
			}
		}
	}
}
