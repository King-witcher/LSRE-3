using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSRE_3;

internal static class Calculus
{
    public delegate double F(double x);

    public static double Integral0_1(F f, double dx)
    {
        double rest = 1.0 % dx;
        double sum = 0;
        for (double i = rest / 2; i < 1; i += dx)
        {
            sum += f(i) * dx;
        }
        return sum;
    }

    public static double Average0_1(F f, double dx)
    {
        double rest = 1.0 % dx;
        double sum = 0;
        for (double x = rest / 2; x < 1; x += dx)
        {
            sum += x * f(x) * dx;
        }
        return sum;
    }

    public static double IntegralR(F f, double dx)
    {
        double g(double x) => Math.Log(x / (1 - x));
        double g_(double x) => 1 / (x * (1 - x));

        return Integral0_1(x => f(g(x)) * g_(x), dx);
    }

    public static double AverageR(F f, double universe, double dx)
    {
        F wf = x => x * f(x);
        return IntegralR(wf, dx) / universe;
    }
}