namespace RecipePlannerFinalDemoAdditions
{
    partial class RecipeStepAdd
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
            this.label3 = new System.Windows.Forms.Label();
            this.stepNumberTextBox = new System.Windows.Forms.TextBox();
            this.stepDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.stepsDataGridView = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorStepsFieldLabel = new System.Windows.Forms.Label();
            this.errorStepNumberLabel = new System.Windows.Forms.Label();
            this.stepsSuccessLabel = new System.Windows.Forms.Label();
            this.stepNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stepDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.removeColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.stepsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(142, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Recipe Steps";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Step Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Step Description:";
            // 
            // stepNumberTextBox
            // 
            this.stepNumberTextBox.Location = new System.Drawing.Point(131, 148);
            this.stepNumberTextBox.Name = "stepNumberTextBox";
            this.stepNumberTextBox.Size = new System.Drawing.Size(61, 27);
            this.stepNumberTextBox.TabIndex = 3;
            this.stepNumberTextBox.Click += new System.EventHandler(this.stepNumberTextBox_Click);
            // 
            // stepDescriptionTextBox
            // 
            this.stepDescriptionTextBox.Location = new System.Drawing.Point(277, 148);
            this.stepDescriptionTextBox.Name = "stepDescriptionTextBox";
            this.stepDescriptionTextBox.Size = new System.Drawing.Size(125, 27);
            this.stepDescriptionTextBox.TabIndex = 4;
            this.stepDescriptionTextBox.Click += new System.EventHandler(this.stepDescriptionTextBox_Click);
            // 
            // stepsDataGridView
            // 
            this.stepsDataGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.stepsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.stepsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stepsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stepNumberColumn,
            this.stepDescriptionColumn,
            this.removeColumn});
            this.stepsDataGridView.Location = new System.Drawing.Point(30, 335);
            this.stepsDataGridView.Name = "stepsDataGridView";
            this.stepsDataGridView.RowHeadersVisible = false;
            this.stepsDataGridView.RowHeadersWidth = 51;
            this.stepsDataGridView.RowTemplate.Height = 29;
            this.stepsDataGridView.Size = new System.Drawing.Size(454, 234);
            this.stepsDataGridView.TabIndex = 5;
            this.stepsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.stepsDataGridView_CellContentClick);
            this.stepsDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.stepsDataGridView_CellValueChanged);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(200, 256);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(94, 29);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(122, 630);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(94, 29);
            this.confirmButton.TabIndex = 7;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(277, 630);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 29);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // errorStepsFieldLabel
            // 
            this.errorStepsFieldLabel.AutoSize = true;
            this.errorStepsFieldLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.errorStepsFieldLabel.ForeColor = System.Drawing.Color.Red;
            this.errorStepsFieldLabel.Location = new System.Drawing.Point(175, 223);
            this.errorStepsFieldLabel.Name = "errorStepsFieldLabel";
            this.errorStepsFieldLabel.Size = new System.Drawing.Size(169, 20);
            this.errorStepsFieldLabel.TabIndex = 9;
            this.errorStepsFieldLabel.Text = "Please fill out all fields.";
            this.errorStepsFieldLabel.Visible = false;
            // 
            // errorStepNumberLabel
            // 
            this.errorStepNumberLabel.AutoSize = true;
            this.errorStepNumberLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.errorStepNumberLabel.ForeColor = System.Drawing.Color.Red;
            this.errorStepNumberLabel.Location = new System.Drawing.Point(55, 178);
            this.errorStepNumberLabel.Name = "errorStepNumberLabel";
            this.errorStepNumberLabel.Size = new System.Drawing.Size(198, 20);
            this.errorStepNumberLabel.TabIndex = 10;
            this.errorStepNumberLabel.Text = "Step number not a number";
            this.errorStepNumberLabel.Visible = false;
            // 
            // stepsSuccessLabel
            // 
            this.stepsSuccessLabel.AutoSize = true;
            this.stepsSuccessLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.stepsSuccessLabel.ForeColor = System.Drawing.Color.Green;
            this.stepsSuccessLabel.Location = new System.Drawing.Point(166, 223);
            this.stepsSuccessLabel.Name = "stepsSuccessLabel";
            this.stepsSuccessLabel.Size = new System.Drawing.Size(178, 20);
            this.stepsSuccessLabel.TabIndex = 11;
            this.stepsSuccessLabel.Text = "Step Added Successfully";
            this.stepsSuccessLabel.Visible = false;
            // 
            // stepNumberColumn
            // 
            this.stepNumberColumn.HeaderText = "Step Number";
            this.stepNumberColumn.MinimumWidth = 6;
            this.stepNumberColumn.Name = "stepNumberColumn";
            this.stepNumberColumn.Width = 75;
            // 
            // stepDescriptionColumn
            // 
            this.stepDescriptionColumn.HeaderText = "Step Description";
            this.stepDescriptionColumn.MinimumWidth = 6;
            this.stepDescriptionColumn.Name = "stepDescriptionColumn";
            this.stepDescriptionColumn.Width = 200;
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
            // RecipeStepAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 823);
            this.Controls.Add(this.stepsSuccessLabel);
            this.Controls.Add(this.errorStepNumberLabel);
            this.Controls.Add(this.errorStepsFieldLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.stepsDataGridView);
            this.Controls.Add(this.stepDescriptionTextBox);
            this.Controls.Add(this.stepNumberTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RecipeStepAdd";
            this.Text = "RecipeStepAdd";
            this.Load += new System.EventHandler(this.RecipeStepAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stepsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox stepNumberTextBox;
        private TextBox stepDescriptionTextBox;
        private DataGridView stepsDataGridView;
        private Button addButton;
        private Button confirmButton;
        private Button cancelButton;
        private Label errorStepsFieldLabel;
        private Label errorStepNumberLabel;
        private Label stepsSuccessLabel;
        private DataGridViewTextBoxColumn stepNumberColumn;
        private DataGridViewTextBoxColumn stepDescriptionColumn;
        private DataGridViewButtonColumn removeColumn;
    }
}