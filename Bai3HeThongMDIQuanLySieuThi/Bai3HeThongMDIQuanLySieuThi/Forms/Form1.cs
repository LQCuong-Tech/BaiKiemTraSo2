using System;
using System.Windows.Forms;

namespace Bai3HeThongMDIQuanLySieuThi.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // --- HÀM ĐIỀU HƯỚNG MDI AN TOÀN ---
        private void ShowChildForm(Form childForm)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == childForm.GetType())
                {
                    f.Activate();
                    return;
                }
            }
            childForm.MdiParent = this;
            childForm.Show();
        }

        // --- SỰ KIỆN MENU ---
        private void menuQuanLySanPham_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmProductCatalog());
        }

        private void menuThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmAsyncReport());
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // --- BỐ CỤC CỬA SỔ ---
        private void menuCascade_Click(object sender, EventArgs e) => this.LayoutMdi(MdiLayout.Cascade);
        private void menuTileHorizontal_Click(object sender, EventArgs e) => this.LayoutMdi(MdiLayout.TileHorizontal);
        private void menuTileVertical_Click(object sender, EventArgs e) => this.LayoutMdi(MdiLayout.TileVertical);

        // --- ĐIỀU KHIỂN PROGRESSBAR TỪ FORM CON ---
        public void ToggleProgressBar(bool isVisible)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => pbMainProgress.Visible = isVisible));
            }
            else
            {
                pbMainProgress.Visible = isVisible;
            }
        }
    }
}