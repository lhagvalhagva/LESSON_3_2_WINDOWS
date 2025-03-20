using Microsoft.Extensions.DependencyInjection;
using POS.Core.Models;
using POS.Services;
using System;
using System.Windows.Forms;

namespace POS.UI
{
    public partial class AddCategoryForm : Form
    {
        private readonly ICategoryService _categoryService;
        private Category? _category;
        private bool _isEditMode = false;

        public AddCategoryForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            
            _categoryService = serviceProvider.GetRequiredService<ICategoryService>();
        }

        // Засах горимд ашиглах конструктор
        public AddCategoryForm(IServiceProvider serviceProvider, Category category) : this(serviceProvider)
        {
            _category = category;
            _isEditMode = true;
            Text = "Ангилал засах";
        }

        private void AddCategoryForm_Load(object sender, EventArgs e)
        {
            // Хэрэв засах горим бол ангилалын мэдээллийг харуулах
            if (_isEditMode && _category != null)
            {
                txtName.Text = _category.Name;
                txtDescription.Text = _category.Description;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Оролтыг шалгах
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Ангилалын нэр оруулна уу.", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                bool success;
                
                if (_isEditMode && _category != null)
                {
                    // Ангилалыг шинэчлэх
                    _category.Name = txtName.Text.Trim();
                    _category.Description = txtDescription.Text?.Trim();
                    
                    success = await _categoryService.UpdateCategoryAsync(_category);
                }
                else
                {
                    // Шинэ ангилал үүсгэх
                    var category = new Category
                    {
                        Name = txtName.Text.Trim(),
                        Description = txtDescription.Text?.Trim(),
                        IsActive = true
                    };
                    
                    success = await _categoryService.CreateCategoryAsync(category);
                }

                if (success)
                {
                    // Хаах
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Ангилал хадгалахад алдаа гарлаа.", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ангилал хадгалахад алдаа гарлаа: {ex.Message}", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(101, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Ангилалын нэр:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(123, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 27);
            this.txtName.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 54);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(74, 20);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Тайлбар:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(123, 51);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(250, 70);
            this.txtDescription.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(123, 136);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 29);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Хадгалах";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(253, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 29);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Цуцлах";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 183);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Шинэ ангилал нэмэх";
            this.Load += new System.EventHandler(this.AddCategoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
} 