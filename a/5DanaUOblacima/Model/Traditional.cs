namespace _5DanaUOblacima.Model
{
    public class Traditional
    {
        public Stats FreeThrows { get; set; }
        public Stats TwoPoints { get; set; }
        public Stats ThreePoints { get; set; }
        public Traditional(Stats freeThrows, Stats twoPoints, Stats threePoints)
        {
            this.FreeThrows = freeThrows; this.TwoPoints = twoPoints; this.ThreePoints = threePoints;
        }
        public void SetTraditional(int FTM, int FTA, int M2P, int A2P, int M3P, int A3P, int gamesPlayed)
        {
            this.FreeThrows.setStats(FTA, FTM, gamesPlayed);
            this.TwoPoints.setStats(A2P, M2P, gamesPlayed); 
            this.ThreePoints.setStats(A3P, M3P, gamesPlayed);
        }

    }
}
