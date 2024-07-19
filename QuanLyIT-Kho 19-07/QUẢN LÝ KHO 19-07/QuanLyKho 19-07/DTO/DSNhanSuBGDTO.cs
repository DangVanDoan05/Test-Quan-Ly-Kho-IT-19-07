using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
     public class DSNhanSuBGDTO
    {
        public DSNhanSuBGDTO(DataRow row)
        {
            this.MABBBG = row["MABBBG"].ToString();
            this.NGAYBG = row["NGAYBG"].ToString();
            this.MANVBG = row["MANVBG"].ToString();
            this.TENNVBG = row["TENNVBG"].ToString();
            this.PBNBG = row["PBNBG"].ToString();
            this.MANVNHANBG = row["MANVNHANBG"].ToString();
            this.TENNVNHANBG = row["TENNVNHANBG"].ToString();
            this.LYDOBG = row["LYDOBG"].ToString();
            this.MAMT = row["MAMT"].ToString();

        }

        private string mABBBG;
        private string nGAYBG;
        private string mANVBG;
        private string tENNVBG;
        private string pBNBG;
        private string mANVNHANBG;
        private string tENNVNHANBG;
        private string lYDOBG;
        private string mAMT;

        public string MABBBG { get => mABBBG; set => mABBBG = value; }
        public string NGAYBG { get => nGAYBG; set => nGAYBG = value; }
        public string MANVBG { get => mANVBG; set => mANVBG = value; }
        public string TENNVBG { get => tENNVBG; set => tENNVBG = value; }
        public string PBNBG { get => pBNBG; set => pBNBG = value; }
        public string MANVNHANBG { get => mANVNHANBG; set => mANVNHANBG = value; }
        public string TENNVNHANBG { get => tENNVNHANBG; set => tENNVNHANBG = value; }
        public string LYDOBG { get => lYDOBG; set => lYDOBG = value; }
        public string MAMT { get => mAMT; set => mAMT = value; }
    }
}
