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
    public partial class frmNhanHangIT : DevExpress.XtraEditors.XtraForm
    {
        public frmNhanHangIT()
        {
            InitializeComponent();
            LoadControll();
        }

        private void LoadControll()
        {
            string MaDH = DHduocchon.MaDHdangchon;
            QlyDonHangITDTO a= QlyDonHangITDAO.Instance.GetDonHangITDTO(MaDH);
            txtMaDonHang.Text = MaDH;
            txtTenLKdat.Text = a.MALK;
            txtSlDat.Text = a.SLDAT+"";

            txtMaDonHang.Enabled = false;
            txtTenLKdat.Enabled = false;
            txtSlDat.Enabled = false;

        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            string MaDH = txtMaDonHang.Text;
            QlyDonHangITDTO a = QlyDonHangITDAO.Instance.GetDonHangITDTO(MaDH);
            string MaLK = a.MALK;
            string Ngaynhan = dtpNgayNhanHang.Value.ToString("dd/MM/yyyy");
          
            string ghichu = txtGhiChu.Text;
            if(txtSLNhan.Text=="")
            {
                MessageBox.Show($" Hãy nhập số lượng nhận. ", "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Update bảng quản lý đơn hàng.
                int Slnhan = int.Parse(txtSLNhan.Text);
                // public int UpdateNhanHang(string MaDonHang, string NgayNhan, int SLNhan, string ghichu)
                QlyDonHangITDAO.Instance.UpdateNhanHang(MaDH, Ngaynhan, Slnhan, ghichu);

              
                // UPDATE tình trạng đặt hàng cho linh kiện trong bảng tồn thiết bị.

                // Nếu mã linh kiện có trong bảng tồn thì Update tình trạng đăt hàng.

                bool CheckLKTon = TonLinhKienDAO.Instance.CheckMaLKTon(MaLK);
                if (CheckLKTon)
                {
                    TonLinhKienDAO.Instance.UpdateNhanHang(MaLK, Ngaynhan, Slnhan);
                }              
                MessageBox.Show("Đã nhận hàng thành công!", "Thông báo:");
                
            }

            this.Close();
        }

    }
}