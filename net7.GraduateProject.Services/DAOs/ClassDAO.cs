using Microsoft.Data.SqlClient;
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
    /// ClassDAO
    /// </summary>
    public class ClassDAO
    {
        DBContext db;

        /// <summary>
        /// 
        /// </summary>
        public ClassDAO()
        {
            db = new DBContext(Common.CTR);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="facultyId"></param>
        /// <param name="branchId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Class> Get(string id, string facultyId, string branchId, int page, int pageSize)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@Id", id),
                new SqlParameter("@FacultyId", facultyId),
                new SqlParameter("@BranchId", branchId),
                new SqlParameter("@Page", page),
                new SqlParameter("@PageSize", pageSize)
            };

                return db.Database.SqlQueryRaw<Class>("uspGetClasses @Id, @FacultyId, @BranchId, @Page, @PageSize", sqlParameters).ToList();
            }
            catch (Exception)
            {
                return new List<Class>();
            }
        }
    }
}
