using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingRoomAPI.HasingPassword
{
    public class Hashing
    {
        public static string getRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(10);
        }
        public static string passwordHash(string Password)
        {
            return BCrypt.Net.BCrypt.HashPassword(Password, getRandomSalt());
        }
        public static bool validate(string Password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(Password, passwordHash);
        }
    }
}