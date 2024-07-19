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

namespace frmMain
{
    public partial class frmDatLinhKien : DevExpress.XtraEditors.XtraForm
    {
        public frmDatLinhKien()
        {
            InitializeComponent();
            LoadCBX();
        }
        private void LoadCBX()
        {
            sglMaLK.Properties.DataSource= TonLinhKienDAO.Instance.GetListMaLKTon();
            sglMaLK.Properties.DisplayMember = "MALK";
            sglMaLK.Properties.ValueMember = "MALK";
            //cbMaLK.DataSource = TonLinhKienDAO.Instance.GetListMaLKTon();
            txtTenLK.Enabled = false;
        }

        private void cbMaLK_SelectedValueChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = sender as System.Windows.Forms.ComboBox;

            cb.ValueMember = "MALK";
            string a = cb.SelectedValue.ToString();


            TonLinhKienDTO malkton = TonLinhKienDAO.Instance.GetMaLKTon(a);
            MaLinhKienDTO malkDTO = MaLinhKienDAO.Instance.GetRowMaLK(a);
            txtTenLK.Text = malkDTO.TENLK;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string a = sglMaLK.Text;
            TonLinhKienDTO malkton = TonLinhKienDAO.Instance.GetMaLKTon(a);
            MaLinhKienDTO malkDTO = MaLinhKienDAO.Instance.GetRowMaLK(a);
            txtTenLK.Text = malkDTO.TENLK;
            int ngay = dtpNgayDatHang.Value.Day;
            int thang = dtpNgayDatHang.Value.Month;
            int nam = dtpNgayDatHang.Value.Year;
            int sldat = int.Parse(txtSLdat.Text);
            string ngaydathang = $"{ngay}/{thang}/{nam}";
            DialogResult kq = MessageBox.Show($"Bạn chắc chắn đã đặt hàng  cho mã linh kiện {a} ?", "Thông Báo:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
               // TonLinhKienDAO.Instance.UpdateDATHANG(a, ngaydathang, sldat);
                MessageBox.Show("Cập nhật thông tin đặt hàng thành công!", "Thông Báo:");
            }

            this.Close();
        }

        private void sglMaLK_EditValueChanged(object sender, EventArgs e)
        {
            string a = sglMaLK.Text;
            TonLinhKienDTO malkton = TonLinhKienDAO.Instance.GetMaLKTon(a);
            MaLinhKienDTO malkDTO = MaLinhKienDAO.Instance.GetRowMaLK(a);
            txtTenLK.Text = malkDTO.TENLK;
        }

        private void searchLookUpEdit1View_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ColumSTT.Instance.CustomDrawRowIndicator(e);
        }
    }
}