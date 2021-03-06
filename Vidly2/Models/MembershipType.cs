﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly2.Models
{
    public class MembershipType
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        /*"Id" or "TypeNameId"
         Every entity must have a key which would be mapped 
         to the primary key in the coresponding database. 
         It is usually called "Id" or "TypeNameId" by convention.
             */
        public byte Id { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonth { get; set; }

        public byte DiscountRate { get; set; }

        //Refactoring Magic numbers from Min18YearsIfAMember attribute
        //0 and 1 correspond to MembershipTypeId's that we defined
        //in our Database.0;
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;

    }
}
