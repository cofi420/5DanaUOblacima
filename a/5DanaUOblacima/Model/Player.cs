﻿namespace _5DanaUOblacima.Model
{
    public class Player
    {
        public string? PlayerName { get; set; }
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

        public Player(){ }
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
            this.GamesPlayed = 0;
            this.Traditional = new Traditional(new Stats(FTA, FTM, (FTM/FTA)*100), new Stats(A2P, M2P, (M2P/A2P)*100), new Stats(A3P, M3P, (M3P / A3P) * 100));
            this.Points = FTM + 2 * M2P + 3 * M3P;
            this.Rebounds = REB;
            this.Blocks = BLK;
            this.Assists = AST;
            this.Steals = STL;
            this.Turnovers = TOV;
            this.Advanced = new Advanced();
        }
        public void setPlayer(int FTM, int FTA, int M2P, int A2P, int M3P, int A3P, int REB, int BLK, int AST, int STL, int TOV)
        {
            this.GamesPlayed++;
            //TODO this.Traditional
            this.Points = (FTM + 2 * M2P + 3 * M3P) / this.GamesPlayed;
            this.Rebounds = (this.Rebounds + REB) / this.GamesPlayed;
            this.Blocks = BLK;
            this.Assists = AST;
            this.Steals = STL;
            this.Turnovers = TOV;
        }
    }
}