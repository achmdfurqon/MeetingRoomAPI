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
    public class RoomsController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [HttpGet]
        public IQueryable<RoomsVM> GetRooms()
        {
            return context.Rooms;
        }
        
        [HttpGet]
        public IHttpActionResult GetRooms(int id)
        {
            RoomsVM room = context.Rooms.Find(id);
            if (room != null)
            {
                return Ok(room);
            }
            return NotFound();
        }
        
        [HttpPost]
        public IHttpActionResult Post(RoomsVM room)
        {
            if (!string.IsNullOrWhiteSpace(room.Name) && !string.IsNullOrWhiteSpace(room.Capacity.ToString()))
            {
                context.Rooms.Add(room);
                var result = context.SaveChanges();
                if (result > 0)
                {
                    return Ok(room);
                }
            }
            return BadRequest();
        }
        
        [HttpPut]
        public IHttpActionResult Put(int id, RoomsVM room)
        {
            var put = context.Rooms.Find(id);
            if (put != null)
            {
                if (!string.IsNullOrWhiteSpace(room.Name) && !string.IsNullOrWhiteSpace(room.Capacity.ToString()))
                {
                    put.Name = room.Name;
                    put.Capacity = room.Capacity;
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
        
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var room = context.Rooms.Find(id);
            if (room != null)
            {
                context.Rooms.Remove(room);
                context.SaveChanges();
                return Ok(room);
            }
            return BadRequest();
        }
    }
}
