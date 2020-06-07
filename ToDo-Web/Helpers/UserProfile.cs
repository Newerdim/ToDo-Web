using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo_Web.Dtos;
using ToDo_Web.Models;

namespace ToDo_Web.Helpers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<List<TaskModel>, List<TaskModelDto>>();
            CreateMap<TaskModel, TaskModelDto>();
        }
    }
}
