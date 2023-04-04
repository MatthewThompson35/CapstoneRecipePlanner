namespace RecipePlannerDesktopApplication
{
    partial class RecipePage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.recipeNameTextBox = new System.Windows.Forms.TextBox();
            this.recipeDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.stepsDataGridView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.recipeIngredientsDataGridView = new System.Windows.Forms.DataGridView();
            this.errorLabel = new System.Windows.Forms.Label();
            this.tagDataGridView = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.addRecipeRequirementsButton = new System.Windows.Forms.Button();
            this.ingredientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.measurement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingredientsRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.step = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stepDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stepsRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tagColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.stepsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeIngredientsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tagDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(150, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add New Recipe";
            // 
            // recipeNameTextBox
            // 
            this.recipeNameTextBox.Location = new System.Drawing.Point(12, 88);
            this.recipeNameTextBox.Name = "recipeNameTextBox";
            this.recipeNameTextBox.Size = new System.Drawing.Size(125, 27);
            this.recipeNameTextBox.TabIndex = 1;
            // 
            // recipeDescriptionTextBox
            // 
            this.recipeDescriptionTextBox.Location = new System.Drawing.Point(163, 88);
            this.recipeDescriptionTextBox.Name = "recipeDescriptionTextBox";
            this.recipeDescriptionTextBox.Size = new System.Drawing.Size(125, 27);
            this.recipeDescriptionTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Recipe Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(163, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Recipe Description:";
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Green;
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addButton.Location = new System.Drawing.Point(113, 777);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(94, 43);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Red;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancelButton.Location = new System.Drawing.Point(287, 777);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 43);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Recipe Steps:";
            // 
            // stepsDataGridView
            // 
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
            this.step,
            this.stepDescription,
            this.stepsRemove});
            this.stepsDataGridView.Location = new System.Drawing.Point(12, 318);
            this.stepsDataGridView.Name = "stepsDataGridView";
            this.stepsDataGridView.RowHeadersVisible = false;
            this.stepsDataGridView.RowHeadersWidth = 51;
            this.stepsDataGridView.RowTemplate.Height = 29;
            this.stepsDataGridView.Size = new System.Drawing.Size(448, 119);
            this.stepsDataGridView.TabIndex = 8;
            this.stepsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.stepsDataGridView_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Recipe Ingredients:";
            // 
            // recipeIngredientsDataGridView
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.recipeIngredientsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.recipeIngredientsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recipeIngredientsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ingredientName,
            this.quantity,
            this.measurement,
            this.ingredientsRemove});
            this.recipeIngredientsDataGridView.Location = new System.Drawing.Point(12, 151);
            this.recipeIngredientsDataGridView.Name = "recipeIngredientsDataGridView";
            this.recipeIngredientsDataGridView.RowHeadersVisible = false;
            this.recipeIngredientsDataGridView.RowHeadersWidth = 51;
            this.recipeIngredientsDataGridView.RowTemplate.Height = 29;
            this.recipeIngredientsDataGridView.Size = new System.Drawing.Size(448, 125);
            this.recipeIngredientsDataGridView.TabIndex = 10;
            this.recipeIngredientsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.recipeIngredientsDataGridView_CellContentClick);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(87, 754);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(169, 20);
            this.errorLabel.TabIndex = 11;
            this.errorLabel.Text = "Please fill out all fields.";
            this.errorLabel.Visible = false;
            // 
            // tagDataGridView
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tagDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tagDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tagDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tagColumn,
            this.tagRemove});
            this.tagDataGridView.Location = new System.Drawing.Point(12, 481);
            this.tagDataGridView.Name = "tagDataGridView";
            this.tagDataGridView.RowHeadersVisible = false;
            this.tagDataGridView.RowHeadersWidth = 51;
            this.tagDataGridView.RowTemplate.Height = 29;
            this.tagDataGridView.Size = new System.Drawing.Size(448, 75);
            this.tagDataGridView.TabIndex = 15;
            this.tagDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tagDataGridView_CellContentClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 452);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 20);
            this.label12.TabIndex = 28;
            this.label12.Text = "Recipe Tags:";
            // 
            // addRecipeRequirementsButton
            // 
            this.addRecipeRequirementsButton.Location = new System.Drawing.Point(185, 620);
            this.addRecipeRequirementsButton.Name = "addRecipeRequirementsButton";
            this.addRecipeRequirementsButton.Size = new System.Drawing.Size(125, 62);
            this.addRecipeRequirementsButton.TabIndex = 29;
            this.addRecipeRequirementsButton.Text = "Add Recipe Requirements";
            this.addRecipeRequirementsButton.UseVisualStyleBackColor = true;
            this.addRecipeRequirementsButton.Click += new System.EventHandler(this.addRecipeRequirementsButton_Click);
            // 
            // ingredientName
            // 
            this.ingredientName.HeaderText = "Ingredient Name";
            this.ingredientName.MinimumWidth = 6;
            this.ingredientName.Name = "ingredientName";
            this.ingredientName.ReadOnly = true;
            this.ingredientName.Width = 125;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Quantity";
            this.quantity.MinimumWidth = 6;
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Width = 75;
            // 
            // measurement
            // 
            this.measurement.HeaderText = "Measurement";
            this.measurement.MinimumWidth = 6;
            this.measurement.Name = "measurement";
            this.measurement.ReadOnly = true;
            this.measurement.Width = 115;
            // 
            // ingredientsRemove
            // 
            this.ingredientsRemove.HeaderText = "Action";
            this.ingredientsRemove.MinimumWidth = 6;
            this.ingredientsRemove.Name = "ingredientsRemove";
            this.ingredientsRemove.Text = "Remove";
            this.ingredientsRemove.UseColumnTextForButtonValue = true;
            this.ingredientsRemove.Width = 125;
            // 
            // step
            // 
            this.step.HeaderText = "Step Number";
            this.step.MinimumWidth = 6;
            this.step.Name = "step";
            this.step.ReadOnly = true;
            this.step.Width = 75;
            // 
            // stepDescription
            // 
            this.stepDescription.HeaderText = "Step Description";
            this.stepDescription.MinimumWidth = 6;
            this.stepDescription.Name = "stepDescription";
            this.stepDescription.ReadOnly = true;
            this.stepDescription.Width = 198;
            // 
            // stepsRemove
            // 
            this.stepsRemove.HeaderText = "Action";
            this.stepsRemove.MinimumWidth = 6;
            this.stepsRemove.Name = "stepsRemove";
            this.stepsRemove.Text = "Remove";
            this.stepsRemove.UseColumnTextForButtonValue = true;
            this.stepsRemove.Width = 125;
            // 
            // tagColumn
            // 
            this.tagColumn.HeaderText = "Tag";
            this.tagColumn.MinimumWidth = 6;
            this.tagColumn.Name = "tagColumn";
            this.tagColumn.ReadOnly = true;
            this.tagColumn.Width = 125;
            // 
            // tagRemove
            // 
            this.tagRemove.HeaderText = "Action";
            this.tagRemove.MinimumWidth = 6;
            this.tagRemove.Name = "tagRemove";
            this.tagRemove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tagRemove.Text = "Remove";
            this.tagRemove.UseColumnTextForButtonValue = true;
            this.tagRemove.Width = 125;
            // 
            // RecipePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 823);
            this.Controls.Add(this.addRecipeRequirementsButton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tagDataGridView);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.recipeIngredientsDataGridView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.stepsDataGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.recipeDescriptionTextBox);
            this.Controls.Add(this.recipeNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "RecipePage";
            this.Text = "RecipePage";
            ((System.ComponentModel.ISupportInitialize)(this.stepsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeIngredientsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tagDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox recipeNameTextBox;
        private TextBox recipeDescriptionTextBox;
        private Label label2;
        private Label label3;
        private Button addButton;
        private Button cancelButton;
        private Label label4;
        private DataGridView stepsDataGridView;
        private Label label5;
        private DataGridView recipeIngredientsDataGridView;
        private Label errorLabel;
        private DataGridView tagDataGridView;
        private Label label12;
        private Button addRecipeRequirementsButton;
        private DataGridViewTextBoxColumn step;
        private DataGridViewTextBoxColumn stepDescription;
        private DataGridViewButtonColumn stepsRemove;
        private DataGridViewTextBoxColumn ingredientName;
        private DataGridViewTextBoxColumn quantity;
        private DataGridViewTextBoxColumn measurement;
        private DataGridViewButtonColumn ingredientsRemove;
        private DataGridViewTextBoxColumn tagColumn;
        private DataGridViewButtonColumn tagRemove;
    }
}