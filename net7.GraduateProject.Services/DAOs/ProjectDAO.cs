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
    /// ProjectDAO
    /// </summary>
    public class ProjectDAO
    {
        DBContext db;

        /// <summary>
        /// 
        /// </summary>
        public ProjectDAO()
        {
            db = new DBContext(Common.CTR);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="student"></param>
        /// <param name="lecturer"></param>
        /// <param name="projectTypeId"></param>
        /// <param name="year"></param>
        /// <param name="facultyId"></param>
        /// <param name="branchId"></param>
        /// <param name="classId"></param>
        /// <param name="pointStatus"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Project> Get(long id, string name, string student, string lecturer, long projectTypeId, int year, string facultyId, string branchId, string classId, int pointStatus, int page, int pageSize)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", id),
                    new SqlParameter("@Name", name),
                    new SqlParameter("@Student", student),
                    new SqlParameter("@Lecturer", lecturer),
                    new SqlParameter("@ProjectTypeId", projectTypeId),
                    new SqlParameter("@Year", year),
                    new SqlParameter("@FacultyId", facultyId),
                    new SqlParameter("@BranchId", branchId),
                    new SqlParameter("@ClassId", classId),
                    new SqlParameter("@PointStatus", pointStatus),
                    new SqlParameter("@Page", page),
                    new SqlParameter("@PageSize", pageSize),
                };

                return db.Database.SqlQueryRaw<Project>("uspGetProjects @Id, @Name, @Student, @Lecturer, @ProjectTypeId, @Year, @FacultyId, @BranchId, @ClassId, @PointStatus, @Page, @PageSize", sqlParameters).ToList();
            }
            catch (Exception)
            {
                return new List<Project>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="student"></param>
        /// <param name="lecturer"></param>
        /// <param name="projectTypeId"></param>
        /// <param name="year"></param>
        /// <param name="facultyId"></param>
        /// <param name="branchId"></param>
        /// <param name="classId"></param>
        /// <param name="pointStatus"></param>
        /// <returns></returns>
        public int Count(long id, string name, string student, string lecturer, long projectTypeId, int year, string facultyId, string branchId, string classId, int pointStatus)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", id),
                    new SqlParameter("@Name", name),
                    new SqlParameter("@Student", student),
                    new SqlParameter("@Lecturer", lecturer),
                    new SqlParameter("@ProjectTypeId", projectTypeId),
                    new SqlParameter("@Year", year),
                    new SqlParameter("@FacultyId", facultyId),
                    new SqlParameter("@BranchId", branchId),
                    new SqlParameter("@ClassId", classId),
                    new SqlParameter("@PointStatus", pointStatus)
                };

                return db.Database.SqlQueryRaw<int>("uspCountProject @Id, @Name, @Student, @Lecturer, @ProjectTypeId, @Year, @FacultyId, @BranchId, @ClassId, @PointStatus", sqlParameters).SingleOrDefault();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert(Project entity)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@Name", entity.Name),
                    new SqlParameter("@TypeId", entity.TypeId),
                    new SqlParameter("@StudentId", entity.StudentId),
                    new SqlParameter("@LecturerId", entity.LecturerId),
                    new SqlParameter("@StartDate", entity.StartDate),
                    new SqlParameter("@EndDate", entity.EndDate)
                };

                return db.Database.SqlQueryRaw<int>("uspInsertProject @Name, @TypeId, @StudentId, @LecturerId, @StartDate, @EndDate", sqlParameters).SingleOrDefault();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(Project entity)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                    new SqlParameter("@Id", entity.Id),
                    new SqlParameter("@Name", entity.Name == null ? "" : entity.Name),
                    new SqlParameter("@TypeId", entity.TypeId == null ? (long) 0 : entity.TypeId),
                    new SqlParameter("@StudentId", entity.StudentId == null ? "" : entity.StudentId),
                    new SqlParameter("@StartDate", entity.StartDate == null ? "" : entity.StartDate),
                    new SqlParameter("@EndDate", entity.EndDate == null ? "" : entity.EndDate),
                    new SqlParameter("@Submission", entity.Submission == null ? "" : entity.Submission),
                    new SqlParameter("@Point", entity.Point == null ? 0 : entity.Point)
            };

            return db.Database.SqlQueryRaw<int>("uspUpdateProject @Id, @Name, @TypeId, @StudentId, @StartDate, @EndDate, @Submission, @Point", sqlParameters).SingleOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(long id)
        {
            try
            {
                SqlParameter sqlParameter = new SqlParameter("@Id", id);

                return db.Database.ExecuteSqlRaw("uspDeleteProject @Id", sqlParameter);
            }
            catch (Exception) { return 0; }
        }
    }
}
