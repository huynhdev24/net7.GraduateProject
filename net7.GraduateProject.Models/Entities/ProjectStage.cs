using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net7.GraduateProject.Models.Entities
{
    /// <summary>
    /// ProjectStage
    /// </summary>
    public class ProjectStage
    {
        public long Id { get; set; }

        public long ProjectId { get; set; }

        public string Name { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Intent { get; set; }

        public string Request { get; set; }

        public string SubmissionDate { get; set; }

        public string Submission { get; set; }

        public string Comment { get; set; }
    }
}
