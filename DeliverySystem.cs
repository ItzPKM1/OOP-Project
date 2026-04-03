
using System.Xml.Linq;

public class DeliverySystem
{
    private List<Warehouse> warehouses ;
    private List<Package> allPackages ;


    public DeliverySystem()
    {
        
        warehouses= new List<Warehouse>();
        allPackages  = new List<Package>();
       
    }


    public void AddWarehouse(Warehouse w)
    {
        warehouses.Add(w);
    }
    public  void AddPackage(Package p)
    {
        allPackages.Add(p);
    } 
    public Package SearchPackageById(int id)
    {
        //→ Must implement search algorithm
        foreach(var pkg in allPackages)
        {
            if(pkg.GetId() == id)
            {
                return pkg;
            }
        } 
        //if no package found with id
        return null;
    }
    
    public void SortPackages()
    {
        //→ Must implement your own sorting 
        int n = allPackages.Count;
        for(int i =0 ; i < n -1; i++)
        {
            for(int j=0; j < n -i - 1; j++)
            {
                if(allPackages[j].CalculatePriorityScore()  < allPackages[j + 1].CalculatePriorityScore())
                {
                    Package temp = allPackages[j];
                    allPackages[j] = allPackages[j+1];
                    allPackages[j+1]=temp;
                }
            }
        }
        Console.WriteLine("Packages are sorted with the highest priority being first in list");
    }
    
    public void ProcessDeliveries()
    {
        // → Assign + deliver 
    }
   
    public void SimulateDay()
    {
        

    } 
    












}
   
    