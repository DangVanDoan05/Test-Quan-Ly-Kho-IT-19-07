using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using DTO;

namespace frmMain.Report
{
    public partial class rptBienBanBG : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBienBanBG()
        {
            InitializeComponent();
        }
        private List<DSTHIETBIBGDTO> _lstDSTBBG;
        private string ddTg;

        public string DdTg { get => ddTg; set => ddTg = value; }
        public rptBienBanBG(DSNhanSuBGDTO TTnsBG)
        {
            InitializeComponent();
            this.DdTg = TTnsBG.NGAYBG;
            this.lblDdTg.Text = DdTg;
        }

        public rptBienBanBG(List<DSTHIETBIBGDTO> list, DSNhanSuBGDTO TTnsBG)
        {
            InitializeComponent();
            this._lstDSTBBG = list;
            this.DataSource = _lstDSTBBG;
            string[] datetime = (TTnsBG.NGAYBG).Split('/');
            this.lblDdTg.Text = $" Đông Dương ngày {datetime[0]} tháng {datetime[1]} năm {datetime[2]} ";
            this.DdTg = TTnsBG.NGAYBG;
            this.lblTgDd.Text = $"Ngày {TTnsBG.NGAYBG}, tại. địa điểm: ....Đông Dương..... Chúng tôi gồm: ";
            this.lblNguoiBG.Text = $"Người bàn giao:....{TTnsBG.TENNVBG}....Bộ phận:....IT.... Mã nhân viên: ....{TTnsBG.MANVBG}.... ";
            this.lblNguoiNhanBG.Text = $"Người nhận bàn giao:...{TTnsBG.TENNVNHANBG}...Bộ phận:...{TTnsBG.PBNBG}....Mã nhân viên:....{TTnsBG.MANVNHANBG}....";
            this.lblLydoBG.Text = $"Lý do bàn giao: ......{TTnsBG.LYDOBG} ......";
            this.lblfooter.Text = "Người bàn giao bàn giao đầy đủ thiết bị đã liệt kê," +
                                  " người nhận bàn giao có trách nhiệm tự bảo quản thiết bị đã nhận." +
                                  " Biên bản được lập thành 02 bản, mỗi bên giữ một bản";
            LoadDataTB();
        }
        private void LoadDataTB()
        {
            lblSTT.DataBindings.Add("Text", _lstDSTBBG, "STT");
            lblTenTB.DataBindings.Add("Text", _lstDSTBBG, "TENTB");
            lblMaTB.DataBindings.Add("Text", _lstDSTBBG, "MATB");
            lblDonVi.DataBindings.Add("Text", _lstDSTBBG, "DONVI");
            lblSoLuong.DataBindings.Add("Text", _lstDSTBBG, "SOLUONG");
            lblTinhTrang.DataBindings.Add("Text", _lstDSTBBG, "TINHTRANG");
            
        }

    }
}
