using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo_Web.Dtos
{
    public class TaskModelForCreateDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? EndDate { get; set; }

        public int? TaskGroupModelId { get; set; }
    }
}
