using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyAPI
{
    public interface IMovieService
    {
        String getParentalControlLevel(String movieId);

    }
}
