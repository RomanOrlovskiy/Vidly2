using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly2.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DateAdded { get; set; }

        [Range(1,20)]
        public byte NumberInStock { get; set; }                

        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }
    }
}
