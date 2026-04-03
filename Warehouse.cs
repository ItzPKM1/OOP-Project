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
    // public Vehicle FindBestVehicle(Package p) //*NOT DONE*
    // {
    //     //based on capacity + efficiency.
    //     Vehicle bestVehicle = null;
    //     double bestEfficiency = 0;
    //     for (int i = 0; i < vehicles.Count; i++)
    //     {
    //         double performance = vehicles[i].CalculateEfficiency();
    //         if ()
    //         {
                
    //         }


    //     }
        

    // }
    public Worker AssignWorker() // using Worker as a parameter is redundant. We can just find the first available worker in the list.
    {
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
        //not done.
        // for (int i = 0; i < packages.Count; i++)
        // {
        //     // if ()
        // }
        return new List<Package>();

    }
}