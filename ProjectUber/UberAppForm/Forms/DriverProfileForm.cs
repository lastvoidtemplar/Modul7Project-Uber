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
    public partial class DriverProfileForm : Form
    {
        private DriverProfileBusiness driverProfileBusiness = new DriverProfileBusiness();
        private DriverBusiness driverBusiness = new DriverBusiness();
        private int editid = 0;
        private int selectedDriver = 0;
        /// <summary>
        /// Constructor of DriverProfileForm. Checks if there are drivers in table Drivers.
        /// </summary>
        public DriverProfileForm()
        {
            InitializeComponent();
            if (driverBusiness.GetAll().Count != 0)
            {
                selectedDriver = driverBusiness.GetAll().First().Id;                
            }
            else DriverTableEmptyMessage();           
        }
        /// <summary>
        /// Show a message in a MessageBox that table Drivers is empty.
        /// </summary>
        private void DriverTableEmptyMessage()
        {
            string message = "Table Drivers is empty! Enter driver first.";
                DialogResult result = MessageBox.Show(message);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    succLoad = false;
                }
        }
        public MainForm main;
        public bool succLoad = true;
        /// <summary>
        /// Fills dataGrids and clears the textBoxes.
        /// </summary>
        private void DriverProfileForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateDriverGrid();
            ClearTextBoxes();
        }
        /// <summary>
        ///  Fills driverprofile dataGridView with the context of the table DriverProfiles.
        /// </summary>
        private void UpdateGrid()
        {
            dataGridView1.DataSource = driverProfileBusiness.GetAll();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        ///  Fills drivers dataGridView with the context of the table Drivers.
        /// </summary>
        private void UpdateDriverGrid()
        {
            dataGridView2.DataSource = driverBusiness.GetAll();
            dataGridView2.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        /// Clears all textBoxes.
        /// </summary>
        private void ClearTextBoxes()
        {
            UsernameTextBox.Text = "";
            PasswordTextBox.Text = "";
        }
        /// <summary>
        /// Gets the id of the selected driver.
        /// </summary>
        /// <returns> Returns the id of the selected driver</returns>
        private int GetIdOfSelectedDriver()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var item = dataGridView2.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                return id;
            }
            return selectedDriver;
        }
        /// <summary>
        /// Gets the information from the textBoxes and driverDataGrid, creates a driverProfile with this parameters and adds it in the database.
        /// </summary>
        private void InsertButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            int driverId = GetIdOfSelectedDriver();
            DriverProfile driverProfile = new DriverProfile();
            driverProfile.Username = username;
            driverProfile.Password = password;
            driverProfile.DriverId = driverId;
            driverProfileBusiness.Add(driverProfile);
            UpdateGrid();
            ClearTextBoxes();
            dataGridView2.ClearSelection();
        }
        /// <summary>
        /// Gets the paramaters of selected driverProfile and shows them in the textBoxes.
        /// </summary>
        /// <param name="id">With this id it finds selected driverProfile.</param>
        private void UpdateTextBoxes(int id)
        {
            DriverProfile driverProfile = driverProfileBusiness.Get(id);
            UsernameTextBox.Text = driverProfile.Username;
            PasswordTextBox.Text = driverProfile.Password;
            dataGridView2.ClearSelection();
            selectedDriver = driverProfile.DriverId;
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
        /// Chooses driverProfile, gets his paramaters and shows them in the textBoxes.
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
        /// Updates the paramaters of the selected driverProfile with these from the textBoxes.
        /// </summary>
        /// <returns>Returns the updated driverProfile.</returns>
        private DriverProfile GetEditDriverProfile()
        {
            DriverProfile driverProfile = new DriverProfile();
            driverProfile.Id = editid;
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;  
            selectedDriver = GetIdOfSelectedDriver();
            driverProfile.Username = username; ;
            driverProfile.Password = password;
            driverProfile.DriverId = selectedDriver;
            return driverProfile;
        }

        private void ResetSelect()
        {

            dataGridView1.ClearSelection();
            dataGridView1.Enabled = true;
        }
        /// <summary>
        /// Updates the selected driverProfile in the database.
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            DriverProfile editDriverProfile = GetEditDriverProfile();
            driverProfileBusiness.Update(editDriverProfile);
            UpdateGrid();
            ResetSelect();
            ToggleSaveUpdate();
            ClearTextBoxes();
            dataGridView2.ClearSelection();
        }
        /// <summary>
        /// Deletes the selected driverProfile from the database.
        /// </summary>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var item = dataGridView1.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                driverProfileBusiness.Delete(id);
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
