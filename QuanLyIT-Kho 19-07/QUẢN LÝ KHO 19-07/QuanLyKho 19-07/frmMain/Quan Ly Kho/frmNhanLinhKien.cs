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
    public partial class frmNhanLinhKien : DevExpress.XtraEditors.XtraForm
    {
        public frmNhanLinhKien()
        {
            InitializeComponent();
            LoadControl();
        }
        private void LoadControl()
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
            int slnhan =int.Parse( txtSLnhan.Text);
            string ngaynhanhang = dtpNgaynhanhang.Value.ToString("dd/MM/yyyy");
            int slsaunhan = malkton.SLTON + slnhan;
            DialogResult kq = MessageBox.Show($"Bạn muốn cập nhật thông tin nhận mã linh kiện {a} ?", "Thông Báo:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
              //  TonLinhKienDAO.Instance.UpdateNHANHANG(a, ngaynhanhang,slnhan, slsaunhan);
                MessageBox.Show("Cập nhật thông tin nhận hàng thành công!", "Thông Báo:");
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