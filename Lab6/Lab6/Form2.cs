using Lab6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Lab6
{
    public partial class Form2 : Form
    {
        private Form1 form;
        private TableLayoutPanel grid;
        private HashSet<Button> buttons = new HashSet<Button>();
        private Dictionary<Button, string> fieldContent = new Dictionary<Button, string>();
        private int foundDydlefy = 0;
        private Label lblTimer;
        private int timeLeft;
        private int timeKrok;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer krokTimer;
        private System.Windows.Forms.Timer szopTimer;

        public Form2(Form1 form)
        {
            this.form = form;
            InitializeComponent();
            Start();
        }
        private void Start()
        {
            Panel mainPanel = new Panel { Dock = DockStyle.Fill };
            this.Controls.Add(mainPanel);
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            mainPanel.Controls.Add(layout);
            lblTimer = new Label
            {
                Text = $"Pozostały czas: {form.time}s",
                Dock = DockStyle.Top,
                Height = 30,
            };
            layout.Controls.Add(lblTimer, 0, 0);
            grid = new TableLayoutPanel();
            grid.RowCount = form.X;
            grid.ColumnCount = form.Y;
            grid.Dock = DockStyle.Fill;
            for (int i = 0; i < form.X; i++)
                grid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / form.X));
            for (int j = 0; j < form.Y; j++)
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / form.Y));

            layout.Controls.Add(grid, 0, 1);

            List<string> contents = new List<string>();
            contents.AddRange(Enumerable.Repeat("Dydelf", form.dydlefy));
            contents.AddRange(Enumerable.Repeat("Krokodyl", form.krokodyle));
            contents.AddRange(Enumerable.Repeat("Szop", form.szopy));
            int total = form.X * form.Y;
            contents.AddRange(Enumerable.Repeat("Puste", total - contents.Count));
            Random rng = new Random();
            contents = contents.OrderBy(x => rng.Next()).ToList();
            int index = 0;
            for (int i = 0; i < form.X; i++)
            {
                for (int j = 0; j < form.Y; j++)
                {
                    Button btn = new Button { Dock = DockStyle.Fill, BackColor = Color.LightGray };
                    btn.Click += Field_Click;
                    grid.Controls.Add(btn, j, i);
                    fieldContent[btn] = contents[index++];
                }
            }
            timeLeft = form.time;
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();


        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            lblTimer.Text = $"Pozostały czas: {timeLeft}s";

            if (timeLeft <= 0)
                EndGame(false, "Czas minął!");
        }
        private void KrokTimer_Tick(object sender, EventArgs e)
        {
            timeKrok--;

            if (timeKrok <= 0)
            {
                krokTimer.Stop();
                EndGame(false, "Krokodyl!");
            }

        }
        private void Field_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            buttons.Add(btn);
            string content = fieldContent[btn];
            if (content == "Dydelf")
            {
                btn.BackColor = Color.Green;
                btn.Text = "D";
                btn.Enabled = false;
                foundDydlefy++;

                if (foundDydlefy == form.dydlefy)
                    EndGame(true, "Wygrałeś!");
            }
            else if (content == "Krokodyl")
            {
                if (btn.Text == "K")
                {
                    btn.BackColor = Color.Red;
                    btn.Text = "K";
                    krokTimer.Stop();
                    btn.Enabled = false;
                }
                else
                {
                    krokTimer = new System.Windows.Forms.Timer();
                    krokTimer.Interval = 1000;
                    krokTimer.Tick += KrokTimer_Tick;
                    krokTimer.Start();
                    btn.BackColor = Color.Red;
                    btn.Text = "K";
                }
            }
            else if (content == "Szop")
            {

                btn.BackColor = Color.Blue;
                btn.Text = "S";
                szopTimer = new System.Windows.Forms.Timer();
                szopTimer.Interval = 2000;
                szopTimer.Start();
                btn.Enabled = false;
                szopTimer.Tick += (s, args) =>
                {
                    szopTimer.Stop();
                    btn.Text = "";
                    btn.BackColor = Color.LightGray;
                    btn.Enabled = true;
                    var neighbors = neigh(btn);
                    foreach (var neighbor in neighbors)
                    {
                        if (neighbor.Text == "D")
                        {
                            foundDydlefy--;
                        }
                        if (neighbor.Text == "K")
                        {
                            krokTimer.Stop();
                        }
                        neighbor.Text = "";
                        neighbor.BackColor = Color.LightGray;
                        neighbor.Enabled = true;
                    }
                };
            }
            else
            {
                btn.BackColor = Color.White;
                btn.Enabled = false;
            }
        }
        private List<Button> neigh(Button btn)
        {
            List<Button> neighbors = new List<Button>();
            int row = grid.GetRow(btn);
            int col = grid.GetColumn(btn);

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    int row2 = row + i;
                    int col2 = col + j;
                    if (row2 >= 0 && row2 < form.X && col2 >= 0 && col2 < form.Y)
                    {
                        Button neighbor = grid.GetControlFromPosition(col2, row2) as Button;
                        if (neighbor != null)
                        {
                            neighbors.Add(neighbor);
                        }
                    }
                }
            }
            return neighbors;
        }
        private void EndGame(bool success, string message)
        {
            gameTimer.Stop();
            MessageBox.Show(message, success ? "Wygrana!" : "Przegrana");
            this.Close();
        }
    }
}