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
    /// LecturerDAO
    /// </summary>
    public class LecturerDAO
    {
        DBContext db;

        /// <summary>
        /// 
        /// </summary>
        public LecturerDAO()
        {
            db = new DBContext(Common.CTR);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public int Login(string username, string password, int groupId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password),
                new SqlParameter("@GroupId", groupId),
            };

            return db.Database.SqlQueryRaw<int>("uspLogin @Username, @Password, @GroupId", sqlParameters).SingleOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fullName"></param>
        /// <param name="facultyId"></param>
        /// <param name="branchId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Lecturer> Get(string id, string fullName, string facultyId, string branchId, int page, int pageSize)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@Id", id),
                new SqlParameter("@FullName", fullName),
                new SqlParameter("@FacultyId", facultyId),
                new SqlParameter("@BranchId", branchId),
                new SqlParameter("@Page", page),
                new SqlParameter("@PageSize", pageSize)
            };

                return db.Database.SqlQueryRaw<Lecturer>("uspGetLecturers @Id, @FullName, @FacultyId, @BranchId, @Page, @PageSize", sqlParameters).ToList();
            }
            catch (Exception)
            {
                return new List<Lecturer>();
            }
        }
    }
}
