namespace LSRE_3;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

class History
{

    public List<Match> Matches;
}

class Calculus
{

}

class RatingModel
{
    History history;

    public double P_Result(Player winner, Player loser)
    {
        double gap = loser.LSR - winner.LSR;
        return 1 / (1 + Math.Exp(gap));
    }

    public void Estimate(int rounds = 30, double precision = 0.01)
    {

    }
}