using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberAppForm.Forms
{
    public partial class TownForm : Form
    {
        private TownBusiness townBusiness = new TownBusiness();
        private int editid = 0;

        public TownForm()
        {
            InitializeComponent();
        }

        public MainForm main;

        private void TownForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            ClearTextBoxes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.Show();
            this.Close();
        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = townBusiness.GetAll();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ClearTextBoxes()
        {
            NameTextBox.Text = "";
            CountryTextBox.Text = "";
            ZipCodeTextBox.Text = "0000";
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string country = CountryTextBox.Text;
            int zipCode = 0;
            int.TryParse(ZipCodeTextBox.Text, out zipCode);
            Town town = new Town();
            town.Name = name;
            town.Country = country;
            town.ZipCode = zipCode;
            townBusiness.Add(town);
            UpdateGrid();
            ClearTextBoxes();
        }

        private void UpdateTextBoxes(int id)
        {
            Town town = townBusiness.Get(id);
            NameTextBox.Text = town.Name;
            CountryTextBox.Text = town.Country;
            ZipCodeTextBox.Text = town.ZipCode.ToString();

        }

        private void ToggleSaveUpdate()
        {
            if (UpdateButton.Visible)
            {
                UpdateButton.Visible = false;
                SaveButton.Visible = true;
            }
            else
            {
                UpdateButton.Visible = true;
                SaveButton.Visible = false;
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var item = dataGridView1.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                UpdateTextBoxes(id);
                ToggleSaveUpdate();
                DisableSelect();
                editid = id;
            }
        }

        private void DisableSelect()
        {
            dataGridView1.Enabled = false;
        }

        private Town GetEditTown()
        {
            Town town = new Town();
            town.Id = editid;
            string name = NameTextBox.Text;
            string country = CountryTextBox.Text;
            int zipCode = 0;
            int.TryParse(ZipCodeTextBox.Text, out zipCode);
            town.Name = name;
            town.Country = country;
            town.ZipCode = zipCode;
            return town;
        }

        private void ResetSelect()
        {

            dataGridView1.ClearSelection();
            dataGridView1.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Town editTown = GetEditTown();
            townBusiness.Update(editTown);
            UpdateGrid();
            ResetSelect();
            ToggleSaveUpdate();
            ClearTextBoxes();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var item = dataGridView1.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                townBusiness.Delete(id);
                UpdateGrid();
                ResetSelect();
            }
        }
    }
}
