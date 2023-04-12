namespace RecipePlannerFinalDemoAdditions
{
    partial class RecipeTagAdd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tagNameTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.tagsDataGridView = new System.Windows.Forms.DataGridView();
            this.tagNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.removeColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorTagFieldLabel = new System.Windows.Forms.Label();
            this.tagSuccessLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tagsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(140, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Recipe Tags";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tag Name:";
            // 
            // tagNameTextBox
            // 
            this.tagNameTextBox.Location = new System.Drawing.Point(109, 165);
            this.tagNameTextBox.Name = "tagNameTextBox";
            this.tagNameTextBox.Size = new System.Drawing.Size(125, 27);
            this.tagNameTextBox.TabIndex = 2;
            this.tagNameTextBox.Click += new System.EventHandler(this.tagNameTextBox_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(344, 163);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(94, 29);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // tagsDataGridView
            // 
            this.tagsDataGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tagsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tagsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tagsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tagNameColumn,
            this.removeColumn});
            this.tagsDataGridView.Location = new System.Drawing.Point(119, 285);
            this.tagsDataGridView.Name = "tagsDataGridView";
            this.tagsDataGridView.RowHeadersVisible = false;
            this.tagsDataGridView.RowHeadersWidth = 51;
            this.tagsDataGridView.RowTemplate.Height = 29;
            this.tagsDataGridView.Size = new System.Drawing.Size(265, 234);
            this.tagsDataGridView.TabIndex = 4;
            this.tagsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tagsDataGridView_CellContentClick);
            // 
            // tagNameColumn
            // 
            this.tagNameColumn.HeaderText = "Tag Name";
            this.tagNameColumn.MinimumWidth = 6;
            this.tagNameColumn.Name = "tagNameColumn";
            this.tagNameColumn.Width = 125;
            // 
            // removeColumn
            // 
            this.removeColumn.HeaderText = "Action";
            this.removeColumn.MinimumWidth = 6;
            this.removeColumn.Name = "removeColumn";
            this.removeColumn.Text = "Remove";
            this.removeColumn.UseColumnTextForButtonValue = true;
            this.removeColumn.Width = 125;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(140, 625);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(94, 29);
            this.confirmButton.TabIndex = 5;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(276, 625);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 29);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // errorTagFieldLabel
            // 
            this.errorTagFieldLabel.AutoSize = true;
            this.errorTagFieldLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.errorTagFieldLabel.ForeColor = System.Drawing.Color.Red;
            this.errorTagFieldLabel.Location = new System.Drawing.Point(308, 132);
            this.errorTagFieldLabel.Name = "errorTagFieldLabel";
            this.errorTagFieldLabel.Size = new System.Drawing.Size(165, 20);
            this.errorTagFieldLabel.TabIndex = 7;
            this.errorTagFieldLabel.Text = "Please fill out tag field";
            this.errorTagFieldLabel.Visible = false;
            // 
            // tagSuccessLabel
            // 
            this.tagSuccessLabel.AutoSize = true;
            this.tagSuccessLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tagSuccessLabel.ForeColor = System.Drawing.Color.Green;
            this.tagSuccessLabel.Location = new System.Drawing.Point(308, 132);
            this.tagSuccessLabel.Name = "tagSuccessLabel";
            this.tagSuccessLabel.Size = new System.Drawing.Size(172, 20);
            this.tagSuccessLabel.TabIndex = 8;
            this.tagSuccessLabel.Text = "Tag Added Successfully";
            this.tagSuccessLabel.Visible = false;
            // 
            // RecipeTagAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 823);
            this.Controls.Add(this.tagSuccessLabel);
            this.Controls.Add(this.errorTagFieldLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.tagsDataGridView);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.tagNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RecipeTagAdd";
            this.Text = "RecipeTagAdd";
            this.Load += new System.EventHandler(this.RecipeTagAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tagsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tagNameTextBox;
        private Button addButton;
        private DataGridView tagsDataGridView;
        private DataGridViewTextBoxColumn tagNameColumn;
        private DataGridViewButtonColumn removeColumn;
        private Button confirmButton;
        private Button cancelButton;
        private Label errorTagFieldLabel;
        private Label tagSuccessLabel;
    }
}