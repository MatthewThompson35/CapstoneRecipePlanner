﻿namespace RecipePlannerDesktopApplication
{
    partial class IngredientsPage
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.ingredientsGridView = new System.Windows.Forms.DataGridView();
            this.ingredientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IngredientColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.decreaseQuantityColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.increaseQuantityColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(75, 411);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(264, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add Ingredient";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(75, 461);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(264, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "Remove Ingredient";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Owned Ingredients:";
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(325, 12);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 4;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // ingredientsGridView
            // 
            this.ingredientsGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ingredientsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ingredientsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ingredientsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IngredientColumn,
            this.decreaseQuantityColumn,
            this.quantityColumn,
            this.increaseQuantityColumn,
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn});
            this.ingredientsGridView.DataSource = this.ingredientBindingSource;
            this.ingredientsGridView.Location = new System.Drawing.Point(12, 51);
            this.ingredientsGridView.Name = "ingredientsGridView";
            this.ingredientsGridView.RowHeadersVisible = false;
            this.ingredientsGridView.RowTemplate.Height = 25;
            this.ingredientsGridView.Size = new System.Drawing.Size(388, 346);
            this.ingredientsGridView.TabIndex = 5;
            // 
            // ingredientBindingSource
            // 
            this.ingredientBindingSource.DataSource = typeof(RecipePlannerLibrary.Models.Ingredient);
            // 
            // IngredientColumn
            // 
            this.IngredientColumn.DataPropertyName = "name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.IngredientColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.IngredientColumn.HeaderText = "Ingredient";
            this.IngredientColumn.Name = "IngredientColumn";
            this.IngredientColumn.ReadOnly = true;
            this.IngredientColumn.Width = 205;
            // 
            // decreaseQuantityColumn
            // 
            this.decreaseQuantityColumn.HeaderText = "";
            this.decreaseQuantityColumn.Name = "decreaseQuantityColumn";
            this.decreaseQuantityColumn.Text = "v";
            this.decreaseQuantityColumn.UseColumnTextForButtonValue = true;
            this.decreaseQuantityColumn.Width = 40;
            // 
            // quantityColumn
            // 
            this.quantityColumn.DataPropertyName = "quantity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.quantityColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.quantityColumn.HeaderText = "Quantity";
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.ReadOnly = true;
            // 
            // increaseQuantityColumn
            // 
            this.increaseQuantityColumn.HeaderText = "";
            this.increaseQuantityColumn.Name = "increaseQuantityColumn";
            this.increaseQuantityColumn.Text = "^";
            this.increaseQuantityColumn.UseColumnTextForButtonValue = true;
            this.increaseQuantityColumn.Width = 40;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Visible = false;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Visible = false;
            // 
            // IngredientsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 519);
            this.Controls.Add(this.ingredientsGridView);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "IngredientsPage";
            this.Text = "IngredientsPage";
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button button1;
        private Button button2;
        private Label label1;
        private Button logoutButton;
        private DataGridView ingredientsGridView;
        private BindingSource ingredientBindingSource;
        private DataGridViewTextBoxColumn IngredientColumn;
        private DataGridViewButtonColumn decreaseQuantityColumn;
        private DataGridViewTextBoxColumn quantityColumn;
        private DataGridViewButtonColumn increaseQuantityColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
    }
}