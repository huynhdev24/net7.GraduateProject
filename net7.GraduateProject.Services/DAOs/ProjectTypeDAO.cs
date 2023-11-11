using Microsoft.EntityFrameworkCore;
using net7.GraduateProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net7.GraduateProject.Services.DAOs
{
    /// <summary>
    /// ProjectTypeDAO
    /// </summary>
    public class ProjectTypeDAO
    {
        DBContext db;

        /// <summary>
        /// 
        /// </summary>
        public ProjectTypeDAO()
        {
            db = new DBContext(Common.CTR);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ProjectType> Get()
        {
            try
            {
                return db.Database.SqlQueryRaw<ProjectType>("uspGetProjectType").ToList();
            }
            catch (Exception)
            {
                return new List<ProjectType>();
            }
        }
    }
}
