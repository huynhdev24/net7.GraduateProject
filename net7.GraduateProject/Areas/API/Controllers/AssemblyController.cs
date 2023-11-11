using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net7.GraduateProject.Models.Entities;
using net7.GraduateProject.Services.DAOs;

namespace net7.GraduateProject.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssemblyController : Controller
    {
        AssemblyDAO dao = new AssemblyDAO();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Get(long id)
        {
            List<Assembly> data = dao.Get(id);

            bool status = data.Count() > 0 ? true : false;

            return Json(new
            {
                status = status,
                data = data
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="assemblyDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Insert(Assembly assembly, List<AssemblyDetail> assemblyDetails)
        {
            var status = dao.Insert(assembly, assemblyDetails);

            return Json(new
            {
                status = status
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="assemblyDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Update(Assembly assembly, List<AssemblyDetail> assemblyDetails)
        {
            var status = dao.Update(assembly, assemblyDetails);

            return Json(new
            {
                status = status
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(long id)
        {
            var status = dao.Delete(id);

            return Json(new
            {
                status = status
            });
        }
    }
}
