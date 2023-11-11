using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net7.GraduateProject.Models.Entities
{
    /// <summary>
    /// DBContext
    /// </summary>
    public partial class DBContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
