using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Bai1QLThietBiDT
{
    public class Device
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public partial class Form1 : Form
    {
        private BindingList<Device> deviceList;
        private BindingSource bindingSource;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            deviceList = new BindingList<Device>();
            bindingSource = new BindingSource { DataSource = deviceList };

            cboCategory.Items.AddRange(new string[] { "Điện thoại", "Máy tính bảng", "Laptop", "Phụ kiện", "Linh kiện" });
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            dgvDevices.AutoGenerateColumns = false;
            dgvDevices.AllowUserToAddRows = false;
            dgvDevices.ReadOnly = true;
            dgvDevices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevices.DataSource = bindingSource;

            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Mã TB", Width = 80 });
            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Tên Thiết Bị", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = "Loại Thiết Bị", Width = 120 });
            
            var colPrice = new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Đơn Giá", Width = 120 };
            colPrice.DefaultCellStyle.Format = "C0";
            colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDevices.Columns.Add(colPrice);
            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "Số Lượng", Width = 80 });
            GenerateNewId();
        }

        private void GenerateNewId()
        {
            txtDeviceId.Text = "TB" + DateTime.Now.ToString("yyMMddHHmmss");
        }

        private bool ValidateData()
        {
            bool isValid = true;
            errorProvider1.Clear();

           if (string.IsNullOrWhiteSpace(txtDeviceName.Text))
            {
                errorProvider1.SetError(txtDeviceName, "Tên thiết bị không được để trống.");
                isValid = false;
            }

            if (cboCategory.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboCategory, "Vui lòng chọn loại thiết bị.");
                isValid = false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                errorProvider1.SetError(txtPrice, "Đơn giá phải là số hợp lệ và > 0.");
                isValid = false;
            }

            return isValid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            var newDevice = new Device
            {
                Id = txtDeviceId.Text,
                Name = txtDeviceName.Text,
                Category = cboCategory.SelectedItem.ToString(),
                Price = decimal.Parse(txtPrice.Text),
                Quantity = (int)numQuantity.Value
            };

            deviceList.Add(newDevice);
            btnClear_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current == null) return;
            if (!ValidateData()) return;

            var currentDevice = (Device)bindingSource.Current;
            currentDevice.Name = txtDeviceName.Text;
            currentDevice.Category = cboCategory.SelectedItem.ToString();
            currentDevice.Price = decimal.Parse(txtPrice.Text);
            currentDevice.Quantity = (int)numQuantity.Value;

            bindingSource.ResetCurrentItem();
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current == null) return;

            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa thiết bị này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                bindingSource.RemoveCurrent();
                btnClear_Click(sender, e);
            }
        }

       private void btnClear_Click(object sender, EventArgs e)
        {
            GenerateNewId();
            txtDeviceName.Clear();
            cboCategory.SelectedIndex = -1;
            txtPrice.Clear();
            numQuantity.Value = 0;
            errorProvider1.Clear();
            dgvDevices.ClearSelection();
        }

        private void dgvDevices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && bindingSource.Current != null)
            {
                var currentDevice = (Device)bindingSource.Current;
                txtDeviceId.Text = currentDevice.Id;
                txtDeviceName.Text = currentDevice.Name;
                cboCategory.SelectedItem = currentDevice.Category;
                txtPrice.Text = currentDevice.Price.ToString("0");
                numQuantity.Value = currentDevice.Quantity;

                errorProvider1.Clear();
            }
        }
    }
}