using BLL_QLDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De1_BaiTapNhom_Nhom3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;


            int choice;
            DanhSachDeTaiBLL dsdt = new DanhSachDeTaiBLL();
            do
            {
                Console.WriteLine();
                Console.WriteLine("======================================================================");
                Console.WriteLine("|\tHỆ THỐNG QUẢN LÝ ĐỀ TÀI NGHIÊN CỨU KHOA HỌC SINH VIÊN\t     |");
                Console.WriteLine("======================================================================");
                Console.WriteLine("|\t\t\t\t\t\t\t\t     |");
                Console.WriteLine("| [1] Tải dữ liệu từ file Xml.\t\t\t\t\t     |");
                Console.WriteLine("| [2] Thêm đề tài từ bàn phím.\t\t\t\t\t     |");
                Console.WriteLine("| [3] Xuất danh sách các đề tài.\t\t\t\t     |");
                Console.WriteLine("| [4] Tìm kiếm đề tài theo tên đề tài.\t\t\t\t     |");
                Console.WriteLine("| [5] Tìm kiếm theo mã số đề tài. \t\t\t\t     |");
                Console.WriteLine("| [6] Tìm kiếm theo tên người chủ trì.\t\t\t\t     |");
                Console.WriteLine("| [7] Danh sách các đề tài theo tên giảng viên hướng dẫn.\t     |");
                Console.WriteLine("| [8] Cập nhật kinh phí thực hiện của các đề tài tăng lên 10%.\t     |");
                Console.WriteLine("| [9] Danh sách đề tài có kinh phí trên 10 triệu.\t\t     |");
                Console.WriteLine("| [10] Danh sách đề tài thuộc lĩnh vực lý thuyết & có thể triển khai.|");
                Console.WriteLine("| [11] Danh sách đề tài kinh tế có số câu hỏi trên 100.\t\t     |");
                Console.WriteLine("| [12] Danh sách đề tài có thời gian thực hiện trên 4 tháng.\t     |");
                Console.WriteLine("| [13] Xóa danh sách.\t\t\t\t\t\t     |");
                Console.WriteLine("| [0] Thoát.\t\t\t\t\t\t\t     |");
                Console.WriteLine("|\t\t\t\t\t\t\t\t     |");
                Console.WriteLine("======================================================================");
                Console.Write("| Chọn chức năng: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            Console.Clear();
                            dsdt.LoadFromXML("DSDETAI.xml");
                            Console.WriteLine("\n---------------------------------------------------------");
                            Console.WriteLine("|\t\tTải dữ liệu thành công!!\t\t|");
                            Console.WriteLine("---------------------------------------------------------");
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            dsdt.NhapVaoList();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            if (dsdt.IsEmpty())
                            {
                                Console.WriteLine("\n---------------------------------------------------------");
                                Console.WriteLine("|\t\tDanh sách rỗng\t\t\t\t|");
                                Console.WriteLine("---------------------------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("\n---------------------------------------------------------");
                                Console.WriteLine("|\t\tDanh sách các đề tài\t\t\t|");
                                Console.WriteLine("---------------------------------------------------------");
                                dsdt.XuatDS();
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.Write("Nhập tên đề tài cần tìm: ");
                            string tdt = Console.ReadLine();
                            Console.WriteLine("\n---------------------------------------------------------");
                            Console.WriteLine("|\t\tKết quả tìm kiếm\t\t\t|");
                            Console.WriteLine("---------------------------------------------------------");
                            dsdt.SearchByDeTai(tdt);
                            break;
                        }
                    case 5:
                        {
                            Console.Write("Nhập mã số đề tài cần tìm: ");
                            string msdt = Console.ReadLine();
                            Console.WriteLine("\n---------------------------------------------------------");
                            Console.WriteLine("|\t\tKết quả tìm kiếm\t\t\t|");
                            Console.WriteLine("---------------------------------------------------------");
                            dsdt.SearchByMaSo(msdt);
                            break;
                        }
                    case 6:
                        {
                            Console.Write("Nhập tên người chủ trì cần tìm: ");
                            string chutri = Console.ReadLine();
                            Console.WriteLine("\n---------------------------------------------------------");
                            Console.WriteLine("|\t\tKết quả tìm kiếm\t\t\t|");
                            Console.WriteLine("---------------------------------------------------------");
                            dsdt.SearchByTenNguoiChuTri(chutri);
                            break;
                        }
                    case 7:
                        {
                            Console.Write("Nhập tên giảng viên hướng dẫn cần tìm: ");
                            string gvhd = Console.ReadLine();
                            Console.WriteLine("\n---------------------------------------------------------");
                            Console.WriteLine("|\t\tKết quả tìm kiếm\t\t\t|");
                            Console.WriteLine("---------------------------------------------------------");
                            dsdt.SearchByGiangVienHD(gvhd);
                            break;
                        }
                    case 8:
                        {
                            Console.Clear();
                            dsdt.UptadeTinhKinhPhi();
                            Console.WriteLine("\n---------------------------------------------------------");
                            Console.WriteLine("|\t\tCập nhật kinh phí thành công!!\t\t|");
                            Console.WriteLine("---------------------------------------------------------");
                            break;
                        }
                    case 9:
                        {
                            Console.WriteLine("\n---------------------------------------------------------");
                            Console.WriteLine("|\t\tĐề tài có kinh phí trên 10 triệu\t|");
                            Console.WriteLine("---------------------------------------------------------");
                            dsdt.OutputKinhPhiTren10Trieu();
                            break;
                        }
                    case 10:
                        {
                            Console.Clear();
                            Console.WriteLine("\n---------------------------------------------------------");
                            Console.WriteLine("|\t\tĐề tài lý thuyết có thể triển khai\t|");
                            Console.WriteLine("---------------------------------------------------------");
                            dsdt.OutputDeTaiCoTheTrienKhai();
                            break;
                        }
                    case 11:
                        {
                            Console.Clear();
                            Console.WriteLine("\n---------------------------------------------------------");
                            Console.WriteLine("|\t\tĐề tài kinh tế có số câu hỏi trên 100\t|");
                            Console.WriteLine("---------------------------------------------------------");
                            dsdt.OutputDeTaiCauHoiTren100();
                            break;
                        }
                    case 12:
                        {
                            Console.Clear();
                            Console.WriteLine("\n---------------------------------------------------------");
                            Console.WriteLine("|\tĐề tài có thời gian thực hiện trên 4 tháng\t|");
                            Console.WriteLine("---------------------------------------------------------");
                            dsdt.OutputDeTaiTGTren4Thang();
                            break;
                        }
                    case 13:
                        {
                            Console.Clear();
                            dsdt.XoaDanhSach();
                            Console.WriteLine("\n---------------------------------------------------------");
                            Console.WriteLine("|\tĐã xóa danh sách\t|");
                            Console.WriteLine("---------------------------------------------------------");
                            break;
                        }
                    case 0:
                        {
                            Console.Clear();
                            Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!!!");
                            break;
                        }
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!! \nVui lòng chọn lại!!!");
                        Console.ReadKey();
                        break;
                }
            } while (choice != 0);
        }

    }
}
