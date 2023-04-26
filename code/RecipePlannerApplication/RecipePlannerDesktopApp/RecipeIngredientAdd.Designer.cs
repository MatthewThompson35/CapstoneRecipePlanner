namespace RecipePlannerFinalDemoAdditions
{
    partial class RecipeIngredientAdd
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
            this.label4 = new System.Windows.Forms.Label();
            this.ingredientNameTextBox = new System.Windows.Forms.TextBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.measurementComboBox = new System.Windows.Forms.ComboBox();
            this.ingredientDataGridView = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorIngredientsFieldsLabel = new System.Windows.Forms.Label();
            this.errorQuantityLabel = new System.Windows.Forms.Label();
            this.ingredientSuccessLabel = new System.Windows.Forms.Label();
            this.errorMeasurementSelectionLabel = new System.Windows.Forms.Label();
            this.ingredientNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.measurementColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.removeColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(111, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Recipe Ingredients";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ingredient Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantity:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(363, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Measurement:";
            // 
            // ingredientNameTextBox
            // 
            this.ingredientNameTextBox.Location = new System.Drawing.Point(34, 186);
            this.ingredientNameTextBox.Name = "ingredientNameTextBox";
            this.ingredientNameTextBox.Size = new System.Drawing.Size(125, 27);
            this.ingredientNameTextBox.TabIndex = 4;
            this.ingredientNameTextBox.Click += new System.EventHandler(this.ingredientNameTextBox_Click);
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(205, 186);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(125, 27);
            this.quantityTextBox.TabIndex = 5;
            this.quantityTextBox.Click += new System.EventHandler(this.quantityTextBox_Click);
            // 
            // measurementComboBox
            // 
            this.measurementComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.measurementComboBox.FormattingEnabled = true;
            this.measurementComboBox.Items.AddRange(new object[] {
            "COUNT",
            "OZ",
            "G"});
            this.measurementComboBox.Location = new System.Drawing.Point(363, 186);
            this.measurementComboBox.Name = "measurementComboBox";
            this.measurementComboBox.Size = new System.Drawing.Size(125, 28);
            this.measurementComboBox.TabIndex = 6;
            this.measurementComboBox.Click += new System.EventHandler(this.measurementComboBox_Click);
            // 
            // ingredientDataGridView
            // 
            this.ingredientDataGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ingredientDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ingredientDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ingredientDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ingredientNameColumn,
            this.quantityColumn,
            this.measurementColumn,
            this.removeColumn});
            this.ingredientDataGridView.Location = new System.Drawing.Point(34, 348);
            this.ingredientDataGridView.Name = "ingredientDataGridView";
            this.ingredientDataGridView.RowHeadersVisible = false;
            this.ingredientDataGridView.RowHeadersWidth = 51;
            this.ingredientDataGridView.RowTemplate.Height = 29;
            this.ingredientDataGridView.Size = new System.Drawing.Size(454, 234);
            this.ingredientDataGridView.TabIndex = 7;
            this.ingredientDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ingredientDataGridView_CellContentClick);
            this.ingredientDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ingredientDataGridView_CellValueChanged);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(205, 267);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(94, 29);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(137, 635);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(94, 29);
            this.confirmButton.TabIndex = 9;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(298, 635);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 29);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // errorIngredientsFieldsLabel
            // 
            this.errorIngredientsFieldsLabel.AutoSize = true;
            this.errorIngredientsFieldsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.errorIngredientsFieldsLabel.ForeColor = System.Drawing.Color.Red;
            this.errorIngredientsFieldsLabel.Location = new System.Drawing.Point(173, 244);
            this.errorIngredientsFieldsLabel.Name = "errorIngredientsFieldsLabel";
            this.errorIngredientsFieldsLabel.Size = new System.Drawing.Size(169, 20);
            this.errorIngredientsFieldsLabel.TabIndex = 11;
            this.errorIngredientsFieldsLabel.Text = "Please fill out all fields.";
            this.errorIngredientsFieldsLabel.Visible = false;
            // 
            // errorQuantityLabel
            // 
            this.errorQuantityLabel.AutoSize = true;
            this.errorQuantityLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.errorQuantityLabel.ForeColor = System.Drawing.Color.Red;
            this.errorQuantityLabel.Location = new System.Drawing.Point(173, 172);
            this.errorQuantityLabel.Name = "errorQuantityLabel";
            this.errorQuantityLabel.Size = new System.Drawing.Size(184, 20);
            this.errorQuantityLabel.TabIndex = 12;
            this.errorQuantityLabel.Text = "Quantity is not a number";
            this.errorQuantityLabel.Visible = false;
            // 
            // ingredientSuccessLabel
            // 
            this.ingredientSuccessLabel.AutoSize = true;
            this.ingredientSuccessLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ingredientSuccessLabel.ForeColor = System.Drawing.Color.Green;
            this.ingredientSuccessLabel.Location = new System.Drawing.Point(149, 244);
            this.ingredientSuccessLabel.Name = "ingredientSuccessLabel";
            this.ingredientSuccessLabel.Size = new System.Drawing.Size(220, 20);
            this.ingredientSuccessLabel.TabIndex = 13;
            this.ingredientSuccessLabel.Text = "Ingredient Successfully Added";
            this.ingredientSuccessLabel.Visible = false;
            // 
            // errorMeasurementSelectionLabel
            // 
            this.errorMeasurementSelectionLabel.AutoSize = true;
            this.errorMeasurementSelectionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.errorMeasurementSelectionLabel.ForeColor = System.Drawing.Color.Red;
            this.errorMeasurementSelectionLabel.Location = new System.Drawing.Point(360, 172);
            this.errorMeasurementSelectionLabel.Name = "errorMeasurementSelectionLabel";
            this.errorMeasurementSelectionLabel.Size = new System.Drawing.Size(142, 20);
            this.errorMeasurementSelectionLabel.TabIndex = 14;
            this.errorMeasurementSelectionLabel.Text = "Select measuremet";
            this.errorMeasurementSelectionLabel.Visible = false;
            // 
            // ingredientNameColumn
            // 
            this.ingredientNameColumn.HeaderText = "Ingredient Name";
            this.ingredientNameColumn.MinimumWidth = 6;
            this.ingredientNameColumn.Name = "ingredientNameColumn";
            this.ingredientNameColumn.Width = 125;
            // 
            // quantityColumn
            // 
            this.quantityColumn.HeaderText = "Quantity";
            this.quantityColumn.MinimumWidth = 6;
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.Width = 75;
            // 
            // measurementColumn
            // 
            this.measurementColumn.HeaderText = "Measurement";
            this.measurementColumn.MinimumWidth = 6;
            this.measurementColumn.Name = "measurementColumn";
            this.measurementColumn.Width = 105;
            // 
            // removeColumn
            // 
            this.removeColumn.HeaderText = "Action";
            this.removeColumn.MinimumWidth = 6;
            this.removeColumn.Name = "removeColumn";
            this.removeColumn.Text = "Remove";
            this.removeColumn.UseColumnTextForButtonValue = true;
            this.removeColumn.Width = 90;
            // 
            // RecipeIngredientAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 823);
            this.Controls.Add(this.errorMeasurementSelectionLabel);
            this.Controls.Add(this.ingredientSuccessLabel);
            this.Controls.Add(this.errorQuantityLabel);
            this.Controls.Add(this.errorIngredientsFieldsLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.ingredientDataGridView);
            this.Controls.Add(this.measurementComboBox);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.ingredientNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RecipeIngredientAdd";
            this.Text = "RecipeIngredientAdd";
            this.Load += new System.EventHandler(this.RecipeIngredientAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ingredientDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox ingredientNameTextBox;
        private TextBox quantityTextBox;
        private ComboBox measurementComboBox;
        private DataGridView ingredientDataGridView;
        private Button addButton;
        private Button confirmButton;
        private Button cancelButton;
        private Label errorIngredientsFieldsLabel;
        private Label errorQuantityLabel;
        private Label ingredientSuccessLabel;
        private Label errorMeasurementSelectionLabel;
        private DataGridViewTextBoxColumn ingredientNameColumn;
        private DataGridViewTextBoxColumn quantityColumn;
        private DataGridViewTextBoxColumn measurementColumn;
        private DataGridViewButtonColumn removeColumn;
    }
}