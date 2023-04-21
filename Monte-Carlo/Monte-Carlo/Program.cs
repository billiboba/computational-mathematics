using static System.Console;
using static System.Math;



class integration
{

    static double Equation(double x)
    {
        return Math.Pow(x, 4) / (0.5 * Math.Pow(x, 2) + x + 6);
    }

    static void Method_of_MonteCarlo(double lowbound,double upbound, double iteration, double[] statsArray)
    {
        double totalSum = 0;
	    double totalSumSquared = 0;
        var rand = new Random();
    	int iter = 0;
        while(iter < iteration - 1)
        {
            double randnum = lowbound + rand.Next()*(upbound-lowbound);
            double functionalVal = Equation(randnum);
            totalSum += functionalVal;
            totalSumSquared += Math.Pow(functionalVal,2);
            iter++;
        }
        double estimate = (upbound-lowbound)*totalSum/iteration; 
	    double expected = totalSum/iteration;

	    double expectedSquare = totalSumSquared/iteration;
        double std = (upbound-lowbound)*Math.Pow((expectedSquare-Math.Pow(expected,2))/(iteration-1) ,0.5);
        statsArray[0] = estimate;
	    statsArray[1] = std;


    }
    static void Main()
    {
        double lowerBound, upperBound;
	    double iterations;

	    lowerBound = 1;
	    upperBound = 5;

	    double[] statsArray = new double[2]; 

	    for(int i =1;i<6;i++)
        {
            iterations = 2*Math.Pow(4,i);
            Method_of_MonteCarlo(lowerBound, upperBound, iterations, statsArray);
            Console.WriteLine("STD = " + Math.Round(statsArray[1],4) + " iterations = " + iterations);
        }
    }
}