namespace Lab2
{
    public partial class Form1 : Form
    {
        int fullPrice = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            if(form2.ShowDialog() == DialogResult.OK)
            {
                fullPrice+= form2.Price;
                textBox1.Text = fullPrice.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            if (form3.ShowDialog() == DialogResult.OK)
            {
                fullPrice += form3.price;
                textBox1.Text = fullPrice.ToString();
            }
        }
    }
}
