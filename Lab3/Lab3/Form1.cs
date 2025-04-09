using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;


namespace Lab3
{
    public partial class Form1 : Form
    {
        public int i = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[i].Index);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnSaveToCSV_Click(sender, e);
        }
        private void btnSaveToCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Pliki CSV (*.csv)|*.csv|Wszystkie pliki (*.*)|*.*";
            saveFileDialog1.Title = "Wybierz lokalizację zapisu pliku CSV";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                ExportToCSV(dataGridView1, saveFileDialog1.FileName);
            }
        }

        private void ExportToCSV(DataGridView dataGridView, string filepath)
        {
            string csvContent = "ID, Nazwisko, Imie, Wiek, Stanowisko\n" + Environment.NewLine;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    csvContent += string.Join(",", Array.ConvertAll(row.Cells.Cast<DataGridViewCell>().ToArray(), c => c.Value)) + Environment.NewLine;
                }
            }
            File.WriteAllText(filepath, csvContent);
        }
        private void LoadCSVToDataGridView(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Plik CSV nie istnieje.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] lines = File.ReadAllLines(filePath);
            // Tworzenie tabeli danych
            DataTable dataTable = new DataTable();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            // Dodanie kolumn na podstawie nagłówka
            string[] headers = lines[0].Split(',');
            foreach (string header in headers)
            {
                dataTable.Columns.Add(header);
            }
            // Dodawanie wierszy do tabeli danych
            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                dataTable.Rows.Add(values);
            }
            // Przypisanie tabeli danych do DataGridView
            dataGridView1.DataSource = dataTable;
        }
        private void btnLoadCSV_Click(object sender, EventArgs e)
        {
            // Wyświetlenie okna dialogowego wyboru pliku CSV
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Pliki CSV (*.csv)|*.csv|Wszystkie pliki (*.*)|*.*";
            openFileDialog1.Title = "Wybierz plik CSV do wczytania";
            openFileDialog1.ShowDialog();
            // Jeśli użytkownik wybierze plik i zatwierdzi, wczytaj dane z pliku CSV
            if (openFileDialog1.FileName != "")
            {
                // Wywołanie funkcji wczytującej dane z pliku CSV
                LoadCSVToDataGridView(openFileDialog1.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnLoadCSV_Click(sender, e);
        }
        public static void SerializeOsobaListToJson(List<Osoba> osoby, string filePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            string jsonString = JsonSerializer.Serialize(osoby, options);
            File.WriteAllText(filePath, jsonString, Encoding.UTF8);
        }
        public List<Osoba> DataToObject()
        {
            List<Osoba> listaOsob = new List<Osoba>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                Osoba osoba = new Osoba();
                if (dataGridView1.Columns.Contains("Id"))
                {
                    object idValue = row.Cells["Id"].Value;
                    if (idValue != null && idValue != DBNull.Value && int.TryParse(idValue.ToString(), out int id))
                    {
                        osoba.Id = id;
                    }
                }

                if (dataGridView1.Columns.Contains("Imie"))
                {
                    object imieValue = row.Cells["Imie"].Value;
                    osoba.Imie = imieValue?.ToString() ?? string.Empty;
                }

                if (dataGridView1.Columns.Contains("Nazwisko"))
                {
                    object nazwiskoValue = row.Cells["Nazwisko"].Value;
                    osoba.Nazwisko = nazwiskoValue?.ToString() ?? string.Empty;
                }

                if (dataGridView1.Columns.Contains("Wiek"))
                {
                    object wiekValue = row.Cells["Wiek"].Value;
                    if (wiekValue != null && wiekValue != DBNull.Value && int.TryParse(wiekValue.ToString(), out int wiek))
                    {
                        osoba.Wiek = wiek;
                    }
                }
                listaOsob.Add(osoba);
            }
            return listaOsob;
        }
        public static List<Osoba> DeserializeOsobaListFromJson(string fileName)
        {
            string jsonString = File.ReadAllText(fileName, Encoding.UTF8);
            List<Osoba> osoby = JsonSerializer.Deserialize<List<Osoba>>(jsonString);
            return osoby; 
        }



        private void button5_Click(object sender, EventArgs e)
        {
            SerializeOsobaListToJson(DataToObject(), "osoby.json");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<Osoba> listaOsob = DeserializeOsobaListFromJson("osoby.json");
            if (listaOsob != null)
            {
                foreach (Osoba osoba in listaOsob)
                {
                        int rowIndex = dataGridView1.Rows.Add();
                        DataGridViewRow newRow = dataGridView1.Rows[rowIndex];

                        if (dataGridView1.Columns.Contains("Id"))
                            newRow.Cells["Id"].Value = osoba.Id;
                        if (dataGridView1.Columns.Contains("Imie"))
                            newRow.Cells["Imie"].Value = osoba.Imie;
                        if (dataGridView1.Columns.Contains("Nazwisko"))
                            newRow.Cells["Nazwisko"].Value = osoba.Nazwisko;
                        if (dataGridView1.Columns.Contains("Wiek"))
                            newRow.Cells["Wiek"].Value = osoba.Wiek;
                    }
                }
            }
    }
}

