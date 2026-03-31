public abstract class Vehicle : Entity
{
    double speed;
    double maxCapacity;
    double currentLoad;
    bool isAvailable;


    public Vehicle(double speed, double maxCapacity) : base(id, name, createdDate)
    {
        this.speed = speed;
        this.maxCapacity = maxCapacity;
        this.currentLoad = 0;
        this.isAvailable = true;
    }

    public void setCapacity(double capacity)
    {
        
    }

    public double getRemainingCapacity()
    {
        return maxCapacity - currentLoad;
    }

    public virtual double CalculateEfficiency()
    {
        return speed / maxCapacity; // project says based on speed and load.
    }

    public abstract void Deliver(List<Package> packages);
    
    public override void DisplayInfo()
    {
        Console.WriteLine("Your speed is " + GetSpeed())
        
    }
}