using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo_Web.Models
{
    public class TaskGroupModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public ICollection<TaskModel> Tasks { get; set; }

        public int UserId { get; set; }
    }
}
