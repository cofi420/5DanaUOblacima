namespace _5DanaUOblacima.Model
{
    public class Advanced
    {
        public double valorization { get; set; }
        public double effectiveFieldGoalPercentage { get; set; }
        public double trueShootingPercentage { get; set; }
        public double hollingerAssistRatio { get; set; }
        public Advanced(int FTM, double FTA, double M2P, double A2P, double M3P, double A3P, double REB, double BLK, double AST, double STL, double TOV)
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
        public void SetAdvanced(double FTM, double FTA, double M2P, double A2P, double M3P, double A3P, double REB, double BLK, double AST, double STL, double TOV)
        {
            
            this.valorization +=  (FTM + 2 * M2P + 3 * M3P + REB + BLK + AST + STL) - (FTA - FTM + A2P - M2P + A3P - M3P + TOV);
                
            if (A2P + A3P != 0)
            {
                this.effectiveFieldGoalPercentage +=  (M2P + M3P + 0.5 * M3P) / (A2P + A3P) * 100;
            }
            if (A2P + A3P + 0.475 * FTA != 0)
            {
                this.trueShootingPercentage += (FTM + 2 * M2P + 3 * M3P) / (2 * (A2P + A3P + 0.475 * FTA)) * 100;
            }
            if (A2P + A3P + 0.475 * FTA + AST + TOV != 0)
            {
                this.hollingerAssistRatio += AST / (A2P + A3P + 0.475 * FTA + AST + TOV) * 100;
            }
        }
        public void CalculateAverage(int gamesPlayed)
        {
            this.valorization = Math.Round(this.valorization / gamesPlayed, 1);
            this.effectiveFieldGoalPercentage = Math.Round(this.effectiveFieldGoalPercentage / gamesPlayed, 1);
            this.trueShootingPercentage = Math.Round(this.trueShootingPercentage / gamesPlayed, 1);
            this.hollingerAssistRatio = Math.Round(this.hollingerAssistRatio / gamesPlayed, 1);
        }
    }
}
