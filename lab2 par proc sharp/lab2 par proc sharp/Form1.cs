namespace lab2_par_proc_sharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out int num1);
            int.TryParse(textBox2.Text, out int num2);                
            for (int i = 1; i <= num1; i++)
            {
                Form form = new Form();
                form.Text = "Form " + i.ToString();
                Label label = new Label();
                form.Controls.Add(label);
                form.Show();
                                
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 2000;
                int count = 1;
                timer.Tick += (sender, eventArgs) =>
                {
                    label.Text = count++.ToString();
                    if (count > num2)
                    {
                        timer.Stop();
                       // form.Close();
                    }
                };
                timer.Start();
            }
        }
    }
}