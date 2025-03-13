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
                int number = int.Parse(currentNumber);
                
                if (currentOperation == "")
                {
                    calculator.result = number;
                }
                
                currentOperation = button.Text;
                currentNumber = "";
                
                memoryDisplayTextBox.Text = calculator.result.ToString();
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
            if (currentOperation != "")
            {
                try
                {
                    int secondNumber = 0;
                    if (currentNumber != "")
                    {
                        secondNumber = int.Parse(currentNumber);
                    }
                    else
                    {
                        secondNumber = calculator.result;
                    }

                    switch (currentOperation)
                    {
                        case "+":
                            calculator.Add(secondNumber);
                            break;
                        case "-":
                            calculator.Subtract(secondNumber);
                            break;
                    }

                    UpdateDisplay(calculator.result.ToString());
                    memoryDisplayTextBox.Text = calculator.result.ToString();
                    ShowAllHistory();

                    currentNumber = calculator.result.ToString();
                    currentOperation = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Тооцоолол хийх үед алдаа гарлаа: " + ex.Message);
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
            currentOperation = "";
            calculator.result = 0;
            calculator.memory.Clear();
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
        /// Санах ойд нэмэх товчлуур (M+) дарагдах үед дуудагдах event handler
        /// Одоогийн утгыг санах ойн сүүлийн утганд нэмнэ
        /// </summary>
        /// <param name="sender">Дарагдсан товчлуур</param>
        /// <param name="e">Event аргумент</param>
        private void MemoryPlusButton_Click(object sender, EventArgs e)
        {
            if (currentNumber != "")
            {
                try
                {
                    int currentValue = int.Parse(currentNumber);
                    var allMemory = calculator.memory.AllMemoryItems;
                    
                    if (allMemory.Count > 0)
                    {
                        calculator.Add(currentValue);
                    }
                    else
                    {
                        calculator.Add(currentValue);
                    }

                    memoryDisplayTextBox.Text = calculator.result.ToString();
                    ShowAllHistory();
                    
                    currentNumber = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("M+ үйлдэл хийх үед алдаа гарлаа: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Санах ойгоос хасах товчлуур (M-) дарагдах үед дуудагдах event handler
        /// Одоогийн утгыг санах ойн сүүлийн утгаас хасна
        /// </summary>
        /// <param name="sender">Дарагдсан товчлуур</param>
        /// <param name="e">Event аргумент</param>
        private void MemoryMinusButton_Click(object sender, EventArgs e)
        {
            if (currentNumber != "")
            {
                try
                {
                    int currentValue = int.Parse(currentNumber);
                    var allMemory = calculator.memory.AllMemoryItems;
                    
                    if (allMemory.Count > 0)
                    {
                        calculator.Subtract(currentValue);
                    }
                    else
                    {
                        calculator.Add(-currentValue);
                    }

                    memoryDisplayTextBox.Text = calculator.result.ToString();
                    ShowAllHistory();
                    
                    currentNumber = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("M- үйлдэл хийх үед алдаа гарлаа: " + ex.Message);
                }
            }
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
            var allHistory = calculator.memory.AllMemoryItems;
            historyListBox.Items.Clear();
            
            foreach (var item in allHistory)
            {
                historyListBox.Items.Add($"Result: {item.Value}");
            }
        }

    }
}
