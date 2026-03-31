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
        //not done.
    }
    public Vehicle FindBestVehicle(Package p)
    {
        //based on capacity + efficiency.

    }
    public void AssignWorker(Worker worker)
    {
        workers.Add(worker);
    }

    public List<Package> GetPendingPackages()
    {
        //not done.
    }
}