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
            this.recipeListView = new System.Windows.Forms.ListView();
            this.logoutButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.viewIngredientsButton = new System.Windows.Forms.Button();
            this.showAvailableRecipesRadioButton = new System.Windows.Forms.RadioButton();
            this.showAllRecipesRadioButton = new System.Windows.Forms.RadioButton();
            this.noRecipesLabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.lastPageButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.firstPageButton = new System.Windows.Forms.Button();
            this.pageNumberLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // recipeListView
            // 
            this.recipeListView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.recipeListView.GridLines = true;
            this.recipeListView.Location = new System.Drawing.Point(37, 134);
            this.recipeListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.recipeListView.Name = "recipeListView";
            this.recipeListView.Size = new System.Drawing.Size(433, 527);
            this.recipeListView.TabIndex = 0;
            this.recipeListView.UseCompatibleStateImageBehavior = false;
            this.recipeListView.SelectedIndexChanged += new System.EventHandler(this.recipeListView_SelectedIndexChanged);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(406, 31);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(76, 48);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(204, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Recipes";
            // 
            // viewIngredientsButton
            // 
            this.viewIngredientsButton.Location = new System.Drawing.Point(62, 735);
            this.viewIngredientsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viewIngredientsButton.Name = "viewIngredientsButton";
            this.viewIngredientsButton.Size = new System.Drawing.Size(382, 44);
            this.viewIngredientsButton.TabIndex = 4;
            this.viewIngredientsButton.Text = "View Ingredients";
            this.viewIngredientsButton.UseVisualStyleBackColor = true;
            this.viewIngredientsButton.Click += new System.EventHandler(this.viewIngredientsButton_Click);
            // 
            // showAvailableRecipesRadioButton
            // 
            this.showAvailableRecipesRadioButton.AutoSize = true;
            this.showAvailableRecipesRadioButton.Location = new System.Drawing.Point(42, 12);
            this.showAvailableRecipesRadioButton.Name = "showAvailableRecipesRadioButton";
            this.showAvailableRecipesRadioButton.Size = new System.Drawing.Size(187, 24);
            this.showAvailableRecipesRadioButton.TabIndex = 6;
            this.showAvailableRecipesRadioButton.TabStop = true;
            this.showAvailableRecipesRadioButton.Text = "Show Available Recipes";
            this.showAvailableRecipesRadioButton.UseVisualStyleBackColor = true;
            this.showAvailableRecipesRadioButton.CheckedChanged += new System.EventHandler(this.showAvailableRecipesRadioButton_CheckedChanged);
            // 
            // showAllRecipesRadioButton
            // 
            this.showAllRecipesRadioButton.AutoSize = true;
            this.showAllRecipesRadioButton.Location = new System.Drawing.Point(42, 43);
            this.showAllRecipesRadioButton.Name = "showAllRecipesRadioButton";
            this.showAllRecipesRadioButton.Size = new System.Drawing.Size(143, 24);
            this.showAllRecipesRadioButton.TabIndex = 7;
            this.showAllRecipesRadioButton.TabStop = true;
            this.showAllRecipesRadioButton.Text = "Show All Recipes";
            this.showAllRecipesRadioButton.UseVisualStyleBackColor = true;
            this.showAllRecipesRadioButton.CheckedChanged += new System.EventHandler(this.showAllRecipesRadioButton_CheckedChanged);
            // 
            // noRecipesLabel
            // 
            this.noRecipesLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.noRecipesLabel.Location = new System.Drawing.Point(79, 337);
            this.noRecipesLabel.Name = "noRecipesLabel";
            this.noRecipesLabel.Size = new System.Drawing.Size(344, 112);
            this.noRecipesLabel.TabIndex = 8;
            this.noRecipesLabel.Text = "There are no recipes to show";
            this.noRecipesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.noRecipesLabel.Visible = false;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(312, 673);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(44, 29);
            this.nextButton.TabIndex = 9;
            this.nextButton.Text = ">";
            this.nextButton.UseVisualStyleBackColor = true;
            // 
            // lastPageButton
            // 
            this.lastPageButton.Location = new System.Drawing.Point(362, 673);
            this.lastPageButton.Name = "lastPageButton";
            this.lastPageButton.Size = new System.Drawing.Size(45, 29);
            this.lastPageButton.TabIndex = 10;
            this.lastPageButton.Text = ">|";
            this.lastPageButton.UseVisualStyleBackColor = true;
            // 
            // previousButton
            // 
            this.previousButton.Location = new System.Drawing.Point(141, 673);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(44, 29);
            this.previousButton.TabIndex = 11;
            this.previousButton.Text = "<";
            this.previousButton.UseVisualStyleBackColor = true;
            // 
            // firstPageButton
            // 
            this.firstPageButton.Location = new System.Drawing.Point(88, 673);
            this.firstPageButton.Name = "firstPageButton";
            this.firstPageButton.Size = new System.Drawing.Size(47, 29);
            this.firstPageButton.TabIndex = 12;
            this.firstPageButton.Text = "|<";
            this.firstPageButton.UseVisualStyleBackColor = true;
            // 
            // pageNumberLabel
            // 
            this.pageNumberLabel.AutoSize = true;
            this.pageNumberLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pageNumberLabel.Location = new System.Drawing.Point(237, 673);
            this.pageNumberLabel.Name = "pageNumberLabel";
            this.pageNumberLabel.Size = new System.Drawing.Size(22, 25);
            this.pageNumberLabel.TabIndex = 13;
            this.pageNumberLabel.Text = "1";
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 804);
            this.Controls.Add(this.pageNumberLabel);
            this.Controls.Add(this.firstPageButton);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.lastPageButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.noRecipesLabel);
            this.Controls.Add(this.showAllRecipesRadioButton);
            this.Controls.Add(this.showAvailableRecipesRadioButton);
            this.Controls.Add(this.viewIngredientsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.recipeListView);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Homepage";
            this.Text = "Recipe Planner Homepage";
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
        private Button lastPageButton;
        private Button previousButton;
        private Button firstPageButton;
        private Label pageNumberLabel;
    }
}

