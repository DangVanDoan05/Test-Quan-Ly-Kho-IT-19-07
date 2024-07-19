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
using DevExpress.XtraGrid.Views.Grid;
using System.IO;

namespace frmMain.Quan_Ly_Dat_Hang
{
    public partial class QuanLySanXuat : DevExpress.XtraEditors.XtraForm
    {
        // phân quyền cho Form đơn hàng

        public QuanLySanXuat()
        {
            InitializeComponent();
            LoadControl();
        }

        string MaDHdc = "";
        int idquyen = CommonUser.Quyen;
        private void LoadControl()
        {
            LoadData();

        }

        private void LoadData()
        {          
            // Load Grid Control.

            gridControl1.DataSource = QlyDonHangITDAO.Instance.GetLsDonHangIT();

        }

        private void searchLookUpEdit1View_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ColumSTT.Instance.CustomDrawRowIndicator(e);
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ColumSTT.Instance.CustomDrawRowIndicator(e);
        }

        private void sglMaLK_EditValueChanged(object sender, EventArgs e)
        {
        //    string maLK = sglMaLK.EditValue.ToString();
        //    MaLinhKienDTO MaLKDTO = MaLinhKienDAO.Instance.GetRowMaLK(maLK);
        //    txtTenLK.Text = MaLKDTO.TENLK;
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            if(idquyen>=2)
            {
                frmDatHangIT f = new frmDatHangIT();
                f.ShowDialog();
                LoadControl();
            }
            else
            {
                MessageBox.Show($" Bạn chưa đủ thẩm quyền cho chức năng này. ", "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnNhanHang_Click(object sender, EventArgs e)
        {
            if(idquyen>=2)
            {
                if (MaDHdc == "")
                {
                    MessageBox.Show($"Chưa chọn mã đơn hàng cần nhận. ", "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DHduocchon.MaDHdangchon = MaDHdc;
                    frmNhanHangIT f = new frmNhanHangIT();
                    f.ShowDialog();
                    LoadControl();
                    MaDHdc = "";
                }
            }
            else
            {
                MessageBox.Show($" Bạn chưa đủ thẩm quyền cho chức năng này. ", "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                MaDHdc = gridView1.GetFocusedRowCellValue("MADH").ToString();
            }
            catch
            {
                MaDHdc = "";
            }           
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            // Kiểm tra linh kiện nhập kho có đang trong kiểm kê ko?
            if(idquyen>=2)
            {
                if (MaDHdc == "")
                {
                    MessageBox.Show($"Chưa chọn mã đơn hàng cần nhập kho. ", "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    QlyDonHangITDTO a = QlyDonHangITDAO.Instance.GetDonHangITDTO(MaDHdc);
                    if (a.NGAYNH == "")
                    {
                        MessageBox.Show($"Hãy nhận hàng trước khi nhập kho.", "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // Kiểm tra tình trạng kiểm kê của linh kiện.
                        TonLinhKienDTO TonLKDTO = TonLinhKienDAO.Instance.GetMaLKTon(a.MALK);
                        int IdTTKK = TonLKDTO.IDTTKIEMKE; // ở bảng tồn sẽ có 2 trạng thái.
                        if (IdTTKK == 0) // trạng thái 0: là trạng thái đang không kiểm kê.
                        {
                            DHduocchon.MaDHdangchon = MaDHdc;
                            frmNhapKhoIT f = new frmNhapKhoIT();
                            f.ShowDialog();
                            LoadControl();
                            MaDHdc = "";
                        }
                        else
                        {
                            MessageBox.Show($"Không thể nhập kho do mã linh kiện {a.MALK} đang thực hiện kiểm kê. ", "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show($" Bạn chưa đủ thẩm quyền cho chức năng này. ", "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (idquyen >= 3)
            {
                if (MaDHdc == "")
                {
                    MessageBox.Show($"Chưa chọn mã đơn hàng cần xóa. ", "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    // cho phép xóa nhiều dòng trong gridview
                    int dem = 0;
                    //  int demloi = 0;

                    List<string> LsMaDHdcChon = new List<string>();

                    foreach (var item in gridView1.GetSelectedRows())
                    {
                        string ma1 = gridView1.GetRowCellValue(item, "MADH").ToString();
                        LsMaDHdcChon.Add(ma1);
                        dem++;
                    }

                    if (dem > 0)
                    {
                        DialogResult kq = MessageBox.Show($"Bạn muốn xóa {dem} đơn hàng được chọn?", "Thông báo:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (kq == DialogResult.Yes)
                        {
                            int demXoa = 0;
                            foreach (string item in LsMaDHdcChon)
                            {

                                QlyDonHangITDTO DonHang = QlyDonHangITDAO.Instance.GetDonHangITDTO(item);
                                int IDttKK = DonHang.IDTTKIEMKE;

                                if(IDttKK==0) // Tình trạng chưa kiểm kê thì mới đc xóa
                                {
                                    if(DonHang.NGAYNK=="")      // Chưa nhập kho với quyền xóa bình thường.                           
                                    {
                                        QlyDonHangITDAO.Instance.Delete(item);
                                        demXoa++;
                                    }
                                    else   // Nếu đã nhập kho thì quản lý trung cấp mới có thể xóa đc.
                                    {
                                        if(idquyen>=5)
                                        {
                                            QlyDonHangITDAO.Instance.Delete(item);
                                            demXoa++;
                                        }

                                    }
                                }
                                else
                                {
                                    if(IDttKK==2)
                                    {
                                        if (idquyen >= 8)  // quyền ADMIN
                                        {
                                            QlyDonHangITDAO.Instance.Delete(item);
                                            demXoa++;
                                        }
                                    }
                                }

                            }

                            if (demXoa < dem)
                            {
                                MessageBox.Show($"Đã xóa {demXoa} đơn hàng, {dem - demXoa} đơn hàng không thể xóa.", "THÀNH CÔNG!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"Đã xóa {dem} đơn hàng được chọn.", "THÀNH CÔNG!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            demXoa = 0;
                            dem = 0;
                        }
                        LoadControl();
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa chọn đơn hàng để xóa.", "Lỗi:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                LoadControl();
            }
            else
            {
                MessageBox.Show($" Bạn chưa đủ thẩm quyền cho chức năng này. ", "Lỗi: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            // string ton = view.GetRowCellDisplayText(e.RowHandle, view.Columns["SLTON"]).ToString();
            string MaDonHang = view.GetRowCellValue(e.RowHandle, view.Columns["MADH"]).ToString();
            List<QlyDonHangITDTO> ListDsQuaHan = QlyDonHangITDAO.Instance.GetLsQuaDuKienNhan();
            QlyDonHangITDTO MaDHDTO = QlyDonHangITDAO.Instance.GetDonHangITDTO(MaDonHang);
            if (MaDHDTO.NGAYNH == "" && MaDHDTO.NGAYNK == "")            //ĐÃ ĐẶT HÀNG
            {
                e.Appearance.BackColor = txtDaDat.BackColor;
            }
            if (MaDHDTO.NGAYNH != "" && MaDHDTO.NGAYNK == "")     //ĐÃ NHẬN HÀNG
            {
                e.Appearance.BackColor = txtDaNhan.BackColor;
            }

            if (MaDHDTO.NGAYNH != "" && MaDHDTO.NGAYNK != "")      //ĐÃ nhập kho
            {
                e.Appearance.BackColor = txtDaNhapKho.BackColor;
            }

            foreach (QlyDonHangITDTO item in ListDsQuaHan)  //ĐÃ QUÁ Thời gian nhận 
            {
                if (MaDonHang == item.MADH && MaDHDTO.NGAYNH == "" && MaDHDTO.NGAYNK == "")
                {
                    e.Appearance.BackColor = txtDaDatLau.BackColor;
                }
            }

            if(MaDHDTO.IDTTKIEMKE==2)
            {
                e.Appearance.BackColor = txtDaKK.BackColor;  // Đã kiểm kê
            }
        }

        void XuatExCel()
        {
            using (System.Windows.Forms.SaveFileDialog saveDialog = new System.Windows.Forms.SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xlsx":
                            gridControl1.ExportToXlsx(exportFilePath);
                            break;

                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnXuatExCell_Click(object sender, EventArgs e)
        {
          
            DialogResult kq = MessageBox.Show("Bạn muốn xuất danh sách máy tính thành File Excel?", "Thông Báo:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                XuatExCel();
            }
            LoadControl();
        }
    }
}