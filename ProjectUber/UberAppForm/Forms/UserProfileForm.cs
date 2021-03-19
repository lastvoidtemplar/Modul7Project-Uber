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
    public partial class UserProfileForm : Form
    {
        private UserProfileBusiness userProfileBusiness = new UserProfileBusiness();
        private UserBusiness userBusiness = new UserBusiness();
        private int editid = 0;
        private int selectedUser = 0;
        /// <summary>
        /// Constructor of UserProfileForm. Checks if there are users in table Users.
        /// </summary>
        public UserProfileForm()
        {
            InitializeComponent();
            if (userBusiness.GetAll().Count != 0) selectedUser = userBusiness.GetAll().First().Id;
            else UsersTableEmptyMessage();
        }
        /// <summary>
        /// Show a message in a MessageBox that table Users is empty.
        /// </summary>
        private void UsersTableEmptyMessage()
        {
            string message = "Table Users is empty! Enter user first.";
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
        private void UserProfileForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateUserGrid();
            ClearTextBoxes();          
        }
        /// <summary>
        ///  Fills userprofile dataGridView with the context of the table UserProfiles.
        /// </summary>
        private void UpdateGrid()
        {
            dataGridView1.DataSource = userProfileBusiness.GetAll();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        ///  Fills users dataGridView with the context of the table Users.
        /// </summary>
        private void UpdateUserGrid()
        {
            dataGridView2.DataSource = userBusiness.GetAll();
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
        /// Gets the id of the selected user.
        /// </summary>
        /// <returns> Returns the id of the selected user</returns>
        private int GetIdOfSelectedUser()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var item = dataGridView2.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                return id;
            }
            return selectedUser;
        }
        /// <summary>
        /// Gets the information from the textBoxes and userDataGrid, creates a userProfile with this parameters and adds it in the database.
        /// </summary>
        private void InsertButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            int user_id = GetIdOfSelectedUser();
            UserProfile userProfile = new UserProfile();
            userProfile.Username = username;
            userProfile.Password = password;
            userProfile.UserId = user_id;
            userProfileBusiness.Add(userProfile);
            UpdateGrid();
            ClearTextBoxes();
            dataGridView2.ClearSelection();
        }
        /// <summary>
        /// Gets the paramaters of selected userProfile and shows them in the textBoxes.
        /// </summary>
        /// <param name="id">With this id it finds selected userProfile.</param>
        private void UpdateTextBoxes(int id)
        {
            UserProfile userProfile = userProfileBusiness.Get(id);
            UsernameTextBox.Text = userProfile.Username;
            PasswordTextBox.Text = userProfile.Password;
            dataGridView2.ClearSelection();
            selectedUser = userProfile.UserId;
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
        /// Chooses userProfile, gets his paramaters and shows them in the textBoxes.
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
        /// Updates the paramaters of the selected userProfile with these from the textBoxes.
        /// </summary>
        /// <returns>Returns the updated userProfile.</returns>
        private UserProfile GetEditUserProfile()
        {
            UserProfile userProfile = new UserProfile();
            userProfile.Id = editid;
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            selectedUser = GetIdOfSelectedUser();
            userProfile.Username = username; ;
            userProfile.Password = password;
            userProfile.UserId = selectedUser;
            return userProfile;
        }

        private void ResetSelect()
        {

            dataGridView1.ClearSelection();
            dataGridView1.Enabled = true;
        }
        /// <summary>
        /// Updates the selected userProfile in the database.
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            UserProfile editUserProfile = GetEditUserProfile();
            userProfileBusiness.Update(editUserProfile);
            UpdateGrid();
            ResetSelect();
            ToggleSaveUpdate();
            ClearTextBoxes();
            dataGridView2.ClearSelection();
        }
        /// <summary>
        /// Deletes the selected userProfile from the database.
        /// </summary>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var item = dataGridView1.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                userProfileBusiness.Delete(id);
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
