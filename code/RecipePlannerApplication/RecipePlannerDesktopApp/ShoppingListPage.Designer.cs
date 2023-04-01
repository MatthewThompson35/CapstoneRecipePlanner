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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShoppingListPage));
            this.ingredientsGridView = new System.Windows.Forms.DataGridView();
            this.IngredientColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.decreaseQuantityColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.increaseQuantityColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Measurement = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsGridView)).BeginInit();
            this.plannerContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ingredientsGridView
            // 
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
            this.Measurement});
            this.ingredientsGridView.Location = new System.Drawing.Point(25, 171);
            this.ingredientsGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ingredientsGridView.Name = "ingredientsGridView";
            this.ingredientsGridView.RowHeadersVisible = false;
            this.ingredientsGridView.RowHeadersWidth = 51;
            this.ingredientsGridView.RowTemplate.Height = 25;
            this.ingredientsGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ingredientsGridView.Size = new System.Drawing.Size(457, 320);
            this.ingredientsGridView.TabIndex = 6;
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
            this.IngredientColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IngredientColumn.Width = 130;
            // 
            // decreaseQuantityColumn
            // 
            this.decreaseQuantityColumn.HeaderText = "";
            this.decreaseQuantityColumn.MinimumWidth = 6;
            this.decreaseQuantityColumn.Name = "decreaseQuantityColumn";
            this.decreaseQuantityColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            this.quantityColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.quantityColumn.Width = 60;
            // 
            // increaseQuantityColumn
            // 
            this.increaseQuantityColumn.HeaderText = "";
            this.increaseQuantityColumn.MinimumWidth = 6;
            this.increaseQuantityColumn.Name = "increaseQuantityColumn";
            this.increaseQuantityColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            this.Measurement.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Measurement.Width = 125;
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
            this.button3.Location = new System.Drawing.Point(423, 516);
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
            this.removeIngredientButton.Location = new System.Drawing.Point(300, 613);
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
            this.purchaseShoppingListButton.Location = new System.Drawing.Point(178, 723);
            this.purchaseShoppingListButton.Name = "purchaseShoppingListButton";
            this.purchaseShoppingListButton.Size = new System.Drawing.Size(165, 58);
            this.purchaseShoppingListButton.TabIndex = 24;
            this.purchaseShoppingListButton.Text = "Purchase Shopping List";
            this.purchaseShoppingListButton.UseVisualStyleBackColor = true;
            this.purchaseShoppingListButton.Click += new System.EventHandler(this.purchaseShoppingListButton_Click);
            // 
            // ShoppingListPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 823);
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
            this.Controls.Add(this.ingredientsGridView);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShoppingListPage";
            this.Text = "ShoppingListPage";
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsGridView)).EndInit();
            this.plannerContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView ingredientsGridView;
        private DataGridViewTextBoxColumn IngredientColumn;
        private DataGridViewButtonColumn decreaseQuantityColumn;
        private DataGridViewTextBoxColumn quantityColumn;
        private DataGridViewButtonColumn increaseQuantityColumn;
        private DataGridViewTextBoxColumn Measurement;
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
    }
}