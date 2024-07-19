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
    public partial class frmDanhSachCaiDat : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhSachCaiDat()
        {

            InitializeComponent();
            loadControl();
        }

        private void loadControl()
        {
            gridControl1.DataSource = DanhSachCaiDatDAO.Instance.GetTable();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ColumSTT.Instance.CustomDrawRowIndicator(e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //// cho phép xóa nhiều dòng trong gridview
            //int dem = 0;
            ////  int demloi = 0;
            //List<string> LsMaNVdcChon = new List<string>();
            //foreach (var item in gridView1.GetSelectedRows())
            //{
            //    string ma1 = gridView1.GetRowCellValue(item, "MANV").ToString();
            //    LsMaNVdcChon.Add(ma1);
            //    dem++;
            //}

            //if (dem > 0)
            //{
            //    DialogResult kq = MessageBox.Show($"Bạn muốn xóa {dem} mã nhân viên được chọn?", "Thông báo:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (kq == DialogResult.Yes)
            //    {
            //        int demXoa = 0;
            //        foreach (string item in LsMaNVdcChon)
            //        {
            //            if (item != CommonUser.UserStatic.MANV)
            //            {
            //                QLNhanVienDAO.Instance.Delete(item);
            //                demXoa++;
            //            }
            //        }

            //        if (demXoa < dem)
            //        {
            //            MessageBox.Show($"Đã xóa {demXoa} nhân viên, {dem - demXoa} không thể xóa.", "THÀNH CÔNG!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            MessageBox.Show($"Đã xóa {dem} nhân viên được chọn.", "THÀNH CÔNG!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        demXoa = 0;
            //        dem = 0;
            //    }
            //    LoadControl();
            //}
            //else
            //{
            //    MessageBox.Show("Bạn chưa chọn nhân viên để xóa.", "Lỗi:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


            // Xóa từng mã cài đặt một 
            string maMT = "";
            foreach (var item in gridView1.GetSelectedRows())
            {
                string ma1 = gridView1.GetRowCellValue(item, "MAMT").ToString();
                string maPM = gridView1.GetRowCellValue(item, "MAPM").ToString();

                maMT = ma1;
                if (maMT == "")
                {
                    MessageBox.Show("Bạn chưa chọn thông tin để xóa.", "Thông Báo:");
                }
                else
                {

                    DialogResult kq = MessageBox.Show($"Bạn muốn xóa thông tin cài phần mềm cho mã máy tính {maMT} ", "Thông Báo:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {                      
                        DanhSachCaiDatDAO.Instance.Delete(maMT, maPM);                                            
                    }
                    MessageBox.Show("Xóa thông tin thành công!");
                    loadControl();
                }
            }
          
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
               

            }
            catch
            {


            }
        }
    }
}