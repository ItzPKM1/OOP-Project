namespace deliverySystem.Model
{
public class Manager : Worker
{
    private int teamSize;
    public Manager(int experienceYears, int tasksCompleted, bool isAvailable, int teamSize) : base(experienceYears, tasksCompleted, isAvailable)
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

    public override void DisplayInfo()
    {
        Console.WriteLine("Your experience years are " + GetExperienceYears());
        Console.WriteLine("Your tasks completed are " + GetTasksCompleted());
        Console.WriteLine("Your availability is " + GetIsAvailable());
        Console.WriteLine("Your team size is : " + teamSize);
    }
}
}