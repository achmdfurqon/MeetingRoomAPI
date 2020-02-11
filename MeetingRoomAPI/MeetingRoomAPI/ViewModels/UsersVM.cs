using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeetingRoomAPI.ViewModels
{
    [Table("TB_M_Users")]
    public class UsersVM
    {        
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }

    [Table("TB_M_Roles")]
    public class RolesVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [Table("TB_T_UserRoles")]
    public class UserRolesVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("UserId")]
        public UsersVM User { get; set; }
        [ForeignKey("RoleId")]
        public RolesVM Role { get; set; }
    }
}