namespace NetworkComRoomTest
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxRefreshtime = new System.Windows.Forms.TextBox();
            this.chkBoxAutoPing = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnScanAll = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.columnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnRoomNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBoxTimer = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnScanAll);
            this.groupBox1.Controls.Add(this.dataGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 582);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Controls.Add(this.txtBoxTimer);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtBoxRefreshtime);
            this.groupBox2.Controls.Add(this.chkBoxAutoPing);
            this.groupBox2.Location = new System.Drawing.Point(0, 512);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(359, 34);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "(1 to 720 only)";
            // 
            // txtBoxRefreshtime
            // 
            this.txtBoxRefreshtime.Location = new System.Drawing.Point(227, 10);
            this.txtBoxRefreshtime.Name = "txtBoxRefreshtime";
            this.txtBoxRefreshtime.Size = new System.Drawing.Size(47, 20);
            this.txtBoxRefreshtime.TabIndex = 3;
            this.txtBoxRefreshtime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxRefreshtime.TextChanged += new System.EventHandler(this.txtBoxRefreshtime_TextChanged);
            // 
            // chkBoxAutoPing
            // 
            this.chkBoxAutoPing.Location = new System.Drawing.Point(5, 8);
            this.chkBoxAutoPing.Name = "chkBoxAutoPing";
            this.chkBoxAutoPing.Size = new System.Drawing.Size(72, 24);
            this.chkBoxAutoPing.TabIndex = 1;
            this.chkBoxAutoPing.Text = "Auto Ping";
            this.chkBoxAutoPing.UseVisualStyleBackColor = true;
            this.chkBoxAutoPing.CheckedChanged += new System.EventHandler(this.chkBoxAutoPing_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 562);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Brian P.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 557);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "By:";
            // 
            // btnScanAll
            // 
            this.btnScanAll.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnScanAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanAll.Location = new System.Drawing.Point(146, 548);
            this.btnScanAll.Name = "btnScanAll";
            this.btnScanAll.Size = new System.Drawing.Size(75, 30);
            this.btnScanAll.TabIndex = 1;
            this.btnScanAll.Text = "Scan All";
            this.btnScanAll.UseVisualStyleBackColor = false;
            this.btnScanAll.Click += new System.EventHandler(this.btnScanAll_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnID,
            this.columnRoomNumber,
            this.columnIP,
            this.columnStatus,
            this.PingTime});
            this.dataGridView.Enabled = false;
            this.dataGridView.Location = new System.Drawing.Point(0, 7);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
            this.dataGridView.Size = new System.Drawing.Size(359, 509);
            this.dataGridView.TabIndex = 0;
            // 
            // columnID
            // 
            this.columnID.HeaderText = "ID";
            this.columnID.Name = "columnID";
            this.columnID.ReadOnly = true;
            this.columnID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.columnID.Width = 35;
            // 
            // columnRoomNumber
            // 
            this.columnRoomNumber.HeaderText = "Room #";
            this.columnRoomNumber.Name = "columnRoomNumber";
            this.columnRoomNumber.ReadOnly = true;
            this.columnRoomNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnRoomNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.columnRoomNumber.Width = 45;
            // 
            // columnIP
            // 
            this.columnIP.HeaderText = "IP Address";
            this.columnIP.Name = "columnIP";
            this.columnIP.ReadOnly = true;
            this.columnIP.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnIP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // columnStatus
            // 
            this.columnStatus.HeaderText = "Online Status";
            this.columnStatus.Name = "columnStatus";
            this.columnStatus.ReadOnly = true;
            this.columnStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // PingTime
            // 
            this.PingTime.HeaderText = "Ping (ms)";
            this.PingTime.Name = "PingTime";
            this.PingTime.ReadOnly = true;
            this.PingTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PingTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.PingTime.Width = 75;
            // 
            // txtBoxTimer
            // 
            this.txtBoxTimer.Location = new System.Drawing.Point(92, 10);
            this.txtBoxTimer.Name = "txtBoxTimer";
            this.txtBoxTimer.ReadOnly = true;
            this.txtBoxTimer.Size = new System.Drawing.Size(103, 20);
            this.txtBoxTimer.TabIndex = 1;
            this.txtBoxTimer.TabStop = false;
            this.txtBoxTimer.Text = "Timer Off";
            this.txtBoxTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxTimer.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(383, 626);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comunication Room Status";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnScanAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnRoomNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PingTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBoxRefreshtime;
        private System.Windows.Forms.CheckBox chkBoxAutoPing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxTimer;
    }
}

