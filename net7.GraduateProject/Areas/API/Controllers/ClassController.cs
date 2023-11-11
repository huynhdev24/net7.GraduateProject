using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net7.GraduateProject.Models.Entities;
using net7.GraduateProject.Services.DAOs;

namespace net7.GraduateProject.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : Controller
    {
        ClassDAO dao = new ClassDAO();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="facultyId"></param>
        /// <param name="branchId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonResult Get(string id = "", string facultyId = "", string branchId = "", int page = 0, int pageSize = 0)
        {

            List<Class> data = dao.Get(id, facultyId, branchId, page, pageSize);
            bool status = data.Count() > 0 ? true : false;

            return Json(new
            {
                status = status,
                data = data
            });
        }
    }
}
