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
    static double interpolate(Data[] f, double xi, int n)
    {
        double[,] y = new double[10,10];
        for(int j = 0; j <= n; j++)
        {
            y[j, j] = f[j].y;
            for(int i = j-1;i>=0;i--)
            {
                y[i, j] = 1 / (f[j].x - f[i].x) * ((xi - f[i].x) * y[i + 1, j] - (xi - f[j].x) * y[i, j - 1]);
            }
        }
        return y[0, n];
    }

    public static void Main(String[] args)
    {

        Data[] f = {new Data(1, 1.0),
                new Data(2, 1.4142),
                new Data(3, 1.7321),
                new Data(4,2.0)};

        Console.Write("Value of f(3) is : " + Math.Round(((double)interpolate(f, 2.56, 3)), 4));

    }
}
