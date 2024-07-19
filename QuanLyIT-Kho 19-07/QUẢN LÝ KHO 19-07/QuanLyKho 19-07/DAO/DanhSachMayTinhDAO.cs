using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DanhSachMayTinhDAO
    {
        private static DanhSachMayTinhDAO instance;

        public static DanhSachMayTinhDAO Instance
        {
            get { if (instance == null) instance = new DanhSachMayTinhDAO(); return DanhSachMayTinhDAO.instance; }
            private set { DanhSachMayTinhDAO.instance = value; }
        }
        private DanhSachMayTinhDAO() { }


        public DataTable GetTable()
        {
            string query = "select * from DANHSACHMAYTINH";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public int TongMT()
        {
            string query = "select * from DANHSACHMAYTINH";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count;
        }
        public List<DanhSachMayTinhDTO> GetListMaMT()
        {
            string query = "select * from DANHSACHMAYTINH";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<DanhSachMayTinhDTO> lsv = new List<DanhSachMayTinhDTO>();
            foreach (DataRow item in data.Rows)
            {
                DanhSachMayTinhDTO maMT = new DanhSachMayTinhDTO(item);
                lsv.Add(maMT);
            }

            return lsv;
        }

        public List<DanhSachMayTinhDTO> GetListMaMTPB(string MaPB)
        {
            string query = "select * from DANHSACHMAYTINH where PHONGBAN= @pb ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] {MaPB});
            List<DanhSachMayTinhDTO> lsv = new List<DanhSachMayTinhDTO>();
            foreach (DataRow item in data.Rows)
            {
                DanhSachMayTinhDTO maMT = new DanhSachMayTinhDTO(item);
                lsv.Add(maMT);
            }
            return lsv;
        }

        public List<DanhSachMayTinhDTO> GetLsMaMTPBnoPM(string MaPB,string MaPM)
        {
            string query = " select * from DANHSACHMAYTINH where PHONGBAN= @pb and DC = 0 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { MaPB });
            List<DanhSachMayTinhDTO> lsv = new List<DanhSachMayTinhDTO>();
            foreach (DataRow item in data.Rows)
            {
                DanhSachMayTinhDTO maMT = new DanhSachMayTinhDTO(item);
                bool Check = DanhSachCaiDatDAO.Instance.CheckPMtrenMT(maMT.MAMT, MaPM);
                if(!Check)
                {
                    lsv.Add(maMT);
                }             
            }
            return lsv;
        }


        public List<DanhSachMayTinhDTO> GetListMaMTDuocChon()
        {
            string query = "select * from DANHSACHMAYTINH where DC=1 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<DanhSachMayTinhDTO> lsv = new List<DanhSachMayTinhDTO>();
            foreach (DataRow item in data.Rows)
            {
                DanhSachMayTinhDTO maMT = new DanhSachMayTinhDTO(item);
                lsv.Add(maMT);
            }
            return lsv;
        }

        public List<DanhSachMayTinhDTO> GetListMaMTChuaChonNoPM(string MaPM)
        {
            string query = "select * from DANHSACHMAYTINH where DC=0 ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<DanhSachMayTinhDTO> lsv = new List<DanhSachMayTinhDTO>();
            foreach (DataRow item in data.Rows)
            {
                DanhSachMayTinhDTO maMT = new DanhSachMayTinhDTO(item);
                bool Check = DanhSachCaiDatDAO.Instance.CheckPMtrenMT(maMT.MAMT, MaPM);
                if (Check)
                {
                   
                }
                else
                {
                    lsv.Add(maMT);
                }
            }
            return lsv;
        }

        public List<DanhSachMayTinhDTO> GetListMaMTBP(string MaBoPhan)
        {
            List<DanhSachMayTinhDTO> lsvMTOfBP = new List<DanhSachMayTinhDTO>();
            List<PhongBanDTO> LsPbOfBP = PhongBanDAO.Instance.GetLsvPbThuocBP(MaBoPhan);
            foreach (PhongBanDTO item in LsPbOfBP)
            {
                string MaPB = item.MAPB;
                List<DanhSachMayTinhDTO> lsvYCOfPB = GetListMaMTPB(MaPB);
                foreach (DanhSachMayTinhDTO item1 in lsvYCOfPB)
                {
                    lsvMTOfBP.Add(item1);
                }
            }
            return lsvMTOfBP;
        }

        public DanhSachMayTinhDTO GetMaMT(string mamt)
        {
            string query = "select * from DANHSACHMAYTINH where MAMT= @ma ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { mamt });
            DanhSachMayTinhDTO maMTDTO = new DanhSachMayTinhDTO(data.Rows[0]);
            return maMTDTO;
        }

        public int CheckMaMT(string MaMT)
        {
            string query = "select * from DANHSACHMAYTINH where MAMT= @ma ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { MaMT });
            return data.Rows.Count;
        }

        public int Insert(string MaMT, bool baohanh, string IP, string MAC, string LOAIMT, string NCC, string phongban, string nguoisd, string matscd, string ngaymua, string hanbh, string ghichu, int DuocChon)
        {
            string query = "insert DANHSACHMAYTINH(MAMT,BAOHANH,IP,MAC,LOAIMT,NCC,PHONGBAN,NGUOISD,MATSCD,NGAYMUA,HANBH,GHICHU,DC) values ( @ma , @BH , @ip , @mac , @loaimt , @ncc , @pb , @ngsd , @matscd , @ngaymua , @hbh , @ghichu , @dc )";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaMT, baohanh, IP, MAC, LOAIMT, NCC, phongban, nguoisd, matscd, ngaymua, hanbh, ghichu });
            return data;

        }
        // HAM SUA
        public int Update(string MaMT, bool baohanh, string IP, string MAC, string LOAIMT, string NCC, string phongban, string nguoisd, string matscd, string ngaymua, string hanbh, string ghichu)
        {
            string query = "UPDATE	DANHSACHMAYTINH SET BAOHANH= @bh ,IP= @ip ,MAC= @mac ,LOAIMT= @loai ,NCC= @ncc ,PHONGBAN= @pb ,NGUOISD= @ngsd ,MATSCD= @matscd ,NGAYMUA= @ngmua ,HANBH= @hbh ,GHICHU= @ghichu WHERE MAMT= @ma ";

            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { baohanh, IP, MAC, LOAIMT, NCC, phongban, nguoisd, matscd, ngaymua, hanbh, ghichu, MaMT });
            return data;

        }

        public int UpdateDuocChon(string MaMT, int DuocChon)
        {
            string query = " UPDATE	DANHSACHMAYTINH SET DC= @dc where MAMT= @maMT ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { DuocChon, MaMT });
            return data;

        }

        // HAM XOA
        public int Delete(string MaMT)
        {
            string query = "DELETE DANHSACHMAYTINH WHERE MAMT= @ma ";
            int data = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaMT });
            return data;

        }

    }
}
