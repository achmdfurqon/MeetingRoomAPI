using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingRoomAPI.Models
{
    public class EmployeeModels
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime birth_date { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}