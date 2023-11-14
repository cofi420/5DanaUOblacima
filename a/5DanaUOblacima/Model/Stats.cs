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
        public Stats(double attempts, double made, double shootingPercentage)
        {
            this.Attempts = attempts;
            this.Made = made;
            this.ShootingPercentage = shootingPercentage;
        }
    }
}
