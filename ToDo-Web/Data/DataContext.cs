using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo_Web.Models;

namespace ToDo_Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<TaskModel> Tasks { get; set; }

        public DbSet<TaskGroupModel> TaskGroups { get; set; }
    }
}
