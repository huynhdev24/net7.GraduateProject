using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net7.GraduateProject.Models.Entities;
using net7.GraduateProject.Services.DAOs;

namespace net7.GraduateProject.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTypeController : Controller
    {
        ProjectTypeDAO dao = new ProjectTypeDAO();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult Get()
        {

            List<ProjectType> data = dao.Get();
            bool status = data.Count() > 0 ? true : false;

            return Json(new
            {
                status = status,
                data = data
            });
        }
    }
}
