using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private string expression = "";
        private string currentNumber = "";

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (!(currentNumber == "0" && button.Content.ToString() == "0") && !(currentNumber.Contains(".") && button.Content.ToString() == "."))
            {
                currentNumber += button.Content.ToString();
                ResultTextBox.Text = currentNumber;
            }
        }


        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            expression += currentNumber + button.Content.ToString();
            ExpressionTextBox.Text = expression;
            currentNumber = "";
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (!currentNumber.Contains("."))
            {
                currentNumber += ".";
                ResultTextBox.Text = currentNumber;
            }
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = "";
            ResultTextBox.Text = currentNumber;
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            expression = "";
            currentNumber = "";
            ExpressionTextBox.Text = expression;
            ResultTextBox.Text = currentNumber;
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber.Length > 0)
            {
                currentNumber = currentNumber.Remove(currentNumber.Length - 1);
                ResultTextBox.Text = currentNumber;
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            expression += currentNumber;
            ExpressionTextBox.Text = expression;

            try
            {
                var result = new DataTable().Compute(expression, null);
                ResultTextBox.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            expression = "";
            currentNumber = "";
        }
    }
}
