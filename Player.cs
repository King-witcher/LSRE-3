namespace LSRE_3;

internal unsafe struct Player
{
    const int MAX_NAME_SIZE = 50;

    public fixed char Name[MAX_NAME_SIZE];
    public double LSR;

    internal LinkedList<Player> victories;
    internal LinkedList<Player> defeats;

    public double RatingLikelihood(double rating)
    {
        double p = 1.0;

        victories.ForEach(player =>
        {
            p *= RatingModel.P_Result(rating, player->LSR);
        });
        defeats.ForEach(player =>
        {
            p *= RatingModel.P_Result(player->LSR, rating);
        });

        return p;
    }

    public void ApproximateRating(double dx)
    {
        double universe = Calculus.IntegralR(RatingLikelihood, dx);
        double average = Calculus.AverageR(RatingLikelihood, universe, dx);
        LSR = average;
    }
}