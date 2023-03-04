namespace RecipePlannerDesktopApplication
{
    partial class PlannedMealsPage
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mondayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tuesdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wednesdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thursdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fridayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saturdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sundayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(143, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "This Week\'s Meals";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mondayColumn,
            this.tuesdayColumn,
            this.wednesdayColumn,
            this.thursdayColumn,
            this.fridayColumn,
            this.saturdayColumn,
            this.sundayColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 134);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(932, 456);
            this.dataGridView1.TabIndex = 1;
            // 
            // mondayColumn
            // 
            this.mondayColumn.HeaderText = "Monday";
            this.mondayColumn.MinimumWidth = 6;
            this.mondayColumn.Name = "mondayColumn";
            this.mondayColumn.ReadOnly = true;
            this.mondayColumn.Width = 125;
            // 
            // tuesdayColumn
            // 
            this.tuesdayColumn.HeaderText = "Tuesday";
            this.tuesdayColumn.MinimumWidth = 6;
            this.tuesdayColumn.Name = "tuesdayColumn";
            this.tuesdayColumn.ReadOnly = true;
            this.tuesdayColumn.Width = 125;
            // 
            // wednesdayColumn
            // 
            this.wednesdayColumn.HeaderText = "Wednesday";
            this.wednesdayColumn.MinimumWidth = 6;
            this.wednesdayColumn.Name = "wednesdayColumn";
            this.wednesdayColumn.ReadOnly = true;
            this.wednesdayColumn.Width = 125;
            // 
            // thursdayColumn
            // 
            this.thursdayColumn.HeaderText = "Thursday";
            this.thursdayColumn.MinimumWidth = 6;
            this.thursdayColumn.Name = "thursdayColumn";
            this.thursdayColumn.ReadOnly = true;
            this.thursdayColumn.Width = 125;
            // 
            // fridayColumn
            // 
            this.fridayColumn.HeaderText = "Friday";
            this.fridayColumn.MinimumWidth = 6;
            this.fridayColumn.Name = "fridayColumn";
            this.fridayColumn.ReadOnly = true;
            this.fridayColumn.Width = 125;
            // 
            // saturdayColumn
            // 
            this.saturdayColumn.HeaderText = "Saturday";
            this.saturdayColumn.MinimumWidth = 6;
            this.saturdayColumn.Name = "saturdayColumn";
            this.saturdayColumn.ReadOnly = true;
            this.saturdayColumn.Width = 125;
            // 
            // sundayColumn
            // 
            this.sundayColumn.HeaderText = "Sunday";
            this.sundayColumn.MinimumWidth = 6;
            this.sundayColumn.Name = "sundayColumn";
            this.sundayColumn.ReadOnly = true;
            this.sundayColumn.Width = 125;
            // 
            // PlannedMealsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 804);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "PlannedMealsPage";
            this.Text = "PlannedMealsPage";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn mondayColumn;
        private DataGridViewTextBoxColumn tuesdayColumn;
        private DataGridViewTextBoxColumn wednesdayColumn;
        private DataGridViewTextBoxColumn thursdayColumn;
        private DataGridViewTextBoxColumn fridayColumn;
        private DataGridViewTextBoxColumn saturdayColumn;
        private DataGridViewTextBoxColumn sundayColumn;
    }
}