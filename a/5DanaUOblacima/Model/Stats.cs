namespace _5DanaUOblacima.Model
{
    public class Stats
    {
        public double Attempts { get; set; }
        public double Made { get; set; }
        public double ShootingPercentage { get; set; }
        public Stats()
        {
            
        }
        public Stats(double attempts, double made)
        {
            this.Attempts = attempts;
            this.Made = made;
            if (this.Made > 0)
            {
            this.ShootingPercentage = made / attempts * 100;
            }
            else
            {
                this.ShootingPercentage = 0;
            }
        }
        public void setStats(double attempts, double made, int gamesPlayed) 
        {
            this.Attempts = (this.Attempts * (gamesPlayed - 1) + attempts) / gamesPlayed;
            this.Made = (this.Made * (gamesPlayed - 1) + made) / gamesPlayed;
            if (this.Made > 0)
            {
                this.ShootingPercentage = this.Made / this.Attempts * 100;
            }
            else
            {
                this.ShootingPercentage = 0;
            }
        }
    }
}
