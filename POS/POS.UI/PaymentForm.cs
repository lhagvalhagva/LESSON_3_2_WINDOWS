using System;
using System.Drawing;
using System.Windows.Forms;

namespace POS.UI
{
    public partial class PaymentForm : Form
    {
        private decimal _totalAmount;
        
        public decimal AmountTendered { get; private set; }
        public decimal Change { get; private set; }

        public PaymentForm(decimal totalAmount)
        {
            InitializeComponent();
            _totalAmount = totalAmount;
            lblTotalAmount.Text = totalAmount.ToString("N0");
        }

        private void InitializeComponent()
        {
            this.lblTotalCaption = new Label();
            this.lblTotalAmount = new Label();
            this.lblAmountTendered = new Label();
            this.txtAmountTendered = new TextBox();
            this.lblChangeCaption = new Label();
            this.lblChange = new Label();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.btnCancel = new Button();
            this.btnComplete = new Button();
            this.btnExactAmount = new Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotalCaption
            // 
            this.lblTotalCaption.AutoSize = true;
            this.lblTotalCaption.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblTotalCaption.Location = new Point(23, 21);
            this.lblTotalCaption.Name = "lblTotalCaption";
            this.lblTotalCaption.Size = new Size(158, 28);
            this.lblTotalCaption.TabIndex = 0;
            this.lblTotalCaption.Text = "Нийт дүн (₮):";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTotalAmount.Location = new Point(187, 21);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new Size(249, 38);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "0";
            this.lblTotalAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAmountTendered
            // 
            this.lblAmountTendered.AutoSize = true;
            this.lblAmountTendered.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblAmountTendered.Location = new Point(23, 81);
            this.lblAmountTendered.Name = "lblAmountTendered";
            this.lblAmountTendered.Size = new Size(152, 28);
            this.lblAmountTendered.TabIndex = 2;
            this.lblAmountTendered.Text = "Төлсөн дүн (₮):";
            // 
            // txtAmountTendered
            // 
            this.txtAmountTendered.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            this.txtAmountTendered.Location = new Point(187, 74);
            this.txtAmountTendered.Name = "txtAmountTendered";
            this.txtAmountTendered.Size = new Size(249, 43);
            this.txtAmountTendered.TabIndex = 3;
            this.txtAmountTendered.TextAlign = HorizontalAlignment.Right;
            this.txtAmountTendered.TextChanged += new EventHandler(this.txtAmountTendered_TextChanged);
            this.txtAmountTendered.KeyPress += new KeyPressEventHandler(this.txtAmountTendered_KeyPress);
            // 
            // lblChangeCaption
            // 
            this.lblChangeCaption.AutoSize = true;
            this.lblChangeCaption.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblChangeCaption.Location = new Point(23, 140);
            this.lblChangeCaption.Name = "lblChangeCaption";
            this.lblChangeCaption.Size = new Size(127, 28);
            this.lblChangeCaption.TabIndex = 4;
            this.lblChangeCaption.Text = "Хариулт (₮):";
            // 
            // lblChange
            // 
            this.lblChange.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblChange.ForeColor = Color.Green;
            this.lblChange.Location = new Point(187, 140);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new Size(249, 38);
            this.lblChange.TabIndex = 5;
            this.lblChange.Text = "0";
            this.lblChange.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnComplete, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExactAmount, 1, 0);
            this.tableLayoutPanel1.Dock = DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new Point(0, 198);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new Size(462, 60);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = Color.IndianRed;
            this.btnCancel.Dock = DockStyle.Fill;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(148, 54);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Цуцлах";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = Color.ForestGreen;
            this.btnComplete.Dock = DockStyle.Fill;
            this.btnComplete.FlatStyle = FlatStyle.Flat;
            this.btnComplete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnComplete.ForeColor = Color.White;
            this.btnComplete.Location = new Point(311, 3);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new Size(148, 54);
            this.btnComplete.TabIndex = 1;
            this.btnComplete.Text = "Төлбөр хийх";
            this.btnComplete.UseVisualStyleBackColor = false;
            this.btnComplete.Click += new EventHandler(this.btnComplete_Click);
            // 
            // btnExactAmount
            // 
            this.btnExactAmount.BackColor = Color.DodgerBlue;
            this.btnExactAmount.Dock = DockStyle.Fill;
            this.btnExactAmount.FlatStyle = FlatStyle.Flat;
            this.btnExactAmount.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnExactAmount.ForeColor = Color.White;
            this.btnExactAmount.Location = new Point(157, 3);
            this.btnExactAmount.Name = "btnExactAmount";
            this.btnExactAmount.Size = new Size(148, 54);
            this.btnExactAmount.TabIndex = 2;
            this.btnExactAmount.Text = "Яг дүн";
            this.btnExactAmount.UseVisualStyleBackColor = false;
            this.btnExactAmount.Click += new EventHandler(this.btnExactAmount_Click);
            // 
            // PaymentForm
            // 
            this.AcceptButton = this.btnComplete;
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new Size(462, 258);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.lblChangeCaption);
            this.Controls.Add(this.txtAmountTendered);
            this.Controls.Add(this.lblAmountTendered);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblTotalCaption);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Төлбөр";
            this.Load += new EventHandler(this.PaymentForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblTotalCaption;
        private Label lblTotalAmount;
        private Label lblAmountTendered;
        private TextBox txtAmountTendered;
        private Label lblChangeCaption;
        private Label lblChange;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnCancel;
        private Button btnComplete;
        private Button btnExactAmount;

        private void txtAmountTendered_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void CalculateChange()
        {
            if (decimal.TryParse(txtAmountTendered.Text, out decimal amountTendered))
            {
                Change = amountTendered - _totalAmount;
                lblChange.Text = Change.ToString("N0");
                btnComplete.Enabled = amountTendered >= _totalAmount;
            }
            else
            {
                lblChange.Text = "0";
                btnComplete.Enabled = false;
            }
        }

        private void btnExactAmount_Click(object sender, EventArgs e)
        {
            txtAmountTendered.Text = _totalAmount.ToString();
            CalculateChange();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAmountTendered.Text, out decimal amountTendered))
            {
                if (amountTendered < _totalAmount)
                {
                    MessageBox.Show("Төлсөн дүн хангалтгүй байна.", "Анхааруулга", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AmountTendered = amountTendered;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Төлсөн дүнг зөв оруулна уу.", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            txtAmountTendered.Focus();
        }

        private void txtAmountTendered_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, control characters, and decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
} 