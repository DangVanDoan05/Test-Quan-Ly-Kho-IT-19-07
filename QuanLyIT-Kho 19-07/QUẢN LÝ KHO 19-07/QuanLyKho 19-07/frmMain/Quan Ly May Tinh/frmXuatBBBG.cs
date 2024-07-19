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
using frmMain.Report;
using DevExpress.XtraReports.UI;
using DAO;
using DTO;


namespace frmMain.Quan_Ly_Dat_Hang
{
    public partial class frmXuatBBBG : DevExpress.XtraEditors.XtraForm
    {
        public frmXuatBBBG()
        {
            InitializeComponent();
            LoadControlForm();
        }
        bool them;
        bool themTTBG;
         void LoadControlForm()
          {
            txtMaBBBG.Text = CommonMaBBBG.MaBBBG;
            txtMaNVBG.Text = CommonUser.UserStatic.MANV;
            txtHoTenNVBG.Text = CommonUser.NhanVienStatic.FULLNAME;
            DanhSachMayTinhDTO MaMTDTO = DanhSachMayTinhDAO.Instance.GetMaMT(CommonMaBBBG.MaMTBG);
            txtPhongBan.Text = MaMTDTO.PHONGBAN;
            int dem = DSNhanSuBGDAO.Instance.CheckExist(CommonMaBBBG.MaBBBG);
            if(dem>0)
            {
                LoadControlTT();
                LoadControl();
            }
            else
            {
                LoadControlTT();
                LockControl(true);
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = false;
                btnCapNhat.Enabled = false;
                btnInBBBG.Enabled = false;
            }
          }

        private void LoadControl()
        {
            LoadData(); 
            LockControl(true); 
        }
        void LoadControlTT()
        {
            LoadDataTT();
            LockControlTT(true);
        }

        private void LockControlTT(bool kt)
        {
            if (kt)
            {
                txtMaBBBG.Enabled = false;
                txtMaNVBG.Enabled = false;
                txtHoTenNVBG.Enabled = false;
                txtPhongBan.Enabled = false;
                txtMaNVNBG.Enabled = false;
                txtHoTenNVNBG.Enabled = false;
                dtpNgayBG.Enabled = false;
                txtLyDoBG.Enabled = false;
                btnThemTT.Enabled = true;
                btnSuaTT.Enabled = true;
                btnXoaTT.Enabled = true;
                btnLuuTT.Enabled = false;
                btnCapNhatTT.Enabled = true;
            }
            else
            {
                txtMaBBBG.Enabled = false;
                txtMaNVBG.Enabled = false;
                txtHoTenNVBG.Enabled = false;
                txtPhongBan.Enabled = false;
                txtMaNVNBG.Enabled = true;
                txtHoTenNVNBG.Enabled = true;
                dtpNgayBG.Enabled = true;
                txtLyDoBG.Enabled = true;
                btnThemTT.Enabled = false;
                btnSuaTT.Enabled = false;
                btnXoaTT.Enabled = false;
                btnLuuTT.Enabled = true;
                btnCapNhatTT.Enabled = true;
               
            }
        }

        private void LoadDataTT()
        {
            gcNSBG.DataSource = DSNhanSuBGDAO.Instance.GetTable(CommonMaBBBG.MaBBBG);
        }

