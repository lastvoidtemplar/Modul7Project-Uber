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
    public partial class VehicleForm : Form
    {
        private VehicleBusiness vehicleBusiness = new VehicleBusiness();
        private int editid = 0;

        public VehicleForm()
        {
            InitializeComponent();
        }

        public MainForm main;

        private void VehicleForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            ClearTextBoxes();
        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = vehicleBusiness.GetAll();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ClearTextBoxes()
        {
            ModelTextBox.Text = "";
            HorsePowersTextBox.Text = "0";
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            string model = ModelTextBox.Text;
            int horsePowers = 0;
            int.TryParse(HorsePowersTextBox.Text, out horsePowers);
            Vehicle vehicle = new Vehicle();
            vehicle.Model = model;
            vehicle.HorsePower = horsePowers;
            vehicleBusiness.Add(vehicle);
            UpdateGrid();
            ClearTextBoxes();
        }

        private void UpdateTextBoxes(int id)
        {
            Vehicle vehicle = vehicleBusiness.Get(id);
            ModelTextBox.Text = vehicle.Model;
            HorsePowersTextBox.Text = vehicle.HorsePower.ToString();
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

        private Vehicle GetEditVehicle()
        {
            Vehicle vehicle = new Vehicle();
            vehicle.Id = editid;
            string model = ModelTextBox.Text;
            int horsePowers = 0;
            int.TryParse(HorsePowersTextBox.Text, out horsePowers);
            vehicle.Model = model;
            vehicle.HorsePower = horsePowers;
            return vehicle;
        }

        private void ResetSelect()
        {

            dataGridView1.ClearSelection();
            dataGridView1.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Vehicle vehicleEdit = GetEditVehicle();
            vehicleBusiness.Update(vehicleEdit);
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
                vehicleBusiness.Delete(id);
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
