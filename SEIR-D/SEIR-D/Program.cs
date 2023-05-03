public class SEIRD
{
    // S — восприимчивые(незараженные) индивидуумы c 3 лет;
    // I — инфицированные с симптомами;
    // R — вылеченные.
    // E — зараженные или находящиеся в инкубационном периоде индивидуумы;
    // H — госпитализированные, т.е.с тяжелым протеканием болезни;
    // C — находящиеся в критическом состоянии, подключенные к аппарату вентиляции легких;
    // D — умершие.


    const double a_E = 0.271, a_I = 0.999, k = 0.000019, p = 0.000000001, b = 0.007, mu = 0.0009, c_isol = 0, y = 0, a = 1;
    public static double func_c(double c_isol)
    {
        return 1 + c_isol * (1 - 2 / 5 * a);
    }

    public static double func_S(double S, double E, double I, double R, double N)
    {
        return -1 * func_c(c_isol) * S / N * (a_I * I + a_E * E) + y * R;
    }

    public static double delta_S(double S, double E, double I, double R, double N, double h)
    {
        return h * func_S(S + h / 2 * func_S(S, E, I, R, N), E, I, R, N);
    }

    public static double func_E(double S, double E, double I, double N)
    {
        return func_c(c_isol) * S / N * (a_I * I + a_E * E) - (k + p) * E;
    }

    public static double delta_E(double S, double E, double I, double N, double h)
    {
        return h * func_E(S, E + h / 2 * func_E(S, E, I, N), I, N);
    }

    public static double func_I(double E, double I)
    {
        return k * E - b * I - mu * I;
    }

    public static double delta_I(double E, double I, double h)
    {
        return h * func_I(E, I + h / 2 * func_I(E, I));
    }

    public static double func_R(double E, double I, double R)
    {
        return b * I + p * E - y * R;
    }

    public static double delta_R(double E, double I, double R, double h)
    {
        return h * func_R(E, I, R + h / 2 * func_R(E, I, R));
    }

    public static double func_D(double I)
    {
        return mu * I;
    }


    public static void Main()
    {
        int t0 = 0, T = 90, h = 1;
        int n = (T - t0) / h + 1;
        double[] S = new double[n];
        double[] E = new double[n];
        double[] I = new double[n];
        double[] R = new double[n];
        double[] D = new double[n];
        double[] N = new double[n];
        double[] t = new double[n];
        E[0] = 99;
        R[0] = 24;
        S[0] = 2798170 - E[0] - R[0];
        I[0] = 0;
        D[0] = 0;
        N[0] = E[0] + R[0] + S[0] + I[0] + D[0];
        t[0] = t0;
        for (int i = 1; i < n; i++)
        {
            t[i] = t0 + i * h;
            S[i] = S[i - 1] + delta_S(S[i - 1], E[i - 1], I[i - 1], R[i - 1], N[i - 1], h);
            E[i] = E[i - 1] + delta_E(S[i - 1], E[i - 1], I[i - 1], N[i - 1], h);
            I[i] = I[i - 1] + delta_I(E[i - 1], I[i - 1], h);
            R[i] = R[i - 1] + delta_R(E[i - 1], I[i - 1], R[i - 1], h);
            D[i] = D[i - 1] + func_D(I[i - 1]);
            N[i] = S[i] + E[i] + I[i] + R[i] + D[i];
        }
        for(int i = 0;i < n;i++)
        {
            Console.WriteLine(" t: "+ Math.Round(t[i],2) +" N: "+ Math.Round(N[i],2)+" S: "+ Math.Round(S[i],2)+" E: "+ Math.Round(E[i],2)+" I: "+ Math.Round(I[i],2)+" R: "+ Math.Round(R[i],2)+" D: "+ Math.Round(D[i],2));
        }
    }
}
