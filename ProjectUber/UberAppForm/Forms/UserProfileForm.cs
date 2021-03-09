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
        private int selectedUsert = 0;
        public UserProfileForm()
        {
            InitializeComponent();
        }

        public MainForm main;

        private void UserProfileForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateUserGrid();
            ClearTextBoxes();
        }

        private void UpdateGrid()
        {
            dataGridView1.DataSource = userProfileBusiness.GetAll();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void UpdateUserGrid()
        {        
            dataGridView2.DataSource = userBusiness.GetAll();
            dataGridView2.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void ClearTextBoxes()
        {
            UsernameTextBox.Text = "";
            PasswordTextBox.Text = "";         
        }
        private int GetIdOfSelectedUser()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var item = dataGridView2.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                return id;
            }
            return userBusiness.GetAll().First().Id;
        }
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

        private void UpdateTextBoxes(int id)
        {
            UserProfile userProfile = userProfileBusiness.Get(id);
            UsernameTextBox.Text = userProfile.Username;
            PasswordTextBox.Text = userProfile.Password;
            dataGridView2.ClearSelection();
            selectedUsert = userProfile.UserId;
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

        private UserProfile GetEditUserProfile()
        {
            UserProfile userProfile = new UserProfile();
            userProfile.Id = editid;
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var item = dataGridView1.SelectedRows[0].Cells;
                selectedUsert = int.Parse(item[0].Value.ToString());
            }
            userProfile.Username = username; ;
            userProfile.Password = password;
            userProfile.UserId = selectedUsert;
            return userProfile;
        }

        private void ResetSelect()
        {

            dataGridView1.ClearSelection();
            dataGridView1.Enabled = true;
        }

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

        private void BackButton_Click(object sender, EventArgs e)
        {
            main.Show();
            this.Close();
        }
    }
}
