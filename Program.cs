using deliverySystem.Model;
using deliverySystem.DSA;
using deliverySystem.CustomException;
namespace deliverySystem.Main // these are just like our java project. 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DeliverySystem deliverySystem = new DeliverySystem();


            Warehouse warehouse = new Warehouse("Main Warehouse");
            
            deliverySystem.AddWarehouse(warehouse); //adding warehouse to system

            
            //menu
            int choice = 0;
            while (choice != 8)
            {
                Console.WriteLine("== Delivery System Menu ==");
                Console.WriteLine("1. Add Entities");
                Console.WriteLine("2. Assign Deliveries");
                Console.WriteLine("3. Sort");
                Console.WriteLine("4. Search");
                Console.WriteLine("5. Run Simulation");
                Console.WriteLine("6. Undo");
                Console.WriteLine("7. Save/Load");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        try
                        {
                            Truck truck1 = new Truck(1, "Truck 1", DateTime.Now, 80, 1000, 0, true, 5.0);
                            warehouse.AddVehicle(truck1); //***NEED TO ADD METHOD. we need to go back to warehouse to add AddVehicle method.
                            Driver driver1 = new Driver (1, "Driver 1", DateTime.Now, 5, 100, true, "Class 1"); //class 1 just means to be able to drive heavy vehichles. Class 2 is for standard vehicles and SUVs, and vans, as well as small trucks.
                            warehouse.AddWorker(driver1);// ***NEED TO ADD METHOD. not workers.Add(driver1) because we want to add to warehouse's list of workers, not a list of workers in main. 
                            Loader loader1 = new Loader (2, "Loader 1", DateTime.Now, 3, 15, true, 50.0);
                            warehouse.AddWorker(loader1); // ***NEED TO ADD METHOD. not workers.Add(loader1) because we want to add to warehouse's list of workers, not a list of workers in main.
                            Package package1 = new Package (1, 10.5, 2, "Location A", "Pending");
                            warehouse.AddPackage(package1);
                            deliverySystem.AddPackage(package1); // also add to delivery system's allPackages list. 
                            Console.WriteLine("Entities added successfully.");
                        }
                        catch (CustomException.CustomException.InvalidDataException ex)
                        {
                            Console.WriteLine("Error occurred while adding entities: " + ex.Message);
                        }
                        catch (CustomException.CustomException.EmptyStructureException ex)
                        {
                            Console.WriteLine("Error occurred while adding entities: " + ex.Message);
                        }
                        catch (CustomException.CustomException.OverCapacityException ex)
                        {
                            Console.WriteLine("Error occurred while adding entities: " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An unexpected error occurred: " + ex.Message);
                        }
                        break;

                    case 2:
                    // Code to assign deliveries
                            Worker assignedWorker = warehouse.AssignWorker();
                            if(assignedWorker != null)
                            {
                                Console.WriteLine("Assigned worker: " + assignedWorker.GetId() + " - " + assignedWorker.GetName());
                            }
                            else
                            {
                                Console.WriteLine("No available worker to assign.");
                            }
                            
                        break;

                    case 3:
                    // Code to sort packages
                            deliverySystem.SortPackages();
                        break;

                    case 4:
                    // Code to search for a package **need to edit.
                            Console.Write("Enter package ID to search: ");
                            int packageId = int.Parse(Console.ReadLine());
                            Package foundPackage = deliverySystem.SearchPackageById(packageId);
                            if(foundPackage != null)
                            {
                                Console.WriteLine("Package found: ID " + foundPackage.GetId() + ", Weight: " + foundPackage.GetWeight() + ", Priority: " + foundPackage.GetPriorityLevel() + ", Destination: " + foundPackage.GetDestination() + ", Status: " + foundPackage.GetStatus());
                            }
                            else
                            {
                                Console.WriteLine("Package with ID " + packageId + " not found.");
                            }
                        break;

                    case 5:
                    // Code to run simulation
                        deliverySystem.SimulateDay();
                        Console.WriteLine("Simulation completed.");

                        break;

                    case 6://For us means exiting?
                    // Code to undo last action

                        break;

                    case 7:
                    // Code to save/load system state
                        break;

                    case 8:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
