using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai3HeThongMDIQuanLySieuThi.Forms

{
    public partial class frmAsyncReport : Form
    {
        private bool isSyncing = true;

        public frmAsyncReport()
        {
            InitializeComponent();
        }

        private void frmAsyncReport_Load(object sender, EventArgs e)
        {
            StartBackgroundSync();
        }

        // --- TẢI DỮ LIỆU BẤT ĐỒNG BỘ (ASYNC/AWAIT) ---
        private async void btnLoadReport_Click(object sender, EventArgs e)
        {
            btnLoadReport.Enabled = false;

            if (this.MdiParent is frmMain mainForm)
            {
                mainForm.ToggleProgressBar(true);
            }

            try
            {
                DataTable data = await Task.Run(() => GetHeavyReportData());
                dgvReport.DataSource = data;
            }
            finally
            {
                if (this.MdiParent is frmMain parent)
                {
                    parent.ToggleProgressBar(false);
                }
                btnLoadReport.Enabled = true;
            }
        }

        private DataTable GetHeavyReportData()
        {
            Thread.Sleep(4000);

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Đơn", typeof(string));
            dt.Columns.Add("Doanh Thu", typeof(decimal));

            dt.Rows.Add("ORD-001", 1500000);
            dt.Rows.Add("ORD-002", 2300000);
            dt.Rows.Add("ORD-003", 850000);

            return dt;
        }

        // --- CẬP NHẬT UI AN TOÀN TỪ THREAD PHỤ ---
        private void StartBackgroundSync()
        {
            Task.Run(async () =>
            {
                Random rnd = new Random();
                while (isSyncing)
                {
                    await Task.Delay(2000);

                    int newOrders = rnd.Next(1, 10);
                    string statusMsg = $"[Đồng bộ ngầm] Quét thấy {newOrders} đơn hàng mới lúc {DateTime.Now:HH:mm:ss}";

                    UpdateSyncStatusSafe(statusMsg);
                }
            });
        }

        private void UpdateSyncStatusSafe(string message)
        {
            if (lblSyncStatus.InvokeRequired)
            {
                lblSyncStatus.Invoke(new Action(() => lblSyncStatus.Text = message));
            }
            else
            {
                lblSyncStatus.Text = message;
            }
        }

        private void frmAsyncReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            isSyncing = false;
        }
    }
}