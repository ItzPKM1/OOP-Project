public class Package
{
    private int id;
    private double weight;
    private int priorityLevel;
    private string destination;
    private string status; //(Pending, Assigned, Delivered)

    public Package(int id, double weight, int priorityLevel, string destination,string status)
    {
        this.id = id;
        this.weight = weight;
        this.priorityLevel = priorityLevel;
        this.destination = destination;
        this.status = status;
    }

   

    
    public int GetId()
    {
        return id;
    }

    public void SetId(int id)
    {
        this.id = id  ;
    }
    public double GetWeight()
    {
        return weight;
    }

    public void SetWeight(double weight)
    {
        {
            throw new InvalidDataException("Weight must be positive");
        }
        this.weight = weight;
       
    }
    public string GetDestination() //fixed from double to string.
    {
        return destination;
    }

    public void SetDestination(string destination)
    {
        this.destination = destination  ;
    }
    public int GetPriorityLevel()
    {
        return priorityLevel;
    }

    public void SetPriorityLevel(int priorityLevel)
    {
        {
            throw new InvalidDataException();
        }
        this.priorityLevel = priorityLevel  ;
    }

    public string GetStatus()
    {
        return status;
    }

    public void SetStatus(string status)
    {
        if (status != "Pending" && status != "Assigned" && status != "Delivered")
        {
            throw new ArgumentException("Invalid status. Status should be either 'Pending', 'Assigned', or 'Delivered'."); //added validation for status.
        }
        this.status = status ;
    }


    public bool IsHeavy()
    {
        double heavyTreshold =100.0;
        return weight > heavyTreshold;
    }
    public double CalculatePriorityScore()
    {
        double score = priorityLevel + weight; //fixed reduancy. maybe we can add something later based on destination, or weight.
        return score;
    }
    public void UpdateStatus(string newStatus)
    {
        this.status = newStatus;
    }

    
}