        private void LoadData()
        {
           
            gridControl1.DataSource = DSTHIETBIBGDAO.Instance.GetTable(CommonMaBBBG.MaBBBG);
           
        }
        private void LockControl(bool kt)
        {
           
            if (kt)
            {
                txtSTT.Enabled = false;
                txtTenTB.Enabled = false;
                txtMaTB.Enabled = false;
                txtDonVi.Enabled = false;
                txtSoLuong.Enabled = false;
                txtTinhTrang.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                btnCapNhat.Enabled = true;
                btnInBBBG.Enabled = true;
            }
            else
            {
                txtSTT.Enabled = true;
                txtTenTB.Enabled = true;
                txtMaTB.Enabled = true;
                txtDonVi.Enabled = true;
                txtSoLuong.Enabled = true;
                txtTinhTrang.Enabled = true;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = true;
                btnCapNhat.Enabled = true;
                btnInBBBG.Enabled = true;
            }
        }
        void ClearText()
        {
            txtSTT.Clear();
            txtTenTB.Clear();
            txtMaTB.Clear();
            txtDonVi.Clear();
            txtSoLuong.Clear();
            txtTinhTrang.Clear();
        }
        void Save()
        {
            if(them)
            {
                int stt = int.Parse(txtSTT.Text);
                string maBBBG = txtMaBBBG.Text;
                string tenTB = txtTenTB.Text;
                string maTB = txtMaTB.Text;
                string donvi = txtDonVi.Text;
                int soluong = int.Parse(txtSoLuong.Text);
                string tinhtrang = txtTinhTrang.Text;
                try
                {
                    DSTHIETBIBGDAO.Instance.Insert(stt, maBBBG, tenTB, maTB, donvi, soluong, tinhtrang);
                    MessageBox.Show("Thêm thành công!", "Thông Báo:");
                    them = false;
                }
                catch
                {

                    MessageBox.Show("STT hoặc Tên thiết bị đã tồn tại.","Thông Báo:");
                }
               
              
            }
            else
            {
                //try
                //{
                    int stt = int.Parse(txtSTT.Text);
                //}
                //catch
                //{
                //    MessageBox.Show("Chưa chọn thiết bị để sửa thông tin.", "Thông Báo:");
                //}
                
                string maBBBG = txtMaBBBG.Text;
                string tenTB = txtTenTB.Text;
                string maTB = txtMaTB.Text;
                string donvi = txtDonVi.Text;
                int soluong = int.Parse(txtSoLuong.Text);
                string tinhtrang = txtTinhTrang.Text;
                try
                {
                    DSTHIETBIBGDAO.Instance.Update(stt, maBBBG, tenTB, maTB, donvi, soluong, tinhtrang);
                    MessageBox.Show("Sửa thông tin thành công!", "Thông Báo:");
                   
                }
                catch
                {

                    MessageBox.Show("Chưa chọn thiết bị để sửa thông tin.", "Thông Báo:");
                }
            }
        }

        private void btnInBBBG_Click(object sender, EventArgs e)
        {
            string mabbbg = txtMaBBBG.Text;
            List<DSTHIETBIBGDTO> ls = DSTHIETBIBGDAO.Instance.GetLsvTB(mabbbg);
            DSNhanSuBGDTO TTnsBG = DSNhanSuBGDAO.Instance.GetTTNSBG(mabbbg);
          
            rptBienBanBG rpt = new rptBienBanBG(ls,TTnsBG);
            rpt.ShowPreview();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LockControl(false);
            them = true;
        }


        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            LockControl(false);
            txtSTT.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            LockControl(false);
            txtSTT.Enabled = false;
            string stt1 = txtSTT.Text.Trim();
            int stt = int.Parse(stt1);
            if (txtSTT.Text == "")
            {
                MessageBox.Show(" Bạn chưa chọn thiết bị để xóa! ");

            }
            else
            {
                DialogResult kq = MessageBox.Show($" Bạn muốn xóa thiết bị thứ {stt} ", "Thông Báo", MessageBoxButtons.OKCancel);
                if (kq == DialogResult.OK)
                {
                    DSTHIETBIBGDAO.Instance.Delete(stt);
                    MessageBox.Show($"Xóa thành công thiết bị thứ {stt} ");
                }

            }
            LoadControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Save();
            LoadControl();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            txtSTT.Text = gridView1.GetFocusedRowCellValue("STT").ToString();
            txtTenTB.Text = gridView1.GetFocusedRowCellValue("TENTB").ToString();
            txtMaTB.Text = gridView1.GetFocusedRowCellValue("MATB").ToString();
            txtDonVi.Text = gridView1.GetFocusedRowCellValue("DONVI").ToString();
            txtSoLuong.Text = gridView1.GetFocusedRowCellValue("SOLUONG").ToString();
            txtTinhTrang.Text = gridView1.GetFocusedRowCellValue("TINHTRANG").ToString();
        }

