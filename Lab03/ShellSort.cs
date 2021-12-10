using System;
using static System.Console;

namespace ShellSort
{
	class ShellSort
	{
		static void Swap(ref int a, ref int b)
		{
			int temp = a;
			a = b;
			b = temp;
		}

		static void Shell(int[] array)
		{
			// Shell sequence
			int gap = array.Length / 2;
			while (gap >= 1)
			{
				for (int i = gap; i < array.Length; i++)
				{
					int j = i;
					while (j >= gap && array[j - gap] < array[j])
					{
						Swap(ref array[j], ref array[j - gap]);
						j = j - gap;
					}
				}

				gap = gap / 2;
			}

		}
		static void Main(string[] args)
		{
			Random rand = new Random();
			Write("n = "); int n = Int32.Parse(ReadLine());
			Write("m = "); int m = Int32.Parse(ReadLine());
			int[,] M = new int[n, m];
			int[] array = new int[n*m];
			int index = 0;
			for (int i = 0; i < n; i ++)
			{
				for (int j = 0; j < m; j++)
				{
					M[i, j] = rand.Next(100);
					if (i > j)
					{
						array[index++] = M[i, j];
						BackgroundColor = ConsoleColor.Green;
						
					}
					Write($"{M[i, j],2}");
					ResetColor();
					Write(" ");
				}
				WriteLine();
			}
			Shell(array);
			index = 0;
			WriteLine("*******  Sorted  ********");
			for (int j = 0; j < m; j++) 
			{
				for (int i = 0; i < n; i++)
				{
					
					if (i > j)
					{
						M[i, j] = array[index++];
					}
				}
			}
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					if (i > j)
						BackgroundColor = ConsoleColor.Green;
					Write($"{M[i, j],2}");
					ResetColor();
					Write(" ");
				}
				WriteLine();
			}
		}
	}
}
