public class Drone : Vehicle
{
    private double maxDistance;
    public Drone(double speed, double maxCapacity, double maxDistance) : base( speed, maxCapacity)
    {
        this.maxDistance = maxDistance;
    }
    public double GetMaxDistance()
    {
        return maxDistance;
    }

    public void SetMaxDistance(double maxDistance)
    {
        this.maxDistance = maxDistance  ;
    }

    public override void  Deliver(List<Package> packages)
    {
        //*not done*
    }

    public override double  CalculateEfficiency()
    {
        return base.CalculateEfficiency() * maxDistance ; // project says based on distance.
    }
    public override void DisplayInfo()
    {
        Console.WriteLine("Max distance is : " + GetMaxDistance());
    }
}