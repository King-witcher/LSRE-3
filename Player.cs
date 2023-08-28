namespace LSRE_3;

public unsafe struct Player
{
    const int MAX_NAME_SIZE = 50;

    public fixed char Name[50];
    public double LSR;

    internal LinkedList<Player>* victories;
    internal LinkedList<Player>* defeats;

    public static Player* Alloc(string name)
    {
        if (name.Length >= MAX_NAME_SIZE) throw new ArgumentOutOfRangeException("name");

        Player* result = malloc<Player>();

        int i = 0;
        for (; i < name.Length; i++)
        {
            result->Name[i] = name[i];
        }
        result->Name[i] = '\0';

        result->LSR = 0;
        result->victories = LinkedList<Player>.Alloc();
        result->defeats = LinkedList<Player>.Alloc();

        return result;
    }

    public double RatingLikelihood(double rating)
    {
        double p = 1.0;

        victories->ForEach(player =>
        {
            p *= RatingModel.P_Result(rating, player->LSR);
        });
        defeats->ForEach(player =>
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