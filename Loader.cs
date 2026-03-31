public class Loader : Worker
{
    private double maxLiftWeight;
    public Loader(int id, string name, DateTime createdDate, double speed, double maxCapacity, double maxLiftWeight) : base(id, name, createdDate, speed, maxCapacity)
    {
        this.maxLiftWeight = maxLiftWeight;
    }
    @Override PerformTask()
    {
        //*not done*
    }
    
}