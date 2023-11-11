using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net7.GraduateProject.Models.Entities
{
    /// <summary>
    /// Assembly
    /// </summary>
    public class Assembly
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string CreatedDate { get; set; }

        public bool Status { get; set; }
    }
}
