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
    /// StudentDAO
    /// </summary>
    public class StudentDAO
    {
        DBContext db;

        /// <summary>
        /// 
        /// </summary>
        public StudentDAO()
        {
            db = new DBContext(Common.CTR);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="fullName"></param>
        /// <param name="facultyId"></param>
        /// <param name="branchId"></param>
        /// <param name="classId"></param>
        /// <param name="trainingSystemId"></param>
        /// <returns></returns>
        public long Count(string Id, string fullName, string facultyId, string branchId, string classId, string trainingSystemId)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", Id),
                    new SqlParameter("@FullName", fullName),
                    new SqlParameter("@FacultyId", facultyId),
                    new SqlParameter("@BranchId", branchId),
                    new SqlParameter("@ClassId", classId),
                    new SqlParameter("@TrainingSystemId", trainingSystemId)
                };

                return db.Database.SqlQueryRaw<long>("uspCountStudent @Id, @FullName, @FacultyId, @BranchId, @ClassId, @TrainingSystemId", sqlParameters).SingleOrDefault();
            }
            catch (Exception) { return 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="fullName"></param>
        /// <param name="facultyId"></param>
        /// <param name="branchId"></param>
        /// <param name="classId"></param>
        /// <param name="trainingSystemId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Student> Get(string Id, string fullName, string facultyId, string branchId, string classId, string trainingSystemId, int page, int pageSize)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", Id),
                    new SqlParameter("@FullName", fullName),
                    new SqlParameter("@FacultyId", facultyId),
                    new SqlParameter("@BranchId", branchId),
                    new SqlParameter("@ClassId", classId),
                    new SqlParameter("@TrainingSystemId", trainingSystemId),
                    new SqlParameter("@Page", page),
                    new SqlParameter("@PageSize", pageSize)
                };

                return db.Database.SqlQueryRaw<Student>("uspGetStudents @Id, @FullName, @FacultyId, @BranchId, @ClassId, @TrainingSystemId, @Page, @PageSize", sqlParameters).ToList();
            }
            catch (Exception) { return null; }
        }
    }
}
