using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo_Web.Dtos
{
    public class TaskModelDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? EndDate { get; set; }

        public bool Completed { get; set; }
    }
}
