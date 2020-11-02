using System;
using System.Drawing;
using System.Threading;

namespace labrab5
{
	class Program
	{
		public  static ConsoleColor startColor = ConsoleColor.Yellow;
		public  static ConsoleColor newColor = ConsoleColor.DarkBlue;
		public  static int delay = 10;		
		public static ulong Counting(int numb)
		{
			ulong factorial = 1;
			for (int i = 2; i <= numb; i++)
			{
				factorial *= Convert.ToUInt64(i);
			}
			
			return factorial;
		}		 
		public static void ChangeColor()
		{			
					
			startColor = newColor;
			newColor = Console.BackgroundColor;			
			Console.BackgroundColor = startColor;
			Console.ForegroundColor = newColor;
		}
		public static void Closing(ulong factorial)
		{
			
			Console.WriteLine();			
			Console.Write("+");
			for (int i = 1; i <= factorial.ToString().Length+1; i++)
			{
				Console.Write("--");
				Thread.Sleep(delay);
			}
			Console.Write("+");
		}
		public static string DrawingNumb(ulong numb)
		{			
			string middleString=numb.ToString();
			for (int i = 1; i <= numb.ToString().Length+2; i++)
			{
				if (i % 2 == 1)
					middleString += "!";
				else
					middleString = "!" + middleString;
				
			}
			return middleString;
		}
		public static void SleepDrawing(string middle)
		{
			for (int i = 0; i < middle.Length; i++)
			{
				Console.Write(middle[i]);
				Thread.Sleep(delay);
			}
		}
		public static void Drawing(int numb)
		{  
			while (true)
			{
				Console.SetCursorPosition(0, Console.WindowHeight/2 - numb.ToString().Length/2*8);

				ulong factorial = Counting(numb);
				Closing(factorial);

				for (int i = 1; i <= factorial.ToString().Length + 1; i++)
				{					
					Console.WriteLine();
					Console.Write("|");
					Thread.Sleep(delay);
					for (int j = 1; j <= factorial.ToString().Length + 1; j++)
					{
						if (Math.Ceiling(Convert.ToDouble(factorial.ToString().Length) / 2) == i)
						{
							SleepDrawing(DrawingNumb(factorial));
							i++;
							break;
						}
						else
						{
							Thread.Sleep(delay);
							Console.Write("$$");
						}

					}
					Console.Write("|");
					Thread.Sleep(delay);
				}

				Closing(factorial);
				ChangeColor();
				Console.Clear();
			}			
		}
		static void Main(string[] args)
		{
			string input;
			int numb;
			Console.WriteLine("Введите факториал");
			
			while(true)
			{
				input = Console.ReadLine().Trim();

				if (input[0] == '!')
					input = input.Substring(1);

				if (Int32.TryParse(input, out numb) && (Convert.ToInt32(input) >= 0))
				{
					numb = Convert.ToInt32(input);
					break;
				}
				else
				{
					Console.Clear();
					Console.WriteLine("Введите коректное натурально число");
				}
					
			}
			Console.BackgroundColor = startColor;
			Console.ForegroundColor = newColor;
			Console.Clear();			
			Drawing(numb);
			
		}
	}
}
