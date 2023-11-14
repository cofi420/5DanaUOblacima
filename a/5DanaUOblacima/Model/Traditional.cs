namespace _5DanaUOblacima.Model
{
    public class Traditional
    {
        public Stats FreeThrows { get; set; }
        public Stats TwoPoints { get; set; }
        public Stats ThreePoints { get; set; }
        public Traditional() { }
        public Traditional(Stats freeThrows, Stats twoPoints, Stats threePoints)
        {
            this.FreeThrows = freeThrows; this.TwoPoints = twoPoints; this.ThreePoints = threePoints;
        }

    }
}
