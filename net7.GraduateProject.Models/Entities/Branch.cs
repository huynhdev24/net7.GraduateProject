using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net7.GraduateProject.Models.Entities
{
    /// <summary>
    /// Branch
    /// </summary>
    public class Branch
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public long FacultyId { get; set; }
    }
}
