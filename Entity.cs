public class Entity
{
    private int id;
    private string name;
    private DateTime createdDate;

    public Entity(int id, string name, DateTime createdDate)
    {
        this.id = id;
        this.name = name;
        this.createdDate = createdDate;
    }

    public int setName
    {
        
    }

    public string getName()
    {
        return name;
    }

    public virtual bool Validate()
    {
        
    }

    public abstract void DisplayInfo();


}