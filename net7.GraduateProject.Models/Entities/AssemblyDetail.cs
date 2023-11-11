using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net7.GraduateProject.Models.Entities
{
    /// <summary>
    /// AssemblyDetail
    /// </summary>
    public class AssemblyDetail
    {
        public long AssemblyId { get; set; }

        public string LecturerId { get; set; }

        public string LecturerName { get; set; }

        public double? Point { get; set; }
    }
}
