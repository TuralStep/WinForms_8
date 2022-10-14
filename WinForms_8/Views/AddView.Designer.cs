namespace WinForms_8.Views
{
    partial class AddView
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
            this.txt_firstName = new System.Windows.Forms.TextBox();
            this.txt_lastName = new System.Windows.Forms.TextBox();
            this.numeric_score = new System.Windows.Forms.NumericUpDown();
            this.btn_save = new System.Windows.Forms.Button();
            this.datePicker_birth = new System.Windows.Forms.MonthCalendar();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_score)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_firstName
            // 
            this.txt_firstName.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txt_firstName.Location = new System.Drawing.Point(16, 35);
            this.txt_firstName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_firstName.Name = "txt_firstName";
            this.txt_firstName.PlaceholderText = "First Name";
            this.txt_firstName.Size = new System.Drawing.Size(234, 36);
            this.txt_firstName.TabIndex = 0;
            // 
            // txt_lastName
            // 
            this.txt_lastName.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txt_lastName.Location = new System.Drawing.Point(16, 98);
            this.txt_lastName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_lastName.Name = "txt_lastName";
            this.txt_lastName.PlaceholderText = "Last Name";
            this.txt_lastName.Size = new System.Drawing.Size(234, 36);
            this.txt_lastName.TabIndex = 1;
            // 
            // numeric_score
            // 
            this.numeric_score.DecimalPlaces = 1;
            this.numeric_score.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numeric_score.Location = new System.Drawing.Point(13, 161);
            this.numeric_score.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.numeric_score.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numeric_score.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_score.Name = "numeric_score";
            this.numeric_score.Size = new System.Drawing.Size(237, 36);
            this.numeric_score.TabIndex = 2;
            this.numeric_score.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Green;
            this.btn_save.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_save.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_save.Location = new System.Drawing.Point(27, 213);
            this.btn_save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(211, 41);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // datePicker_birth
            // 
            this.datePicker_birth.Location = new System.Drawing.Point(274, 35);
            this.datePicker_birth.Margin = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.datePicker_birth.MaxSelectionCount = 1;
            this.datePicker_birth.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.datePicker_birth.Name = "datePicker_birth";
            this.datePicker_birth.ShowToday = false;
            this.datePicker_birth.TabIndex = 7;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Red;
            this.btn_cancel.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_cancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_cancel.Location = new System.Drawing.Point(262, 213);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(211, 41);
            this.btn_cancel.TabIndex = 8;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Date of Birth";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Name and Score";
            // 
            // AddView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 270);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.datePicker_birth);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.numeric_score);
            this.Controls.Add(this.txt_lastName);
            this.Controls.Add(this.txt_firstName);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Page";
            ((System.ComponentModel.ISupportInitialize)(this.numeric_score)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btn_save;
        private Button btn_cancel;
        private Label label1;
        private Label label2;
        public TextBox txt_firstName;
        public TextBox txt_lastName;
        public NumericUpDown numeric_score;
        public MonthCalendar datePicker_birth;
    }
}