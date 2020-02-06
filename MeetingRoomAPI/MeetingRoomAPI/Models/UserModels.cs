using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeetingRoomAPI.Models
{
    [Table("TB_M_Users")]
    public class UserModels
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public ICollection<RoleModels> RoleModels { get; set; }
    }
}