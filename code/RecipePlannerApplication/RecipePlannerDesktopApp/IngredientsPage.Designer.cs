namespace RecipePlannerDesktopApplication
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
            this.addIngredientButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.ingredientsGridView = new System.Windows.Forms.DataGridView();
            this.IngredientColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.decreaseQuantityColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.increaseQuantityColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Measurement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.removeColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ingredientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backButton = new System.Windows.Forms.Button();
            this.serverErrorLabel = new System.Windows.Forms.Label();
            this.beginningButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pageLabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // addIngredientButton
            // 
            this.addIngredientButton.Location = new System.Drawing.Point(94, 657);
            this.addIngredientButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addIngredientButton.Name = "addIngredientButton";
            this.addIngredientButton.Size = new System.Drawing.Size(319, 55);
            this.addIngredientButton.TabIndex = 1;
            this.addIngredientButton.Text = "Add Ingredient";
            this.addIngredientButton.UseVisualStyleBackColor = true;
            this.addIngredientButton.Click += new System.EventHandler(this.addIngredientButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(25, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Owned Ingredients:";
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(415, 16);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(86, 31);
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
            this.Measurement,
            this.removeColumn});
            this.ingredientsGridView.DataSource = this.ingredientBindingSource;
            this.ingredientsGridView.Location = new System.Drawing.Point(25, 181);
            this.ingredientsGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ingredientsGridView.Name = "ingredientsGridView";
            this.ingredientsGridView.RowHeadersVisible = false;
            this.ingredientsGridView.RowHeadersWidth = 51;
            this.ingredientsGridView.RowTemplate.Height = 25;
            this.ingredientsGridView.Size = new System.Drawing.Size(457, 300);
            this.ingredientsGridView.TabIndex = 5;
            this.ingredientsGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ingredientsGridView_CellClick);
            // 
            // IngredientColumn
            // 
            this.IngredientColumn.DataPropertyName = "name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.IngredientColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.IngredientColumn.HeaderText = "Ingredient";
            this.IngredientColumn.MinimumWidth = 6;
            this.IngredientColumn.Name = "IngredientColumn";
            this.IngredientColumn.ReadOnly = true;
            this.IngredientColumn.Width = 105;
            // 
            // decreaseQuantityColumn
            // 
            this.decreaseQuantityColumn.HeaderText = "";
            this.decreaseQuantityColumn.MinimumWidth = 6;
            this.decreaseQuantityColumn.Name = "decreaseQuantityColumn";
            this.decreaseQuantityColumn.Text = "-";
            this.decreaseQuantityColumn.UseColumnTextForButtonValue = true;
            this.decreaseQuantityColumn.Width = 40;
            // 
            // quantityColumn
            // 
            this.quantityColumn.DataPropertyName = "quantity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.quantityColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.quantityColumn.HeaderText = "Quantity";
            this.quantityColumn.MinimumWidth = 6;
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.ReadOnly = true;
            this.quantityColumn.Width = 60;
            // 
            // increaseQuantityColumn
            // 
            this.increaseQuantityColumn.HeaderText = "";
            this.increaseQuantityColumn.MinimumWidth = 6;
            this.increaseQuantityColumn.Name = "increaseQuantityColumn";
            this.increaseQuantityColumn.Text = "+";
            this.increaseQuantityColumn.UseColumnTextForButtonValue = true;
            this.increaseQuantityColumn.Width = 40;
            // 
            // Measurement
            // 
            this.Measurement.DataPropertyName = "Measurement";
            this.Measurement.HeaderText = "Measurement";
            this.Measurement.MinimumWidth = 6;
            this.Measurement.Name = "Measurement";
            this.Measurement.Width = 85;
            // 
            // removeColumn
            // 
            this.removeColumn.HeaderText = "Action";
            this.removeColumn.MinimumWidth = 6;
            this.removeColumn.Name = "removeColumn";
            this.removeColumn.Text = "Remove";
            this.removeColumn.UseColumnTextForButtonValue = true;
            this.removeColumn.Width = 75;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(15, 16);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(94, 29);
            this.backButton.TabIndex = 6;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // serverErrorLabel
            // 
            this.serverErrorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.serverErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.serverErrorLabel.Location = new System.Drawing.Point(166, 12);
            this.serverErrorLabel.Name = "serverErrorLabel";
            this.serverErrorLabel.Size = new System.Drawing.Size(208, 51);
            this.serverErrorLabel.TabIndex = 7;
            this.serverErrorLabel.Text = "The connection to the server could not be made";
            this.serverErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.serverErrorLabel.Visible = false;
            // 
            // beginningButton
            // 
            this.beginningButton.Location = new System.Drawing.Point(25, 508);
            this.beginningButton.Name = "beginningButton";
            this.beginningButton.Size = new System.Drawing.Size(62, 45);
            this.beginningButton.TabIndex = 11;
            this.beginningButton.Text = "<|";
            this.beginningButton.UseVisualStyleBackColor = true;
            this.beginningButton.Click += new System.EventHandler(this.beginningButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(94, 508);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 45);
            this.button1.TabIndex = 12;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // pageLabel
            // 
            this.pageLabel.AutoSize = true;
            this.pageLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pageLabel.Location = new System.Drawing.Point(243, 524);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(24, 28);
            this.pageLabel.TabIndex = 13;
            this.pageLabel.Text = "1";
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(350, 509);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(63, 44);
            this.nextButton.TabIndex = 14;
            this.nextButton.Text = ">";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(419, 508);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 44);
            this.button3.TabIndex = 15;
            this.button3.Text = ">|";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.lastButtonClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(153, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 37);
            this.label2.TabIndex = 16;
            this.label2.Text = "Ingredients Pantry";
            // 
            // IngredientsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 823);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.pageLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.beginningButton);
            this.Controls.Add(this.serverErrorLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.ingredientsGridView);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addIngredientButton);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "IngredientsPage";
            this.Text = "IngredientsPage";
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button addIngredientButton;
        private Label label1;
        private Button logoutButton;
        private DataGridView ingredientsGridView;
        private BindingSource ingredientBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private Button backButton;
        private Label serverErrorLabel;
        private Button beginningButton;
        private Button previousButton;
        private Button previousBttn;
        private Button button1;
        private Label pageLabel;
        private Button nextButton;
        private Button button3;
        private Label label2;
        private DataGridViewTextBoxColumn IngredientColumn;
        private DataGridViewButtonColumn decreaseQuantityColumn;
        private DataGridViewTextBoxColumn quantityColumn;
        private DataGridViewButtonColumn increaseQuantityColumn;
        private DataGridViewTextBoxColumn Measurement;
        private DataGridViewButtonColumn removeColumn;
    }
}