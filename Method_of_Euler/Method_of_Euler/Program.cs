﻿using static System.Console;
using static System.Math;

class Program
{
    static double Equation(double x, double y)
    {
        return  x+Math.Pow(y,2);
    }

    static void Method_of_Euler(double x0, double y, double x,double h)
    {
        double temp = 0.0;
        while(x0 < x)
        {
            temp = y;
            y = y+h*(Equation(x0,y));
            x0 = x0+h;
        }
        Console.WriteLine("Solution at x = "+ x + " is y = " + y);
    }

    static void Main()
    {
        double x0 = 0; //Начальное значение x
        double y = 1; //Начальное значение y
        double x = 1.5; //Точка вычисления приближённого значения
        double h = 0.5; //Шаг
        Method_of_Euler(x0 ,y,x,h);
    }
}