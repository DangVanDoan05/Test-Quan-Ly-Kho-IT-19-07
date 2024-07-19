using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class QlyDonHangITDAO
    {
        private static QlyDonHangITDAO instance;

        public static QlyDonHangITDAO Instance
        {
            get { if (instance == null) instance = new QlyDonHangITDAO(); return QlyDonHangITDAO.instance; }
            private set { QlyDonHangITDAO.instance = value; }
        }

        private QlyDonHangITDAO() {}

        public List<string> GetLsNgayDHDaSX()  // Cần phải sắp xếp theo thời gian.
        {
            string query = "SELECT DISTINCT NGAYDH FROM QLYDONHANGIT "; // Chỉ lấy ra ngày đặt hàng duy nhất.
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<NgayDHDTO> LsNgayDH = new List<NgayDHDTO>();
            foreach (DataRow item in data.Rows)
            {
                NgayDHDTO a = new NgayDHDTO(item);
                LsNgayDH.Add(a);
            }
            int dodai = LsNgayDH.Count();
            DateTime[] MangNgayDH = new DateTime[dodai];
            int m = 0;
            foreach (NgayDHDTO item in LsNgayDH)
            {
                MangNgayDH[m] = item.NGAYDH;
                m++;
            }
            // Sắp xếp ngày yêu cầu:
            // Tiến hành sắp xếp mảng thời gian đặt hàng theo thứ tự giảm dần
            for (int i = 0; i < dodai - 1; i++)
            {
                for (int j = i + 1; j < dodai; j++)
                {
                    if (MangNgayDH[j] > MangNgayDH[i])
                    {
                        DateTime trunggian = MangNgayDH[j];
                        MangNgayDH[j] = MangNgayDH[i];
                        MangNgayDH[i] = trunggian;
                    }
                }
            }

            List<string> LsNgayDHDaSX = new List<string>();
            for (int k = 0; k < dodai; k++)
            {
                string NgayDH = MangNgayDH[k].ToString("dd/MM/yyyy");
                LsNgayDHDaSX.Add(NgayDH);
            }
            return LsNgayDHDaSX;

        }

        public List<QlyDonHangITDTO> GetLsQuaDuKienNhan()
        {
            string query = " select* from QLYDONHANGIT ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<QlyDonHangITDTO> LsQuaHan = new List<QlyDonHangITDTO>();
            foreach (DataRow item in data.Rows)
            {
                QlyDonHangITDTO a = new QlyDonHangITDTO(item);
                DateTime ngayDH = Convert.ToDateTime(a.NGAYDH);

                TimeSpan time = DateTime.Now - ngayDH;
                int songay = time.Days;

                if (songay > 15)
                {
                    LsQuaHan.Add(a);
                }
            }

            return LsQuaHan;
        }
        public List<QlyDonHangITDTO> GetLsDonHangIT()
        {
            string query = " select * from QLYDONHANGIT ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            // Lấy List ngày đặt hàng đã sắp xếp
            List<string> LsNgayDHDaSX = GetLsNgayDHDaSX();
            List<QlyDonHangITDTO> lsv = new List<QlyDonHangITDTO>();
            foreach (string item in LsNgayDHDaSX)
            {
                foreach (DataRow item1 in data.Rows)
                {
                    QlyDonHangITDTO a = new QlyDonHangITDTO(item1);
                    if (a.NGAYDH == item)
                        lsv.Add(a);
                }
            }
            return lsv;
        }

        public bool CheckCoDH(string MaLK)
        {
            string query = "select * from QLYDONHANGIT where MALK= @MaLK and SLNHAP=0 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { MaLK });
            int dem = data.Rows.Count;

            if(dem>0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public QlyDonHangITDTO GetDonHangITDTO(string MaDH)
        {
            string query = "select* from QLYDONHANGIT where MADH= @ma ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { MaDH });
            QlyDonHangITDTO MaMHDTO = new QlyDonHangITDTO(data.Rows[0]);
            return MaMHDTO;
        }


        //  QLYDONHANGIT(MADH, NGAYDH, MALK, TENLK, SLDAT, NGAYNH, SLNHAN, NGAYNK, SLNHAP, GHICHU)


        // HAM THEM 

        public int Insert(string MaDonHang, string MaLK,string TenLK, string NgayDat, int sldat,string NhaMay,string MDSD, string NgayNhan, int SLNhan, string NgayNhapKho,int SLnhapkho, string ghichu, int idKiemKe, string chitietKK)
        {
            string query = "insert QLYDONHANGIT(MADH, MALK, TENLK, NGAYDH , SLDAT,NHAMAY, MDSD , NGAYNH, SLNHAN, NGAYNK, SLNHAP, GHICHU, IDTTKIEMKE, CHITIETTTKK) " +
                        "values ( @ma , @malk , @tenlk , @ngaydh , @sldat , @nhamay , @mdsd , @ngaynh , @slnhan , @ngaynk , @slnhap , @chichu , @id , @chitietttkk )";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaDonHang,MaLK,TenLK,NgayDat,sldat,NhaMay, MDSD,NgayNhan,SLNhan,NgayNhapKho,SLnhapkho,ghichu,idKiemKe,chitietKK});
            return data;
        }


        // Cập nhật thông tin nhận hàng.


        public int UpdateNhanHang(string MaDonHang, string NgayNhan, int SLNhan, string ghichu)
        {
            string query = " UPDATE	QLYDONHANGIT SET NGAYNH= @ngayNH ,SLNHAN= @slnhan ,GHICHU= @ghichu where MADH= @MaDH ";              
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { NgayNhan,  SLNhan,  ghichu, MaDonHang });
            return data;
        }

        // Cập nhật thông tin nhập kho

        public int UpdateNhapKho(string MaDonHang, string NgayNhapKho, int SLNhap, string ghichu)
        {
            string query = " UPDATE	QLYDONHANGIT SET NGAYNK= @ngayNK ,SLNHAP= @slnhap ,GHICHU= @ghichu where MADH= @MaDH ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { NgayNhapKho,  SLNhap,  ghichu , MaDonHang });
            return data;
        }

        public int UpdateTTKK(string MaDonHang, int idKiemKe, string ChiTietKK)
        {
            string query = "update QLYDONHANGIT set IDTTKIEMKE= @IDKK ,CHITIETTTKK= @chitietKK where MADH= @ma ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idKiemKe, ChiTietKK, MaDonHang });
            return data;
        }

        // HAM XOA

        public int Delete(string MaDonHang)
        {
            string query = "DELETE QLYDONHANGIT WHERE MADH= @MaDH ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaDonHang });
            return data;
        }
    }
}
