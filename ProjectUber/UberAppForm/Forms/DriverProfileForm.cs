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

        public DriverProfileForm()
        {
            InitializeComponent();
        }

        public MainForm main;

        private void DriverProfileForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateDriverGrid();
            ClearTextBoxes();
        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = driverProfileBusiness.GetAll();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void UpdateDriverGrid()
        {
            dataGridView2.DataSource = driverBusiness.GetAll();
            dataGridView2.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ClearTextBoxes()
        {
            UsernameTextBox.Text = "";
            PasswordTextBox.Text = "";
        }

        private int GetIdOfSelectedDriver()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var item = dataGridView2.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                return id;
            }
            return driverBusiness.GetAll().First().Id;
        }

        private void InsertButton_Click_1(object sender, EventArgs e)
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

        private void UpdateTextBoxes(int id)
        {
            DriverProfile driverProfile = driverProfileBusiness.Get(id);
            UsernameTextBox.Text = driverProfile.Username;
            PasswordTextBox.Text = driverProfile.Password;
            dataGridView2.ClearSelection();
            selectedDriver = driverProfile.DriverId;
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

        private DriverProfile GetEditDriverProfile()
        {
            DriverProfile driverProfile = new DriverProfile();
            driverProfile.Id = editid;
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var item = dataGridView1.SelectedRows[0].Cells;
                selectedDriver = int.Parse(item[0].Value.ToString());
            }
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

        private void BackButton_Click(object sender, EventArgs e)
        {
            main.Show();
            this.Close();
        }
    }
}
