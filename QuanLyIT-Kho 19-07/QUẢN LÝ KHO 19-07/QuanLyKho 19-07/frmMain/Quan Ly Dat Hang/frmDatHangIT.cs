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
    public partial class frmDatHangIT : DevExpress.XtraEditors.XtraForm
    {
        public frmDatHangIT()
        {
            InitializeComponent();
            LoadControl();
        }

        private void LoadControl()
        {
            sglMaLK.Properties.DataSource = MaLinhKienDAO.Instance.GetListMaLK();
            sglMaLK.Properties.DisplayMember = "MALK";
            sglMaLK.Properties.ValueMember = "MALK";

            sglNhaMay.Properties.DataSource = NHAMAYDAO.Instance.GetLsvNM();
            sglNhaMay.Properties.DisplayMember = "MANHAMAY";
            sglNhaMay.Properties.ValueMember = "MANHAMAY";

            txtTenLK.Enabled = false;
            txtDvTinh.Enabled = false;
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            string MaLK = sglMaLK.Text;
            string TenLK = txtTenLK.Text;                               
            string mdsd = txtMDSD.Text;
            string ngaydh = dtpNgayDatHang.Value.ToString("dd/MM/yyyy");

            string TgDH = dtpNgayDatHang.Value.ToString("-ddMMyyyy-") + DateTime.Now.ToString("HHmmss");
            string MaDonHang = MaLK + TgDH;
            if(TenLK=="")
            {
                MessageBox.Show($"Chưa chọn mã linh kiện cần đặt hàng. ", "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(txtSLDat.Text==""||mdsd=="")
                {
                    MessageBox.Show($"Chưa nhập số lượng cần đặt hoặc chưa nhập mục đích sử dụng. ", "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else 
                {
                    // Tình trạng kiểm kê ban đầu.
                    TinhTrangKiemKeDTO a = TinhTrangKiemKeDAO.Instance.GetKiemKeDTO(0); //Tình trạng 0: đang không kiểm kê.
                    // THÊM VÀO BẢNG ĐẶT HÀNG.
                    try
                    {
                        string NhaMay = sglNhaMay.EditValue.ToString();
                        int sldat = int.Parse(txtSLDat.Text);

                        QlyDonHangITDAO.Instance.Insert(MaDonHang, MaLK, TenLK, ngaydh, sldat,NhaMay, mdsd, "", 0, "", 0, "", a.IDTTKIEMKE, a.CHITIETTTKK);

                        // UPDATE tình trạng đặt hàng cho linh kiện trong bảng tồn thiết bị.

                        // Nếu mã linh kiện có trong bảng tồn thì Update tình trạng đăt hàng.
                        bool CheckLKTon = TonLinhKienDAO.Instance.CheckMaLKTon(MaLK);
                        if (CheckLKTon)
                        {
                            TonLinhKienDAO.Instance.UpdateDatHang(MaLK, ngaydh, sldat);
                        }
                        MessageBox.Show(" Đã tạo đơn hàng thành công! ", " Thông báo: ");
                    }
                    catch 
                    {
                       MessageBox.Show($"Chọn nhà máy sử dụng trong danh sách. ", "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                   
                }
            }          
            this.Close();
        }

        private void sglMaLK_EditValueChanged(object sender, EventArgs e)
        {

            string maLK = sglMaLK.EditValue.ToString();
            MaLinhKienDTO MaLKDTO = MaLinhKienDAO.Instance.GetRowMaLK(maLK);
            txtTenLK.Text = MaLKDTO.TENLK;
            txtDvTinh.Text = MaLKDTO.DVTINH;

        }

        private void searchLookUpEdit1View_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ColumSTT.Instance.CustomDrawRowIndicator(e);
        }
    }

}