public class Truck : Vehicle
{
    private double fuelConsumption;
    public Truck(double speed, double maxCapacity,double currentLoad,bool isAvailable,double fuelConsumption) : base(speed,  maxCapacity, currentLoad, isAvailable)
    {
        this.fuelConsumption = fuelConsumption;
    }

    public override void Deliver(List<Package> packages)
    {
        foreach(Package package in packages)
        {
            if (package.IsHeavy())
            {
                Console.WriteLine("this package is considered heavy");
                package.UpdateStatus("Delivered");
            }
            
        }
    }

    public  override double CalculateEfficiency()
    {
        if(fuelConsumption <= 0)
        {
            throw new Exception("Fuel consumption should be greater than 0");
        }
        return base.CalculateEfficiency() / fuelConsumption; // project says based on speed and load, but also consider fuel consumption.
    }
    
}