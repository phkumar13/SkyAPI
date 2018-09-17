using System.Web.Http;

using SkyAPI.Models;

namespace SkyAPI.Controllers
{
    public class MovieServiceController : ApiController
    {

        /*
         * Dependency Injection can be introduced as under for movies repository to query against 
         * 
            
            private readonly MovieRepository _repository;

            public MovieServiceController(MovieRepository repository)
            {
                _repository = repository;
            }

        */


        // GET api/MovieService/ParentalControlLevel/A
        [HttpGet]
        [Route("api/MovieService/ParentalControlLevel/{movieId}")]
        public string getParentalControlLevel(string movieId)
        {
            //return _repository.getParentalControlLevel(movieId);

            Movie movie = new Movie();
            return movie.getParentalControlLevel(movieId);
        }
    }
}