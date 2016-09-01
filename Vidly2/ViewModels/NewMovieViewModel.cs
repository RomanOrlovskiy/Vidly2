using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
        public string Title
         {
             get
             {
                if (Movie != null && Movie.Id != 0)
                     return "Edit Movie";
 
                 return "New Movie";
             }
         }
    }
}
