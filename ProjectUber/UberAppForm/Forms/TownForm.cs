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
        /// <summary>
        /// Constructor of TownForm.
        /// </summary>
        public TownForm()
        {
            InitializeComponent();
        }

        public MainForm main;
        /// <summary>
        /// Fills dataGrid and clears the textBoxes.
        /// </summary>
        private void TownForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            ClearTextBoxes();
        }
        /// <summary>
        ///  Fills town dataGridView with the context of the table Towns.
        /// </summary>
        private void UpdateGrid()
        {
            dataGridView1.DataSource = townBusiness.GetAll();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        /// Clears all textBoxes.
        /// </summary>
        private void ClearTextBoxes()
        {
            NameTextBox.Text = "";
            CountryTextBox.Text = "";
            ZipCodeTextBox.Text = "0000";
        }
        /// <summary>
        /// Gets the information from the textBoxes, creates a town with this parameters and adds it in the database.
        /// </summary>
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
        /// <summary>
        /// Gets the paramaters of selected town and shows them in the textBoxes.
        /// </summary>
        /// <param name="id">With this id it finds selected town.</param>
        private void UpdateTextBoxes(int id)
        {
            Town town = townBusiness.Get(id);
            NameTextBox.Text = town.Name;
            CountryTextBox.Text = town.Country;
            ZipCodeTextBox.Text = town.ZipCode.ToString();

        }
        /// <summary>
        /// Switches save and update button.
        /// </summary>
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
        /// <summary>
        /// Chooses town, gets his paramaters and shows them in the textBoxes.
        /// </summary>
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
        /// <summary>
        /// Updates the paramaters of the selected town with these from the textBoxes.
        /// </summary>
        /// <returns>Returns the updated town.</returns>
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
        /// <summary>
        /// Updates the selected town in the database.
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Town editTown = GetEditTown();
            townBusiness.Update(editTown);
            UpdateGrid();
            ResetSelect();
            ToggleSaveUpdate();
            ClearTextBoxes();
        }
        /// <summary>
        /// Deletes the selected town from the database.
        /// </summary>
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
        /// <summary>
        /// Returns to the main menu.
        /// </summary>
        private void BackButton_Click(object sender, EventArgs e)
        {
            main.Show();
            this.Close();
        }
    }
}
