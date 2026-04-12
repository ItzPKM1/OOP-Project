namespace deliverySystem.Model
{
public class Van : Vehicle
{
    private bool isElectric;
    public Van(double speed, double maxCapacity,double currentLoad,bool isAvailable, bool isElectric) : base(speed,  maxCapacity, currentLoad, isAvailable)
    {
        this.isElectric = isElectric;
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