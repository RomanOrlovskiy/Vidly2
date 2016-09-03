using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly2.Models
{
    public class RoleName
    {
        //Dealing with the magic string so that we can modify
        //the name only here, not every [Authorize(Role="CanManageMovies")]
        public const string CanManageMovies = "CanManageMovies";
    }
}
