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
    /// AssemblyDAO
    /// </summary>
    public class AssemblyDAO
    {
        DBContext db;

        /// <summary>
        /// 
        /// </summary>
        public AssemblyDAO()
        {
            db = new DBContext(Common.CTR);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Assembly> Get(long id)
        {
            SqlParameter sqlParameter = new SqlParameter("@Id", id);

            return db.Database.SqlQueryRaw<Assembly>("uspGetAssembly @Id", sqlParameter).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="assemblyDetails"></param>
        /// <returns></returns>
        public int Insert(Assembly assembly, List<AssemblyDetail> assemblyDetails)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Id", assembly.Id),
                new SqlParameter("@Name", assembly.Name),
                new SqlParameter("@LecturerId1", assemblyDetails[0].LecturerId),
                new SqlParameter("@LecturerId2", assemblyDetails[1].LecturerId),
            };

            return db.Database.SqlQueryRaw<int>("uspInsertAssembly @Id, @Name, @LecturerId1, @LecturerId2", sqlParameters).SingleOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="assemblyDetails"></param>
        /// <returns></returns>
        public int Update(Assembly assembly, List<AssemblyDetail> assemblyDetails)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Id", assembly.Id),
                new SqlParameter("@Name", assembly.Name == null ? "" : assembly.Name),
                new SqlParameter("@Point", assemblyDetails[0].Point == null ? -1 : assemblyDetails[0].Point),
                new SqlParameter("@LecturerId1", assemblyDetails[1].LecturerId == null ? "" : assemblyDetails[1].LecturerId),
                new SqlParameter("@Point1", assemblyDetails[1].Point == null ? -1 : assemblyDetails[1].Point),
                new SqlParameter("@LecturerId2", assemblyDetails[2].LecturerId == null ? "" : assemblyDetails[2].LecturerId),
                new SqlParameter("@Point2", assemblyDetails[2].Point == null ? -1 : assemblyDetails[2].Point),
            };

            return db.Database.SqlQueryRaw<int>("uspUpdateAssembly @Id, @Name, @Point, @LecturerId1, @Point1, @LecturerId2, @Point2", sqlParameters).SingleOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(long id)
        {
            SqlParameter sqlParameter = new SqlParameter("@Id", id);

            return db.Database.ExecuteSqlRaw("uspDeleteAssembly @Id", sqlParameter);
        }
    }
}
