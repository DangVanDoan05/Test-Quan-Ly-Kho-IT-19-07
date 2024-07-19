using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class QLVATTUSDDAO
    {
        private static QLVATTUSDDAO instance;

        public static QLVATTUSDDAO Instance
        {
            get { if (instance == null) instance = new QLVATTUSDDAO(); return QLVATTUSDDAO.instance; }
            private set { QLVATTUSDDAO.instance = value; }
        }

        private QLVATTUSDDAO() { }

        public DataTable GetTable()
        {
            string query = "select * from QLVATTUSD ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public DataTable GetVtuOfYC(string MaYCKT)
        {
            string query = "select * from QLVATTUSD where MAYCKT = @ma ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { MaYCKT});
            return data;
        }
        public QLVATTUSDDTO GetVtuDTOOfYC (string MaYCKT, string MaVtu)
        {
            string query = "select * from QLVATTUSD where MAYCKT= @maYC and MAVATTUSD= @maVtu ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { MaYCKT, MaVtu });
            QLVATTUSDDTO a = new QLVATTUSDDTO(data.Rows[0]);
            return a;
        }

        public bool CheckUpdateVtu(string MaYCKT)
        {
            string query = "select * from QLVATTUSD where MAYCKT= @maYC ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { MaYCKT });
            int dem = data.Rows.Count;
            if (dem > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckExist(string MaYCKT,string MaVtu)
        {
            string query = "select * from QLVATTUSD where MAYCKT= @maYC and MAVATTUSD= @maVtu ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { MaYCKT , MaVtu });
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


        public int Insert(string MaYCKT, string MaVtu, string TenVtu, int SoLuongSD)
        {
            string query = "insert QLVATTUSD(MAYCKT,MAVATTUSD,TENVATTUSD,SLVATTUSD) values ( @MaYC , @mavattu , @ten , @soluong ) ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaYCKT,MaVtu, TenVtu,  SoLuongSD});
            return data;
        }

        public int UpdateSoLuongSD(string MaYCKT, string MaVtu, int SoLuongSD)
        {
            string query = "update QLVATTUSD set SLVATTUSD= @sl where MAYCKT= @maYC and MAVATTUSD= @MaVtu ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { SoLuongSD , MaYCKT,  MaVtu });
            return data;
        }

        public int DeleteVtu(string MaYCKT, string MaVtu)
        {
            string query = " DELETE QLVATTUSD WHERE MAYCKT= @maYC and MAVATTUSD= @MaVtu ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaYCKT, MaVtu });
            return data;
        }

        public int Delete(string MaYCKT)
        {
            string query = " DELETE QLVATTUSD WHERE MAYCKT= @maYC ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaYCKT });
            return data;
        }

    }
}
