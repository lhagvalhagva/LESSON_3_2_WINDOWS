using POS.Core.Models;
using System;
using System.Windows.Forms;

namespace POS.UI
{
    public partial class UsersForm : Form
    {
        public UsersForm()
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
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "UsersForm";
            this.Text = "Хэрэглэгчийн жагсаалт";
            this.ResumeLayout(false);
        }
    }
} 