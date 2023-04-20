using System;

class GFG
{
    static double first_formul(double u, int n)
    {
        double temp = u;
        for (int i = 1; i < n; i++)
            temp = temp * (u - i);
        return temp;
    }

    static int fact(int n)
    {
        int f = 1;
        for (int i = 2; i <= n; i++)
            f *= i;
        return f;
    }
    public static void Main()
    {
        int n = 4;
        double[] x = { 0.4, 0.8, 1.2, 1.6 };

        double[,] y = new double[n, n];
        y[0, 0] = 2;
        y[1, 0] = 3.2;
        y[2, 0] = 12;
        y[3, 0] = 3;

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < n - i; j++)
                y[j, i] = y[j + 1, i - 1] - y[j, i - 1];
        }


        double value = 1.3;

        double sum = y[0, 0];
        double u = (value - x[0]) / (x[1] - x[0]);
        for (int i = 1; i < n; i++)
        {
            sum = sum + (first_formul(u, i) * y[0, i]) /
                                    fact(i);
        }

        Console.WriteLine("\n Value at " + value + " is " + Math.Round(sum, 6));
    }
}