using MeetingRoomAPI.Models;
using MeetingRoomAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeetingRoomAPI.Controllers
{
    public class RolesController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [HttpGet]
        public IQueryable<RolesVM> GetRoles()
        {
            return context.Roles;
        }

        //[ResponseType(typeof(RoleModels))]
        [HttpGet]
        public IHttpActionResult GetRoles(int id)
        {
            RolesVM role = context.Roles.Find(id);
            if (role != null)
            {
                return Ok(role);
            }
            return NotFound();
        }

        //[ResponseType(typeof(RoleModels))]
        [HttpPost]
        public IHttpActionResult Post(RolesVM role)
        {
            if (!string.IsNullOrWhiteSpace(role.Name))
            {
                context.Roles.Add(role);
                var result = context.SaveChanges();
                if (result > 0)
                {
                    return Ok(role);
                }
            }
            return BadRequest();
        }

        //[ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Put(int id, RolesVM role)
        {
            var put = context.Roles.Find(id);
            if (put != null)
            {
                if (!string.IsNullOrWhiteSpace(role.Name))
                {
                    put.Name = role.Name;
                    context.Entry(put).State = EntityState.Modified;
                    var result = context.SaveChanges();
                    if (result > 0)
                    {
                        return Ok(put);
                    }
                }
                return BadRequest();
            }
            return NotFound();
        }

        //[ResponseType(typeof(RoleModels))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var role = context.Roles.Find(id);
            if (role != null)
            {
                context.Roles.Remove(role);
                context.SaveChanges();
                return Ok(role);
            }
            return BadRequest();
        }
    }
}
