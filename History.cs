
namespace LSRE_3
{
    internal unsafe struct History
    {
        LinkedList<Match> matches;

        public void Add(Match* match)
        {
            matches.Add(match);
        }

        public void DefineIndividualPlayerHistories()
        {
            matches.ForEach(match =>
            {
                var winner = match->winner;
                var loser = match->loser;
                winner->victories.Add(loser);
                loser->defeats.Add(winner);
            });
        }
    }
}
