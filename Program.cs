namespace LSRE_3;

internal unsafe class Program
{
    static void Main(string[] args)
    {
        LinkedList<Player> players = new LinkedList<Player>();
        Dictionary<string, IntPtr> playerDictionary = new Dictionary<string, IntPtr>(64);
        History history = new History();
        string input;

        Console.WriteLine("Getting players.");
        while (true) {
            input = Console.ReadLine();
            if (input == "end")
                break;
            string[] inputPlayers = input.Split(' ');
            Player* winner, loser;

            if (playerDictionary.TryGetValue(inputPlayers[0], out var player1))
            {
                winner = (Player*)player1;
            }
            else
            {
                winner = Player.Alloc(inputPlayers[0]);
                players.Add(winner);
                playerDictionary[inputPlayers[0]] = (IntPtr)winner;
            }

            if (playerDictionary.TryGetValue(inputPlayers[1], out var player2))
            {
                loser = (Player*)player2;
            }
            else
            {
                loser = Player.Alloc(inputPlayers[1]);
                players.Add(loser);
                playerDictionary[inputPlayers[1]] = (IntPtr)loser;
            }

            history.Add(Match.Alloc(winner, loser));

        }

        Console.WriteLine("Creating player caches.");
        history.DefineIndividualPlayerHistories();

        Console.WriteLine("Aproximating.");
        players.ForEach(player =>
        {
            player->ApproximateRating(0.00001);
        });

        Console.Clear();

        players.ForEach(player =>
        {
            Console.WriteLine(player->LSR);
        });
    }
}