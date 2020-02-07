using MeetingRoomAPI.Models;
using MeetingRoomAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MeetingRoomClient.Controllers
{
    public class UsersController : Controller
    {
        readonly HttpClient client = new HttpClient();
        public UsersController()
        {
            client.BaseAddress = new Uri("http://localhost:62529/API/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Detail(int id)
        {
            var responseTask = client.GetAsync("Rooms/" + id).Result.Content.ReadAsAsync<UsersVM>().Result;
            return Json(new { data = responseTask }, JsonRequestBehavior.AllowGet);
        }
    }
}