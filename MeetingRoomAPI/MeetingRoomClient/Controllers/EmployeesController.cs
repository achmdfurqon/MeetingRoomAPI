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
    public class EmployeesController : Controller
    {
        readonly HttpClient client = new HttpClient();
        public EmployeesController()
        {
            client.BaseAddress = new Uri("https://brmapi.azurewebsites.net/API/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ActionResult Index()
        {
            return View(List());
        }

        public JsonResult List()
        {
            IEnumerable<EmployeesVM> employees = null;
            var responseTask = client.GetAsync("Employees");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<EmployeesVM>>();
                readTask.Wait();
                employees = readTask.Result;
            }
            else
            {
                employees = Enumerable.Empty<EmployeesVM>();
                ModelState.AddModelError(string.Empty, "404 Not Found");
            }
            return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
        }
    }
}