using System;
using static System.Math;
using static System.Console;
public static class Task1
{
    public static void Main()
    {
        Write("year = ");
        int year = Int32.Parse(ReadLine());
        int m = 8;
        int y = year % 100;
        int c = year / 100;
        int d = 31;
        while ((Floor(2.6 * m - 0.2) + d + y + Floor(y / 4.0) + Floor(c / 4.0) - 2 * c) % 7 != 0)
            d--;
        WriteLine($"October {d}");

    }
}