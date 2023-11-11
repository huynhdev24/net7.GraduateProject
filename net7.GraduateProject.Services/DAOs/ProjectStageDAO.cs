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
    /// ProjectStageDAO
    /// </summary>
    public class ProjectStageDAO
    {
        DBContext db;

        /// <summary>
        /// 
        /// </summary>
        public ProjectStageDAO()
        {
            db = new DBContext(Common.CTR);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projectId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<ProjectStage> Get(long id, long projectId, string name)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", id),
                    new SqlParameter("@ProjectId", projectId),
                    new SqlParameter("@Name", name)
                };

                return db.Database.SqlQueryRaw<ProjectStage>("uspGetProjectStages @Id, @ProjectId, @Name", sqlParameters).ToList();
            }
            catch (Exception) { return new List<ProjectStage>(); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert(ProjectStage entity)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@ProjectId", entity.ProjectId),
                    new SqlParameter("@Name", entity.Name),
                    new SqlParameter("@StartDate", entity.StartDate),
                    new SqlParameter("@EndDate", entity.EndDate),
                    new SqlParameter("@Intent", entity.Intent),
                    new SqlParameter("@Request", entity.Request)
                };

                return db.Database.ExecuteSqlRaw("uspInsertProjectStage @ProjectId, @Name, @StartDate, @EndDate, @Intent, @Request", sqlParameters);
            }
            catch (Exception) { return 0; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(ProjectStage entity)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", entity.Id),
                    new SqlParameter("@Name", entity.Name != null ? entity.Name : ""),
                    new SqlParameter("@StartDate", entity.StartDate != null ? entity.StartDate : ""),
                    new SqlParameter("@EndDate", entity.EndDate != null ? entity.EndDate : ""),
                    new SqlParameter("@Intent", entity.Intent != null ? entity.Intent : ""),
                    new SqlParameter("@Request", entity.Request != null ? entity.Request : ""),
                    new SqlParameter("@Submission", entity.Submission != null ? entity.Submission : ""),
                    new SqlParameter("@Comment", entity.Comment != null ? entity.Comment : "")
                };

                return db.Database.ExecuteSqlRaw("uspUpdateProjectStage @Id, @Name, @StartDate, @EndDate, @Intent, @Request, @Submission, @Comment", sqlParameters);
            }
            catch (Exception) { return 0; }
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

                return db.Database.ExecuteSqlRaw("uspDeleteProjectStage @Id", sqlParameter);
            }
            catch (Exception) { return 0; }
        }
    }
}
