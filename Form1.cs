namespace RPNCalculator;

using System;
using System.Collections.Generic;
using System.Windows.Forms;


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string InfixToRPN(string input)
        {
            Dictionary<string, int> precedence = new Dictionary<string, int>
            {
                { "+", 1 },
                { "-", 1 },
                { "*", 2 },
                { "/", 2 },
                { "(", 0 }
            };

            Stack<string> stack = new Stack<string>();
            List<string> output = new List<string>();

            string[] tokens = Tokenize(input);

            foreach (string token in tokens)
            {
                if (double.TryParse(token, out _) || char.IsLetter(token[0]))
                {
                    output.Add(token);
                }
                else if (token == "(")
                {
                    stack.Push(token);
                }
                else if (token == ")")
                {
                    while (stack.Count > 0 && stack.Peek() != "(")
                    {
                        output.Add(stack.Pop());
                    }
                    stack.Pop();
                }
                else
                {
                    while (stack.Count > 0 && precedence[stack.Peek()] >= precedence[token])
                    {
                        output.Add(stack.Pop());
                    }
                    stack.Push(token);
                }
            }

            while (stack.Count > 0)
            {
                output.Add(stack.Pop());
            }

            return string.Join(" ", output);
        }

        private string[] Tokenize(string input)
        {
            List<string> tokens = new List<string>();
            string number = "";

            foreach (char c in input)
            {
                if (char.IsWhiteSpace(c)) continue;

                if (char.IsDigit(c) || c == '.')
                {
                    number += c;
                }
                else
                {
                    if (number.Length > 0)
                    {
                        tokens.Add(number);
                        number = "";
                    }

                    if ("+-*/()".Contains(c))
                    {
                        tokens.Add(c.ToString());
                    }
                    else if (char.IsLetter(c))
                    {
                        tokens.Add(c.ToString());
                    }
                    else
                    {
                        throw new Exception($"Недопустимый символ: {c}");
                    }
                }
            }

            if (number.Length > 0)
                tokens.Add(number);

            return tokens.ToArray();
        }

        private void btnAddVariable_Click(object sender, EventArgs e)
        {
            var panel = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                Margin = new Padding(5)
            };

            var lblVar = new Label() { Text = "Var:", Width = 40, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            var txtSymbol = new TextBox() { Width = 40, Font = new Font("Segoe UI", 11F) };
            var lblVal = new Label() { Text = "Value:", Width = 50, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            var txtValue = new TextBox() { Width = 80, Font = new Font("Segoe UI", 11F) };

            var btnRemove = new Button()
            {
                Text = "Удалить",
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                Margin = new Padding(10, 0, 0, 0)
            };

            btnRemove.Click += (s, ev) =>
            {
                panelVariables.Controls.Remove(panel);
                panel.Dispose();
            };

            panel.Controls.Add(lblVar);
            panel.Controls.Add(txtSymbol);
            panel.Controls.Add(lblVal);
            panel.Controls.Add(txtValue);
            panel.Controls.Add(btnRemove);

            panelVariables.Controls.Add(panel);
        }

        private void btnConvert_Click(object sender, EventArgs e)
            {
                try
                {
                    string infix = txtInfix.Text;
                    string rpn = InfixToRPN(infix);
                    txtRPNResult.Text = rpn;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка преобразования: " + ex.Message);
                }
            }


        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                
                Dictionary<string, double> variables = new Dictionary<string, double>();
                foreach (Control ctrl in panelVariables.Controls)
                {
                    if (ctrl is FlowLayoutPanel flp && flp.Controls.Count >= 4)
                    {
                        string key = ((TextBox)flp.Controls[1]).Text.Trim();
                        string valStr = ((TextBox)flp.Controls[3]).Text.Trim();
                        if (double.TryParse(valStr, out double value) && key.Length == 1)
                        {
                            variables[key] = value;
                        }
                        else
                        {
                            MessageBox.Show("Некорректное значение переменной.");
                            return;
                        }
                    }
                }

                string expression = txtRPN.Text;
                double result = EvaluateRPN(expression, variables);
                txtResult.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private double EvaluateRPN(string expr, Dictionary<string, double> vars)
        {
            Stack<double> stack = new Stack<double>();
            var tokens = expr.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out double number))
                {
                    stack.Push(number);
                }
                else if (token.Length == 1 && vars.ContainsKey(token))
                {
                    stack.Push(vars[token]);
                }
                else if (token == "+" || token == "-" || token == "*" || token == "/")
                {
                    if (stack.Count < 2)
                        throw new Exception("Недостаточно операндов для операции " + token);

                    double b = stack.Pop();
                    double a = stack.Pop();

                    switch (token)
                    {
                        case "+": stack.Push(a + b); break;
                        case "-": stack.Push(a - b); break;
                        case "*": stack.Push(a * b); break;
                        case "/": stack.Push(a / b); break;
                    }
                }
                else
                {
                    throw new Exception("Неизвестный токен: " + token);
                }
            }

            if (stack.Count != 1)
                throw new Exception("Ошибка в выражении. Осталось несколько элементов в стеке.");

            return stack.Pop();
        }
}

