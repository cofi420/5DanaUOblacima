namespace _5DanaUOblacima.Model
{
    public class Advanced
    {
        public double valorization { get; set; }
        public double effectiveFieldGoalPercentage { get; set; }
        public double trueShootingPercentage { get; set; }
        public double hollingerAssistRatio { get; set; }
        public Advanced()
        {
            
        }
        public Advanced(int FTM, int FTA, int M2P, int A2P, int M3P, int A3P, int REB, int BLK, int AST, int STL, int TOV)
        {
            //(FTM + 2x2PM + 3x3PM + REB + BLK + AST + STL) - (FTA-FTM + 2PA-2PM + 3PA-3PM + TOV)
            this.valorization = (FTM + 2 * M2P + 3 * M3P + REB + BLK + AST + STL) - (FTA - FTM + A2P - M2P + A3P - M3P + TOV);
            //(2PM + 3PM + 0,5 * 3PM) / (2PA + 3PA) * 100
            this.effectiveFieldGoalPercentage = (M2P + M3P + 0.5 * M3P) / (A2P + A3P) * 100;
            //PTS / (2 * (2PA + 3PA +0,475 * FTA)) * 100
            this.trueShootingPercentage = (FTM + 2 * M2P + 3 * M3P) / (2 * (A2P + A3P + 0.475 * FTA)) *100;
            //AST / (2PA + 3PA + 0,475 * FTA + AST + TOV) * 100
            this.hollingerAssistRatio = AST / (A2P + A3P + 0.475 * FTA + AST + TOV) *100;
        }
    }
}
