using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class QLVATTUSDDTO
    {

        public QLVATTUSDDTO(DataRow row)
        {
            this.MAYCKT = row["MAYCKT"].ToString();
            this.MAVATTUSD = row["MAVATTUSD"].ToString();
            this.TENVATTUSD = row["TENVATTUSD"].ToString();
            this.SLVATTUSD = int.Parse(row["SLVATTUSD"].ToString());         
        }

      //  QLVATTUSD(MAYCKT, MAVATTUSD, TENVATTUSD, SLVATTUSD)
    
        private string mAYCKT;
        private string mAVATTUSD;
        private string tENVATTUSD;
        private int sLVATTUSD;

        public string MAYCKT { get => mAYCKT; set => mAYCKT = value; }
        public string MAVATTUSD { get => mAVATTUSD; set => mAVATTUSD = value; }
      
      
        public string TENVATTUSD { get => tENVATTUSD; set => tENVATTUSD = value; }
        public int SLVATTUSD { get => sLVATTUSD; set => sLVATTUSD = value; }
    }
}
