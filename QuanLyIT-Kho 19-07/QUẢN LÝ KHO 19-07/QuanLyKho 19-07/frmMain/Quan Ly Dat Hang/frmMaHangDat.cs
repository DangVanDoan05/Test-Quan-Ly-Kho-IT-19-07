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
    public partial class frmMaHangDat : DevExpress.XtraEditors.XtraForm
    {
        public frmMaHangDat()
        {
            InitializeComponent();
            LoadControl();
        }
        bool them;
        private void LoadControl()
        {
            LoadData();
            LockControl(true);
        }

        private void LockControl(bool kt)
        {
            if (kt)
            {
                txtMaMH.Enabled = false;
                txtTenMH.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                btnCapNhat.Enabled = true;

            }
            else
            {
                txtMaMH.Enabled = true;
                txtTenMH.Enabled = true;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = true;
                btnCapNhat.Enabled = true;

            }

        }

        private void LoadData()
        {
            gridControl1.DataSource = MaMatHangDAO.Instance.GetTable();
        }
        private void CleanText()
        {
            txtMaMH.Clear();
            txtTenMH.Clear();
        }
        void Save()
        {
            if (them)
            {
                string MaMH = txtMaMH.Text.Trim();
                string TenMH = txtTenMH.Text.Trim();
                string ngayDH = DateTime.Now.ToString("dd/MM/yyyy");
                int socot = MaMatHangDAO.Instance.GetSoCot(MaMH);
                if (socot > 0)
                {
                    MessageBox.Show(" Mã mặt hàng đã tồn tại.", " Thông Báo: ");
                }
                else
                {
                    DialogResult kq = MessageBox.Show($"Bạn muốn thêm mã mặt hàng: {MaMH}", "Thông Báo", MessageBoxButtons.YesNo);
                    if (kq == DialogResult.Yes)
                    {
                        MaMatHangDAO.Instance.Insert(MaMH, TenMH);
                     
                        MessageBox.Show($"Thêm thành công mặt hàng: {MaMH} ", "Thông Báo");
                        them = false;
                    }
                }
            }
            else
            {
                string MaMH = txtMaMH.Text.Trim();
                string TenMH = txtTenMH.Text.Trim();
                if (MaMH == "")
                {
                    MessageBox.Show($"Bạn chưa chọn mặt hàng để sửa thông tin. ", "Thông Báo:");
                }
                else
                {
                    DialogResult kq = MessageBox.Show($"Bạn muốn sửa thông tin mã hàng: {MaMH}", "Thông Báo", MessageBoxButtons.YesNo);
                    if (kq == DialogResult.Yes)

                    {

                        MaMatHangDAO.Instance.Update(TenMH, MaMH);
                      
                        MessageBox.Show($"Sửa thành công mặt hàng: {MaMH} ", "Thông Báo");

                        LoadControl();
                    }
                }
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaMH.Text = gridView1.GetFocusedRowCellValue("MAMH").ToString();
                txtTenMH.Text = gridView1.GetFocusedRowCellValue("TENMH").ToString();
            }
            catch
            {
                MessageBox.Show("Không còn dữ liệu để chọn.", "Thông báo:");
            }
        }
    
        
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ColumSTT.Instance.CustomDrawRowIndicator(e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LockControl(false);
            them = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LockControl(false);
            txtMaMH.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            LockControl(false);
            txtMaMH.Enabled = false;

            string MaMH = txtMaMH.Text.Trim();
            string TenMH = txtTenMH.Text.Trim();
            if (MaMH == "")
            {
                MessageBox.Show($" Bạn chưa chọn mã mặt hàng để xóa ");
                LoadControl();
            }

            else
            {
                DialogResult kq = MessageBox.Show($"Bạn muốn xóa mã mặt hàng: {MaMH}", "Thông Báo", MessageBoxButtons.YesNo);
                if (kq == DialogResult.Yes)
                {
                   MaMatHangDAO.Instance.Delete(MaMH);
                   QlyDonHangPBDAO.Instance.Delete(MaMH);

                    MessageBox.Show($" Xóa thành công mã phòng: {MaMH}", " Thông Báo");
                }
                LoadControl();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Save();
            LoadControl();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

      
    }
}