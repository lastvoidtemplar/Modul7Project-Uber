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
    public partial class OrderForm : Form
    {
        private OrderBusiness orderBusiness = new OrderBusiness();
        private UserProfileBusiness userProfileBusiness = new UserProfileBusiness();
        private DriverProfileBusiness driverProfileBusiness = new DriverProfileBusiness();
        private TownBusiness townBusiness = new TownBusiness();
        private int editid = 0;
        private int selectedUser = 0;
        private int selectedDriver = 0;
        private int selectedTown = 0;
        public OrderForm()
        {
            InitializeComponent();
            if (userProfileBusiness.GetAll().Count != 0)
            {
                selectedUser = userProfileBusiness.GetAll().First().Id;
                if (driverProfileBusiness.GetAll().Count != 0)
                {
                    selectedDriver = driverProfileBusiness.GetAll().First().Id;
                    if (townBusiness.GetAll().Count != 0) selectedTown = townBusiness.GetAll().First().Id;
                    else TownTableEmptyMessage();
                }
                else DriverProfilesTableEmptyMessage();
            }
            else UserProfilesTableEmptyMessage();


        }
        private void UserProfilesTableEmptyMessage()
        {
            string message = "Table UserProfiles is empty! Enter userProfile first.";
            DialogResult result = MessageBox.Show(message);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                succLoad = false;
            }
        }
        private void DriverProfilesTableEmptyMessage()
        {
            string message = "Table DriverProfiles is empty! Enter driverProfile first.";
            DialogResult result = MessageBox.Show(message);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                succLoad = false;
            }
        }
        private void TownTableEmptyMessage()
        {
            string message = "Table Towns is empty! Enter town first.";
            DialogResult result = MessageBox.Show(message);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                succLoad = false;
            }
        }
        public MainForm main;
        public bool succLoad = true;
        private void OrderForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateUserProfileGrid();
            UpdateDriverProfileGrid();
            UpdateTownGrid();
            ClearTextBoxes();
        }
        private void UpdateGrid()
        {
            dataGridView1.DataSource = orderBusiness.GetAll();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void UpdateUserProfileGrid()
        {
            userDataGridView.DataSource = userProfileBusiness.GetAll();
            userDataGridView.ReadOnly = true;
            userDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void UpdateDriverProfileGrid()
        {
            driverDataGridView.DataSource = driverProfileBusiness.GetAll();
            driverDataGridView.ReadOnly = true;
            driverDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void UpdateTownGrid()
        {
            townDataGridView.DataSource = townBusiness.GetAll();
            townDataGridView.ReadOnly = true;
            townDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void ClearTextBoxes()
        {
            DateTime now = DateTime.Now;
            DateTextBox.Text = $"{now.Day} {now.Month} {now.Year}";
            PriceTextBox.Text = "0";
            userDataGridView.ClearSelection();
            driverDataGridView.ClearSelection();
            townDataGridView.ClearSelection();
        }

        private int GetIdOfSelectedUserProfile()
        {
            if (userDataGridView.SelectedRows.Count > 0)
            {
                var item = userDataGridView.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                return id;
            }
            return selectedUser;
        }
        private int GetIdOfSelectedDriverProfile()
        {
            if (driverDataGridView.SelectedRows.Count > 0)
            {
                var item = driverDataGridView.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                return id;
            }
            return selectedDriver;
        }
        private int GetIdOfSelectedTown()
        {
            if (townDataGridView.SelectedRows.Count > 0)
            {
                var item = townDataGridView.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                return id;
            }
            return selectedTown;
        }
        private void InsertButton_Click(object sender, EventArgs e)
        {
            int[] dateArray = DateTextBox.Text.Split().Select(int.Parse).ToArray(); ;
            DateTime date = new DateTime(dateArray[2], dateArray[1], dateArray[0]);
            decimal price = 0;
            decimal.TryParse(PriceTextBox.Text, out price);
            int userProfile_id = GetIdOfSelectedUserProfile();
            int driverProfile_id = GetIdOfSelectedDriverProfile();
            int town_id = GetIdOfSelectedTown();
            Order order = new Order();
            order.UserProfileId = userProfile_id;
            order.DriverProfileId = driverProfile_id;
            order.Date = date;
            order.Price = price;
            order.TownId = town_id;
            orderBusiness.Add(order);
            UpdateGrid();
            ClearTextBoxes();
        }
        private void UpdateTextBoxes(int id)
        {
            Order order = orderBusiness.Get(id);
            DateTime date = order.Date;
            DateTextBox.Text = $"{date.Day} {date.Month} {date.Year}";
            PriceTextBox.Text = order.Price.ToString();
            userDataGridView.ClearSelection();
            driverDataGridView.ClearSelection();
            townDataGridView.ClearSelection();
            selectedUser = order.UserProfileId;
            selectedDriver = order.DriverProfileId;
            selectedTown = order.TownId;
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
        private Order GetEditOrder()
        {
            Order order = new Order();
            order.Id = editid;
            int[] dateArray = DateTextBox.Text.Split().Select(int.Parse).ToArray(); ;
            DateTime date = new DateTime(dateArray[2], dateArray[1], dateArray[0]);
            decimal price = 0;
            decimal.TryParse(PriceTextBox.Text, out price);
            selectedUser = GetIdOfSelectedUserProfile();
            selectedDriver = GetIdOfSelectedDriverProfile();
            selectedTown = GetIdOfSelectedTown();
            order.UserProfileId = selectedUser;
            order.DriverProfileId = selectedDriver;
            order.Date = date;
            order.Price = price;
            order.TownId = selectedTown;
            return order;
        }

        private void ResetSelect()
        {

            dataGridView1.ClearSelection();
            dataGridView1.Enabled = true;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Order editOrder = GetEditOrder();
            orderBusiness.Update(editOrder);
            UpdateGrid();
            ResetSelect();
            ToggleSaveUpdate();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var item = dataGridView1.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                orderBusiness.Delete(id);
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
