namespace EasyMath_v1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e) {
            this.Height = 400;
            this.Width = 660;
            this.BackColor = Color.LightGoldenrodYellow;
            this.Text = "EasyCalc";
            this.KeyPreview = true;

            int a = 0;
            int b = 0;
            List<string> memory = new List<string>(); //A collection to gather all results during program session
            string exportFile = "memory.txt"; //EasyMath\bin\Debug\net6.0-windows\memory.txt

            TextBox calcTxtBx = new TextBox();
            calcTxtBx.Text = "Enter number \"a\": ";
            calcTxtBx.Focus();
            calcTxtBx.Select(0, 0);
            calcTxtBx.ScrollToCaret();
            calcTxtBx.Multiline = true;
            calcTxtBx.Font = new Font("Arial", 15);
            calcTxtBx.ForeColor = Color.Gray;
            calcTxtBx.Height = 190;
            calcTxtBx.Width = 620;
            calcTxtBx.Location = new Point(10, 10);
            calcTxtBx.BackColor = Color.White;
            calcTxtBx.AutoSize = false;
            this.Controls.Add(calcTxtBx);

            ComboBox formulaCB = new ComboBox();            
            formulaCB.Text = "Choose formula here";
            formulaCB.Font = new Font("Arial", 10);
            formulaCB.Width = 250;
            formulaCB.Location = new Point(10, 220);
            formulaCB.Items.Add("Square of sum: (a+b)\u00B2");
            formulaCB.Items.Add("Square of difference: (a-b)\u00B2");
            formulaCB.Items.Add("Sum of squares: a\u00B2+b\u00B2");
            formulaCB.Items.Add("Difference of squares: a\u00B2-b\u00B2");
            formulaCB.Items.Add("Cube of sum: (a+b)\u00B3");
            formulaCB.Items.Add("Cube of difference: (a-b)\u00B3");
            formulaCB.Items.Add("Sum of cubes: a\u00B3 + b\u00B3");
            formulaCB.Items.Add("Difference of cubes: a\u00B3 - b\u00B3");
            this.Controls.Add(formulaCB);

            Label fLabel = new Label();
            fLabel.Text = "Ready to go";
            fLabel.Font = new Font("Arial", 12);
            fLabel.Height = 40;
            fLabel.Width = 300;
            fLabel.Location = new Point(260, 220);
            fLabel.ForeColor = Color.DarkBlue;
            this.Controls.Add(fLabel);

            Button enterButton = new Button();
            enterButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            enterButton.Text = "Enter";
            enterButton.Height = 70;
            enterButton.Width = 200;
            enterButton.AutoSize = false;
            enterButton.Font = new Font("Arial", 12);
            enterButton.Location = new Point(10, 265);
            enterButton.ForeColor = Color.DarkBlue;
            enterButton.MouseMove += entBut_MouseMove;
            enterButton.MouseLeave += entBut_MouseLeave;
            enterButton.Click += enterButton_Click;
            this.Controls.Add(enterButton);
            this.AcceptButton = enterButton;
            this.KeyDown += UserInput;

            Button exportButton = new Button();
            exportButton.Text = "Export";
            exportButton.Height = 70;
            exportButton.Width = 200;
            exportButton.AutoSize = false;
            exportButton.Font = new Font("Arial", 12);
            exportButton.Location = new Point(220, 265);
            exportButton.ForeColor = Color.DarkBlue;
            exportButton.MouseMove += expBut_MouseMove;
            exportButton.MouseLeave += expBut_MouseLeave;
            this.Controls.Add(exportButton);
            exportButton.Click += exportButton_Click;

            Button clearButton = new Button();
            clearButton.Text = "Clear";
            clearButton.Height = 70;
            clearButton.Width = 200;
            clearButton.AutoSize = false;
            clearButton.Font = new Font("Arial", 12);
            clearButton.Location = new Point(430, 265);
            clearButton.ForeColor = Color.DarkBlue;
            clearButton.MouseMove += clrBut_MouseMove;
            clearButton.MouseLeave += clrBut_MouseLeave;
            this.Controls.Add(clearButton);
            clearButton.Click += clearButton_Click;

            void clearButton_Click(object? sender, EventArgs e){ //Clears all fields
                calcTxtBx.Text = "";
                fLabel.Text = "Select formula"; //This one returns to default message
                a = 0;
                b = 0;
                calcTxtBx.Focus();
            }

