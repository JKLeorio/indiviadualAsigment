namespace RPNCalculator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtRPN;
        private System.Windows.Forms.Button btnAddVariable;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.FlowLayoutPanel panelVariables;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageCalc;
        private System.Windows.Forms.TabPage tabPageConvert;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtRPNResult;
        private System.Windows.Forms.TextBox txtInfix;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageCalc = new System.Windows.Forms.TabPage();
            this.tabPageConvert = new System.Windows.Forms.TabPage();

            this.txtRPN = new System.Windows.Forms.TextBox();
            this.btnAddVariable = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.panelVariables = new System.Windows.Forms.FlowLayoutPanel();
            this.txtResult = new System.Windows.Forms.TextBox();

            this.txtInfix = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtRPNResult = new System.Windows.Forms.TextBox();

            this.tabControl.SuspendLayout();
            this.tabPageCalc.SuspendLayout();
            this.tabPageConvert.SuspendLayout();
            this.SuspendLayout();

            
            this.tabControl.Controls.Add(this.tabPageCalc);
            this.tabControl.Controls.Add(this.tabPageConvert);
            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Size = new System.Drawing.Size(620, 450);

            
            this.txtRPN.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRPN.Location = new System.Drawing.Point(20, 20);
            this.txtRPN.Size = new System.Drawing.Size(500, 29);
            this.txtRPN.PlaceholderText = "Введите RPN выражение";

            this.btnAddVariable.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAddVariable.Location = new System.Drawing.Point(20, 60);
            this.btnAddVariable.Size = new System.Drawing.Size(250, 40);
            this.btnAddVariable.Text = "Добавить переменную";
            this.btnAddVariable.Click += new System.EventHandler(this.btnAddVariable_Click);

            this.panelVariables.Location = new System.Drawing.Point(20, 110);
            this.panelVariables.Size = new System.Drawing.Size(550, 200);
            this.panelVariables.AutoScroll = true;
            this.panelVariables.FlowDirection = FlowDirection.TopDown;
            this.panelVariables.WrapContents = false;

            this.btnCalculate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCalculate.Location = new System.Drawing.Point(20, 320);
            this.btnCalculate.Size = new System.Drawing.Size(200, 40);
            this.btnCalculate.Text = "Вычислить";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);

            this.txtResult.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtResult.Location = new System.Drawing.Point(20, 370);
            this.txtResult.Size = new System.Drawing.Size(500, 29);
            this.txtResult.ReadOnly = true;
            this.txtResult.PlaceholderText = "Результат";

            this.tabPageCalc.Controls.Add(this.txtRPN);
            this.tabPageCalc.Controls.Add(this.btnAddVariable);
            this.tabPageCalc.Controls.Add(this.panelVariables);
            this.tabPageCalc.Controls.Add(this.btnCalculate);
            this.tabPageCalc.Controls.Add(this.txtResult);
            this.tabPageCalc.Text = "Вычисление ОПЗ";
            this.tabPageCalc.UseVisualStyleBackColor = true;

            
            this.txtInfix.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtInfix.Location = new System.Drawing.Point(20, 30);
            this.txtInfix.Size = new System.Drawing.Size(500, 29);
            this.txtInfix.PlaceholderText = "Введите инфиксное выражение";

            this.btnConvert.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnConvert.Location = new System.Drawing.Point(20, 70);
            this.btnConvert.Size = new System.Drawing.Size(200, 40);
            this.btnConvert.Text = "Преобразовать";
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);

            this.txtRPNResult.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRPNResult.Location = new System.Drawing.Point(20, 120);
            this.txtRPNResult.Size = new System.Drawing.Size(500, 29);
            this.txtRPNResult.ReadOnly = true;
            this.txtRPNResult.PlaceholderText = "ОПЗ результат";

            this.tabPageConvert.Controls.Add(this.txtInfix);
            this.tabPageConvert.Controls.Add(this.btnConvert);
            this.tabPageConvert.Controls.Add(this.txtRPNResult);
            this.tabPageConvert.Text = "Инфикс → ОПЗ";
            this.tabPageConvert.UseVisualStyleBackColor = true;

            
            this.ClientSize = new System.Drawing.Size(640, 470);
            this.Controls.Add(this.tabControl);
            this.Text = "RPN Калькулятор";
            this.tabControl.ResumeLayout(false);
            this.tabPageCalc.ResumeLayout(false);
            this.tabPageCalc.PerformLayout();
            this.tabPageConvert.ResumeLayout(false);
            this.tabPageConvert.PerformLayout();
            this.ResumeLayout(false);
        }

    }
}
