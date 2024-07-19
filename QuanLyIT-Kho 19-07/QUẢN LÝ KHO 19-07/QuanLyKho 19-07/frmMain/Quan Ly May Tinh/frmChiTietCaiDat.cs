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

namespace frmMain
{
    public partial class frmChiTietCaiDat : DevExpress.XtraEditors.XtraForm
    {
        public frmChiTietCaiDat()
        {
            InitializeComponent();
            LoadControl();
        }
        private void LoadControl()
        {
            gcDsMayTinh.DataSource = DanhSachMayTinhDAO.Instance.GetListMaMT();
            gcDsPhanMem.DataSource = DanhSachPhanMemDAO.Instance.GetListMaMT();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Chọn nhiều máy tính cùng cài đặt nhiều phần mềm 
            string ngaycaidat = dtpNgayCaiDat.Value.ToString("dd/MM/yyyy");

            int DemMT = 0;
            List<string> ListMaMT = new List<string>();         
            foreach (var item in gridView1.GetSelectedRows())
            {
                string ma = gridView1.GetRowCellValue(item, "MAMT").ToString();
                DemMT++;
                ListMaMT.Add(ma);             
            }

            int DemPM = 0;
            List<DanhSachPhanMemDTO> ListMaPM = new List<DanhSachPhanMemDTO>();
            foreach (var item in gridView2.GetSelectedRows())
            {
                string ma1 = gridView2.GetRowCellValue(item, "MAPM").ToString();
                DanhSachPhanMemDTO a = DanhSachPhanMemDAO.Instance.GetMaPM(ma1);
                DemPM++;
                ListMaPM.Add(a);
            }

            if(DemMT==0)
            {
                MessageBox.Show("Chưa chọn máy tính.", "Lỗi:",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if(DemPM==0)
                {
                    MessageBox.Show("Chưa chọn phần mềm.", "Lỗi:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult kq = MessageBox.Show($"Bạn muốn lưu {DemPM} phần mềm cài đặt cho {DemMT} máy tính?", "Thông báo: ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {
                        foreach (string item in ListMaMT)
                        {
                            foreach (DanhSachPhanMemDTO item3 in ListMaPM)
                            {
                                try  // Cho vào try catch do có thể bị trùng mã phần mềm đã cài đặt cho máy tính
                                {
                                    DanhSachCaiDatDAO.Instance.Insert(item, item3.MAPM, item3.TENPM, ngaycaidat);
                                }
                                catch
                                {

                                }
                               
                            }                                               
                        }
                        MessageBox.Show("Lưu thông tin thành công!", "Thông báo:");
                    }
                }
            }
            DemMT = 0;
            DemPM = 0;
            LoadControl();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ColumSTT.Instance.CustomDrawRowIndicator(e);
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ColumSTT.Instance.CustomDrawRowIndicator(e);
        }


        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

            GridView view = sender as GridView;        
            string MaMT = view.GetRowCellValue(e.RowHandle, view.Columns["MAMT"]).ToString();
            bool CheckCDPM = DanhSachCaiDatDAO.Instance.CheckCDPM(MaMT);
           
            if (CheckCDPM)          // Đã cập nhật.
            {
                e.Appearance.BackColor = txtDaCN.BackColor;
            }
            else                    // Chưa cập nhật.
            {
                e.Appearance.BackColor = txtChuaCN.BackColor;
            }
        }
    }
}