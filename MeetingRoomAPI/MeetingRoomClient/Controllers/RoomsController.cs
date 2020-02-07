using MeetingRoomAPI.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MeetingRoomClient.Controllers
{
    public class RoomsController : Controller
    {
        readonly HttpClient client = new HttpClient();
        public RoomsController()
        {
            client.BaseAddress = new Uri("http://localhost:62529/API/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ActionResult Index()
        {
            return View(List());
        }

        public JsonResult List()
        {
            IEnumerable<RoomsVM> room = null;
            var responseTask = client.GetAsync("Rooms");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<RoomsVM>>();
                readTask.Wait();
                room = readTask.Result;
            }
            else
            {
                room = Enumerable.Empty<RoomsVM>();
                ModelState.AddModelError(string.Empty, "404 Not Found");
            }
            return Json(new { data = room }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Create(RoomsVM room)
        {
            var context = JsonConvert.SerializeObject(room);
            var buffer = System.Text.Encoding.UTF8.GetBytes(context);
            var byteContext = new ByteArrayContent(buffer);
            byteContext.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var postTask = client.PostAsync("Rooms/", byteContext).Result;
            return Json(new { data = postTask }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit(int id, RoomsVM room)
        {
            var context = JsonConvert.SerializeObject(room);
            var buffer = System.Text.Encoding.UTF8.GetBytes(context);
            var byteContext = new ByteArrayContent(buffer);
            byteContext.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var putTask = client.PutAsync("Rooms/" + id, byteContext).Result;
            return Json(new { data = putTask }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            var deleteTask = client.DeleteAsync("Rooms/" + id);
            deleteTask.Wait();
            return Json(new { data = deleteTask }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Detail(int id)
        {
            var responseTask = client.GetAsync("Rooms/" + id).Result.Content.ReadAsAsync<RoomsVM>().Result;
            return Json(new { data = responseTask }, JsonRequestBehavior.AllowGet);
        }
    }
}