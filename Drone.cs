
namespace Drone
{
     public class Drone : Vehicle
    {
        private double maxDistance;
        public Drone(double speed, double maxCapacity,double currentLoad,bool isAvailable, double maxDistance) : base( speed,  maxCapacity,currentLoad,isAvailable)
        {
            this.maxDistance = maxDistance;
        }
    

    

        public override void Deliver(List<Package> packages)
        {
            //*not done*
        }

        public override double CalculateEfficiency()
        {
            return base.CalculateEfficiency() / maxDistance; // project says based on distance.
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Max distance is : " + GetMaxDistance());
        }
        
    }
}