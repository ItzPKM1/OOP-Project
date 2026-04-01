public class Manager : Worker
{
    private int teamSize;
    public Manager(int id, string name, DateTime createdDate, double speed, double maxCapacity, int teamSize) : base(id, name, createdDate, speed, maxCapacity)
    {
        this.teamSize = teamSize;
    }

    public Worker FindBestWorker(List<Worker> workers) //initialize list of workers.
    {
        Worker bestWorker = null;
        double bestPerformance = 0;
        for (int i = 0; i < workers.Count; i++)
        {
            double performance = workers[i].CalculateEfficiency();
            if (performance > bestPerformance)
            {
                bestPerformance = performance;
                bestWorker = workers[i];
            }
        }
        return bestWorker;
    }

    
    public override void  PerformTask()
    {
        Console.WriteLine(name + " is managing a team of " + teamSize + " workers.");
    }
    
    
}