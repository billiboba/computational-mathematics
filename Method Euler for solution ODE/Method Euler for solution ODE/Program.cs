using static System.Console;
using static System.Math;

class Program
{
    static public double Equtation(double x, double y)
    {
        return x + y;
    }
    static public void Main()
    {
        double x0 = 0, y0, xn, h, yn = 0, slope;
        int n;
        x0 = Int32.Parse(Console.ReadLine());
        y0 = Int32.Parse(Console.ReadLine());
        xn = Int32.Parse(Console.ReadLine());
        n = Int32.Parse(Console.ReadLine());
        h = (xn - x0) / n;

        for (int i = 0; i < n; i++)
        {
            slope = Equtation(x0, y0);
            yn = y0 + h * slope;
            Console.WriteLine(x0 + " " + y0 + " " + slope + " " + yn);
            y0 = yn;
            x0 = x0 + h;
        }
        Console.WriteLine("y at x = " + xn + " is " + yn);
    }
}