using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net7.GraduateProject.Common;
using net7.GraduateProject.Models.Entities;
using net7.GraduateProject.Services.DAOs;
using Newtonsoft.Json;

namespace net7.GraduateProject.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public JsonResult Login(string username, string password, int type = 0)
        {
            password = Encryptor.MD5Hash(password);

            var dao = new UserDAO();
            var status = dao.Login(username, password, type);

            if (status > 1)
            {
                var data = (new LecturerDAO()).Get(username, "", "", "", 0, 0)[0];

                var user = new User();
                user.Id = data.Id;
                user.Password = data.Password;
                user.FullName = data.FullName;
                user.Avatar = data.Avatar;
                user.Gender = data.Gender;
                user.Birthday = data.Birthday;
                user.Address = data.Address;
                user.Phone = data.Phone;
                user.Email = data.Email;
                user.FacultyId = data.FacultyId;
                user.FacultyName = data.FacultyName;
                user.BranchId = data.BranchId;
                user.BranchName = data.BranchName;
                user.GroupId = data.GroupId;

                if (string.IsNullOrEmpty(HttpContext.Session.GetString("USER_SESSION")))
                {
                    string jsonSave = JsonConvert.SerializeObject(user);
                    HttpContext.Session.SetString("USER_SESSION", jsonSave);
                }

                return Json(new
                {
                    status = status,
                    data = data
                });
            }
            else if (status == 1)
            {
                var data = (new StudentDAO()).Get(username, "", "", "", "", "", 0, 0)[0];

                var user = new User();
                user.Id = data.Id;
                user.Password = data.Password;
                user.FullName = data.FullName;
                user.Avatar = data.Avatar;
                user.Gender = data.Gender;
                user.Birthday = data.Birthday;
                user.Address = data.Address;
                user.Phone = data.Phone;
                user.Email = data.Email;
                user.FacultyId = data.FacultyId;
                user.FacultyName = data.FacultyName;
                user.BranchId = data.BranchId;
                user.BranchName = data.BranchName;
                user.GroupId = 1;

                if (string.IsNullOrEmpty(HttpContext.Session.GetString("USER_SESSION")))
                {
                    string jsonSave = JsonConvert.SerializeObject(user);
                    HttpContext.Session.SetString("USER_SESSION", jsonSave);
                }

                return Json(new
                {
                    status = status,
                    data = data
                });
            }
            else
            {
                return Json(new
                {
                    status = status
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult Logout()
        {
            if (HttpContext.Session.GetString("USER_SESSION") != null)
            {
                HttpContext.Session.SetString("USER_SESSION", null);
                return Json(new
                {
                    status = 1
                });
            }
            else
            {
                return Json(new
                {
                    status = -1
                });
            }
        }
    }
}
