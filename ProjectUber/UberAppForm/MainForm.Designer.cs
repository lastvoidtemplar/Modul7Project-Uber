
namespace UberAppForm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenTownForm = new System.Windows.Forms.Button();
            this.OpenUserForm = new System.Windows.Forms.Button();
            this.OpenUserProfileForm = new System.Windows.Forms.Button();
            this.OpenDriverProfileForm = new System.Windows.Forms.Button();
            this.OpenDriverForm = new System.Windows.Forms.Button();
            this.OpenVehicleForm = new System.Windows.Forms.Button();
            this.OpenOrderForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OpenTownForm
            // 
            this.OpenTownForm.Location = new System.Drawing.Point(47, 18);
            this.OpenTownForm.Name = "OpenTownForm";
            this.OpenTownForm.Size = new System.Drawing.Size(242, 51);
            this.OpenTownForm.TabIndex = 0;
            this.OpenTownForm.Text = "Towns";
            this.OpenTownForm.UseVisualStyleBackColor = true;
            this.OpenTownForm.Click += new System.EventHandler(this.OpenTownForm_Click);
            // 
            // OpenUserForm
            // 
            this.OpenUserForm.Location = new System.Drawing.Point(47, 107);
            this.OpenUserForm.Name = "OpenUserForm";
            this.OpenUserForm.Size = new System.Drawing.Size(242, 51);
            this.OpenUserForm.TabIndex = 1;
            this.OpenUserForm.Text = "Users";
            this.OpenUserForm.UseVisualStyleBackColor = true;
            this.OpenUserForm.Click += new System.EventHandler(this.OpenUserForm_Click);
            // 
            // OpenUserProfileForm
            // 
            this.OpenUserProfileForm.Location = new System.Drawing.Point(47, 193);
            this.OpenUserProfileForm.Name = "OpenUserProfileForm";
            this.OpenUserProfileForm.Size = new System.Drawing.Size(242, 51);
            this.OpenUserProfileForm.TabIndex = 2;
            this.OpenUserProfileForm.Text = "UserProfiles";
            this.OpenUserProfileForm.UseVisualStyleBackColor = true;
            this.OpenUserProfileForm.Click += new System.EventHandler(this.OpenUserProfileForm_Click);
            // 
            // OpenDriverProfileForm
            // 
            this.OpenDriverProfileForm.Location = new System.Drawing.Point(449, 193);
            this.OpenDriverProfileForm.Name = "OpenDriverProfileForm";
            this.OpenDriverProfileForm.Size = new System.Drawing.Size(242, 51);
            this.OpenDriverProfileForm.TabIndex = 5;
            this.OpenDriverProfileForm.Text = "DriverProfiles";
            this.OpenDriverProfileForm.UseVisualStyleBackColor = true;
            this.OpenDriverProfileForm.Click += new System.EventHandler(this.OpenDriverProfileForm_Click);
            // 
            // OpenDriverForm
            // 
            this.OpenDriverForm.Location = new System.Drawing.Point(449, 107);
            this.OpenDriverForm.Name = "OpenDriverForm";
            this.OpenDriverForm.Size = new System.Drawing.Size(242, 51);
            this.OpenDriverForm.TabIndex = 4;
            this.OpenDriverForm.Text = "Drivers";
            this.OpenDriverForm.UseVisualStyleBackColor = true;
            this.OpenDriverForm.Click += new System.EventHandler(this.OpenDriverForm_Click);
            // 
            // OpenVehicleForm
            // 
            this.OpenVehicleForm.Location = new System.Drawing.Point(449, 18);
            this.OpenVehicleForm.Name = "OpenVehicleForm";
            this.OpenVehicleForm.Size = new System.Drawing.Size(242, 51);
            this.OpenVehicleForm.TabIndex = 3;
            this.OpenVehicleForm.Text = "Vehicles";
            this.OpenVehicleForm.UseVisualStyleBackColor = true;
            this.OpenVehicleForm.Click += new System.EventHandler(this.OpenVehicleForm_Click);
            // 
            // OpenOrderForm
            // 
            this.OpenOrderForm.Location = new System.Drawing.Point(249, 294);
            this.OpenOrderForm.Name = "OpenOrderForm";
            this.OpenOrderForm.Size = new System.Drawing.Size(242, 51);
            this.OpenOrderForm.TabIndex = 6;
            this.OpenOrderForm.Text = "Orders";
            this.OpenOrderForm.UseVisualStyleBackColor = true;
            this.OpenOrderForm.Click += new System.EventHandler(this.OpenOrderForm_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 391);
            this.Controls.Add(this.OpenOrderForm);
            this.Controls.Add(this.OpenDriverProfileForm);
            this.Controls.Add(this.OpenDriverForm);
            this.Controls.Add(this.OpenVehicleForm);
            this.Controls.Add(this.OpenUserProfileForm);
            this.Controls.Add(this.OpenUserForm);
            this.Controls.Add(this.OpenTownForm);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenTownForm;
        private System.Windows.Forms.Button OpenUserForm;
        private System.Windows.Forms.Button OpenUserProfileForm;
        private System.Windows.Forms.Button OpenDriverProfileForm;
        private System.Windows.Forms.Button OpenDriverForm;
        private System.Windows.Forms.Button OpenVehicleForm;
        private System.Windows.Forms.Button OpenOrderForm;
    }
}

