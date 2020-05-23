﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo_Web.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        public string Token { get; set; }
    }
}