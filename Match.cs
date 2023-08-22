
using System.Runtime.InteropServices;

namespace LSRE_3;

internal unsafe struct Match
{
    public Player* winner;
    public Player* loser;

    public static Match* Alloc(Player* winner, Player* loser)
    {
        var match = (Match*)Marshal.AllocHGlobal(sizeof(Match));
        match->winner = winner;
        match->loser = loser;
        return match;
    }
}