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
            if (packages[i].Id == packageId)
            {
                packages.RemoveAt(i);
                return;
            }
        }
    }
    // public Vehicle FindBestVehicle(Package p)
    // {
    //     //based on capacity + efficiency.
    //     Vehicle bestVehicle = null;
    //     double bestEfficiency = 0;
    //     for (int i = 0; i < vehicles.Count; i++)
    //     {
    //         if ()
    //         {
                
    //         }
    //     }
    

    // }
    public void AssignWorker(Worker worker)
    {
        for(int i = 0; i < workers.Count; i++)
        {
            if (workers[i].IsAvailable)
            {
                return workers[i];
            }
        }
        return null; // no available worker
    }

    public List<Package> GetPendingPackages()
    {
        //not done.
        for (int i = 0; i < packages.Count; i++)
        {
            // if ()
        }
    }
}