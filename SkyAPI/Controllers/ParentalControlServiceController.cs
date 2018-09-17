using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace SkyAPI.Controllers
{
    public class ParentalControlServiceController : ApiController
    {

        // GET api/MovieService/ParentalControlLevel/A
        [HttpGet]
        [Route("api/ParentalControlService/ParentalControlLevel/{movieId}/{parentalControlLevelPreference}")]
        public string checkParentalControlLevel(string movieId, string parentalControlLevelPreference)
        {

            #region Calling external Web API

            // -------------------------------------------------
            // --- Calling / consuming from external Service ---
            // -------------------------------------------------
            /*
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:1234/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/MovieService/ParentalControlLevel/" + movieId).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsAsync<IEnumerable<string>>().Result;
                foreach (var x in data)
                {
                    // Process Data
                }
            }
            else
            {
                Exception ex = new Exception(response.RequestMessage.ToString());
                return ex.ToString();
            }
            */

            #endregion Calling external Web API

            #region Calling internal Web API

            // -------------------------------------------
            // --- Calling Another Service from within ---
            // -------------------------------------------
            var moviesController = new MovieServiceController
            {
                Request = new HttpRequestMessage(HttpMethod.Get, Request.RequestUri.AbsoluteUri.Replace("/ParentalControlService/ParentalControlLevel/", "/MovieService/ParentalControlLevel/"))
            };
            moviesController.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = new HttpConfiguration();

            string result = moviesController.getParentalControlLevel(movieId);

            if (result.IndexOf("Exception") > 0)
            {
                Exception ex = new Exception(result);
                return ex.ToString();
            }

            return (parentalControlLevelPreference == result).ToString();

            #endregion Calling internal Web API

        }
    }
}
