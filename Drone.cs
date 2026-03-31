public class Drone : Vehicle
{
    private double maxDistance;
    public Drone(int id, string name, DateTime createdDate, double speed, double maxCapacity, double maxDistance) : base(id, name, createdDate, speed, maxCapacity)
    {
        this.maxDistance = maxDistance;
    }

    @Override Deliver(List<Package> packages)
    {
        //*not done*
    }

    @Override CalculateEfficiency()
    {
        return base.CalculateEfficiency() / maxDistance; // project says based on distance.
    }
    
}