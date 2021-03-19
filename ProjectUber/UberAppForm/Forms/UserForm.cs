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
    public partial class UserForm : Form
    {
        private UserBusiness userBusiness = new UserBusiness();
        private int editid = 0;
        /// <summary>
        /// Constructor of UserForm.
        /// </summary>
        public UserForm()
        {
            InitializeComponent();
        }

        public MainForm main;
        /// <summary>
        /// Fills dataGrid and clears the textBoxes.
        /// </summary>
        private void UserForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            ClearTextBoxes();
        }
        /// <summary>
        ///  Fills user dataGridView with the context of the table Users.
        /// </summary>
        private void UpdateGrid()
        {
            dataGridView1.DataSource = userBusiness.GetAll();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
        }
        /// <summary>
        /// Gets the information from the textBoxes, creates a user with this parameters and adds it in the database.
        /// </summary>
        private void InsertButton_Click(object sender, EventArgs e)
        {
            string firstname = FirstNameTextBox.Text;
            string lastname = LastNameTextBox.Text;
            int age = 0;
            int.TryParse(AgeTextBox.Text, out age);
            int count_order = 0;
            int.TryParse(CountOrdersTextBox.Text, out count_order);
            User user = new User();
            user.FirstName = firstname;
            user.LastName = lastname;
            user.Age = age;
            userBusiness.Add(user);
            UpdateGrid();
            ClearTextBoxes();
        }
        /// <summary>
        /// Gets the paramaters of selected user and shows them in the textBoxes.
        /// </summary>
        /// <param name="id">With this id it finds selected user.</param>
        private void UpdateTextBoxes(int id)
        {
            User user = userBusiness.Get(id);
            FirstNameTextBox.Text = user.FirstName;
            LastNameTextBox.Text = user.LastName;
            AgeTextBox.Text = user.Age.ToString();
            CountOrdersTextBox.Text = user.CountOrders.ToString();
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
        /// Chooses user, gets his paramaters and shows them in the textBoxes.
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
        /// Updates the paramaters of the selected user with these from the textBoxes.
        /// </summary>
        /// <returns>Returns the updated user.</returns>
        private User GetEditUser()
        {
            User user = new User();
            user.Id = editid;
            string firstname = FirstNameTextBox.Text;
            string lastname = LastNameTextBox.Text;
            int age = 0;
            int.TryParse(AgeTextBox.Text, out age);
            int count_order = 0;
            int.TryParse(CountOrdersTextBox.Text, out count_order);  
            user.FirstName = firstname;
            user.LastName = lastname;
            user.Age = age;
            return user;
        }

        private void ResetSelect()
        {

            dataGridView1.ClearSelection();
            dataGridView1.Enabled = true;
        }
        /// <summary>
        /// Updates the selected user in the database.
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            User editUser = GetEditUser();
            userBusiness.Update(editUser);
            UpdateGrid();
            ResetSelect();
            ToggleSaveUpdate();
            ClearTextBoxes();
        }
        /// <summary>
        /// Deletes the selected user from the database.
        /// </summary>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var item = dataGridView1.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                userBusiness.Delete(id);
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
