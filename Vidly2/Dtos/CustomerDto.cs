using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly2.Models;

namespace Vidly2.Dtos
{
    //This class should not contain any reference type objects
    //like MembershipType.
    public class CustomerDto
    {
        //No need for data annotations here anymore. We dont need
        //[Required] or [Display] because we are no longer using Views.
       
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        /*We should exclude the MembershipType type because this is
          a domain class and this property here is creating dependancy
          from our DTO to domain model. So if we change MembershipType
          this can impact our DTO. If there is a need, you can create
          DTO class for MembershipType.          
          
             */
        //public MembershipType MembershipType { get; set; }        

        public byte MembershipTypeId { get; set; }
    }
}
