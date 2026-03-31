public class Van : Vehicle
{
    private bool isElectric;
    public Van(int id, string name, DateTime createdDate, double speed, double maxCapacity, bool isElectric) : base(id, name, createdDate, speed, maxCapacity)
    {
        this.isElectric = isElectric;
    }

    @Override Deliver(List<Package> packages)
    {
        //*not done*
    }
    
}