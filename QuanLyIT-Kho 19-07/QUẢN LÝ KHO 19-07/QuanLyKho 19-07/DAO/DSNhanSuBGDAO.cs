using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DSNhanSuBGDAO
    {
        private static DSNhanSuBGDAO instance;

        public static DSNhanSuBGDAO Instance
        {
            get { if (instance == null) instance = new DSNhanSuBGDAO(); return DSNhanSuBGDAO.instance; }
            private set { DSNhanSuBGDAO.instance = value; }
        }

        private DSNhanSuBGDAO() { }

        public DataTable GetTable(string maBBBG)
        {
            string query = "select * from DSNHANSUBG where MABBBG= @ma ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maBBBG });
            return data;
        }
        public int CheckExist(string maBBBG)
        {
            string query = "select * from DSNHANSUBG where MABBBG= @ma ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maBBBG });
            return data.Rows.Count;
        }
        public DSNhanSuBGDTO GetTTNSBG(string maBBBG)
        {
            string query = "select * from DSNHANSUBG where MABBBG= @ma ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maBBBG });
            DSNhanSuBGDTO nhansubg = new DSNhanSuBGDTO(data.Rows[0]);
            return nhansubg;
        }


        public int Insert(string maBBBG, string ngayBG, string MaNVBG, string TenNVBG, string PBNBG, string MaNVnhanBG, string tenNVnhanBG,string lydoBG,string MaMT)
        {
            string query = "insert DSNHANSUBG(MABBBG,NGAYBG,MANVBG,TENNVBG,PBNBG,MANVNHANBG,TENNVNHANBG,LYDOBG,MAMT)" +
                                     " values ( @maBBBG , @ngaybg , @manvbg , @tennvbg , @pb , @manvnhanBG , @tenNVnhanBG , @lydoBG , @maMT ) ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maBBBG, ngayBG, MaNVBG , TenNVBG , PBNBG, MaNVnhanBG,tenNVnhanBG, lydoBG, MaMT });
            return data;
        }

        public int Update(string maBBBG, string ngayBG, string MaNVBG, string TenNVBG, string PBNBG, string MaNVnhanBG, string tenNVnhanBG, string lydoBG, string MaMT)
        {
            string query = "update DSNHANSUBG set NGAYBG= @ngay ,MANVBG= @manvbg ,TENNVBG= @tennvbg ,PBNBG= @pb ,MANVNHANBG= @manvnhanbg ,TENNVNHANBG= @tennvnhanbg ,LYDOBG= @lydo ,MAMT= @mamt where MABBBG= @mabbbg ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] {  ngayBG, MaNVBG, TenNVBG, PBNBG, MaNVnhanBG, tenNVnhanBG, lydoBG, MaMT,maBBBG });
            return data;
        }

        public int Delete(string maBBBG)
        {
            string query = " DELETE DSNHANSUBG WHERE MABBBG= @ma ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] {maBBBG});
            return data;
        }

    }
}
