namespace RecipePlannerDesktopApplication
{
    partial class Homepage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Homepage));
            this.recipeListView = new System.Windows.Forms.ListView();
            this.logoutButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.viewPantryButton = new System.Windows.Forms.Button();
            this.noRecipesLabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.beginningButton = new System.Windows.Forms.Button();
            this.lastPageButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.pageCountLabel = new System.Windows.Forms.Label();
            this.plannerMenuButton = new System.Windows.Forms.Button();
            this.plannerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewMealPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewShoppingListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterButton = new System.Windows.Forms.Button();
            this.activeTagsLbl = new System.Windows.Forms.Label();
            this.filterTagTxt = new System.Windows.Forms.TextBox();
            this.clearFiltersBtn = new System.Windows.Forms.Button();
            this.tagsCmb = new System.Windows.Forms.ComboBox();
            this.deleteFilterBtn = new System.Windows.Forms.Button();
            this.availableCheckbox = new System.Windows.Forms.CheckBox();
            this.allRecipesButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addRecipeButton = new System.Windows.Forms.Button();
            this.plannerContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // recipeListView
            // 
            this.recipeListView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.recipeListView.Location = new System.Drawing.Point(37, 205);
            this.recipeListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.recipeListView.Name = "recipeListView";
            this.recipeListView.Size = new System.Drawing.Size(433, 484);
            this.recipeListView.TabIndex = 0;
            this.recipeListView.UseCompatibleStateImageBehavior = false;
            this.recipeListView.SelectedIndexChanged += new System.EventHandler(this.recipeListView_SelectedIndexChanged);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(439, 7);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(69, 39);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(37, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Recipes:";
            // 
            // viewPantryButton
            // 
            this.viewPantryButton.Location = new System.Drawing.Point(283, 763);
            this.viewPantryButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viewPantryButton.Name = "viewPantryButton";
            this.viewPantryButton.Size = new System.Drawing.Size(165, 44);
            this.viewPantryButton.TabIndex = 4;
            this.viewPantryButton.Text = "View Pantry";
            this.viewPantryButton.UseVisualStyleBackColor = true;
            this.viewPantryButton.Click += new System.EventHandler(this.viewPantryButton_Click);
            // 
            // noRecipesLabel
            // 
            this.noRecipesLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.noRecipesLabel.Location = new System.Drawing.Point(78, 385);
            this.noRecipesLabel.Name = "noRecipesLabel";
            this.noRecipesLabel.Size = new System.Drawing.Size(344, 112);
            this.noRecipesLabel.TabIndex = 8;
            this.noRecipesLabel.Text = "There are no recipes to show";
            this.noRecipesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.noRecipesLabel.Visible = false;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(311, 712);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(59, 29);
            this.nextButton.TabIndex = 9;
            this.nextButton.Text = ">";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // beginningButton
            // 
            this.beginningButton.Location = new System.Drawing.Point(78, 715);
            this.beginningButton.Name = "beginningButton";
            this.beginningButton.Size = new System.Drawing.Size(51, 29);
            this.beginningButton.TabIndex = 10;
            this.beginningButton.Text = "<|";
            this.beginningButton.UseVisualStyleBackColor = true;
            this.beginningButton.Click += new System.EventHandler(this.beginningButton_Click);
            // 
            // lastPageButton
            // 
            this.lastPageButton.Location = new System.Drawing.Point(377, 712);
            this.lastPageButton.Name = "lastPageButton";
            this.lastPageButton.Size = new System.Drawing.Size(51, 29);
            this.lastPageButton.TabIndex = 11;
            this.lastPageButton.Text = ">|";
            this.lastPageButton.UseVisualStyleBackColor = true;
            this.lastPageButton.Click += new System.EventHandler(this.lastPageButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Location = new System.Drawing.Point(136, 715);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(59, 29);
            this.previousButton.TabIndex = 12;
            this.previousButton.Text = "<";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // pageCountLabel
            // 
            this.pageCountLabel.AutoSize = true;
            this.pageCountLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pageCountLabel.Location = new System.Drawing.Point(243, 713);
            this.pageCountLabel.Name = "pageCountLabel";
            this.pageCountLabel.Size = new System.Drawing.Size(24, 28);
            this.pageCountLabel.TabIndex = 13;
            this.pageCountLabel.Text = "1";
            // 
            // plannerMenuButton
            // 
            this.plannerMenuButton.BackColor = System.Drawing.Color.LightCyan;
            this.plannerMenuButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plannerMenuButton.BackgroundImage")));
            this.plannerMenuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plannerMenuButton.Location = new System.Drawing.Point(5, 7);
            this.plannerMenuButton.Name = "plannerMenuButton";
            this.plannerMenuButton.Size = new System.Drawing.Size(43, 39);
            this.plannerMenuButton.TabIndex = 14;
            this.plannerMenuButton.UseVisualStyleBackColor = false;
            this.plannerMenuButton.Click += new System.EventHandler(this.plannerMenuButton_Click);
            // 
            // plannerContextMenuStrip
            // 
            this.plannerContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.plannerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewMealPlanToolStripMenuItem,
            this.viewShoppingListToolStripMenuItem});
            this.plannerContextMenuStrip.Name = "plannerContextMenuStrip";
            this.plannerContextMenuStrip.Size = new System.Drawing.Size(205, 52);
            // 
            // viewMealPlanToolStripMenuItem
            // 
            this.viewMealPlanToolStripMenuItem.Name = "viewMealPlanToolStripMenuItem";
            this.viewMealPlanToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.viewMealPlanToolStripMenuItem.Text = "View Meal Plan";
            this.viewMealPlanToolStripMenuItem.Click += new System.EventHandler(this.viewMealPlanToolStripMenuItem_Click);
            // 
            // viewShoppingListToolStripMenuItem
            // 
            this.viewShoppingListToolStripMenuItem.Name = "viewShoppingListToolStripMenuItem";
            this.viewShoppingListToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.viewShoppingListToolStripMenuItem.Text = "View Shopping List";
            this.viewShoppingListToolStripMenuItem.Click += new System.EventHandler(this.viewShoppingListToolStripMenuItem_Click_1);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(298, 35);
            this.filterButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(112, 31);
            this.filterButton.TabIndex = 15;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // activeTagsLbl
            // 
            this.activeTagsLbl.AutoSize = true;
            this.activeTagsLbl.Location = new System.Drawing.Point(14, 84);
            this.activeTagsLbl.Name = "activeTagsLbl";
            this.activeTagsLbl.Size = new System.Drawing.Size(102, 20);
            this.activeTagsLbl.TabIndex = 16;
            this.activeTagsLbl.Text = "Filter by Tags: ";
            // 
            // filterTagTxt
            // 
            this.filterTagTxt.Location = new System.Drawing.Point(83, 35);
            this.filterTagTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filterTagTxt.Name = "filterTagTxt";
            this.filterTagTxt.PlaceholderText = " Search for Tag";
            this.filterTagTxt.Size = new System.Drawing.Size(197, 27);
            this.filterTagTxt.TabIndex = 17;
            // 
            // clearFiltersBtn
            // 
            this.clearFiltersBtn.Location = new System.Drawing.Point(383, 81);
            this.clearFiltersBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clearFiltersBtn.Name = "clearFiltersBtn";
            this.clearFiltersBtn.Size = new System.Drawing.Size(87, 31);
            this.clearFiltersBtn.TabIndex = 18;
            this.clearFiltersBtn.Text = "Clear Filters";
            this.clearFiltersBtn.UseVisualStyleBackColor = true;
            this.clearFiltersBtn.Click += new System.EventHandler(this.clearFiltersBtn_Click);
            // 
            // tagsCmb
            // 
            this.tagsCmb.FormattingEnabled = true;
            this.tagsCmb.Location = new System.Drawing.Point(107, 80);
            this.tagsCmb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tagsCmb.Name = "tagsCmb";
            this.tagsCmb.Size = new System.Drawing.Size(157, 28);
            this.tagsCmb.TabIndex = 19;
            // 
            // deleteFilterBtn
            // 
            this.deleteFilterBtn.Location = new System.Drawing.Point(283, 81);
            this.deleteFilterBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteFilterBtn.Name = "deleteFilterBtn";
            this.deleteFilterBtn.Size = new System.Drawing.Size(87, 29);
            this.deleteFilterBtn.TabIndex = 20;
            this.deleteFilterBtn.Text = "Remove";
            this.deleteFilterBtn.UseVisualStyleBackColor = true;
            this.deleteFilterBtn.Click += new System.EventHandler(this.deleteFilterBtn_Click);
            // 
            // availableCheckbox
            // 
            this.availableCheckbox.AutoSize = true;
            this.availableCheckbox.Location = new System.Drawing.Point(277, 175);
            this.availableCheckbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.availableCheckbox.Name = "availableCheckbox";
            this.availableCheckbox.Size = new System.Drawing.Size(148, 24);
            this.availableCheckbox.TabIndex = 21;
            this.availableCheckbox.Text = "Available Recipes";
            this.availableCheckbox.UseVisualStyleBackColor = true;
            this.availableCheckbox.CheckedChanged += new System.EventHandler(this.showAvailableRecipesCheck_Changed);
            // 
            // allRecipesButton
            // 
            this.allRecipesButton.Location = new System.Drawing.Point(139, 169);
            this.allRecipesButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.allRecipesButton.Name = "allRecipesButton";
            this.allRecipesButton.Size = new System.Drawing.Size(126, 31);
            this.allRecipesButton.TabIndex = 22;
            this.allRecipesButton.Text = "All Recipes";
            this.allRecipesButton.UseVisualStyleBackColor = true;
            this.allRecipesButton.Click += new System.EventHandler(this.showAllRecipesButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // addRecipeButton
            // 
            this.addRecipeButton.Location = new System.Drawing.Point(78, 765);
            this.addRecipeButton.Name = "addRecipeButton";
            this.addRecipeButton.Size = new System.Drawing.Size(165, 42);
            this.addRecipeButton.TabIndex = 23;
            this.addRecipeButton.Text = "Add Recipe";
            this.addRecipeButton.UseVisualStyleBackColor = true;
            this.addRecipeButton.Click += new System.EventHandler(this.addRecipeButton_Click);
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 823);
            this.Controls.Add(this.addRecipeButton);
            this.Controls.Add(this.allRecipesButton);
            this.Controls.Add(this.availableCheckbox);
            this.Controls.Add(this.deleteFilterBtn);
            this.Controls.Add(this.tagsCmb);
            this.Controls.Add(this.clearFiltersBtn);
            this.Controls.Add(this.filterTagTxt);
            this.Controls.Add(this.activeTagsLbl);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.plannerMenuButton);
            this.Controls.Add(this.pageCountLabel);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.lastPageButton);
            this.Controls.Add(this.beginningButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.noRecipesLabel);
            this.Controls.Add(this.viewPantryButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.recipeListView);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Homepage";
            this.Text = "Recipe Planner Homepage";
            this.plannerContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView recipeListView;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button viewPantryButton;
        private RadioButton showAvailableRecipesRadioButton;
        private RadioButton showAllRecipesRadioButton;
        private Label noRecipesLabel;
        private Button nextButton;
        private Button beginningButton;
        private Button lastPageButton;
        private Button previousButton;
        private Label pageCountLabel;
        private Button plannerMenuButton;
        private ContextMenuStrip plannerContextMenuStrip;
        private ToolStripMenuItem viewMealPlanToolStripMenuItem;
        private Button filterButton;
        private Label activeTagsLbl;
        private TextBox filterTagTxt;
        private Button clearFiltersBtn;
        private ComboBox tagsCmb;
        private Button deleteFilterBtn;
        private CheckBox availableCheckbox;
        private Button allRecipesButton;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem viewShoppingListToolStripMenuItem;
        private Button addRecipeButton;
    }
}

