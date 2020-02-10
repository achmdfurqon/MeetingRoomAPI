using MeetingRoomAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BCrypt;
using MeetingRoomAPI.HasingPassword;

namespace MeetingRoomAPI.Controllers
{
    public class LoginController : ApiController
    {
        ApplicationDbContext myContext = new ApplicationDbContext();
        public IQueryable<UserModels> GetUsers()
        {
            return myContext.Users;
        }

        [HttpGet]
        public IHttpActionResult GetUser(int Id)
        {
            UserModels userModels = myContext.Users.Find(Id);
            if (userModels != null)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost] 
        public IHttpActionResult Login(UserModels userModels)
        { 
                if (!string.IsNullOrWhiteSpace(userModels.Email))
                {
                    var login = myContext.Users.Where(a => a.Email.Equals(userModels.Email)).SingleOrDefault();
                    if(login.Email == userModels.Email)
                    {
                        var check = myContext.Users.FirstOrDefault(u => u.Id == login.Id);
                        if(check.Id == login.Id)
                        {
                        //var password = Hashing.validate(userModels.Password, login.Password);
                        var password = BCrypt.Net.BCrypt.Verify(userModels.Password, login.Password);
                            if (password == true) 
                            {
                            return Content(HttpStatusCode.OK, password);
                            }
                            return NotFound();
                        }
                        return NotFound();
                    }
                    return BadRequest();
                }
                return BadRequest();
        }

        //[HttpGet]
        //public IHttpActionResult GetLogin (UserModels user)
        //{

        //    UserModels userModels = myContext.Users.FirstOrDefault(a => a.Email.Equals(user.Email));
        //    if(userModels != null)
        //    {
        //        return Ok(userModels);
        //    }
        //    return NotFound();

        //}

        public IHttpActionResult PutForgotPassword (UserModels userModels, int Id)
        {
            var put = myContext.Users.Find(Id);
            if(put != null)
            {
                if (!string.IsNullOrWhiteSpace(userModels.Password))
                {
                    put.Password = userModels.Password;
                    myContext.Entry(put).State = EntityState.Modified;
                    var result = myContext.SaveChanges();
                    if(result > 0)
                    {
                        return Ok(userModels);  
                    }
                }
                return BadRequest();
            }
            return NotFound();
        }
    }
}
