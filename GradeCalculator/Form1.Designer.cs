namespace GradeCalculator
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlAssignments = new System.Windows.Forms.Panel();
            this.dgvAssignments = new System.Windows.Forms.DataGridView();
            this.lblPercent = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lblSection = new System.Windows.Forms.Label();
            this.btnAddSection = new System.Windows.Forms.Button();
            this.btnAddAssignment = new System.Windows.Forms.Button();
            this.btnDeleteSection = new System.Windows.Forms.Button();
            this.btnDeleteAssignment = new System.Windows.Forms.Button();
            this.lblAverage = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstViewSections = new System.Windows.Forms.ListView();
            this.dgColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAssignments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(317, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grade Calculator";
            // 
            // pnlAssignments
            // 
            this.pnlAssignments.BackColor = System.Drawing.SystemColors.Control;
            this.pnlAssignments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAssignments.Controls.Add(this.dgvAssignments);
            this.pnlAssignments.Controls.Add(this.lblPercent);
            this.pnlAssignments.Controls.Add(this.txtWeight);
            this.pnlAssignments.Controls.Add(this.lblSection);
            this.pnlAssignments.Location = new System.Drawing.Point(267, 153);
            this.pnlAssignments.Name = "pnlAssignments";
            this.pnlAssignments.Size = new System.Drawing.Size(420, 357);
            this.pnlAssignments.TabIndex = 2;
            // 
            // dgvAssignments
            // 
            this.dgvAssignments.AllowUserToAddRows = false;
            this.dgvAssignments.AllowUserToDeleteRows = false;
            this.dgvAssignments.AllowUserToResizeColumns = false;
            this.dgvAssignments.AllowUserToResizeRows = false;
            this.dgvAssignments.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAssignments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssignments.ColumnHeadersVisible = false;
            this.dgvAssignments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgColumn1,
            this.dgColumn2});
            this.dgvAssignments.Location = new System.Drawing.Point(-1, 35);
            this.dgvAssignments.MultiSelect = false;
            this.dgvAssignments.Name = "dgvAssignments";
            this.dgvAssignments.RowHeadersVisible = false;
            this.dgvAssignments.Size = new System.Drawing.Size(420, 321);
            this.dgvAssignments.TabIndex = 9;
            this.dgvAssignments.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvAssignments_CellValidating);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.Location = new System.Drawing.Point(394, 7);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(21, 19);
            this.lblPercent.TabIndex = 2;
            this.lblPercent.Text = "%";
            // 
            // txtWeight
            // 
            this.txtWeight.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.Location = new System.Drawing.Point(344, 8);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(44, 21);
            this.txtWeight.TabIndex = 1;
            this.txtWeight.Enter += new System.EventHandler(this.txtWeight_Enter);
            this.txtWeight.Validating += new System.ComponentModel.CancelEventHandler(this.txtWeight_Validating);
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblSection.Location = new System.Drawing.Point(5, 4);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(68, 23);
            this.lblSection.TabIndex = 0;
            this.lblSection.Text = "Section";
            // 
            // btnAddSection
            // 
            this.btnAddSection.Location = new System.Drawing.Point(13, 153);
            this.btnAddSection.Name = "btnAddSection";
            this.btnAddSection.Size = new System.Drawing.Size(104, 23);
            this.btnAddSection.TabIndex = 4;
            this.btnAddSection.Text = "Add Section";
            this.btnAddSection.UseVisualStyleBackColor = true;
            this.btnAddSection.Click += new System.EventHandler(this.btnAddSection_Click);
            // 
            // btnAddAssignment
            // 
            this.btnAddAssignment.Location = new System.Drawing.Point(13, 183);
            this.btnAddAssignment.Name = "btnAddAssignment";
            this.btnAddAssignment.Size = new System.Drawing.Size(104, 23);
            this.btnAddAssignment.TabIndex = 5;
            this.btnAddAssignment.Text = "Add Assignment";
            this.btnAddAssignment.UseVisualStyleBackColor = true;
            this.btnAddAssignment.Click += new System.EventHandler(this.btnAddAssignment_Click);
            // 
            // btnDeleteSection
            // 
            this.btnDeleteSection.Location = new System.Drawing.Point(13, 213);
            this.btnDeleteSection.Name = "btnDeleteSection";
            this.btnDeleteSection.Size = new System.Drawing.Size(104, 23);
            this.btnDeleteSection.TabIndex = 6;
            this.btnDeleteSection.Text = "Delete Section";
            this.btnDeleteSection.UseVisualStyleBackColor = true;
            this.btnDeleteSection.Click += new System.EventHandler(this.btnDeleteSection_Click);
            // 
            // btnDeleteAssignment
            // 
            this.btnDeleteAssignment.Location = new System.Drawing.Point(13, 243);
            this.btnDeleteAssignment.Name = "btnDeleteAssignment";
            this.btnDeleteAssignment.Size = new System.Drawing.Size(104, 23);
            this.btnDeleteAssignment.TabIndex = 7;
            this.btnDeleteAssignment.Text = "Delete Assignment";
            this.btnDeleteAssignment.UseVisualStyleBackColor = true;
            this.btnDeleteAssignment.Click += new System.EventHandler(this.btnDeleteAssignment_Click);
            // 
            // lblAverage
            // 
            this.lblAverage.AutoSize = true;
            this.lblAverage.Location = new System.Drawing.Point(12, 554);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(35, 13);
            this.lblAverage.TabIndex = 8;
            this.lblAverage.Text = "label2";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 124;
            // 
            // lstViewSections
            // 
            this.lstViewSections.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstViewSections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstViewSections.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstViewSections.FullRowSelect = true;
            this.lstViewSections.GridLines = true;
            this.lstViewSections.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstViewSections.Location = new System.Drawing.Point(133, 153);
            this.lstViewSections.MultiSelect = false;
            this.lstViewSections.Name = "lstViewSections";
            this.lstViewSections.Size = new System.Drawing.Size(128, 184);
            this.lstViewSections.TabIndex = 0;
            this.lstViewSections.UseCompatibleStateImageBehavior = false;
            this.lstViewSections.View = System.Windows.Forms.View.Details;
            this.lstViewSections.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstViewSections_ItemSelectionChanged);
            // 
            // dgColumn1
            // 
            this.dgColumn1.HeaderText = "Column0";
            this.dgColumn1.Name = "dgColumn1";
            this.dgColumn1.Width = 380;
            // 
            // dgColumn2
            // 
            this.dgColumn2.HeaderText = "Column1";
            this.dgColumn2.Name = "dgColumn2";
            this.dgColumn2.Width = 37;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 627);
            this.Controls.Add(this.lblAverage);
            this.Controls.Add(this.btnDeleteAssignment);
            this.Controls.Add(this.btnDeleteSection);
            this.Controls.Add(this.btnAddAssignment);
            this.Controls.Add(this.btnAddSection);
            this.Controls.Add(this.lstViewSections);
            this.Controls.Add(this.pnlAssignments);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.pnlAssignments.ResumeLayout(false);
            this.pnlAssignments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlAssignments;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.Button btnAddSection;
        private System.Windows.Forms.Button btnAddAssignment;
        private System.Windows.Forms.Button btnDeleteSection;
        private System.Windows.Forms.Button btnDeleteAssignment;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.DataGridView dgvAssignments;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lstViewSections;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgColumn2;
    }
}

