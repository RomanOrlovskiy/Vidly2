using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class CustomerFormViewModel
    {
        //Creating a ViewModel so that it will be possible to pass
        //more than one type of object to the view.

        //Here we can use IEnumerable because we only need the
        //ability to iterate through this type nothing else in the View.
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}