        void SaveTT()
        {
            if(themTTBG)
            {
                string maBBBG = txtMaBBBG.Text;
                string ngaybg = dtpNgayBG.Value.ToString("dd/MM/yyyy");
                string manvbg = txtMaNVBG.Text;
                string tennvbg = txtHoTenNVBG.Text;
                string phongban = txtPhongBan.Text;
                string manvnhanbg = txtMaNVNBG.Text;
                string tennvnhanbg = txtHoTenNVNBG.Text;
                string lydoBG = txtLyDoBG.Text;
                string maMT = CommonMaBBBG.MaMTBG;
                DialogResult kq = MessageBox.Show($"Bạn muốn lưu thông tin nhân sự bàn giao cho biên bản mã {maBBBG} ?",
                    "Thông báo: ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    try
                    {
                        DSNhanSuBGDAO.Instance.Insert(maBBBG, ngaybg, manvbg, tennvbg, phongban, manvnhanbg, tennvnhanbg, lydoBG, maMT);
                        MessageBox.Show("Thêm thành công thông tin nhân sự bàn giao !", "Thông Báo:");
                        themTTBG = false;
                      
                    }
                    catch
                    {
                        MessageBox.Show($"Mã biên bản bàn giao {maBBBG} đã tồn tại!", "Thông Báo:");
                    }

                }
            }
            else
            {

                string maBBBG = txtMaBBBG.Text;
                string ngaybg = dtpNgayBG.Value.ToString("dd/MM/yyyy");
                string manvbg = txtMaNVBG.Text;
                string tennvbg = txtHoTenNVBG.Text;
                string phongban = txtPhongBan.Text;
                string manvnhanbg = txtMaNVNBG.Text;
                string tennvnhanbg = txtHoTenNVNBG.Text;
                string lydoBG = txtLyDoBG.Text;
                string maMT = CommonMaBBBG.MaMTBG;
                if (manvnhanbg == "")
                {
                    MessageBox.Show("Hãy chọn vào BBBG muốn sửa đổi thông tin!", "Thông Báo: ");
                }
                else
                {

                    DialogResult kq = MessageBox.Show($"Bạn muốn sửa thông tin nhân sự bàn giao cho biên bản mã {maBBBG} ?",
                   "Thông báo: ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {

                        DSNhanSuBGDAO.Instance.Update(maBBBG, ngaybg, manvbg, tennvbg, phongban, manvnhanbg, tennvnhanbg, lydoBG, maMT);
                        MessageBox.Show("Sửa thành công thông tin nhân sự bàn giao !", "Thông Báo:");
                      
                    }

                }
            }
        }
        private void btnLuuTT_Click(object sender, EventArgs e)
        {
            SaveTT();
            LoadControlTT();
            LoadControlForm();
            
        }

        private void btnSuaTT_Click(object sender, EventArgs e)
        {
            LockControlTT(false);
        }

        private void btnXoaTT_Click(object sender, EventArgs e)
        {
            string maBBBG = txtMaBBBG.Text;

            DialogResult kq = MessageBox.Show($"Bạn muốn xóa thông tin nhân sự bàn giao cho biên bản mã {maBBBG} ?",
           "Thông báo: ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                DSNhanSuBGDAO.Instance.Delete(maBBBG);
                MessageBox.Show("Xóa thành công thông tin! ", "Thông Báo: ");
                LoadControl();
                
            }
          
        }

        private void gcNSBG_Click(object sender, EventArgs e)
        {
            txtMaNVNBG.Text = gridView2.GetFocusedRowCellValue("MANVNHANBG").ToString();
            txtHoTenNVNBG.Text = gridView2.GetFocusedRowCellValue("TENNVNHANBG").ToString();
            dtpNgayBG.Value =Convert.ToDateTime(gridView2.GetFocusedRowCellValue("NGAYBG").ToString());
            txtLyDoBG.Text = gridView2.GetFocusedRowCellValue("LYDOBG").ToString();
           
        }

        private void btnThemTT_Click(object sender, EventArgs e)
        {
            LockControlTT(false);
            themTTBG = true;
        }

        private void btnCapNhatTT_Click(object sender, EventArgs e)
        {
            LoadControlTT();
        }
    }
}