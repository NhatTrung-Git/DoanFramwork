using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csharp_Project.Models
{
    public class DSThongKe
    {
        private int thang;
        private int soluongbanra;
      
        public int THANG { set { thang = value; } get { return thang; } }
        public int SOLUONGBANRA { set { soluongbanra = value; } get { return soluongbanra; } }

        public DSThongKe()
        {

        }
    }
}