            int SqrSum(int a, int b) { //Here is the arithmetic
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
                int result = (a + b) * (a - b);
                return result;
            }
            int CubeSum(int a, int b) {
                int result = a*a*a + b*b*b + 3*a*b*(a + b);
                return result;
            }
            int CubeDiff(int a, int b) {
                int result = a * a * a - b * b * b - 3 * a * b * (a - b);
                return result;
            }
            int SumCubes(int a, int b) {
                int result = (a + b) * (a * a - a * b + b * b);
                return result;
            }
            int DiffCubes(int a, int b) {
                int result = (a - b) * (a * a + a * b + b * b);
                return result;
            }
            void UserInput(object? sender, KeyEventArgs e) { //Whole method acts like an interface feature
                if (e.KeyData == Keys.Enter) { //This doesn't work, unfortunately - dunno why
                    enterButton.PerformClick(); //It was to make an enter button to control the local Enter button
                    e.Handled = true; //It seems like it demands another hierarchy of elements to work
                } else {
                    int textBoxParse; 
                    int.TryParse(calcTxtBx.Text, out textBoxParse); //This works perfectly 
                    if (textBoxParse == 0){ //Once user enters any digit besides zero
                        calcTxtBx.Text = ""; //Clears the TextBox
                    }
                }
            }
            void entBut_MouseMove(object? sender, EventArgs e) { //Enables mouse hover reaction - color change
                enterButton.BackColor = Color.CornflowerBlue;
                enterButton.ForeColor = Color.White;
            }
            void entBut_MouseLeave(object? sender, EventArgs e) { //This returns button color back to default
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
            void enterButton_Click(object? sender, EventArgs e) { //The primary logic is here
                if (a == 0 && b == 0) {
                    int.TryParse(calcTxtBx.Text, out a);
                    fLabel.Text = ($"Number \"a\" is: {a}");
                    if (a != 0 && b == 0) {
                        calcTxtBx.Text = "Enter number \"b\": ";
                        calcTxtBx.Focus();
                        calcTxtBx.Select(0, 0);
                    }
                }
                else if (a != 0 && b == 0) {
                    int.TryParse(calcTxtBx.Text, out b);
                    fLabel.Text = ($"Number \"b\" is: {b}");
                    if (a != 0 && b != 0) {
                        calcTxtBx.Text = "Select formula";
                        formulaCB.Focus();
                        calcTxtBx.Select(0, 0);
                    }
                }
                else if (a != 0 && b != 0) { //It demands both variables not to be zero
                    switch (formulaCB.SelectedIndex) {
                        case 0:
                            calcTxtBx.Text = $"( {a} + {b} )\u00B2 = {a}\u00B2 + 2*{a}*{b} + {b}\u00B2 = {SqrSum(a, b).ToString()}";
                            fLabel.Text = "( a + b )\u00B2 = a\u00B2 + 2ab + b\u00B2";
                            memory.Add(calcTxtBx.Text);
                            break;
                        case 1:
                            calcTxtBx.Text = $"( {a} - {b} )\u00B2 = {a}\u00B2 - 2*{a}*{b} + {b}\u00B2 = {SqrDiff(a, b).ToString()}";
                            fLabel.Text = "( a - b )\u00B2 = a\u00B2 - 2ab + b\u00B2";
                            memory.Add(calcTxtBx.Text);
                            break;
                        case 2:
                            calcTxtBx.Text = $"{a}\u00B2 + {b}\u00B2 = ( {a} + {b} )\u00B2 - 2 * {a} * {b} = {SumSqr(a, b).ToString()}";
                            fLabel.Text = "a\u00B2+b\u00B2 = ( a + b )\u00B2 - 2ab";
                            memory.Add(calcTxtBx.Text);
                            break;
                        case 3:
                            calcTxtBx.Text = $"{a}\u00B2 - {b}\u00B2 = ( {a} + {b} ) * ( {a} - {b} ) = {DiffSqr(a, b).ToString()}";
                            fLabel.Text = "a\u00B2 - b\u00B2 = ( a + b ) * ( a - b )";
                            memory.Add(calcTxtBx.Text);
                            break;
                        case 4:
                            calcTxtBx.Text = $"( {a} + {b} )\u00B3 = {a}\u00B3 + {b}\u00B3 + 3 * {a} * {b} * ( {a} + {b} ) = {CubeSum(a, b).ToString()}";
                            fLabel.Text = "( a + b )\u00B3 = a\u00B3 + b\u00B3 + 3ab( a + b )";
                            memory.Add(calcTxtBx.Text);
                            break;
                        case 5:
                            calcTxtBx.Text = $"( {a} - {b} )\u00B3 = {a}\u00B3 - {b}\u00B3 - 3 * {a} * {b} * ( {a} - {b} ) = {CubeDiff(a, b).ToString()}";
                            fLabel.Text = "( a - b )\u00B3 = a\u00B3 - b\u00B3 - 3ab( a - b )";
                            memory.Add(calcTxtBx.Text);
                            break;
                        case 6:
                            calcTxtBx.Text = $"{a}\u00B3 + {b}\u00B3 = ( {a} + {b} ) * ( {a}\u00B2 - {a} * {b} + {b}\u00B2) = {SumCubes(a,b).ToString()}";
                            fLabel.Text = "a\u00B3 + b\u00B3 = ( a + b )( a\u00B2 - ab + b\u00B2 )";
                            break;
                        case 7:
                            calcTxtBx.Text = $"{a}\u00B3 - {b}\u00B3 = ( {a} - {b} ) * ( {a}\u00B2 + {a} * {b} + {b}\u00B2) = {DiffCubes(a,b).ToString()}";
                            fLabel.Text = "a\u00B3 - b\u00B3 = ( a - b )( a\u00B2 + ab + b\u00B2 )";
                            break;
                        default:
                            calcTxtBx.Text = "Please select formula first";
                            break;
                    }
                }
            }
            async void exportButton_Click(object? sender, EventArgs e) {
                using (StreamWriter sWriter = new StreamWriter(exportFile, true)) {
                    foreach (string line in memory) //Iterates over a collection of recent results
                        sWriter.WriteLine(line); //And writes them into file
                    calcTxtBx.Text = "Export successful";
                }
            }
        }
    }
}