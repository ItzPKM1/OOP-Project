
namespace DeliverySystemProject
{
<<<<<<< HEAD
    public class Drone : Vehicle
    {
        private double maxDistance;
        public Drone(int id, string name, DateTime createdDate, double speed, double maxCapacity, double maxDistance) : base(id, name, createdDate, speed, maxCapacity)
        {
            this.maxDistance = maxDistance;
        }
=======
    private double maxDistance;
    public Drone(int id, string name, DateTime createdDate, double speed, double maxCapacity, double maxDistance) : base(id, name, createdDate, speed, maxCapacity)
    {
        this.maxDistance = maxDistance;
    }

    public override void Deliver(List<Package> packages)
    {
        //*not done*
    }
>>>>>>> 39c9ed9de8d794a5999ec3f77372b42aa3d8ec22

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