﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net7.GraduateProject.Models.Entities
{
    /// <summary>
    /// Class
    /// </summary>
    public class Class
    {
        public string Id { get; set; }

        public int Size { get; set; }

        public string FacultyId { get; set; }

        public string Faculty { get; set; }

        public string BranchId { get; set; }

        public string Branch { get; set; }

        public string TrainingSystemId { get; set; }

        public string TrainingSystem { get; set; }

        public string CollegeYear { get; set; }
    }
}
