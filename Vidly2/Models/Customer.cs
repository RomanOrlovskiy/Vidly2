﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly2.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter{ get; set; }
        
        /*Navigation Property
            This is called navigation property because it allows
        us to navigate from one type to another. In this case
        from Customer to its MembershipType.
            Those navigation properties are useful when we want to
        load not only an object but also its related objects from database.
        Related objects are simly fields of an object that are a reference
        to another type.
            In this case we will be able to load a Customer and its
        MembershipType together.
             */            
        public MembershipType MembershipType { get; set; }

        #region Foreign Key
        /* Foreign Key
            In some cases(as for optimization) we dont want 
        to load internal Membership object. We might only need a
        Foreign Key. For this job its useful to have a 
        specific property as by convention shown below.
            EF recognise this convention and treats this property 
        as a FOREIGN KEY.
             */
        #endregion
        public byte MembershipTypeId { get; set; }
    }
}
