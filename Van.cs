public class Van : Vehicle
{
    private bool isElectric;
    public Van(int id, string name, DateTime createdDate, double speed, double maxCapacity, bool isElectric) : base(id, name, createdDate, speed, maxCapacity)
    {
        this.isElectric = isElectric;
    }

    public override void  Deliver(List<Package> packages)
    {
        //*not done*
    }
    
}