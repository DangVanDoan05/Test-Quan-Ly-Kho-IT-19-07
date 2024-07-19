using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAO;
using DTO;

namespace frmMain.Quan_Ly_Dat_Hang
{
    public partial class frmNhapKhoIT : DevExpress.XtraEditors.XtraForm
    {
        public frmNhapKhoIT()
        {
            InitializeComponent();
            LoadControll();
        }


        private void LoadControll()
        {
            string MaDH = DHduocchon.MaDHdangchon;
            QlyDonHangITDTO a = QlyDonHangITDAO.Instance.GetDonHangITDTO(MaDH);
            txtMaDonHang.Text = MaDH;
            txtTenLKdat.Text = a.MALK;
            txtSLNhan.Text = a.SLNHAN + "";

            txtMaDonHang.Enabled = false;
            txtTenLKdat.Enabled = false;
            txtSLNhan.Enabled = false;
        }


     

        private void btnLuu_Click_1(object sender, EventArgs e)
        {

            // Cộng vào bảng tồn linh kiện.

            string MaDH = txtMaDonHang.Text;
           
            string Ngaynhap = dtpNgayNhapHang.Value.ToString("dd/MM/yyyy");
           
            // Cộng vào bảng tồn linh kiện:

            QlyDonHangITDTO a = QlyDonHangITDAO.Instance.GetDonHangITDTO(MaDH);
            string NgayDH = a.NGAYDH;
            int sldat = a.SLDAT;
            string NgayNH = a.NGAYNH;
            int slnhan = a.SLNHAN;
            
            if(txtSLNhapKho.Text=="")
            {
                MessageBox.Show($" Hãy nhập số lượng nhập kho ", "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                // Kiểm tra số lượng tồn.
                int Slnhapkho = int.Parse(txtSLNhapKho.Text);
                string MaLK = a.MALK;                         
                MaLinhKienDTO MaLKDTO = MaLinhKienDAO.Instance.GetRowMaLK(MaLK);
                //int SLTon = Ton.SLTON;
                //int SLTonMoi = SLTon + Slnhapkho;
                string ghichu = txtGhiChu.Text;              
                string dvtinh = MaLKDTO.DVTINH;
                string ncc = MaLKDTO.NCC;
                string tenLK = MaLKDTO.TENLK;
                string NguoiNhap = CommonUser.UserStatic.MANV + "-" + CommonUser.UserStatic.FULLNAME;

                // Tình trạng kiểm kê ban đầu của linh kiện:
                TinhTrangKiemKeDTO tinhtrangKKBD = TinhTrangKiemKeDAO.Instance.GetKiemKeDTO(0); // Tình trạng 0: Tình trạng đang không kiểm kê.

                // Update vào bảng đơn hàng.
                QlyDonHangITDAO.Instance.UpdateNhapKho(MaDH, Ngaynhap, Slnhapkho, ghichu);



                    // Update vào BẢNG TỒN LINH KIỆN ( UPDATE SỐ LƯỢNG tồn)
                    // Chưa tồn tại trong bảng tồn Insert vào bảng tồn.
                    // Đã tồn tại trong bảng tồn thì Update lại số lượng tồn.
                bool CheckTonLK = TonLinhKienDAO.Instance.CheckMaLKTon(MaLK);

                if(CheckTonLK) // Tồn rồi thì Update
                {
                    TonLinhKienDTO b = TonLinhKienDAO.Instance.GetMaLKTon(MaLK);
                    int SLTonMoi = Slnhapkho + b.SLTON;
                    TonLinhKienDAO.Instance.UpdateSLTON(MaLK, SLTonMoi);
                }
                else // Chưa tồn thì mới Insert
                {
                   TonLinhKienDAO.Instance.Insert(MaLK, tenLK, Slnhapkho, dvtinh, NgayDH, sldat, NgayNH, slnhan,tinhtrangKKBD.IDTTKIEMKE,tinhtrangKKBD.CHITIETTTKK);                   
                }
              

                // Insert vào bảng thống kê nhập.
                string MaTKNhap = MaLK + "_" + DateTime.Now.ToString("ddMMyyyy") + "_" + DateTime.Now.ToString("HHmmss");
               ThongKeNhapDAO.Instance.Insert(MaTKNhap, MaLK, tenLK, Ngaynhap, Slnhapkho, dvtinh, ncc, NguoiNhap, ghichu, tinhtrangKKBD.IDTTKIEMKE, tinhtrangKKBD.CHITIETTTKK);
                MessageBox.Show("Đã nhập kho linh kiện thành công!", "Thông báo:");

            }
           
            this.Close();
            // Liên thông qua bảng tồn

        }
    }
}