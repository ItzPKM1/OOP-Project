public abstract class Entity
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

   public int GetId()
    {
        return id;
    }

    public void SetId(int id)
    {
        this.id =  id  ;
    }


    public string GetName()
    {
        return name;
    }
    public void SetName(string name)
    {
        if(string.IsNullOrEmpty(name))
        {
            throw new Exception(" Name is empty ");
        }
        
        this.name = name;
    }

    public virtual bool Validate()
    {
       //ASK TEACHER
    }

    public abstract void DisplayInfo();


}