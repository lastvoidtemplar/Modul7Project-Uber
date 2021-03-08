using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberAppForm.Forms;

namespace UberAppForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenTownForm_Click(object sender, EventArgs e)
        {
            TownForm townForm = new TownForm();
            townForm.main = this;
            townForm.Show();
            this.Hide();
        }

      

        private void OpenUserForm_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.main = this;
            userForm.Show();
            this.Hide();
        }

        private void OpenUserProfileForm_Click(object sender, EventArgs e)
        {
            UserProfileForm userProfileForm = new UserProfileForm();
            userProfileForm.main = this;
            userProfileForm.Show();
            this.Hide();
        }

        private void OpenVehicleForm_Click(object sender, EventArgs e)
        {
            VehicleForm vehicleProfileForm = new VehicleForm();
            vehicleProfileForm.main = this;
            vehicleProfileForm.Show();
            this.Hide();
        }

        private void OpenDriverForm_Click(object sender, EventArgs e)
        {
            
        }

        private void OpenDriverProfileForm_Click(object sender, EventArgs e)
        {

        }

        private void OpenOrderForm_Click(object sender, EventArgs e)
        {

        }
    }
}
