using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities
{
    public class Customer:Entity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
