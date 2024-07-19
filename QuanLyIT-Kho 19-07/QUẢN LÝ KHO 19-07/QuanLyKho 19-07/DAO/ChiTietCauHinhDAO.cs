using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ChiTietCauHinhDAO
    {
       
        private static ChiTietCauHinhDAO instance;

        public static ChiTietCauHinhDAO Instance
        {
            get { if (instance == null) instance = new ChiTietCauHinhDAO(); return ChiTietCauHinhDAO.instance; }
            private set { ChiTietCauHinhDAO.instance = value; }
        }
        private ChiTietCauHinhDAO() { }

        public DataTable GetTable()
        {
            string query = "select * from CHITIETCAUHINH";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public int Insert(string MaMT, string phongban,string nguoisd, string chipCPU, string ram, string rom, string mainboard, string vga, string tancase, string tanCPU, string nguon, string vocase)
        {
            string query = "insert CHITIETCAUHINH(MAMT,PHONGBAN,NGUOISD,CHIPCPU,RAM,ROM,MAINBOARD,VGA,TANCASE,TANCPU,NGUON,VOCASE) values ( @mamt , @pb , @ngsd , @cpu , @ram , @rom , @main , @vga , @tancase , @tancpu , @nguon , @vocase )";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaMT, phongban,nguoisd,chipCPU, ram, rom, mainboard, vga, tancase, tanCPU, nguon, vocase });
            return data;

        }

        public int Update(string MaMT, string phongban,string nguoisd, string chipCPU, string ram, string rom, string mainboard, string vga, string tancase, string tanCPU, string nguon, string vocase)
        {
            string query = "UPDATE CHITIETCAUHINH set PHONGBAN= @pb ,NGUOISD= @nguoisd ,CHIPCPU= @cpu ,RAM= @ram ,ROM= @rom ,MAINBOARD= @main ,VGA= @vga ,TANCASE= @case ,TANCPU= @tancpu ,NGUON= @nguon ,VOCASE= @vo  WHERE MAMT= @ma ";

            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { phongban,nguoisd, chipCPU, ram, rom, mainboard, vga, tancase, tanCPU, nguon, vocase, MaMT });
            return data;

        }
        public int Update1(string MaMT, string phongban, string chipCPU, string ram, string rom, string mainboard, string vga, string tancase, string tanCPU, string nguon, string vocase)
        {
            string query = "UPDATE CHITIETCAUHINH set PHONGBAN= @pb ,CHIPCPU= @cpu ,RAM= @ram ,ROM= @rom ,MAINBOARD= @main ,VGA= @vga ,TANCASE= @case ,TANCPU= @tancpu ,NGUON= @nguon ,VOCASE= @vo  WHERE MAMT= @ma ";

            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { phongban, chipCPU, ram, rom, mainboard, vga, tancase, tanCPU, nguon, vocase, MaMT });
            return data;

        }
        public int UpdatePB_NGSD(string MaMT, string phongban, string nguoisd)
        {
            string query = "UPDATE CHITIETCAUHINH set PHONGBAN= @pb ,NGUOISD= @ngsd  WHERE MAMT= @ma ";

            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { phongban,nguoisd, MaMT });
            return data;

        }
        // HAM XOA
        public int Delete(string MaMT)
        {
            string query = "DELETE CHITIETCAUHINH WHERE MAMT= @ma ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaMT });
            return data;

        }
    }
}
