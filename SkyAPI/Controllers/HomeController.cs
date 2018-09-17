using System;
using System.Net.Http;
using System.Web.Mvc;

namespace SkyAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Check()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ParentalControlResults(string message)
        {
            ViewBag.StatusMessage = message;

            return View();
        }

        [HttpPost, ActionName("Check")]
        public ActionResult CheckParentalControlLevel(string parentalControlLevel, string movieId)
        {
            var moviesController = new MovieServiceController
            {
                Request = new HttpRequestMessage(HttpMethod.Get, "/ParentalControlService/ParentalControlLevel/")
            };
            moviesController.Request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = new System.Web.Http.HttpConfiguration();

            string result = moviesController.getParentalControlLevel(movieId);

            if (result.IndexOf("Exception") > 0)
            {
                Exception ex = new Exception(result);
                ViewBag.StatusMessage = ex.ToString();
            }

            ViewBag.StatusMessage = (parentalControlLevel == result) ? "True : Parental Control Level passed" 
                                                                     : "False : Parental Control Level failed";

            return RedirectToAction(nameof(ParentalControlResults), "Home", new { message = ViewBag.StatusMessage });

        }
    }
}
