namespace LSRE_3;

internal class Program
{
    static void Main(string[] args)
    {
        double universe = Calculus.IntegralR(x =>
        {
            return 1 / Math.Exp(x * x);
        }, 0.0001);

        Console.WriteLine(Calculus.AverageR(x =>
        {
            x = x + 1;
            return 1 / Math.Exp(x * x);
        }, universe, 0.001));
    }
}