using POS.Core.Models;
using System;
using System.Windows.Forms;

namespace POS.UI
{
    public partial class SalesForm : Form
    {
        public SalesForm()
        {
            InitializeComponent();
        }
        
        public void SetCurrentUser(User user)
        {
            // Хэрэглэгчийн мэдээллийг хадгалах
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "SalesForm";
            this.Text = "Борлуулалтын жагсаалт";
            this.ResumeLayout(false);
        }
    }
} 