using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly2.Models
{
    public class Customer
    {
        //This approach of changing the name of the label in HTML markup 
        //results in the need to recompile the code every time you change 
        //the label (?).
        [Display(Name = "Date of birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public int Id { get; set; }

        //Data annotations approach of overriding default conventions.
        //To override the default conventions of EF (for example, string type
        //it creates as a nullable field and sets unlimited range) you can specify
        //attributes that will put some limits on the field and as result
        //change its representation in the Database.
        //Another approach is called Fluent API.
        [Required] //Culumn name will no longer be nullable.
        [StringLength(255)]//Limits the size of the string.
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
        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}
