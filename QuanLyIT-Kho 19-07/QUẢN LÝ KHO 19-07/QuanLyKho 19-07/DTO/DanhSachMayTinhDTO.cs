using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DanhSachMayTinhDTO
    {

        public DanhSachMayTinhDTO(DataRow row)
        {
          
            this.MAMT = row["MAMT"].ToString();
            this.BAOHANH = (bool)row["BAOHANH"];
            this.IP = row["IP"].ToString();
            this.MAC = row["MAC"].ToString();
            this.LOAIMT = row["LOAIMT"].ToString();
            this.NCC = row["NCC"].ToString();
            this.PHONGBAN = row["PHONGBAN"].ToString();
            this.NGUOISD = row["NGUOISD"].ToString();
            this.NGAYMUA = row["NGAYMUA"].ToString();
            this.HANBH = row["HANBH"].ToString();
            this.GHICHU = row["GHICHU"].ToString();
            this.DC = int.Parse(row["DC"].ToString());
        }
        public DanhSachMayTinhDTO(string maMT, bool baohanh, string ip, string mac, string LoaiMT, string NCC, string phongban, string nguoisd, string mtscd, string ngaymua, string hanbh, string ghichu)
        {
            this.MAMT = maMT;
            this.BAOHANH = baohanh;
            this.IP = ip;
            this.MAC = mac;
            this.LOAIMT = LoaiMT;
            this.NCC = NCC;
            this.PHONGBAN = phongban;
            this.NGUOISD = nguoisd;
            this.MATSCD = mtscd;
            this.NGAYMUA = ngaymua;
            this.HANBH = hanbh;
            this.GHICHU = ghichu;

        }
        public DanhSachMayTinhDTO(DataRow row, int a = 0)
        {

            this.MAMT = row["MAMT"].ToString();
            this.BAOHANH = true;
            this.IP = row["IP"].ToString();
            this.MAC = row["MAC"].ToString();
            this.LOAIMT = row["LOAIMT"].ToString();
            this.NCC = row["NCC"].ToString();
            this.PHONGBAN = row["PHONGBAN"].ToString();
            this.NGUOISD = row["NGUOISD"].ToString();
            this.NGAYMUA = row["NGAYMUA"].ToString();
            this.HANBH = row["HANBH"].ToString();
            this.GHICHU = row["GHICHU"].ToString();

        }


      
        private string mAMT;
        private bool bAOHANH;
        private string iP;
        private string mAC;
        private string lOAIMT;
        private string nCC;
        private string pHONGBAN;
        private string nGUOISD;
        private string mATSCD;
        private string nGAYMUA;
        private string hANBH;
        private string gHICHU;
        private int dC;

      
        public string MAMT { get => mAMT; set => mAMT = value; }
        public bool BAOHANH { get => bAOHANH; set => bAOHANH = value; }
        public string IP { get => iP; set => iP = value; }
        public string MAC { get => mAC; set => mAC = value; }
        public string LOAIMT { get => lOAIMT; set => lOAIMT = value; }
        public string NCC { get => nCC; set => nCC = value; }
        public string PHONGBAN { get => pHONGBAN; set => pHONGBAN = value; }
        public string NGUOISD { get => nGUOISD; set => nGUOISD = value; }
        public string MATSCD { get => mATSCD; set => mATSCD = value; }
        public string NGAYMUA { get => nGAYMUA; set => nGAYMUA = value; }
        public string HANBH { get => hANBH; set => hANBH = value; }
        public string GHICHU { get => gHICHU; set => gHICHU = value; }
        public int DC { get => dC; set => dC = value; }
    }
}
