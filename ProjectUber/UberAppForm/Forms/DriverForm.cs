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

        public DriverForm()
        {
            InitializeComponent();
        }

        public MainForm main;

        private void DriverForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateVehicleGrid();
            ClearTextBoxes();
        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = driverBusiness.GetAll();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void UpdateVehicleGrid()
        {
            dataGridView2.DataSource = vehicleBusiness.GetAll();
            dataGridView2.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ClearTextBoxes()
        {
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            AgeTextBox.Text = "0";
            CountOrdersTextBox.Text = "0";
            RatingTextBox.Text = "0";
        }

        private int GetIdOfSelectedVehicle()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var item = dataGridView2.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                return id;
            }
            return vehicleBusiness.GetAll().First().Id;
        }

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
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var item = dataGridView1.SelectedRows[0].Cells;
                selectedVehicle = int.Parse(item[0].Value.ToString());
            }
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

        private void BackButton_Click(object sender, EventArgs e)
        {
            main.Show();
            this.Close();
        }
    }
}
