﻿namespace RecipePlannerDesktopApplication
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
            this.ingredientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.measurement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.step = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stepDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.stepsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeIngredientsDataGridView)).BeginInit();
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
            this.recipeNameTextBox.Location = new System.Drawing.Point(246, 95);
            this.recipeNameTextBox.Name = "recipeNameTextBox";
            this.recipeNameTextBox.Size = new System.Drawing.Size(209, 27);
            this.recipeNameTextBox.TabIndex = 1;
            // 
            // recipeDescriptionTextBox
            // 
            this.recipeDescriptionTextBox.Location = new System.Drawing.Point(246, 167);
            this.recipeDescriptionTextBox.Name = "recipeDescriptionTextBox";
            this.recipeDescriptionTextBox.Size = new System.Drawing.Size(209, 27);
            this.recipeDescriptionTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(34, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Recipe Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(34, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Recipe Description:";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(118, 731);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(94, 29);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(287, 731);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 29);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(34, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 28);
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
            this.stepDescription});
            this.stepsDataGridView.Location = new System.Drawing.Point(34, 264);
            this.stepsDataGridView.Name = "stepsDataGridView";
            this.stepsDataGridView.RowHeadersVisible = false;
            this.stepsDataGridView.RowHeadersWidth = 51;
            this.stepsDataGridView.RowTemplate.Height = 29;
            this.stepsDataGridView.Size = new System.Drawing.Size(451, 188);
            this.stepsDataGridView.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(34, 479);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "Recipe Ingredients:";
            // 
            // recipeIngredientsDataGridView
            // 
            this.recipeIngredientsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recipeIngredientsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ingredientName,
            this.quantity,
            this.measurement});
            this.recipeIngredientsDataGridView.Location = new System.Drawing.Point(34, 510);
            this.recipeIngredientsDataGridView.Name = "recipeIngredientsDataGridView";
            this.recipeIngredientsDataGridView.RowHeadersVisible = false;
            this.recipeIngredientsDataGridView.RowHeadersWidth = 51;
            this.recipeIngredientsDataGridView.RowTemplate.Height = 29;
            this.recipeIngredientsDataGridView.Size = new System.Drawing.Size(451, 188);
            this.recipeIngredientsDataGridView.TabIndex = 10;
            // 
            // ingredientName
            // 
            this.ingredientName.HeaderText = "Ingredient Name";
            this.ingredientName.MinimumWidth = 6;
            this.ingredientName.Name = "ingredientName";
            this.ingredientName.Width = 125;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Quantity";
            this.quantity.MinimumWidth = 6;
            this.quantity.Name = "quantity";
            this.quantity.Width = 125;
            // 
            // measurement
            // 
            this.measurement.HeaderText = "Measurement";
            this.measurement.MinimumWidth = 6;
            this.measurement.Name = "measurement";
            this.measurement.Width = 125;
            // 
            // step
            // 
            this.step.HeaderText = "Step Number";
            this.step.MinimumWidth = 6;
            this.step.Name = "step";
            this.step.Width = 125;
            // 
            // stepDescription
            // 
            this.stepDescription.HeaderText = "Step Description";
            this.stepDescription.MinimumWidth = 6;
            this.stepDescription.Name = "stepDescription";
            this.stepDescription.Width = 250;
            // 
            // RecipePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 823);
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
        private DataGridViewTextBoxColumn ingredientName;
        private DataGridViewTextBoxColumn quantity;
        private DataGridViewTextBoxColumn measurement;
        private DataGridViewTextBoxColumn step;
        private DataGridViewTextBoxColumn stepDescription;
    }
}