using System.Diagnostics;

namespace n2l4
{
    public partial class Form1 : Form
    {
        private int _processCount = 0;
        private int _closedProcessCount = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void StartProcesses(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Process process = new Process();
                process.StartInfo.FileName = "notepad.exe";
                process.EnableRaisingEvents = true;
                process.Exited += Process_Exited;
                process.Start();
                _processCount++;
            }
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            _closedProcessCount++;
            MessageBox.Show($"Блокнот {_closedProcessCount} закрыт");
            if (_closedProcessCount == _processCount)
            {
                MessageBox.Show("Все процессы Блокнота закрыты");
                _closedProcessCount = 0;
                _processCount = 0;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartProcesses(5); // Запускаем 5 процессов Блокнота
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int n))
            {
                StartProcesses(n);
            }
            else
            {
                MessageBox.Show("Введите корректное число");
            }
        }
    }
}