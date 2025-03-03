using System;
using System.Windows.Forms;
using CalculatorLibrary.Memory;

namespace CalculatorUi
{
    /// <summary>
    /// Тооны машины үндсэн форм
    /// Энгийн тооны машины үйлдлүүд болон санах ойн үйлдлүүдийг агуулна
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Тооны машины үндсэн класс
        /// </summary>
        private Calculator calculator;

        /// <summary>
        /// Одоо оруулж буй тоо
        /// </summary>
        private string currentNumber = "";

        /// <summary>
        /// Эхний оруулсан тоо
        /// </summary>
        private int? firstNumber = null;

        /// <summary>
        /// Одоогийн сонгосон үйлдэл (+, -)
        /// </summary>
        private string currentOperation = "";

        /// <summary>
        /// Форм үүсгэх үед анхны утгуудыг оноох
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            calculator = new Calculator();
            UpdateDisplay("0");
            ShowAllHistory();
        }

        /// <summary>
        /// Тооны товчлуур дарагдах үед дуудагдах event handler
        /// </summary>
        /// <param name="sender">Дарагдсан товчлуур</param>
        /// <param name="e">Event аргумент</param>
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (currentNumber == "0") currentNumber = "";
            currentNumber += button.Text;
            UpdateDisplay(currentNumber);
        }

        /// <summary>
        /// Үйлдлийн товчлуур дарагдах үед дуудагдах event handler
        /// </summary>
        /// <param name="sender">Дарагдсан товчлуур</param>
        /// <param name="e">Event аргумент</param>
        private void OperationButton_Click(object sender, EventArgs e)
        {
            if (currentNumber != "")
            {
                Button button = (Button)sender;
                firstNumber = int.Parse(currentNumber);
                currentOperation = button.Text;
                currentNumber = "";
                
                try
                {
                    var allMemory = calculator.memory.GetAll();
                    if (allMemory.Count > 0)
                    {
                        memoryDisplayTextBox.Text = calculator.memory.GetLast().ToString();
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// Тэнцүү товчлуур дарагдах үед дуудагдах event handler
        /// Сонгосон үйлдлийг гүйцэтгэж үр дүнг харуулна
        /// </summary>
        /// <param name="sender">Дарагдсан товчлуур</param>
        /// <param name="e">Event аргумент</param>
        private void EqualsButton_Click(object sender, EventArgs e)
        {
            if (firstNumber != null && currentNumber != "")
            {
                try
                {
                    int secondNumber = int.Parse(currentNumber);
                    int result = 0;
                    

                    switch (currentOperation)
                    {
                        case "+":
                            result = calculator.Add((int)firstNumber, secondNumber);
                            break;
                        case "-":
                            result = calculator.Subtract((int)firstNumber, secondNumber);
                            break;
                    }

                    UpdateDisplay(result.ToString());
                    
                    var allMemory = calculator.memory.GetAll();
                    if (allMemory.Count > 0)
                    {
                        memoryDisplayTextBox.Text = calculator.memory.GetLast().ToString();
                    }
                    ShowAllHistory();
                    
                    firstNumber = null;
                    currentNumber = result.ToString();
                    currentOperation = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Тооцоолол хийх үед алдаа гарлаа: " + ex.Message);
                    ClearButton_Click(null, null);
                }
            }
        }

        /// <summary>
        /// Цэвэрлэх товчлуур дарагдах үед дуудагдах event handler
        /// Бүх утгуудыг анхны төлөвт оруулна
        /// </summary>
        /// <param name="sender">Дарагдсан товчлуур</param>
        /// <param name="e">Event аргумент</param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            currentNumber = "0";
            firstNumber = null;
            currentOperation = "";
            UpdateDisplay("0");
        }

        /// <summary>
        /// Санах ойг цэвэрлэх товчлуур дарагдах үед дуудагдах event handler
        /// </summary>
        /// <param name="sender">Дарагдсан товчлуур</param>
        /// <param name="e">Event аргумент</param>
        private void MemoryClearButton_Click(object sender, EventArgs e)
        {
            calculator.memory.Clear();
            ShowAllHistory();
        }

        /// <summary>
        /// Үндсэн дэлгэцийн утгыг шинэчлэх
        /// </summary>
        /// <param name="value">Харуулах утга</param>
        private void UpdateDisplay(string value)
        {
            displayTextBox.Text = value;
        }

        /// <summary>
        /// Санах ойн түүхийг шинэчлэх
        /// </summary>
        private void ShowAllHistory()
        {
            var allHistory = calculator.memory.GetAll();
            historyListBox.Items.Clear();
            
            foreach (var item in allHistory)
            {
                historyListBox.Items.Add($"Result: {item.Value}");
            }
        }
    }
}
