namespace deliverySystem.Model
{
public class Van : Vehicle
{
    private bool isElectric;
    public Van(int id, string name, DateTime createdDate,double speed, double maxCapacity,double currentLoad,bool isAvailable, bool isElectric) : base(id, name, createdDate, speed, maxCapacity, currentLoad, isAvailable)
    {
        this.isElectric = isElectric;
        
    }
    
    public bool GetIsElectric()
    {
        return isElectric;
    }

    public override void Deliver(List<Package> packages)
    {
        foreach(Package package in packages)
        {
            if (!package.IsHeavy()  && package.GetWeight() >=50)
            {
                Console.WriteLine("this package is considered medium");
                package.UpdateStatus("Delivered");
            }
        }
    }
}
}