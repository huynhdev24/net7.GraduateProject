﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net7.GraduateProject.Models.Entities
{
    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        public string Id { get; set; }

        public string Password { get; set; }

        public string Avatar { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public string Birthday { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public long GroupId { get; set; }

        public string ClassId { get; set; }

        public string BranchId { get; set; }

        public string BranchName { get; set; }

        public string FacultyId { get; set; }

        public string FacultyName { get; set; }

        public bool Status { get; set; }
    }
}
