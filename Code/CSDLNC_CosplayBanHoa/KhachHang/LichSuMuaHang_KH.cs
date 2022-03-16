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
    public partial class LichSuMuaHang_KH : Form
    {
        string MAKH;
        DataTable tbl_LSMH;
        Form_Loading form_loading = new Form_Loading();
        public LichSuMuaHang_KH(string makh)
        {
            InitializeComponent();
            MAKH = makh;
        }

        private void Load_Data()
        {
            string sql = "Sp_KH_LayThongTinDH '" + MAKH +  "'";
            tbl_LSMH = Functions.GetDataToTable(sql);
            dGV_LSMH_KH.DataSource = tbl_LSMH;

            // set Font cho tên cột
            dGV_LSMH_KH.Font = new Font("Time New Roman", 13);
            dGV_LSMH_KH.Columns[0].HeaderText = "Mã đơn hàng";
            dGV_LSMH_KH.Columns[1].HeaderText = "Mã khách hàng";
            dGV_LSMH_KH.Columns[2].HeaderText = "Mã nhân viên";
            dGV_LSMH_KH.Columns[3].HeaderText = "Tên người nhận";
            dGV_LSMH_KH.Columns[4].HeaderText = "Địa chỉ người nhận";
            dGV_LSMH_KH.Columns[5].HeaderText = "SĐT người nhận";
            dGV_LSMH_KH.Columns[6].HeaderText = "Phí vận chuyển";
            dGV_LSMH_KH.Columns[7].HeaderText = "Hình thức thanh toán";
            dGV_LSMH_KH.Columns[8].HeaderText = "Ngày muốn giao";
            dGV_LSMH_KH.Columns[9].HeaderText = "Ngày lập";
            dGV_LSMH_KH.Columns[10].HeaderText = "Tình trạng";
            dGV_LSMH_KH.Columns[11].HeaderText = "Tổng tiền";

            // set Font cho dữ liệu hiển thị trong cột
            dGV_LSMH_KH.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dGV_LSMH_KH.Columns[0].Width = 200;
            dGV_LSMH_KH.Columns[1].Width = 0;
            dGV_LSMH_KH.Columns[2].Width = 0;
            dGV_LSMH_KH.Columns[3].Width = 200;
            dGV_LSMH_KH.Columns[4].Width = 200;
            dGV_LSMH_KH.Columns[5].Width = 200;
            dGV_LSMH_KH.Columns[6].Width = 200;
            dGV_LSMH_KH.Columns[7].Width = 0;
            dGV_LSMH_KH.Columns[8].Width = 200;
            dGV_LSMH_KH.Columns[9].Width = 200;
            dGV_LSMH_KH.Columns[10].Width = 200;
            dGV_LSMH_KH.Columns[11].Width = 200;


            //Không cho người dùng thêm dữ liệu trực tiếp
            dGV_LSMH_KH.AllowUserToAddRows = false;
            dGV_LSMH_KH.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btn_xemchitiet_LSMH_KH_Click(object sender, EventArgs e)
        {
            if (txtBox_madh_LSMH_KH.Text.Trim().Length==0)
            {
                MessageBox.Show("Bạn chưa chọn đơn hàng nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CT_DonHang ct_DonHang = new CT_DonHang(txtBox_madh_LSMH_KH.Text.Trim().ToString());
            ct_DonHang.StartPosition = FormStartPosition.CenterScreen;
            ct_DonHang.Show();
        }

        private string Get_HinhThucThanhToan(string httt)
        {
            string kq = "";
            switch(Int32.Parse(httt))
            {
                case 0:
                    {
                        kq = "Thanh toán khi nhận hàng";
                        break;
                        
                    }
                case 1:
                    {
                        kq = "Thanh toán ở nơi khác";
                        break;
                     
                    }
                case 2:
                    {
                        kq = "Thanh toán qua chuyển khoản";
                        break;
                       
                    }
                case 3:
                    {
                        kq = "Thanh toán trực tiếp tại nơi mua hàng";
                        break;
                      
                    }               
            }
            return kq;
        }

        private string Get_TinhTrang(string tt)
        {
            string kq = "";
            switch (Int32.Parse(tt))
            {
                case -1:
                    {
                        kq = "Khách hàng đã huỷ";
                        break;

                    }
                case 0:
                    {
                        kq = "Đã đóng gói, chưa giao cho tài xế";
                        break;

                    }
                case 1:
                    {
                        kq = "Đã giao cho tài xế, đang giao hàng";
                        break;

                    }
                case 2:
                    {
                        kq = "Đã giao thành công";
                        break;

                    }
                case 3:
                    {
                        kq = "Đã hoàn trả hàng";
                        break;

                    }
                case 4:
                    {
                        kq = "Giao chưa thành công";
                        break;

                    }
            }
            return kq;
        }

        private void dGV_LSMH_KH_Click(object sender, EventArgs e)
        {
            //Nếu không có dữ liệu
            if (tbl_LSMH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục 
            txtBox_madh_LSMH_KH.Text = dGV_LSMH_KH.CurrentRow.Cells["MADH"].Value.ToString();
            txtBox_ten_LSMH_KH.Text = dGV_LSMH_KH.CurrentRow.Cells["TENNGUOINHAN"].Value.ToString();
            txtBox_diachi_LSMH_KH.Text = dGV_LSMH_KH.CurrentRow.Cells["DIACHI_NGUOINHAN"].Value.ToString();
            txtBox_sdt_LSMH_KH.Text = dGV_LSMH_KH.CurrentRow.Cells["SDT_NGUOINHAN"].Value.ToString();
            txtBox_ngaymua_LSMH_KH.Text = dGV_LSMH_KH.CurrentRow.Cells["NGAYLAP"].Value.ToString();
            txtBox_ngaymuongiao_LSMH_KH.Text = dGV_LSMH_KH.CurrentRow.Cells["NGAYMUONGIAO"].Value.ToString();
            txtBox_HTthanhtoan_LSMH_KH.Text = Get_HinhThucThanhToan(dGV_LSMH_KH.CurrentRow.Cells["HINHTHUCTHANHTOAN"].Value.ToString());
            txtBox_tinhtrang_LSMH_KH.Text = Get_TinhTrang(dGV_LSMH_KH.CurrentRow.Cells["TINHTRANG"].Value.ToString());
            txtBox_phivanchuyen_LSMH_KH.Text = dGV_LSMH_KH.CurrentRow.Cells["PHIVANCHUYEN"].Value.ToString();
            txtBox_tongtien_LSMH_KH.Text = dGV_LSMH_KH.CurrentRow.Cells["TONGTIEN"].Value.ToString();
            //           
        }

        private void LichSuMuaHang_KH_Load(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
            {
                form_loading.StartPosition = FormStartPosition.CenterParent;
                form_loading.ShowDialog();
            });

            // show form loading         
            t.Start();

            Load_Data();

            form_loading.Close_Form();
        }
    }
}
