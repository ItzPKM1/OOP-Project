public class Driver : Worker
{
    private string licenseType;
    public Driver(int experienceYears, int tasksCompleted, bool isAvailable, string licenseType) : base(experienceYears,  tasksCompleted,  isAvailable)
    {
        this.licenseType = licenseType;
    }
    public string GetLicenseType()
    {
        return licenseType;
    }

    public void SetLicenseType(string licenseType)
    {
        this.licenseType = licenseType ;
    }
    public override void PerformTask()
    {
        Console.WriteLine("Driving Deliveries");
    }

    public override  void DisplayInfo()
    {
        Console.WriteLine("Your license type is : " + GetLicenseType());
    }

    
}