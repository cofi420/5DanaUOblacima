using System.Formats.Asn1;
using System.Globalization;
using Newtonsoft.Json;

namespace _5DanaUOblacima.Model
{
    public class Player
    {
        [JsonConverter(typeof(CustomDoubleConverter))]
        public string PlayerName { get; set; }
        public string? Position { get; set; }
        public int GamesPlayed { get; set; }
        public Traditional? Traditional { get; set; }
        public double Points { get; set; }
        public double Rebounds { get; set; }
        public double Blocks { get; set; }
        public double Assists { get; set; }
        public double Steals { get; set; }
        public double Turnovers { get; set; }
        public Advanced? Advanced { get; set; }

        public Player(string playerName, string position, int gamesPlayed, Traditional traditional, double points, double rebounds, double blocks, double assists, double steals, double turnovers, Advanced advanced)
        {
            this.PlayerName = playerName;
            this.Position = position;
            this.GamesPlayed = gamesPlayed;
            this.Traditional = traditional;
            this.Points = points;
            this.Rebounds = rebounds;
            this.Blocks = blocks;
            this.Assists = assists;
            this.Steals = steals;
            this.Turnovers = turnovers;
            this.Advanced = advanced;
        }
        public Player(string playerName, string position, int FTM, int FTA, int M2P, int A2P, int M3P, int A3P, int REB, int BLK, int AST, int STL, int TOV)
        {
            this.PlayerName = playerName;
            this.Position = position;
            this.GamesPlayed = 1;
            this.Traditional = new Traditional(new Stats(FTA, FTM), new Stats(A2P, M2P), new Stats(A3P, M3P));
            this.Points = FTM + 2 * M2P + 3 * M3P;
            this.Rebounds = REB;
            this.Blocks = BLK;
            this.Assists = AST;
            this.Steals = STL;
            this.Turnovers = TOV;
            this.Advanced = new Advanced(FTM, FTA, M2P, A2P, M3P, A3P, REB, BLK, AST, STL, TOV);
        }
        public void setPlayer(int FTM, int FTA, int M2P, int A2P, int M3P, int A3P, int REB, int BLK, int AST, int STL, int TOV)
        {
            this.GamesPlayed++;
            Traditional.SetTraditional(FTM, FTA, M2P, A2P, M3P, A3P, GamesPlayed);
            this.Points = (this.Points * (this.GamesPlayed - 1) + (FTM + 2 * M2P + 3 * M3P)) / this.GamesPlayed;
            this.Rebounds = (this.Rebounds * (this.GamesPlayed - 1) + REB) / this.GamesPlayed;
            this.Blocks = (this.Blocks * (this.GamesPlayed - 1) + BLK) / this.GamesPlayed;
            this.Assists = (this.Assists * (this.GamesPlayed - 1) + AST) / this.GamesPlayed;
            this.Steals = (this.Steals * (this.GamesPlayed - 1) + STL) / this.GamesPlayed;
            this.Turnovers = (this.Turnovers * (this.GamesPlayed - 1) + TOV) / this.GamesPlayed;
            Advanced.SetAdvanced(Convert.ToDouble(FTM) , Convert.ToDouble(FTA), Convert.ToDouble(M2P), Convert.ToDouble(A2P), Convert.ToDouble(M3P), Convert.ToDouble(A3P), Convert.ToDouble(REB), Convert.ToDouble(BLK), Convert.ToDouble(AST), Convert.ToDouble(STL), Convert.ToDouble(TOV), this.GamesPlayed);
            //TODO fix setAdvanced
        }
    }
    public class CustomDoubleConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            double doubleValue = (double)value;
            string formattedValue = doubleValue.ToString("F1", CultureInfo.InvariantCulture);
            writer.WriteValue(formattedValue);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(double);
        }
    }
}
