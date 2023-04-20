using System;
using System.Collections;

class GFG
{
    static double u_cal(double u, int n)
    {
        double temp = u;
        for (int i = 1; i < n; i++)
            temp = temp * (u + i);
        return temp;
    }
    static int fact(int n)
    {
        int f = 1;
        for (int i = 2; i <= n; i++)
            f *= i;
        return f;
    }
    static void Main()
    {
        int n = 5;
        double[] x = { 1, 2, 3, 4, 5 };

        double[,] y = new double[n, n];
        y[0, 0] = 1.6;
        y[1, 0] = 2.7;
        y[2, 0] = 3.8;
        y[3, 0] = 4.9;
        y[4, 0] = 5.1;

        for (int i = 1; i < n; i++)
        {
            for (int j = n - 1; j >= i; j--)
                y[j, i] = y[j, i - 1] - y[j - 1, i - 1];
        }

        double value = 4.6;
        double sum = y[n - 1, 0];
        double u = (value - x[n - 1]) / (x[1] - x[0]);
        for (int i = 1; i < n; i++)
        {
            sum = sum + (u_cal(u, i) * y[n - 1, i]) /
                                        fact(i);
        }

        Console.WriteLine("\n Value at " + value + " is " + Math.Round(sum, 4));
    }
}