using De1_BaiTapNhom_Nhom3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_QLDT
{
    public class DanhSachDeTaiBLL
    {
        private List<DeTai> dsdtai = new List<DeTai>();
        private DanhSachDeTaiDAL dal = new DanhSachDeTaiDAL();

        public void LoadFromXML(string fileName)
        {
            dsdtai = dal.ReadXML(fileName);
        }

        public void NhapVaoList()
        {
            DeTai deTai = new DeTai();
            Console.WriteLine("\n---------------------------------------------------------");
            Console.WriteLine("|\t\t   Thêm đề tài mới!!\t\t        |");
            Console.WriteLine("---------------------------------------------------------");

            Console.Write("|Nhập mã đề tài: ");
            deTai.MaSo = Console.ReadLine();
            bool tonTai = false;
            if (dsdtai.Any(t => t.MaSo == deTai.MaSo))
            {
                tonTai = true;
                Console.WriteLine("|Đề tài đã tồn tại!!!");
                Console.WriteLine("|Nhấn enter để nhập lại....");
                return;
            }

            Console.Write("|Nhập tên đề tài: ");
            deTai.TenDeTai = Console.ReadLine();

            Console.Write("|Nhập người chủ trì: ");
            deTai.ChuTri = Console.ReadLine();

            Console.Write("|Nhập giảng viên hướng dẫn: ");
            deTai.GiangVienHD = Console.ReadLine();

            Console.Write("|Nhập ngày bắt đầu: ");
            deTai.NgayBatDau = Console.ReadLine();

            Console.Write("|Nhập ngày kết thúc: ");
            deTai.NgayKetThuc = Console.ReadLine();
            Console.WriteLine("|Lĩnh vực nghiên cứu: ");
            Console.WriteLine("|1. Lĩnh vực lý thuyết");
            Console.WriteLine("|2. Lĩnh vực kinh tế");
            Console.WriteLine("|3. Lĩnh vực công nghệ");
            Console.Write("|Chọn lĩnh vực nghiên cứu (1-3): ");
            int chon = int.Parse(Console.ReadLine());

            if (chon < 1 || chon > 3)
            {
                Console.WriteLine("|Lĩnh vực không hợp lệ!!");
            }
            else if (chon == 1)
            {
                var lvlt = new DeTaiLyThuyet();
                int adtt = 0;
                Console.WriteLine("|Có thể áp dụng vào thực tế không? ");
                Console.WriteLine("|1: Có");
                Console.WriteLine("|0: Không ");
                Console.Write("--> ");
                adtt = int.Parse(Console.ReadLine());
                while (adtt != 1 && adtt != 0)
                {
                    Console.WriteLine("Không hợp lệ!!");
                    Console.Write("Nhập lại");
                    adtt = int.Parse(Console.ReadLine());
                }
                if (adtt == 1)
                {
                    lvlt.ApDungThucTe = true;
                }
                else
                {
                    lvlt.ApDungThucTe = false;
                }
                lvlt.TinhKinhPhi();
                deTai.Lv = lvlt;
            }
            else if (chon == 2)
            {
                var lvkt = new DeTaiKinhTe();
                Console.Write("|Nhập số câu hỏi: ");
                lvkt.SoCauHoi = int.Parse(Console.ReadLine());
                lvkt.TinhKinhPhi();
                lvkt.PhiHoTro();
                deTai.Lv = lvkt;
            }
            else
            {
                var lvcn = new DeTaiCongNghe();
                Console.WriteLine("|Nhập môi trường: ");
                Console.WriteLine("|1. Web");
                Console.WriteLine("|2. Window");
                Console.WriteLine("|3. Mobile");
                Console.Write("--> ");
                int moitruong = int.Parse(Console.ReadLine());
                while (moitruong < 1 && moitruong > 3)
                {
                    Console.WriteLine("|Môi trường không hợp lệ!!!");
                    Console.Write("|Nhập lại: ");
                    moitruong = int.Parse(Console.ReadLine());
                }
                if (moitruong == 1)
                {
                    lvcn.MoiTruong = "Web";
                }
                else if (moitruong == 2)
                {
                    lvcn.MoiTruong = "Window";
                }
                else
                {
                    lvcn.MoiTruong = "Mobile";
                }
                lvcn.TinhKinhPhi();
                lvcn.PhiHoTro();
                deTai.Lv = lvcn;
            }
            dsdtai.Add(deTai);

            if (!tonTai)
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("|\t\tThêm thành công!!\t\t\t|");
                Console.WriteLine("---------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("|\t\tThêm không thành công!!\t\t    |");
                Console.WriteLine("---------------------------------------------------------");
            }
        }

        public void XuatDS()
        {
            foreach (DeTai dt in dsdtai)
            {
                dt.XuatTT();
                dt.Lv.XuatTT();
                Console.WriteLine("---------------------------------------------------------");
            }
        }

        public bool IsEmpty()
        {
            return dsdtai.Count == 0;
        }

        public void UptadeTinhKinhPhi()
        {
            foreach (DeTai dt in dsdtai)
            {
                dt.Lv.HeSoTang = dt.Lv.HeSoTang * 1.1;
                dt.Lv.TinhKinhPhi();
            }
        }

        public void SearchByDeTai(string tdt)
        {
            List<DeTai> kq = new List<DeTai>();
            foreach (DeTai dt in dsdtai)
            {
                if (dt.TenDeTai.StartsWith(tdt))
                {
                    kq.Add(dt);
                }
            }
            if (kq.Count == 0)
            {
                Console.WriteLine("|Không tìm thấy đề tài với tên đề tài: " + tdt);
                Console.WriteLine("---------------------------------------------------------");
                return;
            }
            foreach (DeTai dt in kq)
            {
                dt.XuatTT();
                dt.Lv.XuatTT();
                Console.WriteLine("---------------------------------------------------------");
            }
        }

        public void SearchByMaSo(string ms)
        {
            List<DeTai> kq = new List<DeTai>();
            foreach (DeTai dt in dsdtai)
            {
                if (dt.MaSo.StartsWith(ms))
                {
                    kq.Add(dt);
                }
            }
            if (kq.Count == 0)
            {
                Console.WriteLine("|Không tìm thấy đề tài với mã số đề tài: " + ms);
                Console.WriteLine("---------------------------------------------------------");
                return;
            }
            foreach (DeTai dt in kq)
            {
                dt.XuatTT();
                dt.Lv.XuatTT();
                Console.WriteLine("---------------------------------------------------------");
            }
        }

        public void SearchByGiangVienHD(string giangvienhhd)
        {
            List<DeTai> kq = new List<DeTai>();
            foreach (DeTai dt in dsdtai)
            {
                if (dt.GiangVienHD.StartsWith(giangvienhhd))
                {
                    kq.Add(dt);
                }
            }
            if (kq.Count == 0)
            {
                Console.WriteLine("|Không tìm thấy đề tài với tên giảng viên hướng dẫn: " + giangvienhhd);
                Console.WriteLine("---------------------------------------------------------");
                return;
            }
            foreach (DeTai dt in kq)
            {
                dt.XuatTT();
                dt.Lv.XuatTT();
                Console.WriteLine("---------------------------------------------------------");
            }
        }

        public void SearchByTenNguoiChuTri(string chutri)
        {
            List<DeTai> kq = new List<DeTai>();
            foreach (DeTai dt in dsdtai)
            {
                if (dt.ChuTri.StartsWith(chutri))
                {
                    kq.Add(dt);
                }
            }
            if (kq.Count == 0)
            {
                Console.WriteLine("|Không tìm thấy đề tài với tên người chủ trì: " + chutri);
                Console.WriteLine("---------------------------------------------------------");
                return;
            }
            foreach (DeTai dt in kq)
            {
                dt.XuatTT();
                dt.Lv.XuatTT();
                Console.WriteLine("---------------------------------------------------------");
            }
        }

        public void OutputKinhPhiTren10Trieu()
        {
            List<DeTai> kq = new List<DeTai>();
            foreach (DeTai dt in dsdtai)
            {
                if (dt.Lv.KinhPhi > 10)
                {
                    kq.Add(dt);
                }
            }
            foreach (DeTai dt in kq)
            {
                dt.XuatTT();
                dt.Lv.XuatTT();
                Console.WriteLine("---------------------------------------------------------");
            }
        }

        public void OutputDeTaiCoTheTrienKhai()
        {
            List<DeTai> kq = new List<DeTai>();
            foreach (DeTai dt in dsdtai)
            {
                if (dt.Lv is DeTaiLyThuyet lt && lt.ApDungThucTe)
                {
                    kq.Add(dt);
                }
            }
            if (kq.Count == 0)
            {
                Console.WriteLine("|Không tìm thấy đề tài có thể triển khai!!!");
                Console.WriteLine("---------------------------------------------------------");
            }
            foreach (DeTai dt in kq)
            {
                dt.XuatTT();
                dt.Lv.XuatTT();
                Console.WriteLine("---------------------------------------------------------");
            }
        }

        public void OutputDeTaiCauHoiTren100()
        {
            List<DeTai> kq = new List<DeTai>();
            foreach (DeTai dt in dsdtai)
            {
                if (dt.Lv is DeTaiKinhTe ch && ch.SoCauHoi > 100)
                {
                    kq.Add(dt);
                }
            }
            if (kq.Count == 0)
            {
                Console.WriteLine("|Không tìm thấy đề tài có thể triển khai!!!");
                Console.WriteLine("---------------------------------------------------------");
            }
            foreach (DeTai dt in kq)
            {
                dt.XuatTT();
                dt.Lv.XuatTT();
                Console.WriteLine("---------------------------------------------------------");
            }
        }

        public void OutputDeTaiTGTren4Thang()
        {
            List<DeTai> kq = new List<DeTai>();
            foreach (DeTai dt in dsdtai)
            {
                DateTime batDau = DateTime.ParseExact(dt.NgayBatDau, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime ketThuc = DateTime.ParseExact(dt.NgayKetThuc, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                double soThang = (ketThuc - batDau).TotalDays / 30;
                if (soThang > 4)
                {
                    kq.Add(dt);
                }
            }
            if (kq.Count == 0)
            {
                Console.WriteLine("|Không tìm thấy đề tài có thể triển khai!!!");
                Console.WriteLine("---------------------------------------------------------");
            }
            foreach (DeTai dt in kq)
            {
                dt.XuatTT();
                dt.Lv.XuatTT();
                Console.WriteLine("---------------------------------------------------------");
            }
        }

        public void XoaDanhSach()
        {
            dsdtai.Clear();
        }
    }
}
