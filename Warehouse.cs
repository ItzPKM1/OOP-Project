namespace deliverySystem.Model

{

public class Warehouse : IFileHandler
{
    private string name;
    private List<Package> packages;
    private List<Vehicle> vehicles;
    private List<Worker> workers;
    


    public Warehouse(string name)
    {
        this.name = name;
        workers = new List<Worker>();
        vehicles = new List<Vehicle>();
        packages = new List<Package>();
    }

    public void AddPackage(Package p)
    {
        packages.Add(p);
    }
    public void RemovePackage(int packageId)
    {
        for (int i = 0; i < packages.Count; i++)
        {
            if (packages[i].GetId() == packageId) // fixed because was private.
            {
                packages.RemoveAt(i);
                return;
            }
        }
    }
    public Vehicle FindBestVehicle(Package p)
    {
        if(vehicles.Count == 0)
        {
            throw new CustomException.CustomException.EmptyStructureException("No vehicles in warehouse");
        }

        //based on capacity + efficiency.
        Vehicle bestVehicle = null;
        double bestEfficiency = 0;
        for (int i = 0; i < vehicles.Count; i++)
        {
            
                Vehicle v = vehicles[i];

            if(v.GetCurrentLoad() + p.GetWeight() <= v.GetMaxCapacity())
            {
                double efficiency = v.CalculateEfficiency();

                if(efficiency > bestEfficiency)
                {
                    bestEfficiency = efficiency;
                    bestVehicle = v;
                }
            }
        }
            return bestVehicle;

     }
    public Worker AssignWorker()
    {
        if(workers.Count == 0)
        {
            throw new CustomException.CustomException.EmptyStructureException("No workers in warehouse");
        }
        for(int i = 0; i < workers.Count; i++)
        {
            if (workers[i].GetIsAvailable()) // fixed because was private.
            {
                return workers[i];
            }
        }
        return null; // no available worker
    }

    public void AddVehicle(Vehicle v1)
    {
            vehicles.Add(v1);
    }
    //added remove vehicle method to remove vehicle from vehicles list.
    public void RemoveVehicle(int vehicleId)
    {
        for (int i = 0; i < vehicles.Count; i++)
        {
            if (vehicles[i].GetId() == vehicleId) // fixed because was private.
            {
                vehicles.RemoveAt(i);
                return;
            }
        }
    }

    public void AddWorker(Worker v1)
    {
            workers.Add(v1);
    }
    //added remove worker method to remove worker from workers list.    
    public void RemoveWorker(int workerId)
    {
        for (int i = 0; i < workers.Count; i++)
        {
            if (workers[i].GetId() == workerId) // fixed because was private.
            {
                workers.RemoveAt(i);
                return;
            }
        }
    }

    public List<Package> GetPackages()
    {
        return packages;
    }

    public List<Vehicle> GetVehicles()
    {
        return vehicles;
    }
    public List<Worker> GetWorkers()
    {
        return workers;
    }

    // in class the file name was a FILEPATH variable. here it comes in as a parameter, because the IFileHandler interface says Save(string path).
    public void Save(string path)
    {
        using StreamWriter writer = new StreamWriter(path);

        // in class we had one array to save. here we have three lists, so there are three loops.
        foreach (Package p in packages)
        {
            // in class we put a space between the values. here we use | like the project guidelines show.
            // each line also starts with what it is (PACKAGE, VEHICLE or WORKER) so load knows what to make.
            writer.WriteLine("PACKAGE|" + p.GetId() + "|" + p.GetWeight() + "|" + p.GetPriorityLevel() + "|" + p.GetDestination() + "|" + p.GetStatus());
        }

        foreach (Vehicle v in vehicles)
        {
            // new compared to class. a truck, van and drone each have one value the others don't, so we check which one it is first.
            string type;
            string lastValue;

            // "v is Truck truck" checks if this vehicle is really a truck. if it is, we can use it as a Truck with the name truck.
            if (v is Truck truck)
            {
                type = "Truck";
                lastValue = truck.GetFuelConsumption().ToString();
            }
            else if (v is Van van)
            {
                type = "Van";
                lastValue = van.GetIsElectric().ToString();
            }
            else
            {
                Drone drone = (Drone)v; // the only one left is a drone, so we tell c# to treat it as a Drone.
                type = "Drone";
                lastValue = drone.GetMaxDistance().ToString();
            }

            writer.WriteLine("VEHICLE|" + v.GetId() + "|" + type + "|" + v.GetName() + "|" + v.GetSpeed() + "|" + v.GetMaxCapacity() + "|" + v.GetCurrentLoad() + "|" + v.GetIsAvailable() + "|" + lastValue);
        }

        // same idea as the vehicles, but for driver, loader and manager.
        foreach (Worker w in workers)
        {
            string type;
            string lastValue;

            if (w is Driver driver)
            {
                type = "Driver";
                lastValue = driver.GetLicenseType();
            }
            else if (w is Loader loader)
            {
                type = "Loader";
                lastValue = loader.GetMaxLiftWeight().ToString();
            }
            else
            {
                Manager manager = (Manager)w;
                type = "Manager";
                lastValue = manager.GetTeamSize().ToString();
            }

            writer.WriteLine("WORKER|" + w.GetId() + "|" + type + "|" + w.GetName() + "|" + w.GetExperienceYears() + "|" + w.GetTasksCompleted() + "|" + w.GetIsAvailable() + "|" + lastValue);
        }
    }

    public void Load(string path)
    {
        // new compared to class. without this check, a missing file would crash the program.
        if (!File.Exists(path))
        {
            throw new CustomException.CustomException.InvalidDataException("Save file not found: " + path);
        }

        // new compared to class. we fill new lists first, so if a line in the file is bad the warehouse stays how it was.
        List<Package> loadedPackages = new List<Package>();
        List<Vehicle> loadedVehicles = new List<Vehicle>();
        List<Worker> loadedWorkers = new List<Worker>();

        using StreamReader reader = new StreamReader(path);

        string line;

        // Reads each line until the file ends
        while ((line = reader.ReadLine()) != null)
        {
            // in class we only printed the line. here we have to turn it back into an object.
            // Split cuts the line at every | so parts[0] is the first value, parts[1] is the second, and so on.
            string[] parts = line.Split('|');

            if (parts[0] == "PACKAGE")
            {
                // the values come back as text, so the numbers need int.Parse or double.Parse. same order as in Save.
                loadedPackages.Add(new Package(int.Parse(parts[1]), double.Parse(parts[2]), int.Parse(parts[3]), parts[4], parts[5]));
            }
            else if (parts[0] == "VEHICLE")
            {
                int id = int.Parse(parts[1]);
                string type = parts[2];
                string name = parts[3];
                double speed = double.Parse(parts[4]);
                double maxCapacity = double.Parse(parts[5]);
                double currentLoad = double.Parse(parts[6]);
                bool isAvailable = bool.Parse(parts[7]);

                // parts[2] is the type we saved, so we know which class to make. parts[8] is the last value.
                // the created date isn't in the file, so we use DateTime.Now.
                if (type == "Truck")
                {
                    loadedVehicles.Add(new Truck(id, name, DateTime.Now, speed, maxCapacity, currentLoad, isAvailable, double.Parse(parts[8])));
                }
                else if (type == "Van")
                {
                    loadedVehicles.Add(new Van(id, name, DateTime.Now, speed, maxCapacity, currentLoad, isAvailable, bool.Parse(parts[8])));
                }
                else
                {
                    loadedVehicles.Add(new Drone(id, name, DateTime.Now, speed, maxCapacity, currentLoad, isAvailable, double.Parse(parts[8])));
                }
            }
            else if (parts[0] == "WORKER")
            {
                int id = int.Parse(parts[1]);
                string type = parts[2];
                string name = parts[3];
                int experienceYears = int.Parse(parts[4]);
                int tasksCompleted = int.Parse(parts[5]);
                bool isAvailable = bool.Parse(parts[6]);

                // same idea as the vehicles. a worker line is one value shorter, so the last value is parts[7].
                if (type == "Driver")
                {
                    loadedWorkers.Add(new Driver(id, name, DateTime.Now, experienceYears, tasksCompleted, isAvailable, parts[7]));
                }
                else if (type == "Loader")
                {
                    loadedWorkers.Add(new Loader(id, name, DateTime.Now, experienceYears, tasksCompleted, isAvailable, double.Parse(parts[7])));
                }
                else
                {
                    loadedWorkers.Add(new Manager(id, name, DateTime.Now, experienceYears, tasksCompleted, isAvailable, int.Parse(parts[7])));
                }
            }
        }

        // everything loaded without a problem, so now we replace the old lists with the new ones.
        packages = loadedPackages;
        vehicles = loadedVehicles;
        workers = loadedWorkers;
    }

    public List<Package> GetPendingPackages()
    {
        List<Package> pending = new List<Package>();
        for (int i = 0; i < packages.Count; i++)
        {
            if(packages[i].GetStatus() == "Pending")//it will add status pending into list pending
            {
                pending.Add(packages[i]);
            }
        }
        return pending;
    }


}
}