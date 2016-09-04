using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly2.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DateRented { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? DateReturned { get; set; }

        [Required]
        public Movie Movie { get; set; }

        [Required]
        public Customer Customer { get; set; }
        

    }
}
