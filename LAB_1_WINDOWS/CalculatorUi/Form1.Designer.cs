using System;

namespace CalculatorUi
{
    /// <summary>
    /// Тооны машины форм дизайн
    /// </summary>
    partial class Form1
    {
        /// <summary>
        /// Designer-т шаардлагатай хувьсагч
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Ашиглаж байгаа нөөцүүдийг чөлөөлөх
        /// </summary>
        /// <param name="disposing">Үнэн бол удирдсан нөөцүүдийг устгах</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Designer-т шаардлагатай метод - энэ кодыг бүү өөрчил
        /// </summary>
        private void InitializeComponent()
        {
            this.displayTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSubtract = new System.Windows.Forms.Button();
            this.buttonEquals = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.memoryClearButton = new System.Windows.Forms.Button();
            this.historyListBox = new System.Windows.Forms.ListBox();
            this.memorySaveButton = new System.Windows.Forms.Button();
            this.memoryRecallButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.memoryDisplayTextBox = new System.Windows.Forms.TextBox();
            this.memoryPlusButton = new System.Windows.Forms.Button();
            this.memoryMinusButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // displayTextBox
            // 
            this.displayTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.displayTextBox.Location = new System.Drawing.Point(68, 113);
            this.displayTextBox.Name = "displayTextBox";
            this.displayTextBox.ReadOnly = true;
            this.displayTextBox.Size = new System.Drawing.Size(290, 56);
            this.displayTextBox.TabIndex = 0;
            this.displayTextBox.Text = "0";
            this.displayTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(68, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "1";
            this.button1.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(174, 333);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 50);
            this.button2.TabIndex = 2;
            this.button2.Text = "2";
            this.button2.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(280, 333);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 50);
            this.button3.TabIndex = 3;
            this.button3.Text = "3";
            this.button3.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(68, 277);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 50);
            this.button4.TabIndex = 4;
            this.button4.Text = "4";
            this.button4.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(174, 277);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 50);
            this.button5.TabIndex = 5;
            this.button5.Text = "5";
            this.button5.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(280, 277);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 50);
            this.button6.TabIndex = 6;
            this.button6.Text = "6";
            this.button6.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(68, 221);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 50);
            this.button7.TabIndex = 7;
            this.button7.Text = "7";
            this.button7.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(174, 221);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 50);
            this.button8.TabIndex = 8;
            this.button8.Text = "8";
            this.button8.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button9
            // 
            this.button9.CausesValidation = false;
            this.button9.Location = new System.Drawing.Point(280, 221);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(100, 50);
            this.button9.TabIndex = 9;
            this.button9.Text = "9";
            this.button9.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // button0
            // 
            this.button0.Location = new System.Drawing.Point(174, 389);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(100, 50);
            this.button0.TabIndex = 10;
            this.button0.Text = "0";
            this.button0.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(386, 221);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 50);
            this.buttonAdd.TabIndex = 11;
            this.buttonAdd.Text = "+";
            this.buttonAdd.Click += new System.EventHandler(this.OperationButton_Click);
            // 
            // buttonSubtract
            // 
            this.buttonSubtract.Location = new System.Drawing.Point(386, 277);
            this.buttonSubtract.Name = "buttonSubtract";
            this.buttonSubtract.Size = new System.Drawing.Size(100, 50);
            this.buttonSubtract.TabIndex = 12;
            this.buttonSubtract.Text = "-";
            this.buttonSubtract.Click += new System.EventHandler(this.OperationButton_Click);
            // 
            // buttonEquals
            // 
            this.buttonEquals.Location = new System.Drawing.Point(386, 333);
            this.buttonEquals.Name = "buttonEquals";
            this.buttonEquals.Size = new System.Drawing.Size(100, 106);
            this.buttonEquals.TabIndex = 13;
            this.buttonEquals.Text = "=";
            this.buttonEquals.Click += new System.EventHandler(this.EqualsButton_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(392, 158);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(100, 50);
            this.buttonClear.TabIndex = 14;
            this.buttonClear.Text = "C";
            this.buttonClear.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // memoryClearButton
            // 
            this.memoryClearButton.Location = new System.Drawing.Point(392, 107);
            this.memoryClearButton.Name = "memoryClearButton";
            this.memoryClearButton.Size = new System.Drawing.Size(100, 49);
            this.memoryClearButton.TabIndex = 17;
            this.memoryClearButton.Text = "MC";
            this.memoryClearButton.Click += new System.EventHandler(this.MemoryClearButton_Click);
            // 
            // historyListBox
            // 
            this.historyListBox.ItemHeight = 25;
            this.historyListBox.Location = new System.Drawing.Point(561, 113);
            this.historyListBox.Name = "historyListBox";
            this.historyListBox.Size = new System.Drawing.Size(209, 354);
            this.historyListBox.TabIndex = 18;
            // 
            // memorySaveButton
            // 
            this.memorySaveButton.Location = new System.Drawing.Point(0, 0);
            this.memorySaveButton.Name = "memorySaveButton";
            this.memorySaveButton.Size = new System.Drawing.Size(75, 23);
            this.memorySaveButton.TabIndex = 21;
            // 
            // memoryRecallButton
            // 
            this.memoryRecallButton.Location = new System.Drawing.Point(0, 0);
            this.memoryRecallButton.Name = "memoryRecallButton";
            this.memoryRecallButton.Size = new System.Drawing.Size(75, 23);
            this.memoryRecallButton.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 20;
            // 
            // memoryDisplayTextBox
            // 
            this.memoryDisplayTextBox.Location = new System.Drawing.Point(163, 171);
            this.memoryDisplayTextBox.Name = "memoryDisplayTextBox";
            this.memoryDisplayTextBox.ReadOnly = true;
            this.memoryDisplayTextBox.Size = new System.Drawing.Size(195, 31);
            this.memoryDisplayTextBox.TabIndex = 16;
            this.memoryDisplayTextBox.Text = "0";
            this.memoryDisplayTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // memoryPlusButton
            // 
            this.memoryPlusButton.Location = new System.Drawing.Point(540, 58);
            this.memoryPlusButton.Name = "memoryPlusButton";
            this.memoryPlusButton.Size = new System.Drawing.Size(100, 49);
            this.memoryPlusButton.TabIndex = 23;
            this.memoryPlusButton.Text = "M+";
            this.memoryPlusButton.Click += new System.EventHandler(this.MemoryPlusButton_Click);
            // 
            // memoryMinusButton
            // 
            this.memoryMinusButton.Location = new System.Drawing.Point(646, 56);
            this.memoryMinusButton.Name = "memoryMinusButton";
            this.memoryMinusButton.Size = new System.Drawing.Size(100, 49);
            this.memoryMinusButton.TabIndex = 24;
            this.memoryMinusButton.Text = "M-";
            this.memoryMinusButton.Click += new System.EventHandler(this.MemoryMinusButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 604);
            this.Controls.Add(this.historyListBox);
            this.Controls.Add(this.memoryClearButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonEquals);
            this.Controls.Add(this.buttonSubtract);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.displayTextBox);
            this.Controls.Add(this.memorySaveButton);
            this.Controls.Add(this.memoryRecallButton);
            this.Controls.Add(this.memoryDisplayTextBox);
            this.Controls.Add(this.memoryPlusButton);
            this.Controls.Add(this.memoryMinusButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// Үндсэн дэлгэц
        /// </summary>
        private System.Windows.Forms.TextBox displayTextBox;

        /// <summary>
        /// Тооны товчлуурууд (0-9)
        /// </summary>
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button0;

        /// <summary>
        /// Нэмэх үйлдлийн товчлуур
        /// </summary>
        private System.Windows.Forms.Button buttonAdd;

        /// <summary>
        /// Хасах үйлдлийн товчлуур
        /// </summary>
        private System.Windows.Forms.Button buttonSubtract;

        /// <summary>
        /// Тэнцүү товчлуур
        /// </summary>
        private System.Windows.Forms.Button buttonEquals;

        /// <summary>
        /// Цэвэрлэх товчлуур
        /// </summary>
        private System.Windows.Forms.Button buttonClear;

        /// <summary>
        /// Санах ойг цэвэрлэх товчлуур
        /// </summary>
        private System.Windows.Forms.Button memoryClearButton;

        /// <summary>
        /// Түүхийн жагсаалт
        /// </summary>
        private System.Windows.Forms.ListBox historyListBox;

        /// <summary>
        /// Санах ойд хадгалах товчлуур
        /// </summary>
        private System.Windows.Forms.Button memorySaveButton;

        /// <summary>
        /// Санах ойгоос дуудах товчлуур
        /// </summary>
        private System.Windows.Forms.Button memoryRecallButton;

        /// <summary>
        /// Memory текст
        /// </summary>
        private System.Windows.Forms.Label label1;

        /// <summary>
        /// Санах ойн дэлгэц
        /// </summary>
        private System.Windows.Forms.TextBox memoryDisplayTextBox;

        /// <summary>
        /// Санах ойд нэмэх товчлуур (M+)
        /// </summary>
        private System.Windows.Forms.Button memoryPlusButton;

        /// <summary>
        /// Санах ойгоос хасах товчлуур (M-)
        /// </summary>
        private System.Windows.Forms.Button memoryMinusButton;
    }
}


