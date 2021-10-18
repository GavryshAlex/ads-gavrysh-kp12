using System;
using static System.Math;
using static System.Console;
public static class Task1
{
    public static void Main()
    {
        double x, y, z;
        Write("x = "); x = double.Parse(ReadLine());
        Write("y = "); y = double.Parse(ReadLine());
        Write("z = "); z = double.Parse(ReadLine());
        double a, b;
        if (z == 0 || y == 0 || (x / PI) % 1 == 0)
        {
            WriteLine("Wrong value");
            return;
        }
        a = (0.5 / Sin(PI + x)) + Pow(Sin((x + y) / z), 2);
        b = Cos(a * a * x) / (2.0 * y * z);
        WriteLine($"a = {a}\nb = { b}");
    }
}