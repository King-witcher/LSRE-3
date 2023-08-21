using System.Runtime.InteropServices;

namespace LSRE_3;

internal unsafe struct Player
{
    const int MAX_NAME_SIZE = 50;

    public fixed char Name[MAX_NAME_SIZE];
    public double LSR;

    internal LinkedList<Player> victories;
    internal LinkedList<Player> defeats;
}