namespace _5DanaUOblacima.Model
{
    public class Stats
    {
        public double Attempts { get; set; }
        public double Made { get; set; }
        public double ShootingPercentage { get; set; }
        private double AttemptsSum = 0;
        private double MadeSum = 0;
        public Stats(double attempts, double made)
        {
            this.AttemptsSum += attempts;
            this.MadeSum += made;
            this.Attempts = Math.Round(attempts, 1);
            this.Made = Math.Round(made, 1);
            if (this.Made > 0)
            {
            this.ShootingPercentage = Math.Round(made / attempts * 100, 1);
            }
            else
            {
                this.ShootingPercentage = 0;
            }
        }
        public void setStats(double attempts, double made, int gamesPlayed) 
        {
            this.AttemptsSum += attempts;
            this.MadeSum += made;
            this.Attempts = Math.Round((this.Attempts * (gamesPlayed - 1) + attempts) / gamesPlayed, 1);
            this.Made = Math.Round((this.Made * (gamesPlayed - 1) + made) / gamesPlayed, 1);
            if (this.Made > 0)
            {
                this.ShootingPercentage = Math.Round((this.MadeSum / this.AttemptsSum * 100) , 1);
            }
            else
            {
                this.ShootingPercentage = 0;
            }
        }
    }
}
