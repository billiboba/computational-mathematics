using static System.Console;
using static System.Math;
class Program
{
    public const double eps = 0.01;

    unsafe static double Equation(double x)
    {
        return x * x * x + 4 * x - 3;
    }
    static double Equation1(double x)
    {
        return 3 * x * x + 4;
    }
    static double Equation2(double x)
    {
        return 6 * x;
    }
    unsafe public static int Newton(double a, double b, double* c, double eps)
    {
        unsafe
        {
            int k = 0;
            if (Equation(a) * Equation2(a) > 0) *c = a;
            else *c = b;
            do
            {
                *c = *c - Equation(*c) / Equation1(*c);
                k++;
            }
            while (Math.Abs(Equation(*c)) >= eps);
            return k;
        }

    }
    unsafe static void Main(string[] args)
    {
        Console.WriteLine("Your function: x * x * x + 3 * x + 2.2");
        int k;
        double a, b, x;
        Console.Write("a: ");
        a = double.Parse(Console.ReadLine());
        Console.Write("b: ");
        b = double.Parse(Console.ReadLine());
        Newton(a, b, &x, eps);
        Console.Write("x: ");
        Console.WriteLine(Math.Round(x, 3));
    }
}