using POS.Core.Models;
using POS.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace POS.UI
{
    public partial class ProductsForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private User? _currentUser;

        public ProductsForm(IProductService productService, ICategoryService categoryService)
        {
            InitializeComponent();
            _productService = productService;
            _categoryService = categoryService;
        }

        private void InitializeComponent()
        {
            this.pnlTop = new Panel();
            this.cboCategories = new ComboBox();
            this.lblCategory = new Label();
            this.lblTitle = new Label();
            this.dgvProducts = new DataGridView();
            this.pnlBottom = new Panel();
            this.btnDelete = new Button();
            this.btnEdit = new Button();
            this.btnAdd = new Button();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = Color.White;
            this.pnlTop.Controls.Add(this.cboCategories);
            this.pnlTop.Controls.Add(this.lblCategory);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Location = new Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new Size(882, 80);
            this.pnlTop.TabIndex = 0;
            // 
            // cboCategories
            // 
            this.cboCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCategories.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            this.cboCategories.FormattingEnabled = true;
            this.cboCategories.Location = new Point(466, 27);
            this.cboCategories.Name = "cboCategories";
            this.cboCategories.Size = new Size(250, 31);
            this.cboCategories.TabIndex = 2;
            this.cboCategories.SelectedIndexChanged += new EventHandler(this.cboCategories_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblCategory.Location = new Point(387, 30);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new Size(73, 23);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "Ангилал:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.Location = new Point(12, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(229, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Барааны мэдээлэл";
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = Color.White;
            this.dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = DockStyle.Fill;
            this.dgvProducts.Location = new Point(0, 80);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 29;
            this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new Size(882, 423);
            this.dgvProducts.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = Color.WhiteSmoke;
            this.pnlBottom.Controls.Add(this.btnDelete);
            this.pnlBottom.Controls.Add(this.btnEdit);
            this.pnlBottom.Controls.Add(this.btnAdd);
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Location = new Point(0, 453);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new Size(882, 50);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnDelete.BackColor = Color.Crimson;
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Location = new Point(759, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(111, 35);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Устгах";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnEdit.BackColor = Color.DodgerBlue;
            this.btnEdit.FlatStyle = FlatStyle.Flat;
            this.btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnEdit.ForeColor = Color.White;
            this.btnEdit.Location = new Point(642, 8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new Size(111, 35);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Засах";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnAdd.BackColor = Color.ForestGreen;
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Location = new Point(525, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(111, 35);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Нэмэх";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(882, 503);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize = new Size(900, 550);
            this.Name = "ProductsForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Барааны жагсаалт";
            this.Load += new EventHandler(this.ProductsForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Panel pnlTop;
        private ComboBox cboCategories;
        private Label lblCategory;
        private Label lblTitle;
        private DataGridView dgvProducts;
        private Panel pnlBottom;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
            
            // Configure UI based on user role
            bool isManager = user.Role == UserRole.Manager;
            btnAdd.Visible = isManager;
            btnEdit.Visible = isManager;
            btnDelete.Visible = isManager;
        }

        private async void ProductsForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Load categories
                var categories = await _categoryService.GetAllCategoriesAsync();
                cboCategories.Items.Clear();
                cboCategories.Items.Add(new { Id = 0, Name = "-- Бүгд --" });
                foreach (var category in categories)
                {
                    cboCategories.Items.Add(category);
                }
                cboCategories.DisplayMember = "Name";
                cboCategories.ValueMember = "Id";
                cboCategories.SelectedIndex = 0;

                // Setup grid
                SetupProductGrid();
                
                // Load products
                await LoadProductsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Алдаа гарлаа: {ex.Message}", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupProductGrid()
        {
            dgvProducts.Columns.Clear();
            
            // Add columns
            dgvProducts.Columns.Add("Id", "ID");
            dgvProducts.Columns.Add("Code", "Код");
            dgvProducts.Columns.Add("Name", "Барааны нэр");
            dgvProducts.Columns.Add("Category", "Ангилал");
            dgvProducts.Columns.Add("Price", "Үнэ");
            dgvProducts.Columns.Add("StockQuantity", "Үлдэгдэл");
            
            // Configure columns
            dgvProducts.Columns["Id"].Visible = false;
            dgvProducts.Columns["Code"].Width = 100;
            dgvProducts.Columns["Name"].Width = 250;
            dgvProducts.Columns["Category"].Width = 150;
            dgvProducts.Columns["Price"].Width = 100;
            dgvProducts.Columns["StockQuantity"].Width = 100;
            
            // Set numeric format
            dgvProducts.Columns["Price"].DefaultCellStyle.Format = "N0";
            dgvProducts.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProducts.Columns["StockQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private async System.Threading.Tasks.Task LoadProductsAsync(int categoryId = 0)
        {
            try
            {
                dgvProducts.Rows.Clear();
                
                IEnumerable<Product> products;
                if (categoryId == 0)
                {
                    products = await _productService.GetAllProductsAsync();
                }
                else
                {
                    products = await _productService.GetProductsByCategoryIdAsync(categoryId);
                }
                
                foreach (var product in products)
                {
                    int rowIndex = dgvProducts.Rows.Add(
                        product.Id,
                        product.Code,
                        product.Name,
                        product.Category?.Name ?? "Ангилалгүй",
                        product.Price,
                        product.StockQuantity);
                    
                    // Highlight low stock items
                    if (product.StockQuantity < 10)
                    {
                        dgvProducts.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightPink;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Бараа ачаалахад алдаа гарлаа: {ex.Message}", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategories.SelectedIndex < 0) return;
            
            int categoryId = 0;
            if (cboCategories.SelectedIndex > 0)
            {
                var category = cboCategories.SelectedItem as Category;
                if (category != null)
                {
                    categoryId = category.Id;
                }
            }
            
            await LoadProductsAsync(categoryId);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Шинэ форм нээх
                using (var addProductForm = new AddProductForm(Program.ServiceProvider!))
                {
                    var result = addProductForm.ShowDialog();
                    
                    // Хэрэв амжилттай хадгалагдсан бол жагсаалтыг шинэчилнэ
                    if (result == DialogResult.OK)
                    {
                        // Одоогийн сонгосон ангиллын ID-г авах
                        int categoryId = 0;
                        if (cboCategories.SelectedIndex > 0 && cboCategories.SelectedItem is Category category)
                        {
                            categoryId = category.Id;
                        }
                        
                        // Бараануудыг дахин ачаалах
                        _ = LoadProductsAsync(categoryId);
                        MessageBox.Show("Бараа амжилттай нэмэгдлээ.", "Амжилттай", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Алдаа гарлаа: {ex.Message}", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Сонгосон барааг шалгах
                if (dgvProducts.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Засах бараагаа сонгоно уу.", "Анхааруулга", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Сонгосон барааны ID-г авах
                int productId = (int)dgvProducts.SelectedRows[0].Cells["Id"].Value;

                // Бараа мэдээллийг базаас татах
                var product = _productService.GetProductByIdAsync(productId).GetAwaiter().GetResult();
                if (product == null)
                {
                    MessageBox.Show("Бараа олдсонгүй.", "Алдаа", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Бараа засах форм нээх
                using (var editProductForm = new AddProductForm(Program.ServiceProvider!, product))
                {
                    var result = editProductForm.ShowDialog();
                    
                    // Хэрэв амжилттай хадгалагдсан бол жагсаалтыг шинэчилнэ
                    if (result == DialogResult.OK)
                    {
                        // Одоогийн сонгосон ангиллын ID-г авах
                        int categoryId = 0;
                        if (cboCategories.SelectedIndex > 0 && cboCategories.SelectedItem is Category category)
                        {
                            categoryId = category.Id;
                        }
                        
                        // Бараануудыг дахин ачаалах
                        _ = LoadProductsAsync(categoryId);
                        MessageBox.Show("Бараа амжилттай засагдлаа.", "Амжилттай", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Алдаа гарлаа: {ex.Message}", "Алдаа", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Устгах бараагаа сонгоно уу.", "Анхааруулга", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = (int)dgvProducts.SelectedRows[0].Cells["Id"].Value;
            string productName = dgvProducts.SelectedRows[0].Cells["Name"].Value.ToString();

            var result = MessageBox.Show($"Та '{productName}' бараа устгахдаа итгэлтэй байна уу?", 
                "Устгах", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = await _productService.DeleteProductAsync(productId);
                    if (success)
                    {
                        MessageBox.Show("Бараа амжилттай устгагдлаа.", "Амжилттай", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Refresh the product list
                        int categoryId = 0;
                        if (cboCategories.SelectedIndex > 0)
                        {
                            var category = cboCategories.SelectedItem as Category;
                            if (category != null)
                            {
                                categoryId = category.Id;
                            }
                        }
                        
                        _ = LoadProductsAsync(categoryId);
                    }
                    else
                    {
                        MessageBox.Show("Бараа устгахад алдаа гарлаа.", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Алдаа гарлаа: {ex.Message}", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
} 