public class Drone : Vehicle
{
    private double maxDistance;
    public Drone(int id, string name, DateTime createdDate, double speed, double maxCapacity, double maxDistance) : base(id, name, createdDate, speed, maxCapacity)
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
        //*not done*
        //for (int i = 0; i < packages.Count; i++)
        //{
        //    // Deliver each package
        //}
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
        Console.WriteLine("Your name is " + GetName());
        Console.WriteLine("Your ID is " + GetId());
        Console.WriteLine("Your created date is " + GetCreatedDate());
        Console.WriteLine("Your speed is " + GetSpeed());
        Console.WriteLine("Your max capacity is " + GetMaxCapacity());
        Console.WriteLine("Your max distance is " + GetMaxDistance());
    }
    
}