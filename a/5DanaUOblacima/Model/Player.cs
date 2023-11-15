
namespace _5DanaUOblacima.Model
{
    public class Player
    {
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
            this.Points = Math.Round((this.Points * (this.GamesPlayed - 1) + (FTM + 2 * M2P + 3 * M3P)) / this.GamesPlayed, 1);
            this.Rebounds = Math.Round((this.Rebounds * (this.GamesPlayed - 1) + REB) / this.GamesPlayed, 1);
            this.Blocks = Math.Round((this.Blocks * (this.GamesPlayed - 1) + BLK) / this.GamesPlayed, 1);
            this.Assists = Math.Round((this.Assists * (this.GamesPlayed - 1) + AST) / this.GamesPlayed, 1);
            this.Steals = Math.Round((this.Steals * (this.GamesPlayed - 1) + STL) / this.GamesPlayed, 1);
            this.Turnovers = Math.Round((this.Turnovers * (this.GamesPlayed - 1) + TOV) / this.GamesPlayed, 1);
            Advanced.SetAdvanced(FTM , FTA, M2P, A2P, M3P, A3P, REB, BLK, AST, STL, TOV);
        }
    }
    
}
