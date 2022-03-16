using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace CSDLNC_CosplayBanHoa
{
    public partial class MuaHang_KH : Form
    {
        DataTable tbl_SP;
        DataTable tbl_SP2;
        string MAKH;
        Form_Loading form_loading = new Form_Loading();

        public MuaHang_KH(string id)
        {
            InitializeComponent();
            string sql = "SELECT MAKH FROM KHACHHANG WHERE ID = '" + id +"'";
            MAKH = Functions.GetFieldValues(sql);
        }

        private void MuaHang_KH_Load(object sender, EventArgs e)
        {         
            handle_menu();

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

        private void btn_timkiem_MH_KH_Click(object sender, EventArgs e)
        {
            if (txtBox_timkiem_MH_KH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập từ khóa vào ô tìm kiếm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Thread t = new Thread(() =>
            {
                form_loading.StartPosition = FormStartPosition.CenterParent;
                form_loading.ShowDialog();
            });

            // show form loading         
            t.Start();

            string tukhoa = txtBox_timkiem_MH_KH.Text.Trim();
            string sql = "Sp_KH_TimKiemSP '" + tukhoa + "'";
            tbl_SP2 = Functions.GetDataToTable(sql);
            dGV_SP_MH_KH.DataSource = tbl_SP2;

            form_loading.Close_Form();
        }
      
        private void Load_Data()
        {
            string sql = "SELECT MASP, TENSP, THANHPHANCHINH, GIAGOC ,KHUYENMAI, MOTA, CHITIETSP, HINHANH, SOLUONGTON " +
                "FROM SANPHAM";
            tbl_SP = Functions.GetDataToTable(sql);
            dGV_SP_MH_KH.DataSource = tbl_SP;

            // set Font cho tên cột
            dGV_SP_MH_KH.Font = new Font("Time New Roman", 13);
            dGV_SP_MH_KH.Columns[0].HeaderText = "Mã sản phẩm";
            dGV_SP_MH_KH.Columns[1].HeaderText = "Tên sản phẩm";
            dGV_SP_MH_KH.Columns[2].HeaderText = "Thành phần chính";
            dGV_SP_MH_KH.Columns[3].HeaderText = "Giá gốc";
            dGV_SP_MH_KH.Columns[4].HeaderText = "Khuyến mãi";
            dGV_SP_MH_KH.Columns[5].HeaderText = "Mô tả";
            dGV_SP_MH_KH.Columns[6].HeaderText = "Chi tiết sản phẩm";
            dGV_SP_MH_KH.Columns[7].HeaderText = "Hình ảnh";
            dGV_SP_MH_KH.Columns[8].HeaderText = "Số lượng tồn";

            // set Font cho dữ liệu hiển thị trong cột
            dGV_SP_MH_KH.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dGV_SP_MH_KH.Columns[0].Width = 0;
            dGV_SP_MH_KH.Columns[1].Width = 200;
            dGV_SP_MH_KH.Columns[2].Width = 200;
            dGV_SP_MH_KH.Columns[3].Width = 200;
            dGV_SP_MH_KH.Columns[4].Width = 200;
            dGV_SP_MH_KH.Columns[5].Width = 200;
            dGV_SP_MH_KH.Columns[6].Width = 200;
            dGV_SP_MH_KH.Columns[7].Width = 0;
            dGV_SP_MH_KH.Columns[8].Width = 200;


            //Không cho người dùng thêm dữ liệu trực tiếp
            dGV_SP_MH_KH.AllowUserToAddRows = false;
            dGV_SP_MH_KH.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dGV_SP_MH_KH_Click(object sender, EventArgs e)
        {
            //Nếu không có dữ liệu
            if (tbl_SP.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục 
            double phantram = (double)(100 - Int32.Parse(dGV_SP_MH_KH.CurrentRow.Cells["KHUYENMAI"].Value.ToString()))/100;
            double giagoc = double.Parse(dGV_SP_MH_KH.CurrentRow.Cells["GIAGOC"].Value.ToString());
            double giamoi = (double)(phantram * giagoc);
            giamoi = Math.Round(giamoi, 4);

            txtBox_tensp_MH_KH.Text = dGV_SP_MH_KH.CurrentRow.Cells["TENSP"].Value.ToString();
            txtBox_giacu_MH_KH.Text = dGV_SP_MH_KH.CurrentRow.Cells["GIAGOC"].Value.ToString();
            txtBox_giamoi_MH_KH.Text = giamoi.ToString("0.0000");
            txtBox_mota_MH_KH.Text = dGV_SP_MH_KH.CurrentRow.Cells["MOTA"].Value.ToString();
            txtBox_chitietsp_MH_KH.Text = dGV_SP_MH_KH.CurrentRow.Cells["CHITIETSP"].Value.ToString();

            // load anh 
            try
            {
                picBox_anh_DT.Load(dGV_SP_MH_KH.CurrentRow.Cells["HINHANH"].Value.ToString());
            }
            catch (Exception loi)
            {
                MessageBox.Show("Load ảnh thất bại, mã lỗi: " + loi.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);            
                return;
            }

        }


        private void btn_muangay_MH_KH_Click(object sender, EventArgs e)
        {       
            DonHang_KH donHang_KH = new DonHang_KH(
                dGV_SP_MH_KH.CurrentRow.Cells["MASP"].Value.ToString(),
                dGV_SP_MH_KH.CurrentRow.Cells["TENSP"].Value.ToString(),
                txtBox_giamoi_MH_KH.Text.Trim().ToString(),
                dGV_SP_MH_KH.CurrentRow.Cells["SOLUONGTON"].Value.ToString(),
                MAKH,
                dGV_SP_MH_KH.CurrentRow.Cells["HINHANH"].Value.ToString());
            donHang_KH.StartPosition = FormStartPosition.CenterScreen;
            donHang_KH.Show();
        }

        private void handle_menu()
        {
            Load_MenuToolStripMenuItems(hoaSinhNhatToolStripMenuItem, Get_Item_For_Menu1());
            Load_MenuToolStripMenuItems(cheĐeToolStripMenuItem, Get_Item_For_Menu2());
            Load_MenuToolStripMenuItems(hoaTuoiToolStripMenuItem, Get_Item_For_Menu3());
            Load_MenuToolStripMenuItems(mauSacToolStripMenuItem, Get_Item_For_Menu4());
            Load_MenuToolStripMenuItems(hoaĐacBietToolStripMenuItem, Get_Item_For_Menu5());
            Load_MenuToolStripMenuItems(hoaCuoiToolStripMenuItem, Get_Item_For_Menu6());
        }

        private void Load_MenuToolStripMenuItems(ToolStripMenuItem tool_strip_menu_item, List<String> list_items)
        {
            int id = 0;

            foreach(String items in list_items)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(items);
                id++;
                tool_strip_menu_item.DropDownItems.Add(item);
                item.Click += new EventHandler(Item_Click);
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
    
            txtBox_timkiem_MH_KH.Text = item.Text;
            btn_timkiem_MH_KH.PerformClick();
        }

        private List<String> Get_Item_For_Menu1()
        {
            List<String> menu_item = new List<String>();

            menu_item.Add("Hoa sinh nhật Ba Mẹ");
            menu_item.Add("Hoa sinh nhật người yêu");
            menu_item.Add("Hoa sinh nhật bạn bè");

            return menu_item;
        }

        private List<String> Get_Item_For_Menu2()
        {
            List<String> menu_item = new List<String>();

            menu_item.Add("Hoa sinh nhật");
            menu_item.Add("Hoa tặng mẹ");
            menu_item.Add("Hoa tình yêu");
            menu_item.Add("Hoa mừng tốt nghiệp");

            return menu_item;
        }

        private List<String> Get_Item_For_Menu3()
        {
            List<String> menu_item = new List<String>();

            menu_item.Add("Hoa Cúc");
            menu_item.Add("Cẩm Chướng");
            menu_item.Add("Hoa Tulip");
            menu_item.Add("Hoa Ly");
            menu_item.Add("Hoa Hồng");
            menu_item.Add("Lan Hồ Điệp");

            return menu_item;
        }

        private List<String> Get_Item_For_Menu4()
        {
            List<String> menu_item = new List<String>();

            menu_item.Add("Hoa sinh nhật Ba Mẹ");
            menu_item.Add("Hoa sinh nhật người yêu");
            menu_item.Add("Hoa sinh nhật bạn bè");

            return menu_item;
        }

        private List<String> Get_Item_For_Menu5()
        {
            List<String> menu_item = new List<String>();

            menu_item.Add("Hoa sinh nhật Ba Mẹ");
            menu_item.Add("Hoa sinh nhật người yêu");
            menu_item.Add("Hoa sinh nhật bạn bè");

            return menu_item;
        }

        private List<String> Get_Item_For_Menu6()
        {
            List<String> menu_item = new List<String>();

            menu_item.Add("Hoa sinh nhật Ba Mẹ");
            menu_item.Add("Hoa sinh nhật người yêu");
            menu_item.Add("Hoa sinh nhật bạn bè");

            return menu_item;
        }

        private void btn_huytimkiem_MK_KH_Click(object sender, EventArgs e)
        {
            txtBox_timkiem_MH_KH.Text = "";
            dGV_SP_MH_KH.DataSource = tbl_SP;
        }
    }
}
