using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QlyDonHangITDTO
    {

        // QLYDONHANGIT(MADH, MALK, TENLK, NGAYDH , SLDAT,NHAMAY, MDSD , NGAYNH, SLNHAN, NGAYNK, SLNHAP, GHICHU, IDTTKIEMKE, CHITIETTTKK) 

        public QlyDonHangITDTO(DataRow row)
        {
            this.MADH = row["MADH"].ToString();
            this.NGAYDH = row["NGAYDH"].ToString();
            this.MALK = row["MALK"].ToString();
            this.TENLK = row["TENLK"].ToString();
            this.SLDAT =int.Parse(row["SLDAT"].ToString());
            this.NHAMAY = row["NHAMAY"].ToString();
            this.MDSD = row["MDSD"].ToString();
            this.NGAYNH = row["NGAYNH"].ToString();         
            this.SLNHAN = int.Parse(row["SLNHAN"].ToString());
            this.NGAYNK = row["NGAYNK"].ToString();          
            this.SLNHAP = int.Parse(row["SLNHAP"].ToString());
            this.GHICHU = row["GHICHU"].ToString();
            this.IDTTKIEMKE = int.Parse(row["IDTTKIEMKE"].ToString());
            this.CHITIETTTKK = row["CHITIETTTKK"].ToString();
        }

      


        private string mADH;
        private string nGAYDH;      
        private string mALK;      
        private string tENLK;
        private int sLDAT;
        private string nHAMAY;
        private string mDSD;
        private string nGAYNH;
        private int sLNHAN;
        private string nGAYNK;
        private int sLNHAP;      
        private string gHICHU;
        private int iDTTKIEMKE;
        private string cHITIETTTKK;

        public string MADH { get => mADH; set => mADH = value; }
        public string NGAYDH { get => nGAYDH; set => nGAYDH = value; }
        public string MALK { get => mALK; set => mALK = value; }
        public string TENLK { get => tENLK; set => tENLK = value; }
        public int SLDAT { get => sLDAT; set => sLDAT = value; }
        public string NGAYNH { get => nGAYNH; set => nGAYNH = value; }
        public int SLNHAN { get => sLNHAN; set => sLNHAN = value; }
        public string NGAYNK { get => nGAYNK; set => nGAYNK = value; }
        public int SLNHAP { get => sLNHAP; set => sLNHAP = value; }
        public string GHICHU { get => gHICHU; set => gHICHU = value; }
        public string MDSD { get => mDSD; set => mDSD = value; }     
        public string CHITIETTTKK { get => cHITIETTTKK; set => cHITIETTTKK = value; }
        public int IDTTKIEMKE { get => iDTTKIEMKE; set => iDTTKIEMKE = value; }
        public string NHAMAY { get => nHAMAY; set => nHAMAY = value; }
    }

}
