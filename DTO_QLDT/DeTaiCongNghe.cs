using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace De1_BaiTapNhom_Nhom3
{
    public class DeTaiCongNghe : LinhVuc, IDeTai
    {
        private string moiTruong;
        private double hoTro;

        public string MoiTruong { get => moiTruong; set => moiTruong = value; }
        public double HoTro { get => hoTro; set => hoTro = value; }

        public override void XuatTT()
        {
            base.XuatTT();
            Console.WriteLine($"|- Môi trường: {MoiTruong}");
            Console.WriteLine($"|- Kinh Phí của lĩnh vực công nghệ:\t{KinhPhi} tr (VNĐ)\t");
            if (PhiHoTro() <= 1)
                Console.WriteLine($"|- Phi Hỗ Trợ cho lĩnh vực công nghệ:\t{PhiHoTro()} tr (VNĐ)\t");
            else
                Console.WriteLine($"|- Phi Hỗ Trợ cho lĩnh vực công nghệ:\t{PhiHoTro()} nghìn (VNĐ)\t");
        }

        public override void TinhKinhPhi()
        {
            if (MoiTruong.ToLower() == "web" || MoiTruong.ToLower() == "mobile")
                KinhPhi = 15;
            else if (MoiTruong.ToLower() == "window")
                KinhPhi = 10;
            KinhPhi = KinhPhi * HeSoTang;
        }

        public double PhiHoTro()
        {

            if (MoiTruong.ToLower() == "mobile")
                return HoTro = 1;
            else if (MoiTruong.ToLower() == "web")
                return HoTro = 800;
            else if (MoiTruong.ToLower() == "window")
                return HoTro = 500;
            return HoTro = 0;
        }
    }
}