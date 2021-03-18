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
            if (userProfileForm.succLoad == true) { userProfileForm.Show(); this.Hide(); }
            else userProfileForm.Close();
        }

        private void OpenVehicleForm_Click(object sender, EventArgs e)
        {
            VehicleForm vehicleForm = new VehicleForm();
            vehicleForm.main = this;
            vehicleForm.Show();
            this.Hide();
        }

        private void OpenDriverForm_Click(object sender, EventArgs e)
        {
            DriverForm driverForm = new DriverForm();
            driverForm.main = this;
            if (driverForm.succLoad == true) { driverForm.Show(); this.Hide(); }
            else driverForm.Close();          
        }

        private void OpenDriverProfileForm_Click(object sender, EventArgs e)
        {
            DriverProfileForm driverProfileForm = new DriverProfileForm();
            driverProfileForm.main = this;
            if (driverProfileForm.succLoad == true) { driverProfileForm.Show(); this.Hide(); }
            else driverProfileForm.Close();
        }

        private void OpenOrderForm_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.main = this;
            if (orderForm.succLoad == true) { orderForm.Show(); this.Hide(); }
            else orderForm.Close();
        }
    }
}
