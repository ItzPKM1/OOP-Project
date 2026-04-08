public class Drone : Vehicle
{
    private double maxDistance;
    public Drone(double speed, double maxCapacity,double currentLoad,bool isAvailable, double maxDistance) : base( speed,  maxCapacity,currentLoad,isAvailable)
    {
        this.maxDistance = maxDistance;
    }

    public double GetMaxDistance() //added getter for maxDistance
    {
        return maxDistance;
    }
    public void SetMaxDistance(double maxDistance) //added setter for maxDistance
    {
        this.maxDistance = maxDistance;
    }

    public override void Deliver(List<Package> packages)
    {
         foreach(Package package in packages)
        {
            if ( package.GetWeight() <50)
            {
                Console.WriteLine("this package is considered lightly weight");
                package.UpdateStatus("Delivered");
            }
        }
    }

    public override double CalculateEfficiency()
    {
            if(maxDistance <= 0)
            {
                throw new Exception("Max distance should be greater than 0");
            }

        return base.CalculateEfficiency() / maxDistance; // project says based on distance.
    }

    public override void DisplayInfo()
    {
        
        Console.WriteLine("Is it available " + GetIsAvailable());
        Console.WriteLine("Your current load :" + GetCurrentLoad());
        Console.WriteLine("Your speed is " + GetSpeed());
        Console.WriteLine("Your max capacity is " + GetMaxCapacity());
        Console.WriteLine("Your max distance is " + GetMaxDistance());
    }
    
}