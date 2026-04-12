using System.Net;

public class Warehouse
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
            throw new EmptyStructureException("No vehicles in warehouse");
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
    public void AssignWorker(Worker worker)
    {
        if(workers.Count == 0)
        {
            throw new EmptyStructureException("No wokers  in warehouse");
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

    public List<Package> GetPendingPackages() //*NOT DONE*
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