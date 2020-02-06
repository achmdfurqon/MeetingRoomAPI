using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeetingRoomAPI.Models
{
    [Table("TB_M_Roles")]
    public class RoleModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserModels> UserModels { get; set; }
    }
}