using MeetingRoomAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MeetingRoomClient.Controllers
{
    public class LoginController : Controller
    {
        readonly HttpClient client = new HttpClient();
        public LoginController()
        {
            client.BaseAddress = new Uri("http://localhost:62529/API/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult LoginView()
        //{
        //    return View(Login());
        //}
        //public JsonResult Login(UserModels userModels)
        //{
        //    //IEnumerable<UserModels> userModels = null;
        //    var responseTask = client.GetAsync("User");
        //    responseTask.Wait();
        //    var result = responseTask.Result;
        //    if (result.IsSuccessStatusCode)
        //    {
        //        var readTask = result.Content.ReadAsAsync<IList<UserModels>>
        //    }
        //}

        public JsonResult LoginList()
        {
            IEnumerable<UserModels> userModels = null;
            var responsetask = client.GetAsync("UserModels");
            responsetask.Wait();
            var result = responsetask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<UserModels>>();
                readTask.Wait();
                userModels = readTask.Result;
            }
            else
            {
                userModels = Enumerable.Empty<UserModels>();
                ModelState.AddModelError(string.Empty, "Maaf Data Tidak di Temukan");
            }
            return Json(new { data = userModels }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoginUser(UserModels userModels)
        {
            var myContent = JsonConvert.SerializeObject(userModels);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var affectedRow = client.PostAsync("Login", byteContent);
            return Json(new { data = affectedRow }, JsonRequestBehavior.AllowGet);
        }
    }
}