namespace Bai3HeThongMDIQuanLySieuThi.Forms
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLySanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyNhapXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThongKeDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCuaSo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTileHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTileVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbMainProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHeThong,
            this.menuDanhMuc,
            this.menuBaoCao,
            this.menuCuaSo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuHeThong
            // 
            this.menuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDangXuat,
            this.menuThoat});
            this.menuHeThong.Name = "menuHeThong";
            this.menuHeThong.Text = "Hệ thống";
            // 
            // menuDangXuat
            // 
            this.menuDangXuat.Name = "menuDangXuat";
            this.menuDangXuat.Size = new System.Drawing.Size(160, 26);
            this.menuDangXuat.Text = "Đăng xuất";
            // 
            // menuThoat
            // 
            this.menuThoat.Name = "menuThoat";
            this.menuThoat.Size = new System.Drawing.Size(160, 26);
            this.menuThoat.Text = "Thoát";
            this.menuThoat.Click += new System.EventHandler(this.menuThoat_Click);
            // 
            // menuDanhMuc
            // 
            this.menuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuQuanLySanPham,
            this.menuQuanLyNhapXuat});
            this.menuDanhMuc.Name = "menuDanhMuc";
            this.menuDanhMuc.Text = "Danh mục";
            // 
            // menuQuanLySanPham
            // 
            this.menuQuanLySanPham.Name = "menuQuanLySanPham";
            this.menuQuanLySanPham.Size = new System.Drawing.Size(211, 26);
            this.menuQuanLySanPham.Text = "Quản lý Sản phẩm";
            this.menuQuanLySanPham.Click += new System.EventHandler(this.menuQuanLySanPham_Click);
            // 
            // menuQuanLyNhapXuat
            // 
            this.menuQuanLyNhapXuat.Name = "menuQuanLyNhapXuat";
            this.menuQuanLyNhapXuat.Size = new System.Drawing.Size(211, 26);
            this.menuQuanLyNhapXuat.Text = "Quản lý Nhập xuất";
            // 
            // menuBaoCao
            // 
            this.menuBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuThongKeDoanhThu});
            this.menuBaoCao.Name = "menuBaoCao";
            this.menuBaoCao.Text = "Báo cáo";
            // 
            // menuThongKeDoanhThu
            // 
            this.menuThongKeDoanhThu.Name = "menuThongKeDoanhThu";
            this.menuThongKeDoanhThu.Size = new System.Drawing.Size(225, 26);
            this.menuThongKeDoanhThu.Text = "Thống kê Doanh thu";
            this.menuThongKeDoanhThu.Click += new System.EventHandler(this.menuThongKeDoanhThu_Click);
            // 
            // menuCuaSo
            // 
            this.menuCuaSo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCascade,
            this.menuTileHorizontal,
            this.menuTileVertical});
            this.menuCuaSo.Name = "menuCuaSo";
            this.menuCuaSo.Text = "Cửa sổ";
            // 
            // menuCascade
            // 
            this.menuCascade.Name = "menuCascade";
            this.menuCascade.Size = new System.Drawing.Size(189, 26);
            this.menuCascade.Text = "Cascade";
            this.menuCascade.Click += new System.EventHandler(this.menuCascade_Click);
            // 
            // menuTileHorizontal
            // 
            this.menuTileHorizontal.Name = "menuTileHorizontal";
            this.menuTileHorizontal.Size = new System.Drawing.Size(189, 26);
            this.menuTileHorizontal.Text = "Tile Horizontal";
            this.menuTileHorizontal.Click += new System.EventHandler(this.menuTileHorizontal_Click);
            // 
            // menuTileVertical
            // 
            this.menuTileVertical.Name = "menuTileVertical";
            this.menuTileVertical.Size = new System.Drawing.Size(189, 26);
            this.menuTileVertical.Text = "Tile Vertical";
            this.menuTileVertical.Click += new System.EventHandler(this.menuTileVertical_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.pbMainProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 627);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(982, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(865, 20);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Sẵn sàng";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbMainProgress
            // 
            this.pbMainProgress.Name = "pbMainProgress";
            this.pbMainProgress.Size = new System.Drawing.Size(100, 18);
            this.pbMainProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbMainProgress.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Quản Lý (MDI - Bất Đồng Bộ)";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuHeThong;
        private System.Windows.Forms.ToolStripMenuItem menuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem menuThoat;
        private System.Windows.Forms.ToolStripMenuItem menuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLySanPham;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLyNhapXuat;
        private System.Windows.Forms.ToolStripMenuItem menuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem menuThongKeDoanhThu;
        private System.Windows.Forms.ToolStripMenuItem menuCuaSo;
        private System.Windows.Forms.ToolStripMenuItem menuCascade;
        private System.Windows.Forms.ToolStripMenuItem menuTileHorizontal;
        private System.Windows.Forms.ToolStripMenuItem menuTileVertical;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar pbMainProgress;
    }
}