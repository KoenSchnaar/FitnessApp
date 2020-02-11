using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
    }
}
