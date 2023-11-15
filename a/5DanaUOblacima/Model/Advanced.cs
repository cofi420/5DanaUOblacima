namespace _5DanaUOblacima.Model
{
    public class Advanced
    {
        public double valorization { get; set; }
        public double effectiveFieldGoalPercentage { get; set; }
        public double trueShootingPercentage { get; set; }
        public double hollingerAssistRatio { get; set; }
        public Advanced(int FTM, int FTA, int M2P, int A2P, int M3P, int A3P, int REB, int BLK, int AST, int STL, int TOV)
        {
            this.valorization = (FTM + 2 * M2P + 3 * M3P + REB + BLK + AST + STL) - (FTA - FTM + A2P - M2P + A3P - M3P + TOV);
            if (A2P + A3P != 0)
            {
                this.effectiveFieldGoalPercentage = (M2P + M3P + 0.5 * M3P) / (A2P + A3P) * 100;
            }
            else
            {
                this.effectiveFieldGoalPercentage = 0;
            }
            if (A2P + A3P + 0.475 * FTA != 0)
            {
                this.trueShootingPercentage = (FTM + 2 * M2P + 3 * M3P) / (2 * (A2P + A3P + 0.475 * FTA)) * 100;
            }
            else
            {
                this.trueShootingPercentage = 0;
            }
            if (A2P + A3P + 0.475 * FTA + AST + TOV != 0)
            {
                this.hollingerAssistRatio = AST / (A2P + A3P + 0.475 * FTA + AST + TOV) * 100;
            }
            else
            {
                this.hollingerAssistRatio = 0;
            }
        }
        public void SetAdvanced(int FTM, int FTA, int M2P, int A2P, int M3P, int A3P, int REB, int BLK, int AST, int STL, int TOV, int gamesPlayed)
        {
            this.valorization = (this.valorization + (FTM + 2 * M2P + 3 * M3P + REB + BLK + AST + STL) - (FTA - FTM + A2P - M2P + A3P - M3P + TOV)) / gamesPlayed;
                
            if (A2P + A3P != 0)
            {
                this.effectiveFieldGoalPercentage = (this.effectiveFieldGoalPercentage + (M2P + M3P + 0.5 * M3P) / (A2P + A3P) * 100) / gamesPlayed;
            }
            if (A2P + A3P + 0.475 * FTA != 0)
            {
                this.trueShootingPercentage = (this.trueShootingPercentage + (FTM + 2 * M2P + 3 * M3P) / (2 * (A2P + A3P + 0.475 * FTA)) * 100) / gamesPlayed;
            }
            if (A2P + A3P + 0.475 * FTA + AST + TOV != 0)
            {
                this.hollingerAssistRatio = (this.hollingerAssistRatio + AST / (A2P + A3P + 0.475 * FTA + AST + TOV) * 100) / gamesPlayed;
            }
        }
    }
}
