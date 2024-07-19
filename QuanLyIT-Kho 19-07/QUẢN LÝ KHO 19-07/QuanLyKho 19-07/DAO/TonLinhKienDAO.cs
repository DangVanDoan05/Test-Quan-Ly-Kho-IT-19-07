using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TonLinhKienDAO
    {
        private static TonLinhKienDAO instance;

        public static TonLinhKienDAO Instance
        {
            get { if (instance == null) instance = new TonLinhKienDAO(); return TonLinhKienDAO.instance; }
            private set { TonLinhKienDAO.instance = value; }
        }
        private TonLinhKienDAO() { }
        public TonLinhKienDTO GetMaLKTon(string malk)
        {
            string query = "select * from TONLINHKIEN2 where MALK= @malk ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { malk });
            DataRow row = data.Rows[0];
            TonLinhKienDTO maTon = new TonLinhKienDTO(row);
            return maTon;
        }

        public List<TonLinhKienDTO> GetListMaLKTon()
        {
            string query = "select * from TONLINHKIEN2";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<TonLinhKienDTO> lsv = new List<TonLinhKienDTO>();
            foreach (DataRow item in data.Rows)
            {
                TonLinhKienDTO ton = new TonLinhKienDTO(item);
                lsv.Add(ton);
            }
            return lsv;
        }
        public DataTable GetTable()
        {
            string query = "select * from TONLINHKIEN2";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public bool CheckMaLKTon(string malk)
        {
            string query = "select * from TONLINHKIEN2 where MALK= @malk ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { malk });
            int dem= data.Rows.Count;
            if(dem>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Insert(string malk, string tenlk, int slton, string dvtinh, string ngaydat, int sldat, string ngaynhan, int slnhan,int idKiemKe,string ChiTietKK)
        {
            string query = "insert TONLINHKIEN2(MALK,TENLK,SLTON,DVTINH,NGAYDATHANG,SLDAT,NGAYNHANHANG,SLNHAN,IDTTKIEMKE,CHITIETTTKK)" +
                                    " values ( @ma , @ten , @slton , @dvtinh , @ngaydat , @sldat , @ngaynhan , @SLNHAN , @idKK , @chitietKK ) ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] {  malk,tenlk, slton, dvtinh, ngaydat, sldat, ngaynhan, slnhan, idKiemKe,ChiTietKK});
            return data;
        }

        public int Update(string malk, string tenlk, int slton, string dvtinh, bool dathang, string ngaydat, int sldat, bool nhanhang,int slnhan, string ngaynhan)
        {
            string query = "update TONLINHKIEN2 set TENLK= @ten ,SLTON= @slton ,DVTINH= @dvi ,DATHANG= @dh ,NGAYDATHANG= @ndh ,SLDAT= @sldat ,NHANHANG= @nh ,SLNHAN= @slnhan ,NGAYNHANHANG= @ngaynhan where MALK= @ma";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tenlk, slton, dvtinh, dathang, ngaydat, sldat, nhanhang, slnhan, ngaynhan, malk });
            return data;
        }
        public int UpdateTenLKDviTinh(string malk, string tenlk, string dvtinh)
        {
            string query = "update TONLINHKIEN2 set TENLK= @ten ,DVTINH= @dvi where MALK= @ma ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tenlk, dvtinh, malk });
            return data;
        }

        public int UpdateDatHang(string malk, string ngaydat, int sldat)
        {
            string query = "update TONLINHKIEN2 set NGAYDATHANG= @ngaydh ,SLDAT= @sldat where MALK= @ma ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ngaydat, sldat , malk });
            return data;
        }
        public int UpdateNhanHang(string malk, string ngaynhanhang, int slnhan)
        {
            string query = "update TONLINHKIEN2 set NGAYNHANHANG= @ngaydh ,SLNHAN= @slnhan where MALK= @ma ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { ngaynhanhang, slnhan, malk });
            return data;
        }

        public int UpdateTTKiemKe(string malk, int idKiemKe, string ChiTietKK)
        {
            string query = "update TONLINHKIEN2 set IDTTKIEMKE= @IDKK ,CHITIETTTKK= @chitietKK where MALK= @ma ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idKiemKe, ChiTietKK, malk });
            return data;
        }


        public int UpdateSLTON(string malk, int slton)
        {
            string query = "update TONLINHKIEN2 set SLTON= @ton where MALK= @ma ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { slton, malk });
            return data;
        }

        public int Delete(string malk)
        {
            string query = " DELETE TONLINHKIEN2 WHERE MALK= @malk ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { malk });
            return data;
        }


    }

}
