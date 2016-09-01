using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        //If called from Movies/New, then specify Id property
        //so that we can then check which title to display
        //in a View: New movie or Edit movie.
        public MovieFormViewModel()
        {
            Id = 0;
        }

        //When creating or editing a movie, initialize fields
        //with what user has passed.
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
        }


        //Making all those properties nullable is required so that
        //when loading empty form to create New movie (Movies/New)
        //there wont be default data for any of the fields,
        //like 1/1/0001 for DateTime or 0 for byte.
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Release date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }

        //If we specify this propperty as required, we will face
        //a problem while trying to save new object in Movies/Save action
        //This is because when we recieve a Movie object in Save action
        //through Late Binding, its Genre property will be NULL, and as
        //result an exception will be rased. 
        //To deal with this problem we can move [Required] attribute
        //to GenreId property.
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
    }
}
