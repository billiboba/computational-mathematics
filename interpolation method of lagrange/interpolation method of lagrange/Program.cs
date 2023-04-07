using System;

class GFG
{


    class Data
    {
        public double x, y;
        public Data(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    };
    static double interpolate(Data[] f,
                          double xi, double n)
{
    double result = 0; 

    for (int i = 0; i < n; i++)
    {

        double term = f[i].y;
        for (int j = 0; j < n; j++)
        {
            if (j != i)
                term = term * (xi - f[j].x) /
                          (f[i].x - f[j].x);
        }


        result += term;
    }
    return result;
}

public static void Main(String[] args)
{

    Data[] f = {new Data(1,1.6),
                new Data(2, 2.7),
                new Data(3, 3.8),
                new Data(4,4.9),
                new Data(5,5.1)};

    Console.Write("Value of f(3) is : " + Math.Round(((double)interpolate(f, 4.6, 5)),4));

    }
}