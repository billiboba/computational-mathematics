using static System.Console;
using static System.Math;

class integration
{

    static double Equation(double x)
    {
        return Math.Pow(x, 4) / (0.5 * Math.Pow(x, 2) + x + 6);
    }

    static double Method_of_Runge(double a, double b, double n)
    {
        double sum = 0.0;
        double h = (b - a) / n;
        for(int i = 0; i < n; i++)
        {
            sum += Equation(a + h * (i + 0.5));
            sum *= h;
        }
        return sum;
        
    }
    static void Main()
    {
        double a = 0.4;
        double b = 1.5;
        int n = 10;
        Console.WriteLine(Method_of_Runge(a,b,n));
        
    }
}
