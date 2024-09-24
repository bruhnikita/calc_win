using System;
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

        private void AppendNumber(string number)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = number;
            }
            else
            {
                textBox1.Text += number;
            }
        }

        private void n1_Click(object sender, EventArgs e) => AppendNumber("1");
        private void n2_Click(object sender, EventArgs e) => AppendNumber("2");
        private void n3_Click(object sender, EventArgs e) => AppendNumber("3");
        private void n4_Click(object sender, EventArgs e) => AppendNumber("4");
        private void n5_Click(object sender, EventArgs e) => AppendNumber("5");
        private void n6_Click(object sender, EventArgs e) => AppendNumber("6");
        private void n7_Click(object sender, EventArgs e) => AppendNumber("7");
        private void n8_Click(object sender, EventArgs e) => AppendNumber("8");
        private void n9_Click(object sender, EventArgs e) => AppendNumber("9");
        private void n0_Click(object sender, EventArgs e) => AppendNumber("0");

        private void nLeftSk_Click(object sender, EventArgs e) => AppendBracket("(");
        private void nRightSk_Click(object sender, EventArgs e) => AppendBracket(")");

        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void n_dot_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("."))
            {
                textBox1.Text += ".";
            }
        }

        private void AppendOperation(string operation)
        {
            if (textBox1.Text.Length > 0 && "+-*/".IndexOf(textBox1.Text[^1]) == -1 && textBox1.Text[^1] != '(')
            {
                textBox1.Text += operation;
            }
        }

        private void AppendBracket(string bracket)
        {
            if (bracket == "(")
            {
                if (textBox1.Text.Length == 0 || "+-*/(".Contains(textBox1.Text[^1]))
                {
                    textBox1.Text += bracket;
                }
            }
            else if (bracket == ")")
            {
                int openBrackets = textBox1.Text.Split('(').Length - 1;
                int closeBrackets = textBox1.Text.Split(')').Length - 1;

                if (openBrackets > closeBrackets && "+-*/".IndexOf(textBox1.Text[^1]) == -1)
                {
                    textBox1.Text += bracket;
                }
            }
        }

        private void nPlus_Click(object sender, EventArgs e) => AppendOperation("+");
        private void nMinus_Click(object sender, EventArgs e) => AppendOperation("-");
        private void nUmn_Click(object sender, EventArgs e) => AppendOperation("*");
        private void nDelen_CLick(object sender, EventArgs e) => AppendOperation("/");

        private void AppendFunction(string functionName)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = $"{functionName}(";
            }
            else if ("+-*/(".Contains(textBox1.Text[^1]))
            {
                textBox1.Text += $"{functionName}(";
            }
        }

        private void sin_Click(object sender, EventArgs e) => AppendFunction("sin");
        private void cos_Click(object sender, EventArgs e) => AppendFunction("cos");
        private void tan_Click(object sender, EventArgs e) => AppendFunction("tan");
        private void log_Click(object sender, EventArgs e) => AppendFunction("Log(10,"); 
        private void exp_Click(object sender, EventArgs e) => AppendFunction("Exp(");
        private void asin_Click(object sender, EventArgs e) => AppendFunction("asin");
        private void acos_Click(object sender, EventArgs e) => AppendFunction("acos");
        private void atan_Click(object sender, EventArgs e) => AppendFunction("atan");

        private void nRavno_Click(object sender, EventArgs e)
        {
            try
            {
                int openBrackets = textBox1.Text.Split('(').Length - 1;
                int closeBrackets = textBox1.Text.Split(')').Length - 1;
                for (int i = 0; i < openBrackets - closeBrackets; i++)
                {
                    textBox1.Text += ")";
                }

                NCalcExpr ncalcExpression = new NCalcExpr(textBox1.Text);
                var result = ncalcExpression.Evaluate();
                textBox1.Text = Convert.ToDecimal(result).ToString("F10");
            }
            catch (Exception ex)
            {
                textBox1.Text = "Îøèáêà: " + ex.Message;
            }
        }

        
    }
}
