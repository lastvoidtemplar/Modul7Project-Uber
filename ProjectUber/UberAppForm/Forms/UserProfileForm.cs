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
        
        public UserProfileForm()
        {
            InitializeComponent();
        }

        

        private void UserProfileForm_Load(object sender, EventArgs e)
        {
            
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
            selectedUser = userProfile.UserId;
        }

     

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            
        }

        

        private void SaveButton_Click(object sender, EventArgs e)
        {
           
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
