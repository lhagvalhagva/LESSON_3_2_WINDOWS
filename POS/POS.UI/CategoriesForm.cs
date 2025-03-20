using POS.Core.Models;
using POS.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace POS.UI
{
    public partial class CategoriesForm : Form
    {
        private readonly ICategoryService _categoryService;

        public CategoriesForm(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.dgvCategories = new DataGridView();
            this.pnlBottom = new Panel();
            this.btnDelete = new Button();
            this.btnEdit = new Button();
            this.btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.Location = new Point(12, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(230, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ангиллын жагсаалт";
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.BackgroundColor = Color.White;
            this.dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Location = new Point(12, 69);
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersWidth = 51;
            this.dgvCategories.RowTemplate.Height = 29;
            this.dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new Size(758, 334);
            this.dgvCategories.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = Color.WhiteSmoke;
            this.pnlBottom.Controls.Add(this.btnDelete);
            this.pnlBottom.Controls.Add(this.btnEdit);
            this.pnlBottom.Controls.Add(this.btnAdd);
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Location = new Point(0, 409);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new Size(782, 50);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnDelete.BackColor = Color.Crimson;
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Location = new Point(659, 8);
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
            this.btnEdit.Location = new Point(542, 8);
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
            this.btnAdd.Location = new Point(425, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(111, 35);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Нэмэх";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            // 
            // CategoriesForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(782, 459);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.dgvCategories);
            this.Controls.Add(this.lblTitle);
            this.MinimumSize = new Size(800, 500);
            this.Name = "CategoriesForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Ангиллын жагсаалт";
            this.Load += new EventHandler(this.CategoriesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblTitle;
        private DataGridView dgvCategories;
        private Panel pnlBottom;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;

        private async void CategoriesForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Setup grid
                SetupCategoryGrid();
                
                // Load categories
                await LoadCategoriesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Алдаа гарлаа: {ex.Message}", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupCategoryGrid()
        {
            dgvCategories.Columns.Clear();
            
            // Add columns
            dgvCategories.Columns.Add("Id", "ID");
            dgvCategories.Columns.Add("Name", "Ангиллын нэр");
            dgvCategories.Columns.Add("Description", "Тайлбар");
            dgvCategories.Columns.Add("ProductCount", "Барааны тоо");
            
            // Configure columns
            dgvCategories.Columns["Id"].Visible = false;
            dgvCategories.Columns["Name"].Width = 200;
            dgvCategories.Columns["Description"].Width = 350;
            dgvCategories.Columns["ProductCount"].Width = 100;
            
            // Set alignment
            dgvCategories.Columns["ProductCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private async System.Threading.Tasks.Task LoadCategoriesAsync()
        {
            try
            {
                dgvCategories.Rows.Clear();
                
                var categories = await _categoryService.GetAllCategoriesAsync();
                
                foreach (var category in categories)
                {
                    // Get the full category details including products
                    var fullCategory = await _categoryService.GetCategoryByIdAsync(category.Id);
                    
                    int productCount = fullCategory.Products.Count;
                    
                    dgvCategories.Rows.Add(
                        category.Id,
                        category.Name,
                        category.Description,
                        productCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ангилал ачаалахад алдаа гарлаа: {ex.Message}", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Шинэ ангилал нэмэх форм нээх
                using (var addCategoryForm = new AddCategoryForm(Program.ServiceProvider!))
                {
                    var result = addCategoryForm.ShowDialog();
                    
                    // Хэрэв амжилттай хадгалагдсан бол жагсаалтыг шинэчилнэ
                    if (result == DialogResult.OK)
                    {
                        // Ангилалуудыг дахин ачаалах
                        _ = LoadCategoriesAsync();
                        MessageBox.Show("Ангилал амжилттай нэмэгдлээ.", "Амжилттай", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Сонгосон ангилалыг шалгах
                if (dgvCategories.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Засах ангилалаа сонгоно уу.", "Анхааруулга", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Сонгосон ангилалын ID-г авах
                int categoryId = (int)dgvCategories.SelectedRows[0].Cells["Id"].Value;

                // Ангилал мэдээллийг базаас татах
                var category = _categoryService.GetCategoryByIdAsync(categoryId).GetAwaiter().GetResult();
                if (category == null)
                {
                    MessageBox.Show("Ангилал олдсонгүй.", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ангилал засах форм нээх
                using (var editCategoryForm = new AddCategoryForm(Program.ServiceProvider!, category))
                {
                    var result = editCategoryForm.ShowDialog();
                    
                    // Хэрэв амжилттай хадгалагдсан бол жагсаалтыг шинэчилнэ
                    if (result == DialogResult.OK)
                    {
                        // Ангилалуудыг дахин ачаалах
                        _ = LoadCategoriesAsync();
                        MessageBox.Show("Ангилал амжилттай засагдлаа.", "Амжилттай", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Алдаа гарлаа: {ex.Message}", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count == 0)
            {
                MessageBox.Show("Устгах ангилалаа сонгоно уу.", "Анхааруулга", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int categoryId = (int)dgvCategories.SelectedRows[0].Cells["Id"].Value;
            string categoryName = dgvCategories.SelectedRows[0].Cells["Name"].Value.ToString();
            int productCount = Convert.ToInt32(dgvCategories.SelectedRows[0].Cells["ProductCount"].Value);

            if (productCount > 0)
            {
                MessageBox.Show($"'{categoryName}' ангилалд {productCount} бараа байгаа тул устгах боломжгүй.", 
                    "Анхааруулга", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Та '{categoryName}' ангилал устгахдаа итгэлтэй байна уу?", 
                "Устгах", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = await _categoryService.DeleteCategoryAsync(categoryId);
                    if (success)
                    {
                        MessageBox.Show("Ангилал амжилттай устгагдлаа.", "Амжилттай", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Refresh the categories list
                        await LoadCategoriesAsync();
                    }
                    else
                    {
                        MessageBox.Show("Ангилал устгахад алдаа гарлаа.", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
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