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
    public partial class frmBanGiao : DevExpress.XtraEditors.XtraForm
    {
        public frmBanGiao()
        {
            InitializeComponent();
            LoadControl();
            
        }
        private void LoadControl()
        {
            txtMaDonHang.Text = DHduocchon.MaDHdangchon;
            string MaDonHang = txtMaDonHang.Text;
            QlyDonHangPBDTO a = QlyDonHangPBDAO.Instance.GetDonHangDTO(MaDonHang);
            txtTenMH.Text = a.TENHANG;
            txtSLnhan.Text = a.SLNHAN + "";
            txtMaDonHang.Enabled = false;
            txtTenMH.Enabled = false;
            txtSLnhan.Enabled = false;
        }
       
            
        private void searchLookUpEdit1View_CustomDrawRowIndicator_1(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ColumSTT.Instance.CustomDrawRowIndicator(e);
        }
     
        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            string MaDH = txtMaDonHang.Text;
            string NgayBG = dtpNgayNhanBG.Value.ToString("dd/MM/yyyy");
            string ghichu = txtGhiChu.Text;

            if (txtSLBG.Text == "")
            {
                MessageBox.Show($" Hãy nhập số lượng bàn giao. ", "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int Slbangiao = int.Parse(txtSLBG.Text);
                // public int UpdateNhanHang(string MaDonHang, string NgayNhan, int SLNhan, string ghichu)
                QlyDonHangPBDAO.Instance.UpdateBanGiao(MaDH, NgayBG, Slbangiao, ghichu);
                MessageBox.Show("Đã bàn giao thành công!", "Thông báo:");
            }
            this.Close();
        }
    }
}