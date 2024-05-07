using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Order
    {
        public int OrderID { get; set; }
        public string UserMail { get; set; }
        public string ProductName { get; set; }
        public int Yukseklik { get; set; }
        public int Genislik { get; set; }
        public string Adres { get; set; }
        public bool Statu { get; set; }
    }
}
