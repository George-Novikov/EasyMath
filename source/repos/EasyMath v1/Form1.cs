namespace EasyMath_v1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.Height = 500;
            this.Width = 700;
            this.BackColor = Color.LightGoldenrodYellow;
            this.Text = "EasyCalc";

            int a = 0;
            int b = 0;
            List<string> memory = new List<string>();

            CalcTextBox calcTxtBx = new CalcTextBox();
            calcTxtBx.Focus();
            calcTxtBx.Text = "Enter number \"a\": ";
            calcTxtBx.Select(0, 0);
            calcTxtBx.KeyDown += UserInput;
            calcTxtBx.Font = new Font("Arial", 16);
            calcTxtBx.ForeColor = Color.Gray;
            calcTxtBx.Height = 190;
            calcTxtBx.Width = 660;
            calcTxtBx.Location = new Point(10, 10);
            calcTxtBx.BackColor = Color.White;
            calcTxtBx.AutoSize = false;
            this.Controls.Add(calcTxtBx);

            FormulaCB formulaCB = new FormulaCB();            
            formulaCB.Text = "Choose formula here";
            formulaCB.Font = new Font("Arial", 10);
            formulaCB.Height = 120;
            formulaCB.Width = 250;
            formulaCB.Location = new Point(10, 220);
            //formulaCB.AutoSize = false;
            formulaCB.Items.Add("Square of sum: (a+b)\u00B2");
            formulaCB.Items.Add("Square of difference: (a-b)\u00B2");
            formulaCB.Items.Add("Sum of squares: a\u00B2+b\u00B2");
            formulaCB.Items.Add("Difference of squares: a\u00B2-b\u00B2");
            
            this.Controls.Add(formulaCB);

            FormulaLabel fLabel = new FormulaLabel();
            fLabel.Text = "Ready to go";
            fLabel.Font = new Font("Arial", 12);
            fLabel.Height = 70;
            fLabel.Width = 300;
            fLabel.Location = new Point(260, 220);
            fLabel.ForeColor = Color.DarkBlue;
            this.Controls.Add(fLabel);

            MyButton enterButton = new MyButton();
            enterButton.Text = "Enter";
            enterButton.Height = 70;
            enterButton.Width = 200;
            enterButton.AutoSize = false;
            enterButton.Font = new Font("Arial", 12);
            enterButton.Location = new Point(10, 320);
            enterButton.ForeColor = Color.DarkBlue;
            enterButton.MouseMove += entBut_MouseMove;
            enterButton.MouseLeave += entBut_MouseLeave;
            this.Controls.Add(enterButton);
            enterButton.Click += enterButton_Click;

            void enterButton_Click(object? sender, EventArgs e) {
                try {
                    if (a == 0 && b == 0) {
                        int.TryParse(calcTxtBx.Text, out a);
                        fLabel.Text = ($"Number \"a\" is: {a}");
                        calcTxtBx.Text = "Enter number \"b\": ";
                        calcTxtBx.Focus();
                        calcTxtBx.Select(0, 0);
                    } else if (a != 0 && b == 0) {
                        int.TryParse(calcTxtBx.Text, out b);
                        fLabel.Text = ($"Number \"b\" is: {b}");
                        calcTxtBx.Text = "Select formula";
                        formulaCB.Focus();
                        calcTxtBx.Select(0, 0);
                    } else if (a != 0 && b != 0) {
                        try {
                            switch (formulaCB.SelectedIndex) {
                                case 0:
                                    calcTxtBx.Text = $"({a}+{b})\u00B2 = {a}\u00B2 + 2*{a}*{b} + {b}\u00B2 = {SqrSum(a, b).ToString()}";
                                    fLabel.Text = "(a+b)\u00B2 = a\u00B2 + 2ab + b\u00B2";
                                    memory.Add(calcTxtBx.Text);
                                    break;
                                case 1:
                                    calcTxtBx.Text = $"({a}-{b})\u00B2 = {a}\u00B2 - 2*{a}*{b} + {b}\u00B2 = {SqrSum(a, b).ToString()}";
                                    fLabel.Text = "(a-b)\u00B2 = a\u00B2 - 2ab + b\u00B2";
                                    memory.Add(calcTxtBx.Text);
                                    break;
                                default:
                                    calcTxtBx.Text = "Please select formula first";
                                    break;
                            }
                        }
                        catch (Exception ex) {
                            calcTxtBx.Text = "Select formula first";
                        }
                    }
                }
                catch (Exception ex) {
                    calcTxtBx.Text = ex.Message;
                }
            }

            MyButton exportButton = new MyButton();
            exportButton.Text = "Export";
            exportButton.Height = 70;
            exportButton.Width = 200;
            exportButton.AutoSize = false;
            exportButton.Font = new Font("Arial", 12);
            exportButton.Location = new Point(220, 320);
            exportButton.ForeColor = Color.DarkBlue;
            exportButton.MouseMove += expBut_MouseMove;
            exportButton.MouseLeave += expBut_MouseLeave;
            this.Controls.Add(exportButton);

            MyButton clearButton = new MyButton();
            clearButton.Text = "Clear";
            clearButton.Height = 70;
            clearButton.Width = 200;
            clearButton.AutoSize = false;
            clearButton.Font = new Font("Arial", 12);
            clearButton.Location = new Point(430, 320);
            clearButton.ForeColor = Color.DarkBlue;
            clearButton.MouseMove += clrBut_MouseMove;
            clearButton.MouseLeave += clrBut_MouseLeave;
            this.Controls.Add(clearButton);
            clearButton.Click += clearButton_Click;

            void clearButton_Click(object? sender, EventArgs e){
                calcTxtBx.Text = "";
                fLabel.Text = "Select formula";
                a = 0;
                b = 0;
                calcTxtBx.Focus();
            }

            int SqrSum(int a, int b) {
                int result = a * a + 2 * a * b + b * b;
                return result;
            }
            int SqrDiff(int a, int b) {
                int result = a * a - 2 * a * b + b * b;
                return result;
            }
            int SumSqr(int a, int b) {
                int result = (a + b) * (a + b) - 2 * a * b;
                return result;
            }
            int DiffSqr(int a, int b) {
                int result = (a - b) * (a * a + a * b + b * b);
                return result;
            }
            void UserInput(object? sender, EventArgs e) {
                calcTxtBx.Text = "";
            }
            void entBut_MouseMove(object? sender, EventArgs e) {
                enterButton.BackColor = Color.CornflowerBlue;
                enterButton.ForeColor = Color.White;
            }
            void entBut_MouseLeave(object? sender, EventArgs e) {
                enterButton.BackColor = Color.LightGoldenrodYellow;
                enterButton.ForeColor = Color.DarkBlue;
            }
            void expBut_MouseMove(object? sender, EventArgs e) {
                exportButton.BackColor = Color.CornflowerBlue;
                exportButton.ForeColor = Color.White;
            }
            void expBut_MouseLeave(object? sender, EventArgs e)  {
                exportButton.BackColor = Color.LightGoldenrodYellow;
                exportButton.ForeColor = Color.DarkBlue;
            }
            void clrBut_MouseMove(object? sender, EventArgs e) {
                clearButton.BackColor = Color.CornflowerBlue;
                clearButton.ForeColor = Color.White;
            }
            void clrBut_MouseLeave(object? sender, EventArgs e) {
                clearButton.BackColor = Color.LightGoldenrodYellow;
                clearButton.ForeColor = Color.DarkBlue;
            }
            void entBut_EnterKey(object? sender, EventArgs e)
            {
                
            }
        }
    }
    delegate void Button_Click(object sender, EventArgs e);
    
    public class CalcTextBox : TextBox {
        private Color _borderstyle = Color.DarkSlateGray;
        public Color borderColor {
            get { return _borderstyle; }
            set { _borderstyle = value; }
        }
    }
    public class MyButton : Button  {
        
        
    }
    public class FormulaCB : ComboBox
    {
        enum Formulas
        {
            SquareOfSum,
            SquareOfDiff,
            SumOfSquares,
            DiffOfSquares
        }
    private void textBox_Changed()
        {

        }
    }
    public class FormulaLabel : Label
    {
        
    }
}