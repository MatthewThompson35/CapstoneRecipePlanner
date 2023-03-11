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
            this.viewIngredientsButton = new System.Windows.Forms.Button();
            this.showAvailableRecipesRadioButton = new System.Windows.Forms.RadioButton();
            this.showAllRecipesRadioButton = new System.Windows.Forms.RadioButton();
            this.noRecipesLabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.beginningButton = new System.Windows.Forms.Button();
            this.lastPageButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.pageCountLabel = new System.Windows.Forms.Label();
            this.plannerMenuButton = new System.Windows.Forms.Button();
            this.plannerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewMealPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterButton = new System.Windows.Forms.Button();
            this.activeTagsLbl = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.plannerContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // recipeListView
            // 
            this.recipeListView.Location = new System.Drawing.Point(32, 149);
            this.recipeListView.Name = "recipeListView";
            this.recipeListView.Size = new System.Drawing.Size(379, 347);
            this.recipeListView.TabIndex = 0;
            this.recipeListView.UseCompatibleStateImageBehavior = false;
            this.recipeListView.SelectedIndexChanged += new System.EventHandler(this.recipeListView_SelectedIndexChanged);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(372, 9);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(66, 29);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(175, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Recipes";
            // 
            // viewIngredientsButton
            // 
            this.viewIngredientsButton.Location = new System.Drawing.Point(59, 569);
            this.viewIngredientsButton.Name = "viewIngredientsButton";
            this.viewIngredientsButton.Size = new System.Drawing.Size(334, 33);
            this.viewIngredientsButton.TabIndex = 4;
            this.viewIngredientsButton.Text = "View Ingredients";
            this.viewIngredientsButton.UseVisualStyleBackColor = true;
            this.viewIngredientsButton.Click += new System.EventHandler(this.viewIngredientsButton_Click);
            // 
            // showAvailableRecipesRadioButton
            // 
            this.showAvailableRecipesRadioButton.AutoSize = true;
            this.showAvailableRecipesRadioButton.Location = new System.Drawing.Point(82, 14);
            this.showAvailableRecipesRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showAvailableRecipesRadioButton.Name = "showAvailableRecipesRadioButton";
            this.showAvailableRecipesRadioButton.Size = new System.Drawing.Size(148, 19);
            this.showAvailableRecipesRadioButton.TabIndex = 6;
            this.showAvailableRecipesRadioButton.TabStop = true;
            this.showAvailableRecipesRadioButton.Text = "Show Available Recipes";
            this.showAvailableRecipesRadioButton.UseVisualStyleBackColor = true;
            this.showAvailableRecipesRadioButton.CheckedChanged += new System.EventHandler(this.showAvailableRecipesRadioButton_CheckedChanged);
            // 
            // showAllRecipesRadioButton
            // 
            this.showAllRecipesRadioButton.AutoSize = true;
            this.showAllRecipesRadioButton.Location = new System.Drawing.Point(236, 14);
            this.showAllRecipesRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showAllRecipesRadioButton.Name = "showAllRecipesRadioButton";
            this.showAllRecipesRadioButton.Size = new System.Drawing.Size(114, 19);
            this.showAllRecipesRadioButton.TabIndex = 7;
            this.showAllRecipesRadioButton.TabStop = true;
            this.showAllRecipesRadioButton.Text = "Show All Recipes";
            this.showAllRecipesRadioButton.UseVisualStyleBackColor = true;
            this.showAllRecipesRadioButton.CheckedChanged += new System.EventHandler(this.showAllRecipesRadioButton_CheckedChanged);
            // 
            // noRecipesLabel
            // 
            this.noRecipesLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.noRecipesLabel.Location = new System.Drawing.Point(69, 253);
            this.noRecipesLabel.Name = "noRecipesLabel";
            this.noRecipesLabel.Size = new System.Drawing.Size(301, 84);
            this.noRecipesLabel.TabIndex = 8;
            this.noRecipesLabel.Text = "There are no recipes to show";
            this.noRecipesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.noRecipesLabel.Visible = false;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(273, 520);
            this.nextButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(52, 22);
            this.nextButton.TabIndex = 9;
            this.nextButton.Text = ">";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // beginningButton
            // 
            this.beginningButton.Location = new System.Drawing.Point(69, 520);
            this.beginningButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.beginningButton.Name = "beginningButton";
            this.beginningButton.Size = new System.Drawing.Size(45, 22);
            this.beginningButton.TabIndex = 10;
            this.beginningButton.Text = "<|";
            this.beginningButton.UseVisualStyleBackColor = true;
            this.beginningButton.Click += new System.EventHandler(this.beginningButton_Click);
            // 
            // lastPageButton
            // 
            this.lastPageButton.Location = new System.Drawing.Point(330, 520);
            this.lastPageButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lastPageButton.Name = "lastPageButton";
            this.lastPageButton.Size = new System.Drawing.Size(45, 22);
            this.lastPageButton.TabIndex = 11;
            this.lastPageButton.Text = ">|";
            this.lastPageButton.UseVisualStyleBackColor = true;
            this.lastPageButton.Click += new System.EventHandler(this.lastPageButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Location = new System.Drawing.Point(119, 520);
            this.previousButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(52, 22);
            this.previousButton.TabIndex = 12;
            this.previousButton.Text = "<";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // pageCountLabel
            // 
            this.pageCountLabel.AutoSize = true;
            this.pageCountLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pageCountLabel.Location = new System.Drawing.Point(213, 520);
            this.pageCountLabel.Name = "pageCountLabel";
            this.pageCountLabel.Size = new System.Drawing.Size(19, 21);
            this.pageCountLabel.TabIndex = 13;
            this.pageCountLabel.Text = "1";
            // 
            // plannerMenuButton
            // 
            this.plannerMenuButton.BackColor = System.Drawing.Color.LightCyan;
            this.plannerMenuButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plannerMenuButton.BackgroundImage")));
            this.plannerMenuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plannerMenuButton.Location = new System.Drawing.Point(10, 9);
            this.plannerMenuButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.plannerMenuButton.Name = "plannerMenuButton";
            this.plannerMenuButton.Size = new System.Drawing.Size(54, 42);
            this.plannerMenuButton.TabIndex = 14;
            this.plannerMenuButton.UseVisualStyleBackColor = false;
            this.plannerMenuButton.Click += new System.EventHandler(this.plannerMenuButton_Click);
            // 
            // plannerContextMenuStrip
            // 
            this.plannerContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.plannerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewMealPlanToolStripMenuItem});
            this.plannerContextMenuStrip.Name = "plannerContextMenuStrip";
            this.plannerContextMenuStrip.Size = new System.Drawing.Size(155, 26);
            // 
            // viewMealPlanToolStripMenuItem
            // 
            this.viewMealPlanToolStripMenuItem.Name = "viewMealPlanToolStripMenuItem";
            this.viewMealPlanToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.viewMealPlanToolStripMenuItem.Text = "View Meal Plan";
            this.viewMealPlanToolStripMenuItem.Click += new System.EventHandler(this.viewMealPlanToolStripMenuItem_Click);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(288, 49);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(62, 23);
            this.filterButton.TabIndex = 15;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // activeTagsLbl
            // 
            this.activeTagsLbl.AutoSize = true;
            this.activeTagsLbl.Location = new System.Drawing.Point(69, 86);
            this.activeTagsLbl.Name = "activeTagsLbl";
            this.activeTagsLbl.Size = new System.Drawing.Size(81, 15);
            this.activeTagsLbl.TabIndex = 16;
            this.activeTagsLbl.Text = "Filter by Tags: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(82, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 23);
            this.textBox1.TabIndex = 17;
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 617);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.activeTagsLbl);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.plannerMenuButton);
            this.Controls.Add(this.pageCountLabel);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.lastPageButton);
            this.Controls.Add(this.beginningButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.noRecipesLabel);
            this.Controls.Add(this.showAllRecipesRadioButton);
            this.Controls.Add(this.showAvailableRecipesRadioButton);
            this.Controls.Add(this.viewIngredientsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.recipeListView);
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
        private System.Windows.Forms.Button viewIngredientsButton;
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
        private TextBox textBox1;
    }
}

