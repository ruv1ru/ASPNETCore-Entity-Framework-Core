using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspnetCoreEFCoreExample.Models
{
    public class MyModel :BaseEntity
    {
        public string Name { get; set; }


        public override string GetDisplayName()
        {
            return "";
        }

        public override bool IsChildOfBee()
        {
            return false;
        }
    }

    public class EntityBee :BaseEntity
    {
        public string Name { get; set; }

        public ICollection<EntityCee> EntityCees {get;set;}
        public ICollection<EntityDee> EntityDees {get;set;}


        public override string GetDisplayName()
        {
            return "Entity Bee";
        }

        public override bool IsChildOfBee()
        {
            return false;
        }
    }
    public class EntityCee :BaseEntity
    {
        public string Name { get; set; }


        public override string GetDisplayName()
        {
            return "Entity Cee";
        }

        public override bool IsChildOfBee()
        {
            return true;
        }
    }
    public class EntityDee :BaseEntity
    {
        public string Name { get; set; }

        
        public override string GetDisplayName()
        {
            return "Entity Dee";
        }

        public override bool IsChildOfBee()
        {
            return true;
        }
    }

    public abstract class BaseEntity
    {

        [Key]
        public int Id { get; set; }

        public abstract bool IsChildOfBee();
        public abstract string GetDisplayName();
    }

    
}
