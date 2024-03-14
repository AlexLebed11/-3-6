using System.Threading.Tasks.Dataflow;

namespace l_3_p3
{
    public partial class Form1 : Form
    {
        List<Thread> threads = new List<Thread>();
        int N;

        static object lockOn = new Object();

        public Form1()
        {
            InitializeComponent();
        }

        public void RunT(object formObj)
        {

            Form form = (Form)formObj;
            Label label = new Label();
            form.Controls.Add(label);
            form.Show();


            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            int count = 1;
            timer.Tick += (s, ev) =>
            {
                label.Text = $"иру {count++.ToString()}";
                if (count > 10)
                {
                    timer.Stop();
                    form.Close();
                }
            };
            timer.Start();

            Application.Run(form);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            N = int.Parse(textBox1.Text);
            for (int i = 0; i < N; i++)
            {
                Form form = new Form();
                Thread thread = new Thread(new ParameterizedThreadStart(RunT!));
                thread.Start(form);
                threads.Add(thread);
            }
        }
    }
}
