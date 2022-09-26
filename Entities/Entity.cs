using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Entity : AccessControl
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }


        public void EnableEntity()
        {
            this.CreatedAt = DateTime.Now;
            this.Active = true;
        }

        public void DisableEntity()
        {
            this.Active = false;
        }
    }
    public class AccessControl
    {
        public int AccessCount { get; set; }
        public int AccessUserId { get; set; }
        public DateTime LastAccess { get; set; }

    }
}
