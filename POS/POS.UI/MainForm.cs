using POS.Core.Models;
using POS.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace POS.UI
{
    public partial class MainForm : Form
    {
        private readonly IProductService _productService;
        private readonly ISaleService _saleService;
        private readonly IReceiptService _receiptService;
        private readonly ProductsForm _productsForm;
        private readonly CategoriesForm _categoriesForm;
        private readonly HelpForm _helpForm;

        private List<SaleItem> _cartItems = new List<SaleItem>();
        private decimal _totalAmount = 0;

        public User LoggedInUser { get; set; }

        public MainForm(
            IProductService productService,
            ISaleService saleService,
            IReceiptService receiptService,
            ProductsForm productsForm,
            CategoriesForm categoriesForm,
            HelpForm helpForm)
        {
            InitializeComponent();
            _productService = productService;
            _saleService = saleService;
            _receiptService = receiptService;
            _productsForm = productsForm;
            _categoriesForm = categoriesForm;
            _helpForm = helpForm;
        }

        private void InitializeComponent()
        {
            this.menuStrip = new MenuStrip();
            this.mnuProducts = new ToolStripMenuItem();
            this.mnuCategories = new ToolStripMenuItem();
            this.mnuHelp = new ToolStripMenuItem();
            this.statusStrip = new StatusStrip();
            this.lblStatus = new ToolStripStatusLabel();
            this.pnlTop = new Panel();
            this.txtProductCode = new TextBox();
            this.lblProductCode = new Label();
            this.pnlCenter = new Panel();
            this.dgvCart = new DataGridView();
            this.pnlBottom = new Panel();
            this.btnPay = new Button();
            this.lblTotal = new Label();
            this.lblTotalCaption = new Label();
            
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            
            // menuStrip
            this.menuStrip.ImageScalingSize = new Size(20, 20);
            this.menuStrip.Items.AddRange(new ToolStripItem[] {
                this.mnuProducts,
                this.mnuCategories,
                this.mnuHelp});
            this.menuStrip.Location = new Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new Size(982, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            
            // mnuProducts
            this.mnuProducts.Name = "mnuProducts";
            this.mnuProducts.Size = new Size(77, 24);
            this.mnuProducts.Text = "Бараа";
            this.mnuProducts.Click += new EventHandler(this.mnuProducts_Click);
            
            // mnuCategories
            this.mnuCategories.Name = "mnuCategories";
            this.mnuCategories.Size = new Size(87, 24);
            this.mnuCategories.Text = "Ангилал";
            this.mnuCategories.Click += new EventHandler(this.mnuCategories_Click);
            
            // mnuHelp
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new Size(92, 24);
            this.mnuHelp.Text = "Тусламж";
            this.mnuHelp.Click += new EventHandler(this.mnuHelp_Click);
            
            // statusStrip
            this.statusStrip.ImageScalingSize = new Size(20, 20);
            this.statusStrip.Items.AddRange(new ToolStripItem[] {
                this.lblStatus});
            this.statusStrip.Location = new Point(0, 626);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new Size(982, 26);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            
            // lblStatus
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(87, 20);
            this.lblStatus.Text = "Статус: Бэлэн";
            
            // pnlTop
            this.pnlTop.BackColor = Color.WhiteSmoke;
            this.pnlTop.Controls.Add(this.txtProductCode);
            this.pnlTop.Controls.Add(this.lblProductCode);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Location = new Point(0, 28);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new Size(982, 70);
            this.pnlTop.TabIndex = 2;
            
            // txtProductCode
            this.txtProductCode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtProductCode.Location = new Point(180, 18);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new Size(250, 34);
            this.txtProductCode.TabIndex = 1;
            this.txtProductCode.KeyPress += new KeyPressEventHandler(this.txtProductCode_KeyPress);
            
            // lblProductCode
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblProductCode.Location = new Point(12, 21);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new Size(162, 28);
            this.lblProductCode.TabIndex = 0;
            this.lblProductCode.Text = "Барааны код:";
            
            // pnlCenter
            this.pnlCenter.Controls.Add(this.dgvCart);
            this.pnlCenter.Dock = DockStyle.Fill;
            this.pnlCenter.Location = new Point(0, 98);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Padding = new Padding(10);
            this.pnlCenter.Size = new Size(982, 462);
            this.pnlCenter.TabIndex = 3;
            
            // dgvCart
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.BackgroundColor = Color.White;
            this.dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Dock = DockStyle.Fill;
            this.dgvCart.Location = new Point(10, 10);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersWidth = 51;
            this.dgvCart.RowTemplate.Height = 29;
            this.dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new Size(962, 442);
            this.dgvCart.TabIndex = 0;
            this.dgvCart.CellContentClick += new DataGridViewCellEventHandler(this.dgvCart_CellContentClick);
            
            // pnlBottom
            this.pnlBottom.BackColor = Color.WhiteSmoke;
            this.pnlBottom.Controls.Add(this.btnPay);
            this.pnlBottom.Controls.Add(this.lblTotal);
            this.pnlBottom.Controls.Add(this.lblTotalCaption);
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Location = new Point(0, 560);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new Size(982, 66);
            this.pnlBottom.TabIndex = 4;
            
            // btnPay
            this.btnPay.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnPay.BackColor = Color.ForestGreen;
            this.btnPay.FlatStyle = FlatStyle.Flat;
            this.btnPay.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnPay.ForeColor = Color.White;
            this.btnPay.Location = new Point(822, 11);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new Size(150, 45);
            this.btnPay.TabIndex = 2;
            this.btnPay.Text = "Төлбөр";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new EventHandler(this.btnPay_Click);
            
            // lblTotal
            this.lblTotal.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.lblTotal.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTotal.Location = new Point(566, 16);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new Size(250, 35);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = ContentAlignment.MiddleRight;
            
            // lblTotalCaption
            this.lblTotalCaption.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.lblTotalCaption.AutoSize = true;
            this.lblTotalCaption.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblTotalCaption.Location = new Point(476, 18);
            this.lblTotalCaption.Name = "lblTotalCaption";
            this.lblTotalCaption.Size = new Size(84, 28);
            this.lblTotalCaption.TabIndex = 0;
            this.lblTotalCaption.Text = "Нийт: ₮";
            
            // MainForm
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(982, 652);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new Size(1000, 700);
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ПОС СИСТЕМ";
            this.WindowState = FormWindowState.Maximized;
            this.Load += new EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MenuStrip menuStrip;
        private ToolStripMenuItem mnuProducts;
        private ToolStripMenuItem mnuCategories;
        private ToolStripMenuItem mnuHelp;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;
        private Panel pnlTop;
        private TextBox txtProductCode;
        private Label lblProductCode;
        private Panel pnlCenter;
        private DataGridView dgvCart;
        private Panel pnlBottom;
        private Button btnPay;
        private Label lblTotal;
        private Label lblTotalCaption;

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set form title with user info
            this.Text = $"ПОС СИСТЕМ - {LoggedInUser.Username} ({LoggedInUser.Role})";
            
            // Configure access based on user role
            if (LoggedInUser.Role == UserRole.Cashier)
            {
                mnuCategories.Visible = false;
            }

            // Configure cart DataGridView
            SetupCartDataGridView();
            UpdateTotalAmount();
        }

        private void SetupCartDataGridView()
        {
            // Clear existing columns
            dgvCart.Columns.Clear();

            // Create columns
            dgvCart.Columns.Add("ProductId", "ID");
            dgvCart.Columns.Add("ProductCode", "Код");
            dgvCart.Columns.Add("ProductName", "Барааны нэр");
            dgvCart.Columns.Add("UnitPrice", "Нэгж үнэ");
            dgvCart.Columns.Add("Quantity", "Тоо");
            dgvCart.Columns.Add("Subtotal", "Дүн");

            // Add buttons for quantity adjustment
            DataGridViewButtonColumn plusButtonColumn = new DataGridViewButtonColumn();
            plusButtonColumn.HeaderText = "";
            plusButtonColumn.Text = "+";
            plusButtonColumn.Name = "BtnPlus";
            plusButtonColumn.UseColumnTextForButtonValue = true;
            dgvCart.Columns.Add(plusButtonColumn);

            DataGridViewButtonColumn minusButtonColumn = new DataGridViewButtonColumn();
            minusButtonColumn.HeaderText = "";
            minusButtonColumn.Text = "-";
            minusButtonColumn.Name = "BtnMinus";
            minusButtonColumn.UseColumnTextForButtonValue = true;
            dgvCart.Columns.Add(minusButtonColumn);

            DataGridViewButtonColumn removeButtonColumn = new DataGridViewButtonColumn();
            removeButtonColumn.HeaderText = "";
            removeButtonColumn.Text = "X";
            removeButtonColumn.Name = "BtnRemove";
            removeButtonColumn.UseColumnTextForButtonValue = true;
            dgvCart.Columns.Add(removeButtonColumn);

            // Hide ProductId column
            dgvCart.Columns["ProductId"].Visible = false;

            // Set column properties
            dgvCart.Columns["ProductCode"].Width = 100;
            dgvCart.Columns["ProductName"].Width = 250;
            dgvCart.Columns["UnitPrice"].Width = 120;
            dgvCart.Columns["Quantity"].Width = 80;
            dgvCart.Columns["Subtotal"].Width = 120;
            dgvCart.Columns["BtnPlus"].Width = 50;
            dgvCart.Columns["BtnMinus"].Width = 50;
            dgvCart.Columns["BtnRemove"].Width = 50;

            // Set alignment
            dgvCart.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCart.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCart.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Format numeric columns
            dgvCart.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";
            dgvCart.Columns["Subtotal"].DefaultCellStyle.Format = "N0";
        }

        private async void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                string productCode = txtProductCode.Text.Trim();
                if (!string.IsNullOrEmpty(productCode))
                {
                    try
                    {
                        var product = await _productService.GetProductByCodeAsync(productCode);
                        if (product != null)
                        {
                            AddProductToCart(product);
                            txtProductCode.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Барааны код олдсонгүй.", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Алдаа гарлаа: {ex.Message}", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AddProductToCart(Product product)
        {
            // Check if product already exists in the cart
            var existingItem = _cartItems.FirstOrDefault(item => item.ProductId == product.Id);
            
            if (existingItem != null)
            {
                // Increment quantity
                existingItem.Quantity++;
                existingItem.Subtotal = existingItem.Quantity * existingItem.UnitPrice;
            }
            else
            {
                // Add new item
                var newItem = new SaleItem
                {
                    ProductId = product.Id,
                    Product = product,
                    Quantity = 1,
                    UnitPrice = product.Price,
                    Subtotal = product.Price
                };
                
                _cartItems.Add(newItem);
            }
            
            RefreshCartDataGridView();
            UpdateTotalAmount();
        }

        private void RefreshCartDataGridView()
        {
            dgvCart.Rows.Clear();
            
            foreach (var item in _cartItems)
            {
                int rowIndex = dgvCart.Rows.Add(
                    item.ProductId,
                    item.Product.Code,
                    item.Product.Name,
                    item.UnitPrice,
                    item.Quantity,
                    item.Subtotal);
                
                // Add some color to the row based on quantity
                if (item.Quantity > 5)
                {
                    dgvCart.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void UpdateTotalAmount()
        {
            _totalAmount = _cartItems.Sum(item => item.Subtotal);
            lblTotal.Text = _totalAmount.ToString("N0");
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvCart.Columns["BtnPlus"].Index)
            {
                // Increase quantity
                int productId = (int)dgvCart.Rows[e.RowIndex].Cells["ProductId"].Value;
                var item = _cartItems.FirstOrDefault(i => i.ProductId == productId);
                if (item != null)
                {
                    item.Quantity++;
                    item.Subtotal = item.Quantity * item.UnitPrice;
                    RefreshCartDataGridView();
                    UpdateTotalAmount();
                }
            }
            else if (e.ColumnIndex == dgvCart.Columns["BtnMinus"].Index)
            {
                // Decrease quantity
                int productId = (int)dgvCart.Rows[e.RowIndex].Cells["ProductId"].Value;
                var item = _cartItems.FirstOrDefault(i => i.ProductId == productId);
                if (item != null && item.Quantity > 1)
                {
                    item.Quantity--;
                    item.Subtotal = item.Quantity * item.UnitPrice;
                    RefreshCartDataGridView();
                    UpdateTotalAmount();
                }
            }
            else if (e.ColumnIndex == dgvCart.Columns["BtnRemove"].Index)
            {
                // Remove item
                int productId = (int)dgvCart.Rows[e.RowIndex].Cells["ProductId"].Value;
                var item = _cartItems.FirstOrDefault(i => i.ProductId == productId);
                if (item != null)
                {
                    _cartItems.Remove(item);
                    RefreshCartDataGridView();
                    UpdateTotalAmount();
                }
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (_cartItems.Count == 0)
            {
                MessageBox.Show("Сагс хоосон байна.", "Анхааруулга", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create a new PaymentForm
            using (var paymentForm = new PaymentForm(_totalAmount))
            {
                if (paymentForm.ShowDialog() == DialogResult.OK)
                {
                    decimal amountTendered = paymentForm.AmountTendered;
                    decimal change = paymentForm.Change;

                    // Create sale object
                    var sale = new Sale
                    {
                        SaleDate = DateTime.Now,
                        UserId = LoggedInUser.Id,
                        TotalAmount = _totalAmount,
                        AmountTendered = amountTendered,
                        Change = change,
                        SaleItems = _cartItems.ToList()
                    };

                    ProcessSale(sale);
                }
            }
        }

        private async void ProcessSale(Sale sale)
        {
            try
            {
                lblStatus.Text = "Статус: Боловсруулж байна...";
                bool success = await _saleService.CreateSaleAsync(sale);

                if (success)
                {
                    // Print receipt
                    bool printed = await _receiptService.PrintReceiptAsync(sale);
                    string receiptText = await _receiptService.GenerateReceiptAsync(sale);

                    // Show receipt in dialog
                    MessageBox.Show(receiptText, "Баримт", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear cart
                    _cartItems.Clear();
                    RefreshCartDataGridView();
                    UpdateTotalAmount();
                    lblStatus.Text = "Статус: Амжилттай";
                }
                else
                {
                    MessageBox.Show("Худалдааг боловсруулахад алдаа гарлаа.", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblStatus.Text = "Статус: Алдаа";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Алдаа гарлаа: {ex.Message}", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Статус: Алдаа";
            }
        }

        private void mnuProducts_Click(object sender, EventArgs e)
        {
            _productsForm.ShowDialog();
        }

        private void mnuCategories_Click(object sender, EventArgs e)
        {
            _categoriesForm.ShowDialog();
        }

        private void mnuHelp_Click(object sender, EventArgs e)
        {
            _helpForm.ShowDialog();
        }
    }
} 