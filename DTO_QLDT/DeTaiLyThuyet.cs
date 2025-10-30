using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace De1_BaiTapNhom_Nhom3
{
    public class DeTaiLyThuyet : LinhVuc
    {
        private bool apDungThucTe;

        public bool ApDungThucTe { get => apDungThucTe; set => apDungThucTe = value; }

        public override void XuatTT()
        {
            base.XuatTT();
            Console.WriteLine($"|- Áp dụng thực tế: {ApDungThucTe}");
            Console.WriteLine($"|- Kinh Phí của lĩnh vực lý thuyết:\t{KinhPhi} tr (VNĐ) \t");
        }

        public override void TinhKinhPhi()
        {
            if (ApDungThucTe)
                KinhPhi = 15;
            else
                KinhPhi = 8;
            KinhPhi = KinhPhi * HeSoTang;
        }
    }
}