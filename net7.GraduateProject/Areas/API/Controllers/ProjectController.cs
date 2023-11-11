using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net7.GraduateProject.Models.Entities;
using net7.GraduateProject.Services.DAOs;

namespace net7.GraduateProject.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        ProjectDAO dao = new ProjectDAO();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="student"></param>
        /// <param name="lecturer"></param>
        /// <param name="projectTypeId"></param>
        /// <param name="year"></param>
        /// <param name="facultyId"></param>
        /// <param name="branchId"></param>
        /// <param name="classId"></param>
        /// <param name="pointStatus"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonResult Get(long id = 0, string name = "", string student = "", string lecturer = "", int projectTypeId = 0, int year = 0, string facultyId = "", string branchId = "", string classId = "", int pointStatus = 2, int page = 0, int pageSize = 0)
        {
            List<Project> data = dao.Get(id, name, student, lecturer, projectTypeId, year, facultyId, branchId, classId, pointStatus, page, pageSize);
            long totalRow = dao.Count(id, name, student, lecturer, projectTypeId, year, facultyId, branchId, classId, pointStatus);
            bool status = data.Count() > 0 ? true : false;

            return Json(new
            {
                status = status,
                data = data,
                totalRow = totalRow
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Insert(Project model)
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
        public JsonResult Update(Project model)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteSelection(long[] id)
        {
            int[] data = new int[id.Length];

            for (int i = 0; i < id.Length; i++)
            {
                data[i] = dao.Delete(id[i]);
            }

            return Json(new
            {
                status = true,
                data = data
            });
        }
    }
}
