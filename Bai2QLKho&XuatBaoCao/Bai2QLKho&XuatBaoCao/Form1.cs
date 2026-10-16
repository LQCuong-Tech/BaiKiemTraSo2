using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Bai2QLKho_XuatBaoCao
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
    }

    public partial class Form1 : Form
    {
        private BindingList<Product> productList;
        private BindingSource bindingSource;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            productList = new BindingList<Product>();
            bindingSource = new BindingSource { DataSource = productList };
            productList.ListChanged += ProductList_ListChanged;

            cboCategory.Items.AddRange(new string[] { "Điện thoại", "Máy tính bảng", "Laptop", "Phụ kiện", "Linh kiện" });
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            SetupDataGridView();
            GenerateNewId();

            timerClock.Start();
            UpdateStatusInfo();
        }

        private void SetupDataGridView()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.DataSource = bindingSource;

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Mã SP", Width = 80 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Tên Sản Phẩm", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = "Loại SP", Width = 100 });

            var colPrice = new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Đơn Giá", Width = 100 };
            colPrice.DefaultCellStyle.Format = "C0";
            dgvProducts.Columns.Add(colPrice);

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "Số Lượng", Width = 80 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ImagePath", HeaderText = "Đường Dẫn Ảnh", Width = 150 });
        }

        private void GenerateNewId()
        {
            txtProductId.Text = "SP" + DateTime.Now.ToString("yyMMddHHmmss");
        }

        // ================= XỬ LÝ STATUS STRIP =================
        private void ProductList_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateStatusInfo();
        }

        private void UpdateStatusInfo()
        {
            int totalQuantity = 0;
            decimal totalValue = 0;

            foreach (var p in productList)
            {
                totalQuantity += p.Quantity;
                totalValue += (p.Quantity * p.Price);
            }

            lblStatusTotalQty.Text = $"Tổng số lượng: {totalQuantity}";
            lblStatusTotalValue.Text = $"Tổng giá trị: {totalValue:C0}";
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblStatusTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        // ================= CHỌN ẢNH (OPEN FILE DIALOG) =================
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh sản phẩm";
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtImagePath.Text = ofd.FileName;
                    picProductImage.ImageLocation = ofd.FileName;
                }
            }
        }

        // ================= XỬ LÝ CRUD =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text)) return;

            productList.Add(new Product
            {
                Id = txtProductId.Text,
                Name = txtProductName.Text,
                Category = cboCategory.SelectedItem?.ToString() ?? "",
                Price = decimal.Parse(txtPrice.Text),
                Quantity = (int)numQuantity.Value,
                ImagePath = txtImagePath.Text
            });
            btnClear_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Product currentProduct)
            {
                currentProduct.Name = txtProductName.Text;
                currentProduct.Category = cboCategory.SelectedItem?.ToString();
                currentProduct.Price = decimal.Parse(txtPrice.Text);
                currentProduct.Quantity = (int)numQuantity.Value;
                currentProduct.ImagePath = txtImagePath.Text;
                bindingSource.ResetCurrentItem();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current != null &&
                MessageBox.Show("Xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bindingSource.RemoveCurrent();
                btnClear_Click(sender, e);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            GenerateNewId();
            txtProductName.Clear();
            cboCategory.SelectedIndex = -1;
            txtPrice.Clear();
            numQuantity.Value = 0;
            txtImagePath.Clear();
            picProductImage.Image = null;
            dgvProducts.ClearSelection();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && bindingSource.Current is Product currentProduct)
            {
                txtProductId.Text = currentProduct.Id;
                txtProductName.Text = currentProduct.Name;
                cboCategory.SelectedItem = currentProduct.Category;
                txtPrice.Text = currentProduct.Price.ToString("0");
                numQuantity.Value = currentProduct.Quantity;
                txtImagePath.Text = currentProduct.ImagePath;

                if (!string.IsNullOrEmpty(currentProduct.ImagePath) && File.Exists(currentProduct.ImagePath))
                    picProductImage.ImageLocation = currentProduct.ImagePath;
                else
                    picProductImage.Image = null;
            }
        }

        // ================= XUẤT/NHẬP CSV =================
        private void ExportCSV()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV File (*.csv)|*.csv";
                sfd.Title = "Xuất báo cáo kho";
                sfd.FileName = "BaoCaoKho_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Mã SP,Tên Sản Phẩm,Loại,Đơn Giá,Số Lượng,Đường Dẫn Ảnh");

                    foreach (var p in productList)
                    {
                        string safeName = p.Name.Contains(",") ? $"\"{p.Name}\"" : p.Name;
                        sb.AppendLine($"{p.Id},{safeName},{p.Category},{p.Price},{p.Quantity},{p.ImagePath}");
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Xuất file CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ImportCSV()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV File (*.csv)|*.csv";
                ofd.Title = "Nhập dữ liệu kho";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var lines = File.ReadAllLines(ofd.FileName, Encoding.UTF8);
                        productList.Clear();

                        for (int i = 1; i < lines.Length; i++)
                        {
                            if (string.IsNullOrWhiteSpace(lines[i])) continue;
                            string[] data = lines[i].Split(',');

                            if (data.Length >= 6)
                            {
                                productList.Add(new Product
                                {
                                    Id = data[0],
                                    Name = data[1].Trim('"'),
                                    Category = data[2],
                                    Price = decimal.TryParse(data[3], out decimal pr) ? pr : 0,
                                    Quantity = int.TryParse(data[4], out int qt) ? qt : 0,
                                    ImagePath = data[5]
                                });
                            }
                        }
                        MessageBox.Show("Nhập dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ================= SỰ KIỆN MENU & TOOLSTRIP =================
        private void menuImportCSV_Click(object sender, EventArgs e) => ImportCSV();
        private void menuExportCSV_Click(object sender, EventArgs e) => ExportCSV();
        private void menuExit_Click(object sender, EventArgs e) => this.Close();
        private void toolBtnImport_Click(object sender, EventArgs e) => ImportCSV();
        private void toolBtnExport_Click(object sender, EventArgs e) => ExportCSV();

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}