using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DSTHIETBIBGDTO
    {
        public DSTHIETBIBGDTO(DataRow row)
        {
            this.STT= int.Parse(row["STT"].ToString());
            this.MABBBG = row["MABBBG"].ToString();
            this.TENTB = row["TENTB"].ToString();
            this.MATB = row["MATB"].ToString();
            this.DONVI = row["DONVI"].ToString();
            this.SOLUONG = int.Parse(row["SOLUONG"].ToString());
            this.TINHTRANG = row["TINHTRANG"].ToString();

        }
        private int sTT;
        private string mABBBG;
        private string tENTB;
        private string mATB;
        private string dONVI;
        private int sOLUONG;
        private string tINHTRANG;

        public string MABBBG { get => mABBBG; set => mABBBG = value; }
        public string TENTB { get => tENTB; set => tENTB = value; }
        public string MATB { get => mATB; set => mATB = value; }
        public string DONVI { get => dONVI; set => dONVI = value; }
        public int SOLUONG { get => sOLUONG; set => sOLUONG = value; }
        public string TINHTRANG { get => tINHTRANG; set => tINHTRANG = value; }
        public int STT { get => sTT; set => sTT = value; }
    }
}
