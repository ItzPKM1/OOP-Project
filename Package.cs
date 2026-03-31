public class Package
{
    private int id;
    private double weight;
    private int priorityLevel;
    private string destination;
    private string status; //(Pending, Assigned, Delivered)

    public Package(int id, double weight, int priorityLevel, string destination)
    {
        this.id = id;
        this.weight = weight;
        this.priorityLevel = priorityLevel;
        this.destination = destination;
    }

    public double CalculatePriorityScore()
    {
        
    }
    public void UpdateStatus(string newStatus)
    {
        this.status = newStatus;
    }

    public bool isHeavy()
    {
        // weight >threshhold
    }
    public int getId()
    {
        return id;
    }

    public double getWeight()
    {
        return weight;
    }
}