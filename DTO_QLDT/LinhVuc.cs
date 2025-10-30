using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace De1_BaiTapNhom_Nhom3
{
    public abstract class LinhVuc
    {
        protected double kinhPhi;
        private double heSoTang = 1.0;


        public double KinhPhi { get => kinhPhi; set => kinhPhi = value; }
        public double HeSoTang { get => heSoTang; set => heSoTang = value; }

        public abstract void TinhKinhPhi();

        public virtual void XuatTT()
        {
        }
    }
}