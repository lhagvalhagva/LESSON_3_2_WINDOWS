using System;
using System.Windows.Forms;
using CalculatorLibrary.Memory;
using System.Collections.Generic;

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
        /// Сонгогдсон санах ойн элементийн индекс
        /// </summary>
        private int selectedMemoryIndex = -1;

        /// <summary>
        /// Форм үүсгэх үед анхны утгуудыг оноох
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            calculator = new Calculator();
            UpdateDisplay("0");
            ShowAllHistory();
            
            historyListBox.SelectedIndexChanged += HistoryListBox_SelectedIndexChanged;
        }

        /// <summary>
        /// Санах ойн элемент сонгох үед дуудагдах handler
        /// </summary>
        private void HistoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedMemoryIndex = historyListBox.SelectedIndex;
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
                    int nemegdehvvn = 0;
                    nemegdehvvn = currentNumber != "" ? int.Parse(currentNumber) : calculator.result;

                    switch (currentOperation)
                    {
                        case "+":
                            calculator.Add(nemegdehvvn);
                            break;
                        case "-":
                            calculator.Subtract(nemegdehvvn);
                            break;
                    }

                    UpdateDisplay(calculator.result.ToString());
                    memoryDisplayTextBox.Text = calculator.result.ToString();

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
            UpdateDisplay("0");
        }

        /// <summary>
        /// Санах ойд хадгалах товчлуур (MS) дарагдах үед дуудагдах event handler
        /// </summary>
        private void MemorySaveButton_Click(object sender, EventArgs e)
        {
            int valueToSave;
            
            if (currentNumber != "")
            {
                valueToSave = int.Parse(currentNumber);
            }
            else
            {
                valueToSave = calculator.result;
            }
            
            calculator.memory.Save(valueToSave);
            
            ShowAllHistory();
            
            selectedMemoryIndex = calculator.memory.AllMemoryItems.Count - 1;
            historyListBox.SelectedIndex = selectedMemoryIndex;
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
            selectedMemoryIndex = -1;
        }

        /// <summary>
        /// Санах ойд нэмэх товчлуур (M+) дарагдах үед дуудагдах event handler
        /// Одоогийн утгыг сонгосон санах ойн утганд нэмнэ
        /// </summary>
        private void MemoryPlusButton_Click(object sender, EventArgs e)
        {
            if (currentNumber != "")
            {
                try
                {
                    int currentValue = int.Parse(currentNumber);
                    var allMemory = calculator.memory.AllMemoryItems;
                    
                    if (selectedMemoryIndex >= 0 && selectedMemoryIndex < allMemory.Count)
                    {
                        
                        int selectedValue = allMemory[selectedMemoryIndex].Value;
            
                        int newValue = selectedValue + currentValue;
                        
                        UpdateSelectedMemoryItem(newValue);
                        
                    }   
                    else
                    {
                        MessageBox.Show("Та санах ойн элемент сонгоогүй байна!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("M+ үйлдэл хийх үед алдаа гарлаа: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Та эхлээд тоо оруулна уу!");
            }
        }

        /// <summary>
        /// Санах ойгоос хасах товчлуур (M-) дарагдах үед дуудагдах event handler
        /// Одоогийн утгыг сонгосон санах ойн утгаас хасна
        /// </summary>
        private void MemoryMinusButton_Click(object sender, EventArgs e)
        {
            if (currentNumber != "")
            {
                try
                {
                    int currentValue = int.Parse(currentNumber);
                    var allMemory = calculator.memory.AllMemoryItems;
                    
                    if (selectedMemoryIndex >= 0 && selectedMemoryIndex < allMemory.Count)
                    {
                        int selectedValue = allMemory[selectedMemoryIndex].Value;
                        
                        int newValue = selectedValue - currentValue;
                        
                        UpdateSelectedMemoryItem(newValue);
                        
                    }
                    else
                    {
                        MessageBox.Show("Та санах ойн элемент сонгоогүй байна!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("M- үйлдэл хийх үед алдаа гарлаа: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Та эхлээд тоо оруулна уу!");
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
            
            for (int i = 0; i < allHistory.Count; i++)
            {
                historyListBox.Items.Add($"[{i+1}] Value: {allHistory[i].Value}");
            }
            
            if (selectedMemoryIndex >= 0 && selectedMemoryIndex < historyListBox.Items.Count)
            {
                historyListBox.SelectedIndex = selectedMemoryIndex;
            }
        }
        
        /// <summary>
        /// Сонгогдсон санах ойн элементийг шинэчлэх
        /// </summary>
        /// <param name="newValue">Шинэ утга</param>
        private void UpdateSelectedMemoryItem(int newValue)
        {
            var allMemory = calculator.memory.AllMemoryItems;
            
            if (selectedMemoryIndex >= 0 && selectedMemoryIndex < allMemory.Count)
            {
                List<int> tempValues = new List<int>();
                for (int i = 0; i < allMemory.Count; i++)
                {
                    if (i == selectedMemoryIndex)
                    {
                        tempValues.Add(newValue);
                    }
                    else
                    {
                        tempValues.Add(allMemory[i].Value);
                    }
                }
                
                calculator.memory.Clear();
                
                foreach (int value in tempValues)
                {
                    calculator.memory.Save(value);
                }
                
                ShowAllHistory();
                
                if (selectedMemoryIndex < historyListBox.Items.Count)
                {
                    historyListBox.SelectedIndex = selectedMemoryIndex;
                }
            }
        }

    }
}
