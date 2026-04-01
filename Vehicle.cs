public abstract class Vehicle : Entity
{
    private double speed;
    private double maxCapacity;
    private double currentLoad;
    private bool isAvailable;


    public Vehicle(int id, string name, DateTime createdDate,double speed, double maxCapacity) : base(id, name, createdDate)
    {
        this.speed = speed;
        this.maxCapacity = maxCapacity;
        this.currentLoad = 0;
        this.isAvailable = true;
    }

    public double GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(double speed)
    {
        this.speed =  speed  ;
    }
    public int GetMaxCapacity()
    {
        return maxCapacity;
    }

    public void SetMaxCapacity(double maxCapacity)
    {
        if(maxCapacity < 0)
        {
            throw new Exception("Max capacity can't be less than 0");
        }
        this.maxCapacity = maxCapacity;
    }
    public int GetIsAvailable()
    {
        return isAvailable;
    }

    public void SetIsAvailable(bool isAvailable)
    {
        this.isAvailable = isAvailable;
    }
    public double GetRemainingCapacity()
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
        Console.WriteLine("Your speed is " + GetSpeed());
        Console.WriteLine("Your speed is " + GetSpeed());
        Console.WriteLine("Your speed is " + GetSpeed());
        Console.WriteLine("Your speed is " + GetSpeed());
        Console.WriteLine("Your speed is " + GetSpeed());
        //Not done
        
    }
}