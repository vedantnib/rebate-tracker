
namespace Asg2_vxn200012
{
    partial class rebateForm
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
            this.components = new System.ComponentModel.Container();
            this.displayDetailsView = new System.Windows.Forms.ListView();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.firstName = new System.Windows.Forms.TextBox();
            this.midName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addLine1 = new System.Windows.Forms.TextBox();
            this.addLine2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cityBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.zipCode = new System.Windows.Forms.TextBox();
            this.stateBox = new System.Windows.Forms.TextBox();
            this.gender = new System.Windows.Forms.TextBox();
            this.phoneNumber = new System.Windows.Forms.TextBox();
            this.emailAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.yesRButton = new System.Windows.Forms.RadioButton();
            this.noRButton = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.dateReceived = new System.Windows.Forms.DateTimePicker();
            this.saveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // displayDetailsView
            // 
            this.displayDetailsView.FullRowSelect = true;
            this.displayDetailsView.HideSelection = false;
            this.displayDetailsView.Location = new System.Drawing.Point(12, 36);
            this.displayDetailsView.Name = "displayDetailsView";
            this.displayDetailsView.Size = new System.Drawing.Size(319, 736);
            this.displayDetailsView.TabIndex = 2;
            this.displayDetailsView.UseCompatibleStateImageBehavior = false;
            this.displayDetailsView.SelectedIndexChanged += new System.EventHandler(this.displayDetailsView_SelectedIndexChanged);
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(356, 36);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(86, 20);
            this.firstNameLabel.TabIndex = 3;
            this.firstNameLabel.Text = "First Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(589, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Middle Name";
            // 
            // firstName
            // 
            this.firstName.Location = new System.Drawing.Point(356, 62);
            this.firstName.MaxLength = 25;
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(201, 26);
            this.firstName.TabIndex = 5;
            this.firstName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.firstName.Validating += new System.ComponentModel.CancelEventHandler(this.firstName_Validating);
            // 
            // midName
            // 
            this.midName.Location = new System.Drawing.Point(609, 62);
            this.midName.MaxLength = 1;
            this.midName.Name = "midName";
            this.midName.Size = new System.Drawing.Size(36, 26);
            this.midName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(713, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Last Name";
            // 
            // lastName
            // 
            this.lastName.Location = new System.Drawing.Point(717, 62);
            this.lastName.MaxLength = 25;
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(201, 26);
            this.lastName.TabIndex = 8;
            //this.lastName.TextChanged += new System.EventHandler(this.lastName_TextChanged);
            this.lastName.Validating += new System.ComponentModel.CancelEventHandler(this.lastName_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Address Line 1";
            // 
            // addLine1
            // 
            this.addLine1.Location = new System.Drawing.Point(356, 126);
            this.addLine1.MaxLength = 35;
            this.addLine1.Name = "addLine1";
            this.addLine1.Size = new System.Drawing.Size(201, 26);
            this.addLine1.TabIndex = 10;
            this.addLine1.Validating += new System.ComponentModel.CancelEventHandler(this.addLine1_Validating);
            // 
            // addLine2
            // 
            this.addLine2.Location = new System.Drawing.Point(356, 191);
            this.addLine2.MaxLength = 35;
            this.addLine2.Name = "addLine2";
            this.addLine2.Size = new System.Drawing.Size(201, 26);
            this.addLine2.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(352, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Address Line 2";
            // 
            // cityBox
            // 
            this.cityBox.Location = new System.Drawing.Point(356, 256);
            this.cityBox.MaxLength = 25;
            this.cityBox.Name = "cityBox";
            this.cityBox.Size = new System.Drawing.Size(201, 26);
            this.cityBox.TabIndex = 13;
            this.cityBox.Validating += new System.ComponentModel.CancelEventHandler(this.cityBox_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(356, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "City";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(605, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "State";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(356, 297);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Zip code";
            // 
            // zipCode
            // 
            this.zipCode.Location = new System.Drawing.Point(360, 335);
            this.zipCode.MaxLength = 9;
            this.zipCode.Name = "zipCode";
            this.zipCode.Size = new System.Drawing.Size(201, 26);
            this.zipCode.TabIndex = 18;
            // 
            // stateBox
            // 
            this.stateBox.Location = new System.Drawing.Point(609, 256);
            this.stateBox.MaxLength = 2;
            this.stateBox.Name = "stateBox";
            this.stateBox.Size = new System.Drawing.Size(56, 26);
            this.stateBox.TabIndex = 17;
            this.stateBox.Validating += new System.ComponentModel.CancelEventHandler(this.stateBox_Validating_1);
            // 
            // gender
            // 
            this.gender.Location = new System.Drawing.Point(609, 335);
            this.gender.MaxLength = 1;
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(31, 26);
            this.gender.TabIndex = 19;
            // 
            // phoneNumber
            // 
            this.phoneNumber.Location = new System.Drawing.Point(356, 408);
            this.phoneNumber.MaxLength = 10;
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.Size = new System.Drawing.Size(201, 26);
            this.phoneNumber.TabIndex = 20;
            // 
            // emailAddress
            // 
            this.emailAddress.Location = new System.Drawing.Point(360, 493);
            this.emailAddress.MaxLength = 60;
            this.emailAddress.Name = "emailAddress";
            this.emailAddress.Size = new System.Drawing.Size(201, 26);
            this.emailAddress.TabIndex = 21;
            this.emailAddress.Validating += new System.ComponentModel.CancelEventHandler(this.emailAddress_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(605, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Gender";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(356, 376);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Phone Number";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(356, 456);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 20);
            this.label10.TabIndex = 24;
            this.label10.Text = "Email Address";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(352, 559);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(220, 20);
            this.label11.TabIndex = 25;
            this.label11.Text = "Proof of purchased attached?";
            // 
            // yesRButton
            // 
            this.yesRButton.AutoSize = true;
            this.yesRButton.Location = new System.Drawing.Point(356, 582);
            this.yesRButton.Name = "yesRButton";
            this.yesRButton.Size = new System.Drawing.Size(55, 24);
            this.yesRButton.TabIndex = 26;
            this.yesRButton.TabStop = true;
            this.yesRButton.Text = "Yes";
            this.yesRButton.UseVisualStyleBackColor = true;
            // 
            // noRButton
            // 
            this.noRButton.AutoSize = true;
            this.noRButton.Location = new System.Drawing.Point(468, 582);
            this.noRButton.Name = "noRButton";
            this.noRButton.Size = new System.Drawing.Size(47, 24);
            this.noRButton.TabIndex = 27;
            this.noRButton.TabStop = true;
            this.noRButton.Text = "No";
            this.noRButton.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(356, 644);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 20);
            this.label12.TabIndex = 28;
            this.label12.Text = "Date";
            // 
            // dateReceived
            // 
            this.dateReceived.Location = new System.Drawing.Point(360, 667);
            this.dateReceived.Name = "dateReceived";
            this.dateReceived.Size = new System.Drawing.Size(265, 26);
            this.dateReceived.TabIndex = 29;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(360, 740);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 32);
            this.saveButton.TabIndex = 30;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(559, 740);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 32);
            this.deleteButton.TabIndex = 31;
            this.deleteButton.Text = "Delete ";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(751, 740);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 32);
            this.clearButton.TabIndex = 32;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 832);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(950, 22);
            this.statusStrip.TabIndex = 33;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(83, 17);
            this.statusLabel.Text = "Add New Data";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // rebateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 854);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.dateReceived);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.noRButton);
            this.Controls.Add(this.yesRButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.emailAddress);
            this.Controls.Add(this.phoneNumber);
            this.Controls.Add(this.gender);
            this.Controls.Add(this.stateBox);
            this.Controls.Add(this.zipCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cityBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addLine2);
            this.Controls.Add(this.addLine1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.midName);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.displayDetailsView);
            this.KeyPreview = true;
            this.Name = "rebateForm";
            this.Text = "Rebate Form";
            this.Load += new System.EventHandler(this.rebateForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView displayDetailsView;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.TextBox midName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox addLine1;
        private System.Windows.Forms.TextBox addLine2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cityBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox zipCode;
        private System.Windows.Forms.TextBox stateBox;
        private System.Windows.Forms.TextBox gender;
        private System.Windows.Forms.TextBox phoneNumber;
        private System.Windows.Forms.TextBox emailAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton yesRButton;
        private System.Windows.Forms.RadioButton noRButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateReceived;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}

