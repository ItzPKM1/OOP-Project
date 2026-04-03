namespace Entity
{
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
        public DateTime GetCreatedDate()
        {
            return createdDate;
        }

        public void SetCreatedDate(DateTime createdDate)
        {
            this.createdDate =  createdDate  ;
        }
        public virtual bool Validate()
        {
            if (string.IsNullOrEmpty(GetName()))
            {
                throw new Exception("This cant be empty or null ");
                
            }

            if(GetCreatedDate() > DateTime.Now)
            {
                throw new Exception("This date is invalid");
                
            }

            return true;
        }

        public abstract void DisplayInfo();

    }

}    

