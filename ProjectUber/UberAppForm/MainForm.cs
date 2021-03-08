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
    }
}
