public abstract class Vehicle : Entity
{
    private double speed;
    private double maxCapacity;
    private double currentLoad;
    private bool isAvailable;


    public Vehicle(int id, string name, DateTime createdDate,double speed, double maxCapacity,double currentLoad,bool isAvailable) : base(id, name, createdDate)
    {
        this.speed = speed;
        this.maxCapacity = maxCapacity;
        this.currentLoad = 0;
        this.isAvailable = true;
    }

    //getters and setters
    public double GetSpeed()
    {
        return speed;
    }
    public void SetSpeed(double speed)
    {
        this.speed = speed;
    }

    public double GetMaxCapacity()
    {
        return maxCapacity;
    }

    public void SetCapacity(double capacity)
    {
        if(GetMaxCapacity() <= 0)
        {
            throw new Exception("your capacity can't be less than 0");
        }
        this.maxCapacity = capacity;
    }
    public double GetCurrentLoad()
    {
        return currentLoad;
    }
    public void SetCurrentLoad(double load)
    {
        this.currentLoad = load;
    }
    public bool GetIsAvailable()
    {
        return isAvailable;
    }
    public void SetIsAvailable(bool available)
    {
        this.isAvailable = available;
    }

    public void SetCapacity(double capacity)
    {
        
    }

    public double GetRemainingCapacity()
    {
        return maxCapacity - currentLoad;
    }

    public virtual double CalculateEfficiency()
    {
        return speed / currentLoad; // project says based on speed and load.
    }

    public abstract void Deliver(List<Package> packages);
    
    public override void DisplayInfo()
    {
        Console.WriteLine("Your id is " + GetId());
        Console.WriteLine("Your name is " + GetName());
        Console.WriteLine("Your created date is " + GetCreatedDate());
        Console.WriteLine("Your speed is " + GetSpeed());
        Console.WriteLine("Your max capacity is " + GetMaxCapacity());
        
        
    }
}