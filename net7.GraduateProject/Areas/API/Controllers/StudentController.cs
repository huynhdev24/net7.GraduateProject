using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net7.GraduateProject.Models.Entities;
using net7.GraduateProject.Services.DAOs;

namespace net7.GraduateProject.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        StudentDAO dao = new StudentDAO();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fullName"></param>
        /// <param name="facultyId"></param>
        /// <param name="branchId"></param>
        /// <param name="classId"></param>
        /// <param name="trainingSystemId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonResult Get(string id = "", string fullName = "", string facultyId = "", string branchId = "", string classId = "", string trainingSystemId = "", int page = 0, int pageSize = 0)
        {
            List<Student> data = dao.Get(id, fullName, facultyId, branchId, classId, trainingSystemId, page, pageSize);
            long totalRow = dao.Count(id, fullName, facultyId, branchId, classId, trainingSystemId);
            bool status = data.Count() > 0 ? true : false;

            return Json(new
            {
                status = status,
                data = data,
                totalRow = totalRow
            });
        }
    }
}
