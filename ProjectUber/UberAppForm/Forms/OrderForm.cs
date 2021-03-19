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
        /// <summary>
        /// Constructor of OrderForm. Checks if there are entities in tables UserProfiles, DriverProfiles and Towns.
        /// </summary>
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
        /// <summary>
        /// Show a message in a MessageBox that table UserProfiles is empty.
        /// </summary>
        private void UserProfilesTableEmptyMessage()
        {
            string message = "Table UserProfiles is empty! Enter userProfile first.";
            DialogResult result = MessageBox.Show(message);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                succLoad = false;
            }
        }
        /// <summary>
        /// Show a message in a MessageBox that table DriverProfiles is empty.
        /// </summary>
        private void DriverProfilesTableEmptyMessage()
        {
            string message = "Table DriverProfiles is empty! Enter driverProfile first.";
            DialogResult result = MessageBox.Show(message);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                succLoad = false;
            }
        }
        /// <summary>
        /// Show a message in a MessageBox that table Towns is empty.
        /// </summary>
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
        /// <summary>
        /// Fills dataGrids and clears the textBoxes.
        /// </summary>
        private void OrderForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateUserProfileGrid();
            UpdateDriverProfileGrid();
            UpdateTownGrid();
            ClearTextBoxes();
        }
        /// <summary>
        ///  Fills order dataGridView with the context of the table Orders.
        /// </summary>
        private void UpdateGrid()
        {
            dataGridView1.DataSource = orderBusiness.GetAll();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        ///  Fills userProfiles dataGridView with the context of the table UserProfiles.
        /// </summary>
        private void UpdateUserProfileGrid()
        {
            userDataGridView.DataSource = userProfileBusiness.GetAll();
            userDataGridView.ReadOnly = true;
            userDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        ///  Fills driverProfiles dataGridView with the context of the table DriverProfiles.
        /// </summary>
        private void UpdateDriverProfileGrid()
        {
            driverDataGridView.DataSource = driverProfileBusiness.GetAll();
            driverDataGridView.ReadOnly = true;
            driverDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        ///  Fills town dataGridView with the context of the table Towns.
        /// </summary>
        private void UpdateTownGrid()
        {
            townDataGridView.DataSource = townBusiness.GetAll();
            townDataGridView.ReadOnly = true;
            townDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        /// Clears all textBoxes.
        /// </summary>
        private void ClearTextBoxes()
        {
            DateTime now = DateTime.Now;
            DateTextBox.Text = $"{now.Day} {now.Month} {now.Year}";
            PriceTextBox.Text = "0";
            userDataGridView.ClearSelection();
            driverDataGridView.ClearSelection();
            townDataGridView.ClearSelection();
        }
        /// <summary>
        /// Gets the id of the selected userProfles.
        /// </summary>
        /// <returns> Returns the id of the selected userProfile</returns>
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
        /// <summary>
        /// Gets the id of the selected driverProfles.
        /// </summary>
        /// <returns> Returns the id of the selected driverProfile</returns>
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
        /// <summary>
        /// Gets the id of the selected town.
        /// </summary>
        /// <returns> Returns the id of the selected town</returns>
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
        /// <summary>
        /// Gets the information from the textBoxes and dataGrids, creates a order with this parameters and adds it in the database.
        /// </summary>
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
        /// <summary>
        /// Gets the paramaters of selected order and shows them in the textBoxes.
        /// </summary>
        /// <param name="id">With this id it finds selected order.</param>
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
        /// Chooses order, gets his paramaters and shows them in the textBoxes.
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
        /// Updates the paramaters of the selected order with these from the textBoxes.
        /// </summary>
        /// <returns>Returns the updated order.</returns>
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
        /// <summary>
        /// Updates the selected order in the database.
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Order editOrder = GetEditOrder();
            orderBusiness.Update(editOrder);
            UpdateGrid();
            ResetSelect();
            ToggleSaveUpdate();
        }
        /// <summary>
        /// Deletes the selected order from the database.
        /// </summary>
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
