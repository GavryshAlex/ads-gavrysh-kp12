using System;
using static System.Console;
using static System.Convert;
namespace Lab05
{
	class Program
	{
		
		static void Main(string[] args)
		{
			int n, m, temp;
			int[,] M;
			int[] arr;
			int index = 0, index2 = 1;
			Random rand = new Random();
			int i, j;
			Write("1. Generate matrix\n2. Control example\nChoice: ");
			temp = ToInt32(ReadLine());
			if (temp == 1)
			{
				Write("M = "); n = ToInt32(ReadLine());
				Write("N = "); m = ToInt32(ReadLine());
				if (n <= 0 || m <= 0 || n != m) { WriteLine("Error"); return; }
				M = new int[n, m];
				arr = new int[n*m/3];
				for (i = 0; i < n; i++)
				{
					for (j = 0; j < m; j++)
					{
						M[i, j] = index2++;
					}
				}
				suffle(M, n, m);
				for (i = 0; i < n; i++)
				{
					for (j = 0; j < m; j++)
					{
						if (i > j && i + j > n - 1)
						{
							arr[index++] = M[i, j];
						}
					}
				}
				printMatrix(M, n, m);
			}
			else if (temp == 2)
			{
				Write("M = 5\n"); n = 5;
				Write("N = 5\n"); m = 5;
				M = new int[n, m];
				arr = new int[n * m / 3];
				
				for (i = 0; i < n; i++)
				{
					for (j = 0; j < m; j++)
					{
						M[i, j] = index2++;
						if (i > j && i + j > n - 1)
						{
							BackgroundColor = ConsoleColor.Green;
							arr[index++] = M[i, j];
						}
						Write($"{M[i, j],2}");
						ResetColor();
						Write(" ");
					}
					WriteLine();
				}
			}
			else
			{
				WriteLine("Error");
				return;
			}
			if (index >= n)
				quickSort(arr, 0, index);
			else
				insertionSort(arr, index);

			i = n - 1; j = 1;
			int index3 = 0;
			if (index >= n) { index3 = 1; index++; }
			while (index3 < index)
			{
				while(i > j + 1 && index3 < index)
				{
					M[i, j] = arr[index3];
					j++;
					index3++;
				}
				M[i, j] = arr[index3];
				i--;
				j--;
				M[i, j] = arr[index3];
				index3++;
				while (i + j > n && index3 < index)
				{
					M[i, j] = arr[index3];
					j--;
					index3++;
				}
				M[i, j] = arr[index3];
				i--;
				j++;
				M[i, j] = arr[index3];
				index3++;
			}
			printMatrix(M, n, m);

		}
		static void printMatrix(int[,] M, int n, int m)
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					if (i > j && i + j > n - 1)
					{
						BackgroundColor = ConsoleColor.Green;
					}
					Write($"{M[i, j],2}");
					ResetColor();
					Write(" ");
				}
				WriteLine();
			}
		}
		static void Swap(ref int first, ref int second)
		{
			int temp = first;
			first = second;
			second = temp;
		}

		static int partition(int[] arr, int low, int high)
		{
			int pivot = arr[high];
			int i = (low - 1);
			for (int j = low; j <= high - 1; j++)
			{
				if (arr[j] <= pivot)
				{
					i++;
					Swap(ref arr[i], ref arr[j]);
				}
			}
			Swap(ref arr[i + 1], ref arr[high]);
			return (i + 1);
		}

		static void quickSort(int[] arr, int low, int high)
		{
			if (low < high)
			{
				int index = partition(arr, low, high);
				quickSort(arr, low, index - 1);
				quickSort(arr, index + 1, high);
			}
		}
		static void insertionSort(int[] arr, int length)
		{
			for (int i = 1; i < length; i++)
			{
				int key = arr[i];
				bool flag = false;
				for (int j = i - 1; j >= 0 && !flag;)
				{
					if (key < arr[j])
					{
						arr[j + 1] = arr[j];
						j--;
						arr[j + 1] = key;
					}
					else flag = true;
				}
			}
		}
		static void suffle(int[,] M, int n, int m)
		{
			Random rand = new Random();
			for (int i = 0; i < n + m; i ++)
			{
				int i1 = rand.Next(n);
				int j1 = rand.Next(m);
				int i2 = rand.Next(n);
				int j2 = rand.Next(m);
				Swap(ref M[i1, j1], ref M[i2, j2]);
			}
		}
	}
}
