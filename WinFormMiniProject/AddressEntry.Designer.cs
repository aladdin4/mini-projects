namespace WinFormMiniProject
{
    partial class AddressEntry
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
            this.cityText = new System.Windows.Forms.TextBox();
            this.streerAddressText = new System.Windows.Forms.TextBox();
            this.cityLabel = new System.Windows.Forms.Label();
            this.streetAddressLabel = new System.Windows.Forms.Label();
            this.zipCodeText = new System.Windows.Forms.TextBox();
            this.stateText = new System.Windows.Forms.TextBox();
            this.zipCodeLabel = new System.Windows.Forms.Label();
            this.stateLabel = new System.Windows.Forms.Label();
            this.addressEntryLabel = new System.Windows.Forms.Label();
            this.saveAddressEntry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cityText
            // 
            this.cityText.Location = new System.Drawing.Point(299, 228);
            this.cityText.Name = "cityText";
            this.cityText.Size = new System.Drawing.Size(423, 44);
            this.cityText.TabIndex = 6;
            // 
            // streerAddressText
            // 
            this.streerAddressText.Location = new System.Drawing.Point(299, 147);
            this.streerAddressText.Name = "streerAddressText";
            this.streerAddressText.Size = new System.Drawing.Size(423, 44);
            this.streerAddressText.TabIndex = 5;
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(36, 231);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(82, 41);
            this.cityLabel.TabIndex = 3;
            this.cityLabel.Text = "City:";
            // 
            // streetAddressLabel
            // 
            this.streetAddressLabel.AutoSize = true;
            this.streetAddressLabel.Location = new System.Drawing.Point(36, 147);
            this.streetAddressLabel.Name = "streetAddressLabel";
            this.streetAddressLabel.Size = new System.Drawing.Size(244, 41);
            this.streetAddressLabel.TabIndex = 4;
            this.streetAddressLabel.Text = "Street Address:";
            // 
            // zipCodeText
            // 
            this.zipCodeText.Location = new System.Drawing.Point(299, 387);
            this.zipCodeText.Name = "zipCodeText";
            this.zipCodeText.Size = new System.Drawing.Size(423, 44);
            this.zipCodeText.TabIndex = 10;
            // 
            // stateText
            // 
            this.stateText.Location = new System.Drawing.Point(299, 306);
            this.stateText.Name = "stateText";
            this.stateText.Size = new System.Drawing.Size(423, 44);
            this.stateText.TabIndex = 9;
            // 
            // zipCodeLabel
            // 
            this.zipCodeLabel.AutoSize = true;
            this.zipCodeLabel.Location = new System.Drawing.Point(36, 390);
            this.zipCodeLabel.Name = "zipCodeLabel";
            this.zipCodeLabel.Size = new System.Drawing.Size(158, 41);
            this.zipCodeLabel.TabIndex = 7;
            this.zipCodeLabel.Text = "Zip Code:";
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(36, 309);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(101, 41);
            this.stateLabel.TabIndex = 8;
            this.stateLabel.Text = "State:";
            // 
            // addressEntryLabel
            // 
            this.addressEntryLabel.AutoSize = true;
            this.addressEntryLabel.Font = new System.Drawing.Font("Montserrat", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressEntryLabel.Location = new System.Drawing.Point(34, 37);
            this.addressEntryLabel.Name = "addressEntryLabel";
            this.addressEntryLabel.Size = new System.Drawing.Size(297, 51);
            this.addressEntryLabel.TabIndex = 11;
            this.addressEntryLabel.Text = "Address Entry";
            // 
            // saveAddressEntry
            // 
            this.saveAddressEntry.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveAddressEntry.Location = new System.Drawing.Point(565, 481);
            this.saveAddressEntry.Name = "saveAddressEntry";
            this.saveAddressEntry.Size = new System.Drawing.Size(137, 39);
            this.saveAddressEntry.TabIndex = 12;
            this.saveAddressEntry.Text = "Save";
            this.saveAddressEntry.UseVisualStyleBackColor = true;
            this.saveAddressEntry.Click += new System.EventHandler(this.saveAddressEntry_Click);
            // 
            // AddressEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 616);
            this.Controls.Add(this.saveAddressEntry);
            this.Controls.Add(this.addressEntryLabel);
            this.Controls.Add(this.zipCodeText);
            this.Controls.Add(this.stateText);
            this.Controls.Add(this.zipCodeLabel);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.cityText);
            this.Controls.Add(this.streerAddressText);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.streetAddressLabel);
            this.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Name = "AddressEntry";
            this.Text = "Address Entry Form By Tim Corey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cityText;
        private System.Windows.Forms.TextBox streerAddressText;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label streetAddressLabel;
        private System.Windows.Forms.TextBox zipCodeText;
        private System.Windows.Forms.TextBox stateText;
        private System.Windows.Forms.Label zipCodeLabel;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label addressEntryLabel;
        private System.Windows.Forms.Button saveAddressEntry;
    }
}