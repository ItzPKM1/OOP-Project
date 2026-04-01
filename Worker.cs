using System.Diagnostics;

public abstract class Worker : Entity
{
    private int experienceYears;
    private int tasksCompleted;
    private bool isAvailable;


    public Worker(int id, string name, DateTime createdDate,int experienceYears, int tasksCompleted, bool isAvailable) : base(id, name, createdDate)
    {
        this.experienceYears = experienceYears;
        this.tasksCompleted = tasksCompleted;
        this.isAvailable = isAvailable;
    }
    public int GetExperienceYears()
    {
        return experienceYears;
    }

    public void SetExperienceYears(int experienceYears)
    {
        this.experienceYears = experienceYears  ;
    }
    public int GetTasksCompleted()
    {
        return tasksCompleteds;
    }

    public void SetTaskCompleted(int taskCompleted)
    {
        this.tasksCompleted = taskCompleted  ;
    }
    public bool GetIsAvailable()
    {
        return isAvailable;
    }

    public void SetIsAvailable(bool isAvailable)
    {
        this.isAvailable = isAvailable ;
    }
    
    public void AddTask()
    {
        tasksCompleted++;
        Console.WriteLine("Task completed : " + tasksCompleted);
    }


    public virtual double CalculatePerformance()
    {
        Console.WriteLine("Your perfomance is");
        return experienceYears * tasksCompleted;
    }

    public abstract void PerformTask();
    
    
}