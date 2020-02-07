using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeetingRoomAPI.ViewModels
{
    [Table("TB_M_Roles")]
    public class RolesVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UsersVM> User { get; set; }
    }
}