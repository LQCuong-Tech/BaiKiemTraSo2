namespace Bai3HeThongMDIQuanLySieuThi.Forms
{
    partial class frmAsyncReport
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.btnLoadReport = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.lblSyncStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadReport
            // 
            this.btnLoadReport.Location = new System.Drawing.Point(12, 12);
            this.btnLoadReport.Name = "btnLoadReport";
            this.btnLoadReport.Size = new System.Drawing.Size(220, 40);
            this.btnLoadReport.TabIndex = 0;
            this.btnLoadReport.Text = "Tải Báo Cáo Doanh Thu";
            this.btnLoadReport.UseVisualStyleBackColor = true;
            this.btnLoadReport.Click += new System.EventHandler(this.btnLoadReport_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(12, 65);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.RowTemplate.Height = 24;
            this.dgvReport.Size = new System.Drawing.Size(758, 335);
            this.dgvReport.TabIndex = 1;
            // 
            // lblSyncStatus
            // 
            this.lblSyncStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSyncStatus.AutoSize = true;
            this.lblSyncStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSyncStatus.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSyncStatus.Location = new System.Drawing.Point(12, 415);
            this.lblSyncStatus.Name = "lblSyncStatus";
            this.lblSyncStatus.Size = new System.Drawing.Size(217, 18);
            this.lblSyncStatus.TabIndex = 2;
            this.lblSyncStatus.Text = "Trạng thái đồng bộ: Đang chờ...";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.lblSyncStatus);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.btnLoadReport);
            this.Name = "frmAsyncReport";
            this.Text = "Báo Cáo & Đồng Bộ Dữ Liệu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAsyncReport_FormClosing);
            this.Load += new System.EventHandler(this.frmAsyncReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadReport;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label lblSyncStatus;
    }
}