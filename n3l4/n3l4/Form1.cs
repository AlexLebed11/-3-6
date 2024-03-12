namespace n3l4
{
    public partial class Form1 : Form
    {
        private Thread mouseThread;
        private Thread circleThread;
        private Point mousePosition;
        private Point circlePosition;
        private const int circleRadius = 50;


        public Form1()
        {
            InitializeComponent();

            mouseThread = new Thread(TrackMouse);
            circleThread = new Thread(DrawCircle);

            mouseThread.Start();
            circleThread.Start();
        }
        private void TrackMouse()
        {
            while (true)
            {
                mousePosition = this.PointToClient(Cursor.Position);
                Thread.Sleep(10);
            }
        }

        private void DrawCircle()
        {
            while (true)
            {
                this.Invalidate();
                Thread.Sleep(10);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (circlePosition == null)
            {
                circlePosition = new Point(this.Width / 2, this.Height / 2);
            }

            if (Math.Sqrt(Math.Pow(mousePosition.X - circlePosition.X, 2) + Math.Pow(mousePosition.Y - circlePosition.Y, 2)) < circleRadius)
            {
                // Move the circle away from the mouse
                circlePosition.X += (circlePosition.X - mousePosition.X) / 2;
                circlePosition.Y += (circlePosition.Y - mousePosition.Y) / 2;
            }

            e.Graphics.FillEllipse(Brushes.Red, circlePosition.X - circleRadius, circlePosition.Y - circleRadius, circleRadius * 2, circleRadius * 2);
        }
    }
}