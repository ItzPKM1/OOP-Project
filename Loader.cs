public class Loader : Worker
{
    private double maxLiftWeight;
    public Loader(int experienceYears, int tasksCompleted, bool isAvailable, double maxLiftWeight) : base(experienceYears, tasksCompleted, isAvailable)
    {
        this.maxLiftWeight = maxLiftWeight;
    }

    public double GetMaxLiftWeight()
    {
        return maxLiftWeight;
    }

    public void SetMaxLiftWeight(double maxLiftWeight) //fixed setter name.
    {
        this.maxLiftWeight =  maxLiftWeight;
    }
    public double CalculatePriorityScore()//check again
    {
          
         return  experienceYears *  tasksCompleted;
       
    }
   
   

    
    public override void DisplayInfo()
    {
       
        Console.WriteLine("Your experience years are " + GetExperienceYears());
        Console.WriteLine("Your tasks completed are " + GetTasksCompleted());
        Console.WriteLine("Your availability is " + GetIsAvailable());
        Console.WriteLine("Your max lift weight is : " + GetMaxLiftWeight());
    }
    
   
}