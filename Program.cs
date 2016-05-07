using System;

namespace CodeBrowser
{
	class Program //main program class
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("This program tests code to"); //explain functionality
			Console.WriteLine ("analyse its structure");

			Text.GetFile ();//get file

			Console.WriteLine (Text.input); //this is just a test, comment out in future revision

			//Console.WriteLine (Analysis.results); //print the results of the analysis
			//once programmodified to include results variable

			Console.WriteLine ("Press any key to terminate...");//let user acknowledge results
			Console.Read ();
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
				if (element == ';' || element == '{' || element == '}')
				{
					//results = String.Concat (results, element);
					results += element.ToString();
					Console.WriteLine (element);
				}
			}
		}
	}
}
