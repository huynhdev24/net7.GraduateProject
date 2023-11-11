using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net7.GraduateProject.Models.Entities;
using net7.GraduateProject.Services.DAOs;

namespace net7.GraduateProject.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectStageController : Controller
    {
        ProjectStageDAO dao = new ProjectStageDAO();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projectId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Get(long id = 0, long projectId = 0, string name = "")
        {
            var data = dao.Get(id, projectId, name);
            var status = data.Count() > 0 ? true : false;

            return Json(new
            {
                status = status,
                data = data
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Insert(ProjectStage model)
        {
            var status = dao.Insert(model);

            return Json(new
            {
                status = status
            });

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Update(ProjectStage model)
        {
            var status = dao.Update(model);

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
