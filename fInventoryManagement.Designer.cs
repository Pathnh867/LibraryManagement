namespace LibraryManagement
{
    partial class fInventoryManagement
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
            pnlLostBookInfo = new Panel();
            lblNotes = new Label();
            txtReason = new TextBox();
            lblReason = new Label();
            dateTimePicker1 = new DateTimePicker();
            cboEmployee = new ComboBox();
            txtBookTitle = new TextBox();
            btnSelectCopy = new Button();
            txtDescription = new TextBox();
            lblReportDate = new Label();
            lblEmployee = new Label();
            lblBookTitle = new Label();
            txtCopyId = new TextBox();
            lblCopyId = new Label();
            txtLostBookId = new TextBox();
            lblInventoryId = new Label();
            lblInventoryInfo = new Label();
            pnlLostBookInfo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLostBookInfo
            // 
            pnlLostBookInfo.BackColor = Color.White;
            pnlLostBookInfo.Controls.Add(lblNotes);
            pnlLostBookInfo.Controls.Add(txtReason);
            pnlLostBookInfo.Controls.Add(lblReason);
            pnlLostBookInfo.Controls.Add(dateTimePicker1);
            pnlLostBookInfo.Controls.Add(cboEmployee);
            pnlLostBookInfo.Controls.Add(txtBookTitle);
            pnlLostBookInfo.Controls.Add(btnSelectCopy);
            pnlLostBookInfo.Controls.Add(txtDescription);
            pnlLostBookInfo.Controls.Add(lblReportDate);
            pnlLostBookInfo.Controls.Add(lblEmployee);
            pnlLostBookInfo.Controls.Add(lblBookTitle);
            pnlLostBookInfo.Controls.Add(txtCopyId);
            pnlLostBookInfo.Controls.Add(lblCopyId);
            pnlLostBookInfo.Controls.Add(txtLostBookId);
            pnlLostBookInfo.Controls.Add(lblInventoryId);
            pnlLostBookInfo.Controls.Add(lblInventoryInfo);
            pnlLostBookInfo.Location = new Point(20, 20);
            pnlLostBookInfo.Name = "pnlLostBookInfo";
            pnlLostBookInfo.Size = new Size(930, 200);
            pnlLostBookInfo.TabIndex = 2;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.BackColor = Color.White;
            lblNotes.ForeColor = Color.FromArgb(94, 76, 76);
            lblNotes.Location = new Point(450, 125);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(61, 20);
            lblNotes.TabIndex = 17;
            lblNotes.Text = "Ghi chú:";
            // 
            // txtReason
            // 
            txtReason.Location = new Point(550, 52);
            txtReason.MaxLength = 200;
            txtReason.Multiline = true;
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(350, 50);
            txtReason.TabIndex = 4;
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.BackColor = Color.White;
            lblReason.ForeColor = Color.FromArgb(94, 76, 76);
            lblReason.Location = new Point(450, 55);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(47, 20);
            lblReason.TabIndex = 15;
            lblReason.Text = "Lý do:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(155, 192);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(126, 27);
            dateTimePicker1.TabIndex = 3;
            // 
            // cboEmployee
            // 
            cboEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEmployee.FormattingEnabled = true;
            cboEmployee.Location = new Point(155, 157);
            cboEmployee.Name = "cboEmployee";
            cboEmployee.Size = new Size(250, 28);
            cboEmployee.TabIndex = 2;
            // 
            // txtBookTitle
            // 
            txtBookTitle.Location = new Point(155, 122);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.ReadOnly = true;
            txtBookTitle.Size = new Size(250, 27);
            txtBookTitle.TabIndex = 12;
            // 
            // btnSelectCopy
            // 
            btnSelectCopy.BackColor = Color.MediumAquamarine;
            btnSelectCopy.FlatAppearance.BorderSize = 0;
            btnSelectCopy.FlatStyle = FlatStyle.Flat;
            btnSelectCopy.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelectCopy.ForeColor = Color.White;
            btnSelectCopy.Location = new Point(315, 87);
            btnSelectCopy.Name = "btnSelectCopy";
            btnSelectCopy.Size = new Size(80, 27);
            btnSelectCopy.TabIndex = 1;
            btnSelectCopy.Text = "Chọn";
            btnSelectCopy.UseVisualStyleBackColor = false;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(550, 122);
            txtDescription.MaxLength = 500;
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(350, 130);
            txtDescription.TabIndex = 5;
            // 
            // lblReportDate
            // 
            lblReportDate.AutoSize = true;
            lblReportDate.BackColor = Color.White;
            lblReportDate.ForeColor = Color.FromArgb(94, 76, 76);
            lblReportDate.Location = new Point(15, 195);
            lblReportDate.Name = "lblReportDate";
            lblReportDate.Size = new Size(105, 20);
            lblReportDate.TabIndex = 9;
            lblReportDate.Text = "Ngày báo cáo:";
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.BackColor = Color.White;
            lblEmployee.ForeColor = Color.FromArgb(94, 76, 76);
            lblEmployee.Location = new Point(15, 160);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(112, 20);
            lblEmployee.TabIndex = 7;
            lblEmployee.Text = "Người báo cáo:";
            // 
            // lblBookTitle
            // 
            lblBookTitle.AutoSize = true;
            lblBookTitle.BackColor = Color.White;
            lblBookTitle.ForeColor = Color.FromArgb(94, 76, 76);
            lblBookTitle.Location = new Point(15, 125);
            lblBookTitle.Name = "lblBookTitle";
            lblBookTitle.Size = new Size(68, 20);
            lblBookTitle.TabIndex = 5;
            lblBookTitle.Text = "Tên sách:";
            // 
            // txtCopyId
            // 
            txtCopyId.CharacterCasing = CharacterCasing.Upper;
            txtCopyId.Location = new Point(155, 87);
            txtCopyId.MaxLength = 10;
            txtCopyId.Name = "txtCopyId";
            txtCopyId.ReadOnly = true;
            txtCopyId.Size = new Size(150, 27);
            txtCopyId.TabIndex = 0;
            // 
            // lblCopyId
            // 
            lblCopyId.AutoSize = true;
            lblCopyId.BackColor = Color.White;
            lblCopyId.ForeColor = Color.FromArgb(94, 76, 76);
            lblCopyId.Location = new Point(15, 90);
            lblCopyId.Name = "lblCopyId";
            lblCopyId.Size = new Size(89, 20);
            lblCopyId.TabIndex = 3;
            lblCopyId.Text = "Mã bản sao:";
            // 
            // txtLostBookId
            // 
            txtLostBookId.Enabled = false;
            txtLostBookId.Location = new Point(155, 52);
            txtLostBookId.Name = "txtLostBookId";
            txtLostBookId.Size = new Size(200, 27);
            txtLostBookId.TabIndex = 2;
            // 
            // lblInventoryId
            // 
            lblInventoryId.AutoSize = true;
            lblInventoryId.BackColor = Color.White;
            lblInventoryId.ForeColor = Color.FromArgb(94, 76, 76);
            lblInventoryId.Location = new Point(15, 55);
            lblInventoryId.Name = "lblInventoryId";
            lblInventoryId.Size = new Size(85, 20);
            lblInventoryId.TabIndex = 1;
            lblInventoryId.Text = "Mã kiểm kê";
            // 
            // lblInventoryInfo
            // 
            lblInventoryInfo.AutoSize = true;
            lblInventoryInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInventoryInfo.ForeColor = Color.FromArgb(210, 121, 106);
            lblInventoryInfo.Location = new Point(15, 15);
            lblInventoryInfo.Name = "lblInventoryInfo";
            lblInventoryInfo.Size = new Size(209, 28);
            lblInventoryInfo.TabIndex = 0;
            lblInventoryInfo.Text = "THÔNG TIN KIỂM KÊ";
            // 
            // fInventoryManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 241, 240);
            ClientSize = new Size(970, 650);
            Controls.Add(pnlLostBookInfo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fInventoryManagement";
            Text = "Form1";
            pnlLostBookInfo.ResumeLayout(false);
            pnlLostBookInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLostBookInfo;
        private Label lblNotes;
        private TextBox txtReason;
        private Label lblReason;
        private DateTimePicker dateTimePicker1;
        private ComboBox cboEmployee;
        private TextBox txtBookTitle;
        private Button btnSelectCopy;
        private TextBox txtDescription;
        private Label lblReportDate;
        private Label lblEmployee;
        private Label lblBookTitle;
        private TextBox txtCopyId;
        private Label lblCopyId;
        private TextBox txtLostBookId;
        private Label lblInventoryId;
        private Label lblInventoryInfo;
    }
}