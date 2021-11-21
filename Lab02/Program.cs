using System;
using static System.Console;
namespace Lab02_Program2
{
	class Program
	{
		static void Main(string[] args)
		{ 
			Random rand = new Random();
			int N, M, i, j;
			try
			{
				Write("N = "); N = Int32.Parse(ReadLine());
				Write("M = "); M = Int32.Parse(ReadLine());
			}
			catch
			{
				WriteLine("Error");
				return;
			}
			if (N % 2 == 1 || N < 2 || M < 1)
			{
				WriteLine("Error");
				return;
			}
			
			int[,] matrix = new int[N, M];
			WriteLine("1 - Generate Random Matrix\n2 - Use Control Matrix");
			string str = ReadLine();
			if (str == "1")
				for (i = 0; i < N; i++)
				{
					for (j = 0; j < M; j++)
					{
						matrix[i, j] = rand.Next(1, 1000);
					}
				}
			else if (str == "2")
			{
				int count = 1;
				for (i = 0; i < N; i++)
				{
					for (j = 0; j < M; j++)
					{
						matrix[i, j] = count++;
					}
				}
			}
			else
			{
				WriteLine("Error");
				return;
			}
			for (i = 0; i < N; i++)
			{
				for (j = 0; j < M; j++)
				{
					Write($"{matrix[i, j], 3}  ");
				}
				WriteLine();
			}
			int iMin = N - 1, iMax = N - 1, jMin = 0, jMax = 0;
			int min = matrix[iMin, jMin], max = matrix[iMax, jMax];
			i = N-1; j = 0;
			WriteLine($"{i}, {j}: {matrix[i, j]}");
			while (i >= N/2)
			{
				if (i == N / 2 && j != M - 1)
				{
					j++;
					WriteLine($"{i}, {j}: {matrix[i, j]}");
					if(min > matrix[i, j])
					{
						min = matrix[i, j];
						iMin = i;
						jMin = j;
					}
					else if (max < matrix[i, j])
					{
						max = matrix[i, j];
						iMax = i;
						jMax = j;
					}
				}
				else if (j == 0 || j == M-1)
				{
					i--;
					WriteLine($"{i}, {j}: {matrix[i, j]}");
					if (min > matrix[i, j])
					{
						min = matrix[i, j];
						iMin = i;
						jMin = j;
					}
					else if (max < matrix[i, j])
					{
						max = matrix[i, j];
						iMax = i;
						jMax = j;
					}
				}
				
				
				while(i < N-1 && j < M-1)
				{
					j++;
					i++;
					WriteLine($"{i}, {j}: {matrix[i, j]}");
					if (min > matrix[i, j])
					{
						min = matrix[i, j];
						iMin = i;
						jMin = j;
					}
					else if (max < matrix[i, j])
					{
						max = matrix[i, j];
						iMax = i;
						jMax = j;
					}
				}
				if (i == N - 1 && j != M - 1)
				{
					j++;
					WriteLine($"{i}, {j}: {matrix[i, j]}");
				}
				else if (j == M - 1 && i != 0)
				{
					i--;
					WriteLine($"{i}, {j}: {matrix[i, j]}");
				}
					
				if (min > matrix[i, j])
				{
					min = matrix[i, j];
					iMin = i;
					jMin = j;
				}
				else if (max < matrix[i, j])
				{
					max = matrix[i, j];
					iMax = i;
					jMax = j;
				}
				while (j > 0 && i > N/2)
				{
					i--;
					j--;
					WriteLine($"{i}, {j}: {matrix[i, j]}");
					if (min > matrix[i, j])
					{
						min = matrix[i, j];
						iMin = i;
						jMin = j;
					}
					else if (max < matrix[i, j])
					{
						max = matrix[i, j];
						iMax = i;
						jMax = j;
					}
				}
			}
			int lastElementIndex;
			if (M % 2 == 1)
				lastElementIndex = 0;
			else
				lastElementIndex = N / 2 - 1;
			while (j != 0 || i != lastElementIndex)
			{
				while (i > 0)
				{
					i--;
					WriteLine($"{i}, {j}: {matrix[i, j]}");
					if (min > matrix[i, j])
					{
						min = matrix[i, j];
						iMin = i;
						jMin = j;
					}
					else if (max < matrix[i, j])
					{
						max = matrix[i, j];
						iMax = i;
						jMax = j;
					}
				}

				if (j != 0)
				{
					j--;
					WriteLine($"{i}, {j}: {matrix[i, j]}");
					if (min > matrix[i, j])
					{
						min = matrix[i, j];
						iMin = i;
						jMin = j;
					}
					else if (max < matrix[i, j])
					{
						max = matrix[i, j];
						iMax = i;
						jMax = j;
					}
				}
				if (j != 0 || i != lastElementIndex)
					while (i + 1 < N / 2)
					{
						i++;
						WriteLine($"{i}, {j}: {matrix[i, j]}");
						if (min > matrix[i, j])
						{
							min = matrix[i, j];
							iMin = i;
							jMin = j;
						}
						else if (max < matrix[i, j])
						{
							max = matrix[i, j];
							iMax = i;
							jMax = j;
						}
					}
				if(j != 0)
				{
					j--;
					WriteLine($"{i}, {j}: {matrix[i, j]}");
					if (min > matrix[i, j])
					{
						min = matrix[i, j];
						iMin = i;
						jMin = j;
					}
					else if (max < matrix[i, j])
					{
						max = matrix[i, j];
						iMax = i;
						jMax = j;
					}
				}
			}
			WriteLine($"max = {max}, indexMax = {iMax}, {jMax}");
			WriteLine($"min = {min}, indexMin = {iMin}, {jMin}");
		}
	}
}
