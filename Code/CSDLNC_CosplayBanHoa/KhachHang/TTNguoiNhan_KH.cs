using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CSDLNC_CosplayBanHoa
{
    public partial class TTNguoiNhan_KH : Form
    {
        Thread t;
        DataTable tbl_TTNN;
        string MAKH;
        string TONGCONG;
        string TENKH;
        string DIACHI;
        string SDT;
        string PHIGIAOHANG;
        string TGMONGMUON;
        string MASP, SLMUA, THANHTIEN;
        public TTNguoiNhan_KH(string makh, string tongcong, string masp, string slmua, string thanhtien)
        {
            InitializeComponent();
            MAKH = makh;
            TONGCONG = tongcong;
            MASP = masp;
            SLMUA = slmua;
            THANHTIEN = thanhtien;
        }

        // xử lí đóng form TT người nhận và mở form thanh toán
        public void open_FormThanhToan(object obj)
        {         
            Application.Run(new ThanhToan_KH(
               MAKH,
            TENKH,
            DIACHI,
            SDT,
            PHIGIAOHANG,
            TGMONGMUON,
            TONGCONG,
            MASP, 
            SLMUA, 
            THANHTIEN));
        }

        private void btn_thanhtoan_TTNN_KH_Click(object sender, EventArgs e)
        {
            this.Close();
            t = new Thread(open_FormThanhToan);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void cBox_nguoinhan_TTNN_KH_CheckedChanged(object sender, EventArgs e)
        {
            if (cBox_nguoinhan_TTNN_KH.Checked == true)
            {
                string sql = "SELECT KH.TENKH, TK.SDT, TK.DIACHI " +
                    "FROM KHACHHANG KH, TAIKHOAN TK " +
                    "WHERE KH.ID = TK.ID " +
                    "AND KH.MAKH = '" + MAKH + "'";
                tbl_TTNN = Functions.GetDataToTable(sql);

                txtBox_ten_TTNN_KH.Text = tbl_TTNN.Rows[0].Field<String>(0);
                txtBox_sdt_TTNN_KH.Text = tbl_TTNN.Rows[0].Field<String>(1);
                txtBox_diachi_TTNN_KH.Text = tbl_TTNN.Rows[0].Field<String>(2);    
            }
            else
            {
                txtBox_ten_TTNN_KH.Text = "";
                txtBox_sdt_TTNN_KH.Text = "";
                txtBox_diachi_TTNN_KH.Text = "";               
            }
        }

        private void txtBox_diachi_TTNN_KH_TextChanged(object sender, EventArgs e)
        {
            txtBox_phigiaohang_TTNN_KH.Text = "30000.0000";
        }
        private void TTNguoiNhan_KH_FormClosing(object sender, FormClosingEventArgs e)
        {
            TENKH = txtBox_ten_TTNN_KH.Text.Trim();
            DIACHI = txtBox_diachi_TTNN_KH.Text.Trim();
            SDT = txtBox_sdt_TTNN_KH.Text.Trim();
            PHIGIAOHANG = txtBox_phigiaohang_TTNN_KH.Text.Trim();
            TGMONGMUON = dTP_thoigianmongmuon_TTNV_KH.Text.Trim();     
        }
    }
}
