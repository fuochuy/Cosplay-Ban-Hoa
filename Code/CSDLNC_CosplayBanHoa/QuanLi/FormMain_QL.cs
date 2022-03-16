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
    public partial class FormMain_QL : Form
    {
        Thread t;
        public FormMain_QL()
        {
            InitializeComponent();
        }

        // mở 1 form con
        private Form activeform = null;
        private void openChildForm(Form childForm)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm_KH.Controls.Add(childForm);
            panelChildForm_KH.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // xử lí chuyển màu khi click vào button
        private Button currentButton;
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = ColorTranslator.FromHtml("#4169E1");
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(39, 39, 58);
                    previousBtn.ForeColor = Color.Gainsboro;
                }
            }
        }

        // xử lí đăng xuất + đăng nhập lại
        public void open_FormDangNhap(object obj)
        {
            Application.Run(new DangNhap());
        }

        private void btn_dangxuat_QL_Click(object sender, EventArgs e)
        {
            this.Close();
            t = new Thread(open_FormDangNhap);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void btn_thongke_QL_Click(object sender, EventArgs e)
        {
            openChildForm(new ThongKe_QL());
            ActivateButton(sender);
        }

        private void FormMain_QL_Load(object sender, EventArgs e)
        {
            btn_thongke_QL.PerformClick();
        }

        private void btn_hieusuatnv_QL_Click(object sender, EventArgs e)
        {
            openChildForm(new HieuSuatNV_QL());
            ActivateButton(sender);
        }

        private void btn_thietlapgiamgia_QL_Click(object sender, EventArgs e)
        {
            openChildForm(new ThietLapGiamGia_QL());
            ActivateButton(sender);
        }

        private void btn_thoat_KH_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
