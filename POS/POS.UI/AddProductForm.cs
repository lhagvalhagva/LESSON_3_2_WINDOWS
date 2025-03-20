using Microsoft.Extensions.DependencyInjection;
using POS.Core.Models;
using POS.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace POS.UI
{
    public partial class AddProductForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private Product? _product; // Засах барааны обьект
        private bool _isEditMode = false; // Засах горим эсэх

        public AddProductForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            
            // Сервисүүдийг DI-ээс авах
            _productService = serviceProvider.GetRequiredService<IProductService>();
            _categoryService = serviceProvider.GetRequiredService<ICategoryService>();
        }

        // Засах горимд ашиглах конструктор
        public AddProductForm(IServiceProvider serviceProvider, Product product) : this(serviceProvider)
        {
            _product = product;
            _isEditMode = true;
            Text = "Бараа засах";
        }

        private async void AddProductForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Ангиллуудыг ачаалах
                var categories = await _categoryService.GetAllCategoriesAsync();
                
                if (categories == null || !categories.Any())
                {
                    MessageBox.Show("Ангилал олдсонгүй. Эхлээд ангилал үүсгэнэ үү.", 
                        "Анхааруулга", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                // ComboBox-д ангиллуудыг нэмэх
                cboCategory.DisplayMember = "Name";
                cboCategory.ValueMember = "Id";
                cboCategory.DataSource = categories;

                // Хэрэв засах горим бол бараа мэдээллийг харуулах
                if (_isEditMode && _product != null)
                {
                    txtName.Text = _product.Name;
                    txtBarCode.Text = _product.Code;
                    txtPrice.Text = _product.Price.ToString();
                    txtStock.Text = _product.StockQuantity.ToString();
                    
                    // Ангилал сонгох
                    for (int i = 0; i < cboCategory.Items.Count; i++)
                    {
                        var category = cboCategory.Items[i] as Category;
                        if (category != null && category.Id == _product.CategoryId)
                        {
                            cboCategory.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ангилал ачаалахад алдаа гарлаа: {ex.Message}", 
                    "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Оролтыг шалгах
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Барааны нэр оруулна уу.", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtBarCode.Text))
                {
                    MessageBox.Show("Баркод оруулна уу.", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBarCode.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPrice.Text) || !decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Зөв үнэ оруулна уу.", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrice.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtStock.Text) || !int.TryParse(txtStock.Text, out int stockQuantity))
                {
                    MessageBox.Show("Зөв үлдэгдэл оруулна уу.", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtStock.Focus();
                    return;
                }

                if (cboCategory.SelectedItem == null)
                {
                    MessageBox.Show("Ангилал сонгоно уу.", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCategory.Focus();
                    return;
                }

                bool success;
                
                if (_isEditMode && _product != null)
                {
                    // Барааг шинэчлэх
                    _product.Name = txtName.Text.Trim();
                    _product.Code = txtBarCode.Text.Trim();
                    _product.Price = price;
                    _product.StockQuantity = stockQuantity;
                    _product.CategoryId = ((Category)cboCategory.SelectedItem).Id;
                    
                    success = await _productService.UpdateProductAsync(_product);
                }
                else
                {
                    // Шинэ бараа үүсгэх
                    var product = new Product
                    {
                        Name = txtName.Text.Trim(),
                        Code = txtBarCode.Text.Trim(),
                        Price = price,
                        StockQuantity = stockQuantity,
                        CategoryId = ((Category)cboCategory.SelectedItem).Id
                    };
                    
                    success = await _productService.CreateProductAsync(product);
                }

                if (success)
                {
                    // Хаах
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Бараа хадгалахад алдаа гарлаа.", 
                        "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Бараа хадгалахад алдаа гарлаа: {ex.Message}", 
                    "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
} 