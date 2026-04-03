public class Manager : Worker
{
    private int teamSize;
    public Manager(int id, string name, DateTime createdDate, double speed, double maxCapacity, int teamSize, bool isAvailable) : base(id, name, createdDate, speed, maxCapacity, isAvailable)
    {
        this.teamSize = teamSize;
    }

    public Worker FindBestWorker(List<Worker> workers) //initialize list of workers.
    {
        Worker bestWorker = null;
        double bestPerformance = 0;
        
        for (int i = 0; i < workers.Count; i++)
        {
            double performance = workers[i].CalculatePerformance(); // fixed to performance, not efficiency.
            if (bestWorker == null || performance > bestPerformance) // fixed. bestPerformance = 0 can fail if all workers have negative performance, so we check for bestWorker == null first.
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