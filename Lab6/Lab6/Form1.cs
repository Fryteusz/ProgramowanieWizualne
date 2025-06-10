namespace Lab6
{
    public partial class Form1 : Form
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int time { get; private set; }

        public int dydlefy { get; private set; }

        public int krokodyle { get; private set; }
        public int szopy { get; private set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 form = new Form1();
            form.X = X;
            form.Y = Y;
            form.time = time;
            form.dydlefy = dydlefy;
            form.krokodyle = krokodyle;
            form.szopy = szopy;
            Form2 newWindow = new Form2(form);
            if (newWindow.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using var newWindow = new Form3();
            if (newWindow.ShowDialog() == DialogResult.OK)
            {
                X = newWindow.X;
                Y = newWindow.Y;
                time = newWindow.time;
                dydlefy = newWindow.dydlefy;
                krokodyle = newWindow.krokodyle;
                szopy = newWindow.szopy;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}