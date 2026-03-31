public class Driver : Worker
{
    private string licenseType;
    public Driver(int id, string name, DateTime createdDate, double speed, double maxCapacity, string licenseType) : base(id, name, createdDate, speed, maxCapacity)
    {
        this.licenseType = licenseType;
    }

    @Override PerformTask()
    {
        //*not done*
    }
    
}