using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly2.Dtos
{
    public class MembershipTypeDto
    {
        //Creating this DTO so that CustomerDto wont have dependancy on
        //MembershipType, but rather use this DTO.
        public byte Id { get; set; }
        public string Name { get; set; }
        //No need for all other properties because of a reason
    }
}
