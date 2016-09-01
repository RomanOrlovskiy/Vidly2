using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly2.Models
{
    public class Movie
    {
        public int  Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        /* DateTime2 is required to avoid an error when 
           trying to save changes to DB in Controller
           using SaveChanges() method. This error occures
           because DB and this property have different
           default DateTime types. So i specify here this
           attribute to a property and make changes to DB
           through migration to changes the default value
           of this field in DB.*/
        
        [Display(Name="Release date")]
        [Column(TypeName = "DateTime2")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name="Date added")]
        [Column(TypeName = "DateTime2")]
        public DateTime DateAdded { get; set; }

        
        [Range(1,20)]
        [Display(Name="Number in stock")]
        public byte NumberInStock { get; set; }

        //If we specify this propperty as required, we will face
        //a problem while trying to save new object in Movies/Save action
        //This is because when we recieve a Movie object in Save action
        //through Late Binding, its Genre property will be NULL, and as
        //result an exception will be rased. 
        //To deal with this problem we can move [Required] attribute
        //to GenreId property.       
        public Genre Genre { get; set; }
        
        [Required]
        [Display(Name="Genre")]
        public byte GenreId { get; set; }



    }
}
