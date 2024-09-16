namespace Maestro_Resizer
{
    partial class fmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
            this.dgwData = new System.Windows.Forms.DataGridView();
            this.CommandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disabled = new System.Windows.Forms.DataGridViewImageColumn();
            this.IsDisabled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBackToInstalled = new System.Windows.Forms.Button();
            this.pInstalled = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pbxInfo = new System.Windows.Forms.PictureBox();
            this.lblExtensions = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnCreateToggle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwData)).BeginInit();
            this.pInstalled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwData
            // 
            this.dgwData.AllowUserToAddRows = false;
            this.dgwData.AllowUserToDeleteRows = false;
            this.dgwData.AllowUserToResizeColumns = false;
            this.dgwData.AllowUserToResizeRows = false;
            this.dgwData.BackgroundColor = System.Drawing.Color.White;
            this.dgwData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgwData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgwData.ColumnHeadersHeight = 29;
            this.dgwData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgwData.ColumnHeadersVisible = false;
            this.dgwData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CommandName,
            this.Disabled,
            this.IsDisabled});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgwData.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgwData.GridColor = System.Drawing.Color.Gainsboro;
            this.dgwData.Location = new System.Drawing.Point(0, 0);
            this.dgwData.Name = "dgwData";
            this.dgwData.RowHeadersVisible = false;
            this.dgwData.RowHeadersWidth = 51;
            this.dgwData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgwData.RowTemplate.Height = 36;
            this.dgwData.RowTemplate.ReadOnly = true;
            this.dgwData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwData.Size = new System.Drawing.Size(457, 254);
            this.dgwData.TabIndex = 1;
            this.dgwData.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgwData_CellMouseDown);
            this.dgwData.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwData_CellMouseEnter);
            this.dgwData.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwData_CellMouseLeave);
            // 
            // CommandName
            // 
            this.CommandName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.CommandName.DefaultCellStyle = dataGridViewCellStyle1;
            this.CommandName.HeaderText = "CommandName";
            this.CommandName.MinimumWidth = 6;
            this.CommandName.Name = "CommandName";
            // 
            // Disabled
            // 
            this.Disabled.HeaderText = "Disabled";
            this.Disabled.MinimumWidth = 6;
            this.Disabled.Name = "Disabled";
            this.Disabled.Width = 36;
            // 
            // IsDisabled
            // 
            this.IsDisabled.HeaderText = "IsDisabled";
            this.IsDisabled.MinimumWidth = 6;
            this.IsDisabled.Name = "IsDisabled";
            this.IsDisabled.Visible = false;
            this.IsDisabled.Width = 125;
            // 
            // btnBackToInstalled
            // 
            this.btnBackToInstalled.BackColor = System.Drawing.Color.White;
            this.btnBackToInstalled.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBackToInstalled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToInstalled.ForeColor = System.Drawing.Color.White;
            this.btnBackToInstalled.Image = global::Maestro_Resizer.Properties.Resources.back;
            this.btnBackToInstalled.Location = new System.Drawing.Point(12, 271);
            this.btnBackToInstalled.Name = "btnBackToInstalled";
            this.btnBackToInstalled.Size = new System.Drawing.Size(33, 33);
            this.btnBackToInstalled.TabIndex = 5;
            this.btnBackToInstalled.UseVisualStyleBackColor = false;
            this.btnBackToInstalled.Click += new System.EventHandler(this.btnBackToInstalled_Click);
            // 
            // pInstalled
            // 
            this.pInstalled.Controls.Add(this.btnSettings);
            this.pInstalled.Controls.Add(this.pbxInfo);
            this.pInstalled.Controls.Add(this.lblExtensions);
            this.pInstalled.Controls.Add(this.lblInfo);
            this.pInstalled.Controls.Add(this.btnCreateToggle);
            this.pInstalled.Location = new System.Drawing.Point(0, 0);
            this.pInstalled.Name = "pInstalled";
            this.pInstalled.Size = new System.Drawing.Size(457, 315);
            this.pInstalled.TabIndex = 3;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.White;
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = global::Maestro_Resizer.Properties.Resources.settings;
            this.btnSettings.Location = new System.Drawing.Point(308, 252);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(33, 33);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // pbxInfo
            // 
            this.pbxInfo.Image = global::Maestro_Resizer.Properties.Resources.success;
            this.pbxInfo.Location = new System.Drawing.Point(178, 45);
            this.pbxInfo.Name = "pbxInfo";
            this.pbxInfo.Size = new System.Drawing.Size(100, 100);
            this.pbxInfo.TabIndex = 3;
            this.pbxInfo.TabStop = false;
            // 
            // lblExtensions
            // 
            this.lblExtensions.AutoSize = true;
            this.lblExtensions.ForeColor = System.Drawing.Color.DimGray;
            this.lblExtensions.Location = new System.Drawing.Point(146, 189);
            this.lblExtensions.Name = "lblExtensions";
            this.lblExtensions.Size = new System.Drawing.Size(176, 20);
            this.lblExtensions.TabIndex = 2;
            this.lblExtensions.Text = "JPG, JPEG, PNG, BMP, TIFF";
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfo.Location = new System.Drawing.Point(20, 158);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(416, 23);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Пункт меню «Изменить размер» добавлен";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCreateToggle
            // 
            this.btnCreateToggle.BackColor = System.Drawing.Color.Firebrick;
            this.btnCreateToggle.FlatAppearance.BorderSize = 0;
            this.btnCreateToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateToggle.ForeColor = System.Drawing.Color.White;
            this.btnCreateToggle.Location = new System.Drawing.Point(115, 252);
            this.btnCreateToggle.Name = "btnCreateToggle";
            this.btnCreateToggle.Size = new System.Drawing.Size(187, 33);
            this.btnCreateToggle.TabIndex = 0;
            this.btnCreateToggle.Text = "Убрать пункт меню";
            this.btnCreateToggle.UseVisualStyleBackColor = false;
            this.btnCreateToggle.Click += new System.EventHandler(this.btnCreateToggle_Click);
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(457, 316);
            this.Controls.Add(this.pInstalled);
            this.Controls.Add(this.btnBackToInstalled);
            this.Controls.Add(this.dgwData);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maestro Resizer";
            this.Load += new System.EventHandler(this.fmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwData)).EndInit();
            this.pInstalled.ResumeLayout(false);
            this.pInstalled.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgwData;
        private System.Windows.Forms.Button btnBackToInstalled;
        private System.Windows.Forms.Panel pInstalled;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.PictureBox pbxInfo;
        private System.Windows.Forms.Label lblExtensions;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnCreateToggle;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommandName;
        private System.Windows.Forms.DataGridViewImageColumn Disabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDisabled;
    }
}