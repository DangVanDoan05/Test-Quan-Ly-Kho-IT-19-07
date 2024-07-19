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
    public partial class frmCauHinhChiTiet : DevExpress.XtraEditors.XtraForm
    {
        public frmCauHinhChiTiet()
        {
            InitializeComponent();
            LoadControl();
        }

        private void LoadControl()
        {
            LockControl(true);
            LoadData();
            CleanText();
        }

        private void LoadData()
        {
           gridControl1.DataSource = ChiTietCauHinhDAO.Instance.GetTable();
        }
        private void CleanText()
        {
            txtMaMT.Clear();
            txtPhongBan.Clear();
            txtCPU.Clear();
            txtMainBoard.Clear();
            txtNguon.Clear();
            txtRAM.Clear();
            txtROM.Clear();
            txtTanCASE.Clear();
            txtTanCPU.Clear();
            txtVGA.Clear();
            txtVoCase.Clear();
        }

        private void LockControl(bool kt)
        {
           if(kt)
            {
                txtMaMT.Enabled = false;
                txtPhongBan.Enabled = false;
                txtCPU.Enabled = false;
                txtMainBoard.Enabled = false;
                txtNguon.Enabled = false;
                txtRAM.Enabled = false;
                txtROM.Enabled = false;
                txtTanCASE.Enabled = false;
                txtTanCPU.Enabled = false;
                txtVGA.Enabled = false;
                txtVoCase.Enabled = false;
                btnCapNhatCH.Enabled = true;
                btnLuu.Enabled = false;
                btnCapNhat.Enabled = true;
            }
           else
            {
                txtMaMT.Enabled = false;
                txtPhongBan.Enabled = false;
                txtCPU.Enabled = true;
                txtMainBoard.Enabled = true;
                txtNguon.Enabled = true;
                txtRAM.Enabled = true;
                txtROM.Enabled = true;
                txtTanCASE.Enabled = true;
                txtTanCPU.Enabled = true;
                txtVGA.Enabled = true;
                txtVoCase.Enabled = true;
                btnCapNhatCH.Enabled = false;
                btnLuu.Enabled = true;
                btnCapNhat.Enabled = true;
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaMT.Text = gridView1.GetFocusedRowCellValue("MAMT").ToString();
                txtPhongBan.Text = gridView1.GetFocusedRowCellValue("PHONGBAN").ToString();
                txtCPU.Text = gridView1.GetFocusedRowCellValue("CHIPCPU").ToString();
                txtRAM.Text = gridView1.GetFocusedRowCellValue("RAM").ToString();
                txtROM.Text = gridView1.GetFocusedRowCellValue("ROM").ToString();
                txtMainBoard.Text = gridView1.GetFocusedRowCellValue("MAINBOARD").ToString();
                txtVGA.Text = gridView1.GetFocusedRowCellValue("VGA").ToString();
                txtTanCASE.Text = gridView1.GetFocusedRowCellValue("TANCASE").ToString();
                txtTanCPU.Text = gridView1.GetFocusedRowCellValue("TANCPU").ToString();
                txtNguon.Text = gridView1.GetFocusedRowCellValue("NGUON").ToString();
                txtVoCase.Text = gridView1.GetFocusedRowCellValue("VOCASE").ToString();
            }
            catch
            {
              
            }

        }
      
        private void btnCapNhatCH_Click(object sender, EventArgs e)
        {
            LockControl(false);
           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maMT = txtMaMT.Text;
            string phongban = txtPhongBan.Text;
            string CPU = txtCPU.Text;
            string RAM = txtRAM.Text;
            string ROM = txtROM.Text;
            string MainBoard=txtMainBoard.Text;
            string VGA= txtVGA.Text;
            string TanCase= txtTanCASE.Text;
            string TANCPU= txtTanCPU.Text;
            string Nguon= txtNguon.Text;
            string VoCase= txtVoCase.Text;
            if (maMT == "")
            {
                MessageBox.Show("Hãy chọn mã máy tính để cập nhật cấu hình!", "Thông Báo:");
                LoadControl();
            }
            else
            {
                DialogResult kq = MessageBox.Show($"Bạn muốn cập nhật cấu hình mã máy {maMT} ?", "Thông Báo: ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    ChiTietCauHinhDAO.Instance.Update1(maMT, phongban, CPU, RAM, ROM, MainBoard, VGA, TanCase, TANCPU, Nguon, VoCase);
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông Báo:");
                }
                LoadControl();

            }

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ColumSTT.Instance.CustomDrawRowIndicator(e);
        }
    }
}