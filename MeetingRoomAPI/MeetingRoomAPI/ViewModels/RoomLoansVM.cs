using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeetingRoomAPI.ViewModels
{
    [Table("TB_T_RoomLoans")]
    public class RoomLoansVM
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime LoanDate { get; set; }
        public int RoomId { get; set; }
    }
}