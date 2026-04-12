using deliverySystem.CustomException;
namespace deliverySystem.Model
{
    public abstract class Vehicle : Entity
    {
        private double speed;
        private double maxCapacity;
        private double currentLoad;
        private bool isAvailable;


        public Vehicle(int id, string name, DateTime createdDate,double speed, double maxCapacity,double currentLoad,bool isAvailable) : base(id, name, createdDate)
        {
            this.speed = speed;
            this.maxCapacity = maxCapacity;
            this.currentLoad = currentLoad;
            this.isAvailable = isAvailable;
        }

        public double GetSpeed()
        {
            return speed;
        }

        public void SetSpeed(double speed)
        {
            this.speed =  speed  ;
        }
        public double GetMaxCapacity()
        {
            return maxCapacity;
        }

        public void SetMaxCapacity(double maxCapacity)
        {
            if(maxCapacity < 0)
            {
                throw new Exception("Max capacity can't be less than 0");
            }
            this.maxCapacity = maxCapacity;
        }
        public double GetCurrentLoad()
        {
            return currentLoad;
        }

        public void SetCurrentLoad(double currentLoad)
        {
            if(currentLoad > maxCapacity)
            {
                throw new CustomException.CustomException.OverCapacityException("Vehicle cannot be greater than max cap");
            }
            this.currentLoad =  currentLoad  ;
        }
        public bool GetIsAvailable()
        {
            return isAvailable;
        }

        public void SetIsAvailable(bool isAvailable)
        {
            this.isAvailable = isAvailable;
        }
        public double GetRemainingCapacity()
        {
            return  maxCapacity - currentLoad;
        }

        public virtual double CalculateEfficiency()
        {
            return  speed / maxCapacity; // project says based on speed and load.
        }

        public abstract void Deliver(List<Package> packages);
        
        public override void DisplayInfo()
        {
            Console.WriteLine("Your id is " + GetId());
            Console.WriteLine("Your name is " + GetName());
            Console.WriteLine("Your created date is " + GetCreatedDate());
            Console.WriteLine("Your speed is " + GetSpeed());
            Console.WriteLine("Your max capacity is " + GetMaxCapacity());
            
            
        }
    }
}