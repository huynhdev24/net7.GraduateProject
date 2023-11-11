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
    /// UserDAO
    /// </summary>
    public class UserDAO
    {
        DBContext db;

        /// <summary>
        /// 
        /// </summary>
        public UserDAO()
        {
            db = new DBContext(Common.CTR);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Login(string username, string password, int type)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password),
                new SqlParameter("@Type", type),
            };

            return db.Database.SqlQueryRaw<int>("uspLogin @Username, @Password, @Type", sqlParameters).SingleOrDefault();
        }
    }
}
