using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
