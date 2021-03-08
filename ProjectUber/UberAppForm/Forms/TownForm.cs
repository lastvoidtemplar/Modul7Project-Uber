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
    public partial class TownForm : Form
    {
        public TownForm()
        {
            InitializeComponent();
        }
        public MainForm main;
        private void TownForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.Show();
            this.Close();
        }
    }
}
