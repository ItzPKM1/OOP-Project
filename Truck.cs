public class Truck : Vehicle
{
    private double fuelConsumption;
    public Truck(int id, string name, DateTime createdDate, double speed, double maxCapacity, double fuelConsumption) : base(id, name, createdDate, speed, maxCapacity)
    {
        this.fuelConsumption = fuelConsumption;
    }

    public override void Deliver(List<Package> packages)
    {
        //*not done*
    }

    public  override double CalculateEfficiency()
    {
        return base.CalculateEfficiency() / fuelConsumption; // project says based on speed and load, but also consider fuel consumption.
    }
    
}