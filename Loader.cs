public class Loader : Worker
{
    private double maxLiftWeight;
    public Loader(int experienceYears, int tasksCompleted, bool isAvailable, double maxLiftWeight) : base(experienceYears,  tasksCompleted,  isAvailable)
    {
        this.maxLiftWeight = maxLiftWeight;
    }

    public double GetMaxLiftWeight()
    {
        return maxLiftWeight;
    }

    public void SetMaxWeightLifts(double maxLiftWeight)
    {
        this.maxLiftWeight =  maxLiftWeight;
    }
    public override void PerformTask()
    {
        //*not done*
    }
    
   
}