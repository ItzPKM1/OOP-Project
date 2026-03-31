public abstract class Worker : Entity
{
    private int experienceYears;
    private int tasksCompleted;
    private bool isAvailable;


    public Worker(int experienceYears, int tasksCompleted, bool isAvailable) : base(id, name, createdDate)
    {
        this.experienceYears = experienceYears;
        this.tasksCompleted = tasksCompleted;
        this.isAvailable = isAvailable;
    }

    public void addTask ()
    {
        
    }

    public virtual double CalculatePerformance()
    {
        
    }

    public abstract void PerformTask();
    
    
}