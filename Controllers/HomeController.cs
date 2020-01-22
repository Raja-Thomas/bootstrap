using apiProject.Models;
using bootstrap.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace bootstrap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GetMembers()
        {
            ServicePointManager.ServerCertificateValidationCallback +=
  (Sender, Cer, Chain, SslPolicyErrors) => true;
            IEnumerable<Category> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("GetCategories").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
            return View(empList);
        }
    }
}
