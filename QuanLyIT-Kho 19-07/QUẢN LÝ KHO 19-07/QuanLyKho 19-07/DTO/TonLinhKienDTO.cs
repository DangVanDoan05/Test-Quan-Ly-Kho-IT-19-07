using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TonLinhKienDTO
    {
      
        public TonLinhKienDTO(DataRow row)
        {          
            this.MALK = row["MALK"].ToString();
            this.TENLK = row["TENLK"].ToString();
            this.SLTON = int.Parse(row["SLTON"].ToString());
            this.DVTINH = row["DVTINH"].ToString();         
            this.NGAYDATHANG = row["NGAYDATHANG"].ToString();
            this.SLDAT = int.Parse(row["SLDAT"].ToString());
            this.NGAYNHANHANG = row["NGAYNHANHANG"].ToString();
            this.SLNHAN = int.Parse(row["SLNHAN"].ToString());        
            this.IDTTKIEMKE = int.Parse(row["IDTTKIEMKE"].ToString());
            this.CHITIETTTKK = row["CHITIETTTKK"].ToString();
        }

        // TONLINHKIEN2(MALK, TENLK, SLTON, DVTINH, NGAYDATHANG, SLDAT, NGAYNHANHANG, SLNHAN,IDTTKIEMKE,CHITIETTTKK)"

        private string mALK;
        private string tENLK;
        private int sLTON;
        private string dVTINH;      
        private string nGAYDATHANG;
        private int sLDAT;    
        private string nGAYNHANHANG;
        private int sLNHAN;
        private string gHICHU;
        private int iDTTKIEMKE;
        private string cHITIETTTKK;


        public string MALK { get => mALK; set => mALK = value; }
        public string TENLK { get => tENLK; set => tENLK = value; }
        public int SLTON { get => sLTON; set => sLTON = value; }
        public string DVTINH { get => dVTINH; set => dVTINH = value; }
        public string NGAYDATHANG { get => nGAYDATHANG; set => nGAYDATHANG = value; }
        public int SLDAT { get => sLDAT; set => sLDAT = value; }
        public string NGAYNHANHANG { get => nGAYNHANHANG; set => nGAYNHANHANG = value; }
        public int SLNHAN { get => sLNHAN; set => sLNHAN = value; }
        public string GHICHU { get => gHICHU; set => gHICHU = value; }
        public int IDTTKIEMKE { get => iDTTKIEMKE; set => iDTTKIEMKE = value; }
        public string CHITIETTTKK { get => cHITIETTTKK; set => cHITIETTTKK = value; }
    }
}
