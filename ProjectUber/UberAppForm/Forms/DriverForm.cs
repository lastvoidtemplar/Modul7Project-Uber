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
    public partial class DriverForm : Form
    {
        private DriverBusiness driverBusiness = new DriverBusiness();
        private VehicleBusiness vehicleBusiness = new VehicleBusiness();
        private int editid = 0;
        private int selectedVehicle = 0;
        /// <summary>
        /// Constructor of DriverForm. Checks if there are vehecles in table Vehicles.
        /// </summary>
        public DriverForm()
        {
            InitializeComponent();
            if (vehicleBusiness.GetAll().Count != 0) selectedVehicle = vehicleBusiness.GetAll().First().Id;
            else TownTableEmptyMessage();
        }
        /// <summary>
        /// Show a message in a MessageBox that table Vehicles is empty.
        /// </summary>
        private void TownTableEmptyMessage()
        {
            string message = "Table Vehecles is empty! Enter vehicle first.";
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
        private void DriverForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateVehicleGrid();
            ClearTextBoxes();
            
        }
        /// <summary>
        ///  Fills driver dataGridView with the context of the table Drivers.
        /// </summary>
        private void UpdateGrid()
        {
            dataGridView1.DataSource = driverBusiness.GetAll();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        ///  Fills vehicle dataGridView with the context of the table Vehicles.
        /// </summary>
        private void UpdateVehicleGrid()
        {
            dataGridView2.DataSource = vehicleBusiness.GetAll();
            dataGridView2.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        /// Clears all textBoxes.
        /// </summary>
        private void ClearTextBoxes()
        {
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            AgeTextBox.Text = "0";
            CountOrdersTextBox.Text = "0";
            RatingTextBox.Text = "0";
        }
        /// <summary>
        /// Gets the id of the selected vehicle.
        /// </summary>
        /// <returns> Returns the id of the selected vehicle</returns>
        private int GetIdOfSelectedVehicle()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var item = dataGridView2.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                return id;
            }
            return selectedVehicle;
        }
        /// <summary>
        /// Gets the information from the textBoxes and vehicleDataGrid, creates a driver with this parameters and adds it in the database.
        /// </summary>
        private void InsertButton_Click(object sender, EventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            int age = 0;
            int.TryParse(AgeTextBox.Text, out age);
            int countOrders = 0;
            int.TryParse(CountOrdersTextBox.Text, out countOrders);
            int rating = 0;
            int.TryParse(RatingTextBox.Text, out rating);
            int vehicleId = GetIdOfSelectedVehicle();
            Driver driver = new Driver();
            driver.FirstName = firstName;
            driver.LastName = lastName;
            driver.Age = age;
            driver.CountOrders = countOrders;
            driver.Rating = rating;
            driver.VehicleId = vehicleId;
            driverBusiness.Add(driver);
            UpdateGrid();
            ClearTextBoxes();
            dataGridView2.ClearSelection();
        }
        /// <summary>
        /// Gets the paramaters of selected driver and shows them in the textBoxes.
        /// </summary>
        /// <param name="id">With this id it finds selected driver.</param>
        private void UpdateTextBoxes(int id)
        {
            Driver driver = driverBusiness.Get(id);
            FirstNameTextBox.Text = driver.FirstName;
            LastNameTextBox.Text = driver.LastName;
            CountOrdersTextBox.Text = driver.CountOrders.ToString();
            RatingTextBox.Text = driver.Rating.ToString();
            dataGridView2.ClearSelection();
            selectedVehicle = driver.VehicleId;
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
        /// Chooses driver,gets his paramaters and shows them in the textBoxes.
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
        /// Updates the paramaters of the selected driver with these from the textBoxes.
        /// </summary>
        /// <returns>Returns the updated driver.</returns>
        private Driver GetEditDriver()
        {
            Driver driver = new Driver();
            driver.Id = editid;
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            int age = 0;
            int.TryParse(AgeTextBox.Text, out age);
            int countOrders = 0;
            int.TryParse(CountOrdersTextBox.Text, out countOrders);
            int rating = 0;
            int.TryParse(RatingTextBox.Text, out rating);
            selectedVehicle = GetIdOfSelectedVehicle();
            driver.FirstName = firstName;
            driver.LastName = lastName;
            driver.Age = age;
            driver.CountOrders = countOrders;
            driver.Rating = rating;
            driver.VehicleId = selectedVehicle;
            return driver;
        }

        private void ResetSelect()
        {

            dataGridView1.ClearSelection();
            dataGridView1.Enabled = true;
        }
        /// <summary>
        /// Updates the selected driver in the database.
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Driver editDriver = GetEditDriver();
            driverBusiness.Update(editDriver);
            UpdateGrid();
            ResetSelect();
            ToggleSaveUpdate();
            ClearTextBoxes();
            dataGridView2.ClearSelection();
        }
        /// <summary>
        /// Deletes the selected driver from the database.
        /// </summary>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var item = dataGridView1.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                driverBusiness.Delete(id);
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
