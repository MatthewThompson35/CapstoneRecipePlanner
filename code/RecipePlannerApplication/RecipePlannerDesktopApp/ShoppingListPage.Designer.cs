namespace RecipePlannerDesktopApplication
{
    partial class ShoppingListPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShoppingListPage));
            this.ingredientsGridView = new System.Windows.Forms.DataGridView();
            this.ingredientColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.decrementColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incrementCOlumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.measurmentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingredientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.serverErrorLabel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.pageLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.beginningButton = new System.Windows.Forms.Button();
            this.removeIngredientButton = new System.Windows.Forms.Button();
            this.addIngredientButton = new System.Windows.Forms.Button();
            this.plannerMenuButton = new System.Windows.Forms.Button();
            this.plannerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showRecipesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPantryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseShoppingListButton = new System.Windows.Forms.Button();
            this.addIngredientsForRemainingMealsButton = new System.Windows.Forms.Button();
            this.addAllIngredientsCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).BeginInit();
            this.plannerContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ingredientsGridView
            // 
            this.ingredientsGridView.AllowUserToAddRows = false;
            this.ingredientsGridView.AllowUserToDeleteRows = false;
            this.ingredientsGridView.AllowUserToResizeColumns = false;
            this.ingredientsGridView.AutoGenerateColumns = false;
            this.ingredientsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ingredientsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ingredientColumn,
            this.decrementColumn,
            this.quantityColumn,
            this.incrementCOlumn,
            this.measurmentColumn});
            this.ingredientsGridView.DataSource = this.ingredientBindingSource;
            this.ingredientsGridView.Location = new System.Drawing.Point(29, 171);
            this.ingredientsGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ingredientsGridView.Name = "ingredientsGridView";
            this.ingredientsGridView.RowHeadersVisible = false;
            this.ingredientsGridView.RowHeadersWidth = 51;
            this.ingredientsGridView.RowTemplate.Height = 25;
            this.ingredientsGridView.Size = new System.Drawing.Size(457, 319);
            this.ingredientsGridView.TabIndex = 25;
            this.ingredientsGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ingredientsGridView_CellClick);
            this.ingredientsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ingredientsGridView_CellContentClick);
            // 
            // ingredientColumn
            // 
            this.ingredientColumn.DataPropertyName = "name";
            this.ingredientColumn.HeaderText = "Ingredient";
            this.ingredientColumn.MinimumWidth = 6;
            this.ingredientColumn.Name = "ingredientColumn";
            this.ingredientColumn.Width = 135;
            // 
            // decrementColumn
            // 
            this.decrementColumn.HeaderText = "";
            this.decrementColumn.MinimumWidth = 6;
            this.decrementColumn.Name = "decrementColumn";
            this.decrementColumn.Text = "-";
            this.decrementColumn.UseColumnTextForButtonValue = true;
            this.decrementColumn.Width = 30;
            // 
            // quantityColumn
            // 
            this.quantityColumn.DataPropertyName = "quantity";
            this.quantityColumn.HeaderText = "Quantity";
            this.quantityColumn.MinimumWidth = 6;
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.Width = 125;
            // 
            // incrementCOlumn
            // 
            this.incrementCOlumn.HeaderText = "";
            this.incrementCOlumn.MinimumWidth = 6;
            this.incrementCOlumn.Name = "incrementCOlumn";
            this.incrementCOlumn.Text = "+";
            this.incrementCOlumn.UseColumnTextForButtonValue = true;
            this.incrementCOlumn.Width = 30;
            // 
            // measurmentColumn
            // 
            this.measurmentColumn.DataPropertyName = "measurement";
            this.measurmentColumn.HeaderText = "Measurement";
            this.measurmentColumn.MinimumWidth = 6;
            this.measurmentColumn.Name = "measurmentColumn";
            this.measurmentColumn.Width = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(178, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 37);
            this.label1.TabIndex = 7;
            this.label1.Text = "Shopping List";
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(400, 28);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(86, 31);
            this.logoutButton.TabIndex = 9;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // serverErrorLabel
            // 
            this.serverErrorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.serverErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.serverErrorLabel.Location = new System.Drawing.Point(159, 19);
            this.serverErrorLabel.Name = "serverErrorLabel";
            this.serverErrorLabel.Size = new System.Drawing.Size(208, 51);
            this.serverErrorLabel.TabIndex = 10;
            this.serverErrorLabel.Text = "The connection to the server could not be made";
            this.serverErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.serverErrorLabel.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(423, 517);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 44);
            this.button3.TabIndex = 22;
            this.button3.Text = ">|";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(353, 517);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(63, 44);
            this.nextButton.TabIndex = 21;
            this.nextButton.Text = ">";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // pageLabel
            // 
            this.pageLabel.AutoSize = true;
            this.pageLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pageLabel.Location = new System.Drawing.Point(247, 532);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(24, 28);
            this.pageLabel.TabIndex = 20;
            this.pageLabel.Text = "1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 516);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 45);
            this.button1.TabIndex = 19;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // beginningButton
            // 
            this.beginningButton.Location = new System.Drawing.Point(29, 516);
            this.beginningButton.Name = "beginningButton";
            this.beginningButton.Size = new System.Drawing.Size(62, 45);
            this.beginningButton.TabIndex = 18;
            this.beginningButton.Text = "<|";
            this.beginningButton.UseVisualStyleBackColor = true;
            this.beginningButton.Click += new System.EventHandler(this.beginningButton_Click);
            // 
            // removeIngredientButton
            // 
            this.removeIngredientButton.Location = new System.Drawing.Point(299, 613);
            this.removeIngredientButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.removeIngredientButton.Name = "removeIngredientButton";
            this.removeIngredientButton.Size = new System.Drawing.Size(165, 59);
            this.removeIngredientButton.TabIndex = 17;
            this.removeIngredientButton.Text = "Remove Ingredient";
            this.removeIngredientButton.UseVisualStyleBackColor = true;
            this.removeIngredientButton.Click += new System.EventHandler(this.removeIngredientButton_Click);
            // 
            // addIngredientButton
            // 
            this.addIngredientButton.Location = new System.Drawing.Point(51, 615);
            this.addIngredientButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addIngredientButton.Name = "addIngredientButton";
            this.addIngredientButton.Size = new System.Drawing.Size(165, 55);
            this.addIngredientButton.TabIndex = 16;
            this.addIngredientButton.Text = "Add Ingredient";
            this.addIngredientButton.UseVisualStyleBackColor = true;
            this.addIngredientButton.Click += new System.EventHandler(this.addIngredientButton_Click);
            // 
            // plannerMenuButton
            // 
            this.plannerMenuButton.BackColor = System.Drawing.Color.LightCyan;
            this.plannerMenuButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plannerMenuButton.BackgroundImage")));
            this.plannerMenuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plannerMenuButton.Location = new System.Drawing.Point(14, 19);
            this.plannerMenuButton.Name = "plannerMenuButton";
            this.plannerMenuButton.Size = new System.Drawing.Size(43, 39);
            this.plannerMenuButton.TabIndex = 23;
            this.plannerMenuButton.UseVisualStyleBackColor = false;
            this.plannerMenuButton.Click += new System.EventHandler(this.plannerMenuButton_Click);
            // 
            // plannerContextMenuStrip
            // 
            this.plannerContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.plannerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showRecipesToolStripMenuItem,
            this.showPantryToolStripMenuItem});
            this.plannerContextMenuStrip.Name = "plannerContextMenuStrip";
            this.plannerContextMenuStrip.Size = new System.Drawing.Size(166, 52);
            // 
            // showRecipesToolStripMenuItem
            // 
            this.showRecipesToolStripMenuItem.Name = "showRecipesToolStripMenuItem";
            this.showRecipesToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.showRecipesToolStripMenuItem.Text = "View Recipes";
            this.showRecipesToolStripMenuItem.Click += new System.EventHandler(this.showRecipesToolStripMenuItem_Click);
            // 
            // showPantryToolStripMenuItem
            // 
            this.showPantryToolStripMenuItem.Name = "showPantryToolStripMenuItem";
            this.showPantryToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.showPantryToolStripMenuItem.Text = "View Pantry";
            this.showPantryToolStripMenuItem.Click += new System.EventHandler(this.showPantryToolStripMenuItem_Click);
            // 
            // purchaseShoppingListButton
            // 
            this.purchaseShoppingListButton.Location = new System.Drawing.Point(299, 709);
            this.purchaseShoppingListButton.Name = "purchaseShoppingListButton";
            this.purchaseShoppingListButton.Size = new System.Drawing.Size(165, 59);
            this.purchaseShoppingListButton.TabIndex = 24;
            this.purchaseShoppingListButton.Text = "Purchase Shopping List";
            this.purchaseShoppingListButton.UseVisualStyleBackColor = true;
            this.purchaseShoppingListButton.Click += new System.EventHandler(this.purchaseShoppingListButton_Click);
            // 
            // addIngredientsForRemainingMealsButton
            // 
            this.addIngredientsForRemainingMealsButton.Location = new System.Drawing.Point(51, 709);
            this.addIngredientsForRemainingMealsButton.Name = "addIngredientsForRemainingMealsButton";
            this.addIngredientsForRemainingMealsButton.Size = new System.Drawing.Size(165, 59);
            this.addIngredientsForRemainingMealsButton.TabIndex = 26;
            this.addIngredientsForRemainingMealsButton.Text = "Add Ingredients for Remaining Meals";
            this.addIngredientsForRemainingMealsButton.UseVisualStyleBackColor = true;
            this.addIngredientsForRemainingMealsButton.Click += new System.EventHandler(this.addIngredientsForRemainingMealsButton_Click);
            // 
            // addAllIngredientsCheckbox
            // 
            this.addAllIngredientsCheckbox.AutoSize = true;
            this.addAllIngredientsCheckbox.Location = new System.Drawing.Point(58, 785);
            this.addAllIngredientsCheckbox.Name = "addAllIngredientsCheckbox";
            this.addAllIngredientsCheckbox.Size = new System.Drawing.Size(159, 24);
            this.addAllIngredientsCheckbox.TabIndex = 27;
            this.addAllIngredientsCheckbox.Text = "Add All Ingredients";
            this.addAllIngredientsCheckbox.UseVisualStyleBackColor = true;
            // 
            // ShoppingListPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 823);
            this.Controls.Add(this.addAllIngredientsCheckbox);
            this.Controls.Add(this.addIngredientsForRemainingMealsButton);
            this.Controls.Add(this.ingredientsGridView);
            this.Controls.Add(this.purchaseShoppingListButton);
            this.Controls.Add(this.plannerMenuButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.pageLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.beginningButton);
            this.Controls.Add(this.removeIngredientButton);
            this.Controls.Add(this.addIngredientButton);
            this.Controls.Add(this.serverErrorLabel);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShoppingListPage";
            this.Text = "ShoppingListPage";
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).EndInit();
            this.plannerContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Button logoutButton;
        private Label serverErrorLabel;
        private Button button3;
        private Button nextButton;
        private Label pageLabel;
        private Button button1;
        private Button beginningButton;
        private Button removeIngredientButton;
        private Button addIngredientButton;
        private Button plannerMenuButton;
        private ContextMenuStrip plannerContextMenuStrip;
        private ToolStripMenuItem showRecipesToolStripMenuItem;
        private ToolStripMenuItem showPantryToolStripMenuItem;
        private Button purchaseShoppingListButton;
        private DataGridView ingredientsGridView;
        private BindingSource ingredientBindingSource;
        private DataGridViewTextBoxColumn ingredientColumn;
        private DataGridViewButtonColumn decrementColumn;
        private DataGridViewTextBoxColumn quantityColumn;
        private DataGridViewButtonColumn incrementCOlumn;
        private DataGridViewTextBoxColumn measurmentColumn;
        private DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn measurementDataGridViewTextBoxColumn;
        private Button addIngredientsForRemainingMealsButton;
        private CheckBox addAllIngredientsCheckbox;
    }
}