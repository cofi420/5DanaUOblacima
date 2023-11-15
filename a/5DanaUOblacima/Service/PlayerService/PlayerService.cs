using _5DanaUOblacima.Model;
using Microsoft.OpenApi.Validations;
using Microsoft.VisualBasic.FileIO;
using System.Xml.Linq;

namespace _5DanaUOblacima.Service.PlayerService
{
    public class PlayerService : IPlayerService
    {
        private static List<Player> players = new List<Player>();
        private static Dictionary<string, Player> playersMap = new Dictionary<string, Player>();
        public PlayerService()
        {
            players = new List<Player>();
            string csvFilePath = "resources/L9HomeworkChallengePlayersInput.csv";
            ParseCSV(csvFilePath);
        }
        static bool IsPlayerInList(string playerName)
        {
            foreach(var player in players)
            {
                Console.WriteLine(player.PlayerName + "\t" +  playerName);
                if (player.PlayerName.Equals(playerName))
                {
                    return true;
                }
            }
            return false;
        }
        static void ParseCSV(string filePath)
        {
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
                    if (playersMap.ContainsKey(fields[0]))
                    {
                        playersMap[fields[0]].setPlayer(Int32.Parse(fields[2]), Int32.Parse(fields[3]), Int32.Parse(fields[4]), Int32.Parse(fields[5]), Int32.Parse(fields[6]), Int32.Parse(fields[7]), Int32.Parse(fields[8]), Int32.Parse(fields[9]), Int32.Parse(fields[10]), Int32.Parse(fields[11]), Int32.Parse(fields[12]));
                    }
                    else
                    {
                        Player player = new(fields[0], fields[1], Int32.Parse(fields[2]), Int32.Parse(fields[3]), Int32.Parse(fields[4]), Int32.Parse(fields[5]), Int32.Parse(fields[6]), Int32.Parse(fields[7]), Int32.Parse(fields[8]), Int32.Parse(fields[9]), Int32.Parse(fields[10]), Int32.Parse(fields[11]), Int32.Parse(fields[12]));
                        players.Add(player);
                        playersMap.Add(fields[0], player);
                    }
                }
            }
        }
        public List<Player> GetAllPlayers()
        {
            return players;
        }

        public Player? GetSinglePlayer(string name)
        {
            if (playersMap.ContainsKey(name)) return playersMap[name];
            return null;
        }
    }
}
