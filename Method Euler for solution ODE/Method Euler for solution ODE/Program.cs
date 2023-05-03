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
        double n;
        x0 = Double.Parse(Console.ReadLine());
        y0 = Double.Parse(Console.ReadLine());
        xn = Double.Parse(Console.ReadLine());
        n = Double.Parse(Console.ReadLine());
        h = (xn - x0) / n;

        for (int i = 0; i < n; i++)
        {
            slope = Equtation(x0, y0);
            yn = y0 + h * slope;
            Console.WriteLine(Math.Round(x0,2) + " " + Math.Round(y0,2) + " " + Math.Round(slope,2) + " " + Math.Round(yn,2);
            y0 = yn;
            x0 = x0 + h;
        }
        Console.WriteLine("y at x = " +Math.Round(xn,2) + " is " + Math.Round(yn,2);
    }
}