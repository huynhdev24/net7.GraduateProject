using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net7.GraduateProject.Models.Entities;
using net7.GraduateProject.Services.DAOs;

namespace net7.GraduateProject.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssemblyDetailController : Controller
    {
        AssemblyDetailDAO dao = new AssemblyDetailDAO();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Get(long id)
        {
            Assembly assembly = new AssemblyDAO().Get(id).SingleOrDefault();
            List<AssemblyDetail> assemblyDetails = dao.Get(id);


            return Json(new
            {
                data = new { assembly, assemblyDetails }
            });
        }
    }
}
