public class Manager : Worker
{
    private int teamSize;
    public Manager(int id, string name, DateTime createdDate, double speed, double maxCapacity, int teamSize) : base(id, name, createdDate, speed, maxCapacity)
    {
        this.teamSize = teamSize;
    }

    Worker FindBestWorker()
    {
        //return the best worker
    }
    public override void  PerformTask()
    {
        Dontunderstand
    }
    
}