using Microsoft.VisualBasic.FileIO;

namespace _5DanaUOblacima.Service.PlayerService
{
    public class PlayerService : IPlayerService
    {
        private static List<Player> players = new();
        private static Dictionary<string, Player> playersMap = new Dictionary<string, Player>();
        public PlayerService()
        {
            string csvFilePath = "resources/L9HomeworkChallengePlayersInput.csv";
            players = ParseCSV(csvFilePath);
        }
        static List<Player> ParseCSV(string filePath)
        {
            List<Player> playerList = new List<Player>();

            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // Skip the header line
                if (!parser.EndOfData)
                {
                    parser.ReadLine();
                }

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    Player player = new(fields[0], fields[1], Int32.Parse(fields[2]), Int32.Parse(fields[3]), Int32.Parse(fields[4]), Int32.Parse(fields[5]), Int32.Parse(fields[6]), Int32.Parse(fields[7]), Int32.Parse(fields[8]), Int32.Parse(fields[9]), Int32.Parse(fields[10]), Int32.Parse(fields[11]), Int32.Parse(fields[12]));
                    if (playersMap.ContainsKey(fields[0]))
                    {
                        playersMap[fields[0]].setPlayer(Int32.Parse(fields[2]), Int32.Parse(fields[3]), Int32.Parse(fields[4]), Int32.Parse(fields[5]), Int32.Parse(fields[6]), Int32.Parse(fields[7]), Int32.Parse(fields[8]), Int32.Parse(fields[9]), Int32.Parse(fields[10]), Int32.Parse(fields[11]), Int32.Parse(fields[12]));

                    }
                    else
                    {
                        playersMap.Add(fields[0], player);
                        playerList.Add(player);
                    }
                }
            }

            return playerList;
        }
        public List<Player> GetAllPlayers()
        {
            return players;
        }

        public Player? GetSinglePlayer(string name)
        {
            var player = players.Find(x => x.PlayerName == name);
            if (player == null) { return null; }
            return player;
        }
    }
}
