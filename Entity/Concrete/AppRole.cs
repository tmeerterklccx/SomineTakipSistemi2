using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class AppRole:IdentityRole<int>
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
