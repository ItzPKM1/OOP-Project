public class Driver : Worker
{
    private string licenseType;
    public Driver(int id, string name, DateTime createdDate, int experienceYears, int tasksCompleted, bool isAvailable, string licenseType) : base(id, name, createdDate, experienceYears, tasksCompleted, isAvailable)
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
        Console.WriteLine("Your name is " + GetName());
        Console.WriteLine("Your created date is " + GetCreatedDate());
        Console.WriteLine("Your experience years are " + GetExperienceYears());
        Console.WriteLine("Your tasks completed are " + GetTasksCompleted());
        Console.WriteLine("Your availability is " + GetIsAvailable());
        Console.WriteLine("Your license type is : " + GetLicenseType());
    }

    
}