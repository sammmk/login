﻿namespace MetaData.CLL
{
    partial class FrmEditDestinations
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
            this.pnl_editDealers = new System.Windows.Forms.Panel();
            this.splt_editDestinations = new System.Windows.Forms.SplitContainer();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.cmb_search = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grd_editDestination = new System.Windows.Forms.DataGridView();
            this.pnl_editDealers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splt_editDestinations)).BeginInit();
            this.splt_editDestinations.Panel1.SuspendLayout();
            this.splt_editDestinations.Panel2.SuspendLayout();
            this.splt_editDestinations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_editDestination)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_editDealers
            // 
            this.pnl_editDealers.Controls.Add(this.splt_editDestinations);
            this.pnl_editDealers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_editDealers.Location = new System.Drawing.Point(0, 0);
            this.pnl_editDealers.Name = "pnl_editDealers";
            this.pnl_editDealers.Size = new System.Drawing.Size(659, 435);
            this.pnl_editDealers.TabIndex = 1;
            // 
            // splt_editDestinations
            // 
            this.splt_editDestinations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splt_editDestinations.Location = new System.Drawing.Point(0, 0);
            this.splt_editDestinations.Name = "splt_editDestinations";
            this.splt_editDestinations.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splt_editDestinations.Panel1
            // 
            this.splt_editDestinations.Panel1.Controls.Add(this.txt_search);
            this.splt_editDestinations.Panel1.Controls.Add(this.cmb_search);
            this.splt_editDestinations.Panel1.Controls.Add(this.label1);
            // 
            // splt_editDestinations.Panel2
            // 
            this.splt_editDestinations.Panel2.Controls.Add(this.grd_editDestination);
            this.splt_editDestinations.Size = new System.Drawing.Size(659, 435);
            this.splt_editDestinations.SplitterDistance = 53;
            this.splt_editDestinations.TabIndex = 1;
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(267, 25);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(186, 19);
            this.txt_search.TabIndex = 2;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // cmb_search
            // 
            this.cmb_search.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_search.FormattingEnabled = true;
            this.cmb_search.Items.AddRange(new object[] {
            "<<Select>>",
            "ALL",
            "Destination Name",
            "Owner Name"});
            this.cmb_search.Location = new System.Drawing.Point(117, 24);
            this.cmb_search.Name = "cmb_search";
            this.cmb_search.Size = new System.Drawing.Size(131, 20);
            this.cmb_search.TabIndex = 1;
            this.cmb_search.SelectedIndexChanged += new System.EventHandler(this.cmb_search_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seach By :";
            // 
            // grd_editDestination
            // 
            this.grd_editDestination.AllowUserToAddRows = false;
            this.grd_editDestination.AllowUserToDeleteRows = false;
            this.grd_editDestination.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_editDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_editDestination.Location = new System.Drawing.Point(0, 0);
            this.grd_editDestination.Name = "grd_editDestination";
            this.grd_editDestination.ReadOnly = true;
            this.grd_editDestination.RowTemplate.Height = 21;
            this.grd_editDestination.Size = new System.Drawing.Size(659, 378);
            this.grd_editDestination.TabIndex = 0;
            this.grd_editDestination.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_editDestination_CellContentClick);
            // 
            // FrmEditDestinations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(659, 435);
            this.Controls.Add(this.pnl_editDealers);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditDestinations";
            this.Text = "Edit Destinations";
            this.Load += new System.EventHandler(this.FrmEditDestinations_Load);
            this.pnl_editDealers.ResumeLayout(false);
            this.splt_editDestinations.Panel1.ResumeLayout(false);
            this.splt_editDestinations.Panel1.PerformLayout();
            this.splt_editDestinations.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splt_editDestinations)).EndInit();
            this.splt_editDestinations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_editDestination)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_editDealers;
        private System.Windows.Forms.SplitContainer splt_editDestinations;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.ComboBox cmb_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grd_editDestination;
    }
}