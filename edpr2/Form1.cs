using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using NCalc;
using NCalcExpr = NCalc.Expression;


namespace edpr2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void n1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Text += "1";
            }
        }

        private void n2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "2";
            }
            else
            {
                textBox1.Text += "2";
            }
        }

        private void n3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "3";
            }
            else
            {
                textBox1.Text += "3";
            }
        }

        private void n4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "4";
            }
            else
            {
                textBox1.Text += "4";
            }
        }

        private void n5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "5";
            }
            else
            {
                textBox1.Text += "5";
            }
        }

        private void n6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "6";
            }
            else
            {
                textBox1.Text += "6";
            }
        }

        private void n7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "7";
            }
            else
            {
                textBox1.Text += "7";
            }
        }

        private void n8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "8";
            }
            else
            {
                textBox1.Text += "8";
            }
        }

        private void n9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "9";
            }
            else
            {
                textBox1.Text += "9";
            }
        }

        private void n0_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "0")
            {
                textBox1.Text = "0";
            }
            else
            {
                textBox1.Text += "0";
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != "0")
            {
                textBox1.Text = "0";
            }
        }

        private void n_dot_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text += ".";
            }
            else
            {
                textBox1.Text = textBox1.Text;
            }
        }

        private string currentValue = "";
        private string operationValue = "";

        private void nPlus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                currentValue = textBox1.Text;
                textBox1.Text = "0";
                operationValue = "+";
            }
        }

        private void nUmn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                currentValue = textBox1.Text;
                textBox1.Text = "0";
                operationValue = "*";
            }
        }

        private void nMinus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                currentValue = textBox1.Text;
                textBox1.Text = "0";
                operationValue = "-";
            }
        }

        private void nDelen_CLick(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                currentValue = textBox1.Text;
                textBox1.Text = "0";
                operationValue = "/";
            }
        }

        private void nRavno_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && currentValue != "")
            {
                try
                {
                    decimal result = 0;
                    switch (operationValue)
                    {
                        case "+":
                            result = decimal.Parse(currentValue) + decimal.Parse(textBox1.Text);
                            break;
                        case "-":
                            result = decimal.Parse(currentValue) - decimal.Parse(textBox1.Text);
                            break;
                        case "*":
                            result = decimal.Parse(currentValue) * decimal.Parse(textBox1.Text);
                            break;
                        case "/":
                            result = decimal.Parse(currentValue) / decimal.Parse(textBox1.Text);
                            break;
                    }
                    textBox1.Text = result.ToString("F10");
                    currentValue = "";
                    operationValue = "";
                }
                catch (Exception ex)
                {
                    textBox1.Text = "Ошибка: " + ex.Message;
                }
            }
        }

        private decimal EvaluateExpression(string expression)
        {
            // парсим выражение
            string[] parts = expression.Split('+');
            if (parts.Length > 1)
            {
                decimal sum = 0;
                foreach (string part in parts)
                {
                    sum += EvaluatePart(part);
                }
                return sum;
            }
            else
            {
                return EvaluatePart(expression);
            }
        }

        private decimal EvaluatePart(string part)
        {
            // парсим часть выражения
            string[] parts = part.Split('/');
            if (parts.Length > 1)
            {
                decimal result = decimal.Parse(parts[0]);
                for (int i = 1; i < parts.Length; i++)
                {
                    result /= decimal.Parse(parts[i]);
                }
                return result;
            }
            else
            {
                parts = part.Split('*');
                if (parts.Length > 1)
                {
                    decimal result = decimal.Parse(parts[0]);
                    for (int i = 1; i < parts.Length; i++)
                    {
                        result *= decimal.Parse(parts[i]);
                    }
                    return result;
                }
                else
                {
                    return decimal.Parse(part);
                }
            }
        }

        private double Logarithm(double value)
        {
            return Math.Log(value);
        }

        private double Exponent(double value)
        {
            return Math.Exp(value);
        }

        private void log_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                try
                {
                    double value = Convert.ToDouble(textBox1.Text);
                    double result = Logarithm(value);
                    textBox1.Text = string.Format("{0:F10}", result);
                }
                catch (Exception ex)
                {
                    textBox1.Text = "Ошибка: " + ex.Message;
                }
            }
        }

        private void exp_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                try
                {
                    double value = Convert.ToDouble(textBox1.Text);
                    double result = Exponent(value);
                    textBox1.Text = string.Format("{0:F10}", result);
                }
                catch (Exception ex)
                {
                    textBox1.Text = "Ошибка: " + ex.Message;
                }
            }
        }

        private void sin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                double value = Double.Parse(textBox1.Text);
                double angleInRadians = DegreesToRadians(value);
                double result = Math.Sin(angleInRadians);
                textBox1.Text = result.ToString("F10");
            }
        }

        private void cos_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                double value = Double.Parse(textBox1.Text);
                double angleInRadians = DegreesToRadians(value);
                double result = Math.Cos(angleInRadians);
                textBox1.Text = result.ToString("F10");
            }
        }

        private void tan_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                double value = Double.Parse(textBox1.Text);
                double angleInRadians = DegreesToRadians(value);
                double result = Math.Tan(angleInRadians);
                textBox1.Text = result.ToString("F10");
            }
        }

        private void asin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                double value = Double.Parse(textBox1.Text);
                if (value < -1 || value > 1)
                {
                    textBox1.Text = "Ошибка: значение вне диапазона";
                }
                else
                {
                    double result = Math.Asin(value);
                    double angleInDegrees = RadiansToDegrees(result);
                    textBox1.Text = angleInDegrees.ToString("F10");
                }
            }
        }

        private void acos_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                double value = Double.Parse(textBox1.Text);
                if (value < -1 || value > 1)
                {
                    textBox1.Text = "Ошибка: значение вне диапазона";
                }
                else
                {
                    double result = Math.Acos(value);
                    double angleInDegrees = RadiansToDegrees(result);
                    textBox1.Text = angleInDegrees.ToString("F10");
                }
            }
        }

        private void atan_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                double value = Double.Parse(textBox1.Text);
                double result = Math.Atan(value);
                double angleInDegrees = RadiansToDegrees(result);
                textBox1.Text = angleInDegrees.ToString("F10");
            }
        }

        private double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        private double RadiansToDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }
    }
}