using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSRE_3;

class RatingModel
{
    History history;

    public static double P_Result(double rw, double rl)
    {
        return 1 / (1 + Math.Exp(rl - rw));
    }

    public double P_Result(Player winner, Player loser)
    {
        double gap = loser.LSR - winner.LSR;
        return 1 / (1 + Math.Exp(gap));
    }

    public void Estimate(int rounds = 30, double precision = 0.01)
    {

    }
}