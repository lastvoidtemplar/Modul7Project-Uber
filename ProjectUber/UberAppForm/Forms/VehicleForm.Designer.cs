
namespace UberAppForm.Forms
{
    partial class VehicleForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.InsertButton = new System.Windows.Forms.Button();
            this.HorsePowersTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ModelTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(140, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 29);
            this.label4.TabIndex = 35;
            this.label4.Text = "Vehicles";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(396, 19);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(658, 334);
            this.dataGridView1.TabIndex = 34;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.Location = new System.Drawing.Point(130, 236);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(93, 32);
            this.UpdateButton.TabIndex = 33;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(239, 236);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(93, 32);
            this.DeleteButton.TabIndex = 32;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(130, 236);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(93, 32);
            this.SaveButton.TabIndex = 31;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Visible = false;
            // 
            // InsertButton
            // 
            this.InsertButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertButton.Location = new System.Drawing.Point(25, 236);
            this.InsertButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(93, 32);
            this.InsertButton.TabIndex = 30;
            this.InsertButton.Text = "Insert";
            this.InsertButton.UseVisualStyleBackColor = true;
            // 
            // HorsePowersTextBox
            // 
            this.HorsePowersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HorsePowersTextBox.Location = new System.Drawing.Point(160, 155);
            this.HorsePowersTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HorsePowersTextBox.Name = "HorsePowersTextBox";
            this.HorsePowersTextBox.Size = new System.Drawing.Size(196, 28);
            this.HorsePowersTextBox.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 24);
            this.label2.TabIndex = 26;
            this.label2.Text = "Horse powers:";
            // 
            // ModelTextBox
            // 
            this.ModelTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModelTextBox.Location = new System.Drawing.Point(106, 101);
            this.ModelTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ModelTextBox.Name = "ModelTextBox";
            this.ModelTextBox.Size = new System.Drawing.Size(196, 28);
            this.ModelTextBox.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "Model:";
            // 
            // BackButton
            // 
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(25, 300);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(109, 32);
            this.BackButton.TabIndex = 23;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            // 
            // VehicleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 371);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.HorsePowersTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ModelTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BackButton);
            this.Name = "VehicleForm";
            this.Text = "VehicleForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.TextBox HorsePowersTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ModelTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BackButton;
    }
}