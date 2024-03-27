using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class ContactInfo
    {
        public int ID { get; set; }
        public string HeadText { get; set; }
        public string BottomText { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string EMail { get; set; }
        public string MapLocation { get; set; }
    }
}
