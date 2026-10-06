using deliverySystem.Model;
using deliverySystem.DSA;
using deliverySystem.CustomException;
namespace deliverySystem.Main // these are just like our java project. 
{
    public class Program
    
    {
        private static int nextWorkerId = 1;
        private static int nextPackageId = 1;
        private static int nextVehicleId = 1; //fixed typo in variable name
        private static string saveFilePath = "delivery_data.txt"; // fixed file path
        private static CustomStack<string> undoStack = new CustomStack<string>(100); // added undo stack. holds up to 100 actions currently.

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
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Input number is too large. Please enter a valid number.");
                    continue;
                }
            

                switch (choice)
                {
                    case 1:

                        try
                        {
                            AddEntitiesMenu(deliverySystem, warehouse); // fixed method name to match the actual method
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
                        try
                        {
                            AssignDeliveries(warehouse); // fixed method name to match the actual method
                        }
                        catch (CustomException.CustomException.EmptyStructureException ex)
                        {
                            Console.WriteLine("Error occurred while assigning deliveries: " + ex.Message);
                        }
                        catch (CustomException.CustomException.OverCapacityException ex)
                        {
                            Console.WriteLine("Error occurred while assigning deliveries: " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An unexpected error occurred: " + ex.Message);
                        }

                        break;

                    case 3:
                    // Code to sort packages
                            deliverySystem.SortPackages();
                        break;

                    case 4:
                    // Code to search for a package **need to edit.
                            Console.Write("Enter package ID to search: ");
                            //** needs to be wrapped in a trycatch.
                            try
                            {
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
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid package ID.");
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Input number is too large. Please enter a valid package ID.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("An unexpected error occurred while searching for the package: " + ex.Message);
                            }

                        break;

                    case 5:
                    // Code to run simulation
                    try 
                    {
                        deliverySystem.SimulateDay();
                        Console.WriteLine("Simulation completed.");
                    }
                    catch (CustomException.CustomException.EmptyStructureException ex)
                    {
                        Console.WriteLine("Error occurred during simulation: " + ex.Message);
                    }
                    
                    catch (Exception ex)
                    {
                        Console.WriteLine("An unexpected error occurred during simulation: " + ex.Message);
                    }       
                        break;

                    case 6://For us means exiting?
                    // Code to undo last action
                    try
                    {
                        UndoLastAction(warehouse, deliverySystem);
                    }
                    catch (CustomException.CustomException.InvalidDataException ex)
                    {
                        Console.WriteLine("Error occurred while undoing last action: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An unexpected error occurred while undoing last action: " + ex.Message);
                    }
                        break;

                    case 7:
                    // Code to save/load system state
                    Console.Write("Type 'S' to save or 'L' to load: ");
                    string saveLoadChoice = Console.ReadLine().ToUpper();
                    try
                    {
                        if (saveLoadChoice == "S")
                        {
                            warehouse.Save(saveFilePath);
                            Console.WriteLine("System state saved successfully.");
                        }
                        else if (saveLoadChoice == "L")
                        {
                            
                            warehouse.Load(saveFilePath);

                            deliverySystem = new DeliverySystem(); // reinitialize the delivery system to avoid null reference issues
                            deliverySystem.AddWarehouse(warehouse); // re-add the warehouse to the delivery system
                            foreach (Package package in warehouse.GetPackages())
                            {
                                deliverySystem.AddPackage(package); // re-add packages to the delivery system
                            }
                            UpdateNextIds(warehouse); // update next IDs based on loaded data
                            undoStack = new CustomStack<string>(100); // reset the undo stack after loading
                            Console.WriteLine("System state loaded from " + saveFilePath);
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please enter 'S' or 'L'.");
                        }
                    }
                    catch (CustomException.CustomException.InvalidDataException ex)
                    {
                        Console.WriteLine("Error occurred while saving/loading: " + ex.Message);
                    }

                    catch (FileNotFoundException ex)
                    {
                        Console.WriteLine("File not found: " + ex.Message);
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("I/O error occurred: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred while saving/loading: " + ex.Message);
                    }
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
        private static void AssignDeliveries(Warehouse warehouse)
        {
            Console.WriteLine("Assigning deliveries not done yet.");// work on later.
        }
        private static void UndoLastAction(Warehouse warehouse, DeliverySystem deliverySystem)
        {
            if (undoStack.IsEmpty())
            {
                Console.WriteLine("No actions to undo.");
                return;
            }

            string lastAction = undoStack.Pop();
            string [] actionParts = lastAction.Split(':');
            string type = actionParts[0];
            int id = int.Parse(actionParts[1]);
            if (type == "package")
            {
                warehouse.RemovePackage(id);
                deliverySystem.RemovePackage(id); //because pacakage is in two lists.
            }
            else if (type == "worker")
            {
                warehouse.RemoveWorker(id);
            }
            else
            {
                warehouse.RemoveVehicle(id);
            }

            Console.WriteLine("Undid last action: removed " + type + " with ID " + id);
        }

        private static void UpdateNextIds(Warehouse warehouse)
        {
            //update nextWorkerId
            nextWorkerId = 1;
            foreach (Worker w in warehouse.GetWorkers())
            {
                if (w.GetId() >= nextWorkerId)
                {
                    nextWorkerId = w.GetId() + 1;
                }
            }

            //update nextPackageId
            nextPackageId = 1;
            foreach (Package p in warehouse.GetPackages())
            {
                if (p.GetId() >= nextPackageId)
                {
                    nextPackageId = p.GetId() + 1;
                }
            }

            //update nextVehicleId
            nextVehicleId = 1;
            foreach (Vehicle v in warehouse.GetVehicles())
            {
                if (v.GetId() >= nextVehicleId)
                {
                    nextVehicleId = v.GetId() + 1;
                }
            }
        }
        //sub menu for option 1.
        private static void AddEntitiesMenu(DeliverySystem deliverySystem, Warehouse warehouse)
        {
            int subChoice = 0;
            while (subChoice != 4)
            {
                Console.WriteLine("== Add Entities Menu ==");
                Console.WriteLine("1. Add Worker");
                Console.WriteLine("2. Add Package");
                Console.WriteLine("3. Add Vehicle");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Enter your choice: ");

                // fixed input parsing with try-catch to handle invalid inputs
                try
                {
                    subChoice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Input number is too large. Please enter a valid number.");
                    continue;
                }
            
                switch (subChoice)
                {
                    case 1:
                        AddWorker(warehouse);
                        break;
                    case 2:
                        AddPackage(deliverySystem, warehouse);
                        break;
                    case 3:
                        AddVehicle(warehouse);
                        break;
                    case 4:
                        Console.WriteLine("Returning to Main Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        //added methods to add worker, package, and vehicle with input validation and exception handling
        private static void AddWorker(Warehouse warehouse)
        {
            Console.Write("Enter worker type (driver, loader, or manager): ");
            string type = Console.ReadLine().ToLower(); // so now we have inputs in all cases.
            if (type != "driver" && type != "loader" && type != "manager") // added bike as a valid vehicle type
            {
                Console.WriteLine("Invalid worker type. Please enter 'loader', 'driver', or 'manager'.");
                return;
            }
            Console.Write("Enter worker name: ");
            string name = Console.ReadLine();
            Console.Write("Enter experience years: ");
            int experienceYears = int.Parse(Console.ReadLine());
            Console.Write("Enter tasks completed: ");
            int tasksCompleted = int.Parse(Console.ReadLine());
            Console.Write("Is the worker available? (true/false): ");
            bool isAvailable = bool.Parse(Console.ReadLine());

            Worker worker;
            if (type == "driver")
            {
                Console.Write("Enter driving license type (for Driver): ");
                string licenseType = Console.ReadLine();

                worker = new Driver(nextWorkerId++, name, DateTime.Now, experienceYears, tasksCompleted, isAvailable, licenseType);
            }
            else if (type == "loader")
            {
                Console.Write("Enter max lift weight (for Loader): ");
                double maxLiftWeight = double.Parse(Console.ReadLine());
                worker = new Loader(nextWorkerId++, name, DateTime.Now, experienceYears, tasksCompleted, isAvailable, maxLiftWeight);
            }
            else 
            {
                Console.Write("Enter team Size (for Manager): ");
                int teamSize = int.Parse(Console.ReadLine());
                worker = new Manager(nextWorkerId++, name, DateTime.Now, experienceYears, tasksCompleted, isAvailable, teamSize);
            }
            
            warehouse.AddWorker(worker);
            undoStack.Push("worker:" + worker.GetId()); // push the action to the undo stack
            Console.WriteLine("Worker added successfully.");
        }

        private static void AddPackage(DeliverySystem deliverySystem, Warehouse warehouse)
        {
            Console.Write("Enter package weight: ");
            double weight = double.Parse(Console.ReadLine());
            Console.Write("Enter package priority level (1-5): ");
            int priorityLevel = int.Parse(Console.ReadLine());
            Console.Write("Enter package destination: ");
            string destination = Console.ReadLine();

            if (weight <= 0)
            {
                Console.WriteLine("Invalid weight. Please enter a positive number.");
                return;
            }

            if (priorityLevel < 1 || priorityLevel > 5)
            {
                Console.WriteLine("Invalid priority level. Please enter a number between 1 and 5.");
                return;
            }

            Package package = new Package(nextPackageId++, weight, priorityLevel, destination, "Pending");
            deliverySystem.AddPackage(package);
            warehouse.AddPackage(package);
            undoStack.Push("package:" + package.GetId());
            Console.WriteLine("Package added successfully.");
        }

        private static void AddVehicle(Warehouse warehouse)
        {
            Console.Write("Enter vehicle type: ");
            string type = Console.ReadLine().ToLower(); // so now we have inputs in all cases.
            if (type != "truck" && type != "van" && type != "drone") // added bike as a valid vehicle type
            {
                Console.WriteLine("Invalid vehicle type. Please enter 'truck' or 'van'.");
                return;
            }
            Console.Write("Enter vehicle name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the vehicle's speed (km/h): ");
            double speed = double.Parse(Console.ReadLine());
            Console.Write("Enter the vehicle capacity: ");
            double capacity = double.Parse(Console.ReadLine());
            
            Vehicle vehicle; // declare the vehicle variable here. we can make branches to become truck, van, or drone. 
            
            if (type == "truck")
            {
                Console.Write("Enter fuel consumption: ");
                double fuelConsumption = double.Parse(Console.ReadLine());
                vehicle = new Truck(nextVehicleId++, name, DateTime.Now, speed, capacity, 0, true, fuelConsumption); //vehicle is abstract,
            }
        
            else if (type == "van")
            {
                Console.Write("Is it electric? (true/false): ");
                bool isElectric = bool.Parse(Console.ReadLine());
                vehicle = new Van(nextVehicleId++, name, DateTime.Now, speed, capacity, 0, true, isElectric); //vehicle is abstract,
            }
            else
            {
                Console.Write("Enter Max Distance (for Drone): ");
                double maxDistance = double.Parse(Console.ReadLine());
                vehicle = new Drone(nextVehicleId++, name, DateTime.Now, speed, capacity, 0, true, maxDistance); //vehicle is abstract,
            }
            warehouse.AddVehicle(vehicle);
            undoStack.Push("vehicle:" + vehicle.GetId());
            Console.WriteLine("Vehicle added successfully.");
        }
    }
}
