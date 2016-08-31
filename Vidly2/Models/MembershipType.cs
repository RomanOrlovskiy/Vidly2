using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly2.Models
{
    public class MembershipType
    {
        /*"Id" or "TypeNameId"
         Every entity must have a key which would be mapped 
         to the primary key in the coresponding database. 
         It is usually called "Id" or "TypeNameId" by convention.
             */
        public byte Id { get; set; }

        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }

    }
}
