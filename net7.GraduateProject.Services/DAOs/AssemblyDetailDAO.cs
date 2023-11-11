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
    /// AssemblyDetailDAO
    /// </summary>
    public class AssemblyDetailDAO
    {
        DBContext db;

        /// <summary>
        /// 
        /// </summary>
        public AssemblyDetailDAO()
        {
            db = new DBContext(Common.CTR);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<AssemblyDetail> Get(long id)
        {
            SqlParameter sqlParameter = new SqlParameter("@Id", id);

            return db.Database.SqlQueryRaw<AssemblyDetail>("uspGetAssemblyDetails @Id", sqlParameter).ToList();
        }
    }
}
