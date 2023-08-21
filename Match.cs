
namespace LSRE_3;

internal unsafe struct Match
{
    Player* winner;
    Player* loser;
}

unsafe struct MatchList<T> where T : unmanaged
{
    T* node;
}