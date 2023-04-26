namespace RecipePlannerDesktopApplication
{
    partial class RecipeDetailsPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.recipeDetailsTextBox = new System.Windows.Forms.TextBox();
            this.daysComboBox = new System.Windows.Forms.ComboBox();
            this.mealTypeComboBox = new System.Windows.Forms.ComboBox();
            this.dayLabel = new System.Windows.Forms.Label();
            this.mealTypeLabel = new System.Windows.Forms.Label();
            this.addToMealPlanButton = new System.Windows.Forms.Button();
            this.weekComboBox = new System.Windows.Forms.ComboBox();
            this.weekLabel = new System.Windows.Forms.Label();
            this.updateSuccessfullyLabel = new System.Windows.Forms.Label();
            this.plannerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.findRecipeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMealPlanToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.yesButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.cookButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.comboboxesErrorLabel = new System.Windows.Forms.Label();
            this.isCookedLabel = new System.Windows.Forms.Label();
            this.cookYesButton = new System.Windows.Forms.Button();
            this.cookNoButton = new System.Windows.Forms.Button();
            this.shareRecipeButton = new System.Windows.Forms.Button();
            this.plannerContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(120, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recipe Information";
            // 
            // recipeDetailsTextBox
            // 
            this.recipeDetailsTextBox.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.recipeDetailsTextBox.Location = new System.Drawing.Point(52, 241);
            this.recipeDetailsTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.recipeDetailsTextBox.Multiline = true;
            this.recipeDetailsTextBox.Name = "recipeDetailsTextBox";
            this.recipeDetailsTextBox.ReadOnly = true;
            this.recipeDetailsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.recipeDetailsTextBox.Size = new System.Drawing.Size(350, 330);
            this.recipeDetailsTextBox.TabIndex = 2;
            // 
            // daysComboBox
            // 
            this.daysComboBox.FormattingEnabled = true;
            this.daysComboBox.Location = new System.Drawing.Point(67, 82);
            this.daysComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.daysComboBox.Name = "daysComboBox";
            this.daysComboBox.Size = new System.Drawing.Size(80, 23);
            this.daysComboBox.TabIndex = 3;
            this.daysComboBox.Visible = false;
            this.daysComboBox.SelectedIndexChanged += new System.EventHandler(this.daysComboBox_SelectedIndexChanged);
            // 
            // mealTypeComboBox
            // 
            this.mealTypeComboBox.FormattingEnabled = true;
            this.mealTypeComboBox.Location = new System.Drawing.Point(177, 82);
            this.mealTypeComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mealTypeComboBox.Name = "mealTypeComboBox";
            this.mealTypeComboBox.Size = new System.Drawing.Size(94, 23);
            this.mealTypeComboBox.TabIndex = 4;
            this.mealTypeComboBox.Visible = false;
            this.mealTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.mealTypeComboBox_SelectedIndexChanged);
            // 
            // dayLabel
            // 
            this.dayLabel.AutoSize = true;
            this.dayLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dayLabel.Location = new System.Drawing.Point(88, 58);
            this.dayLabel.Name = "dayLabel";
            this.dayLabel.Size = new System.Drawing.Size(37, 21);
            this.dayLabel.TabIndex = 5;
            this.dayLabel.Text = "Day";
            this.dayLabel.Visible = false;
            // 
            // mealTypeLabel
            // 
            this.mealTypeLabel.AutoSize = true;
            this.mealTypeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mealTypeLabel.Location = new System.Drawing.Point(177, 58);
            this.mealTypeLabel.Name = "mealTypeLabel";
            this.mealTypeLabel.Size = new System.Drawing.Size(80, 21);
            this.mealTypeLabel.TabIndex = 6;
            this.mealTypeLabel.Text = "Meal Type";
            this.mealTypeLabel.Visible = false;
            // 
            // addToMealPlanButton
            // 
            this.addToMealPlanButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.addToMealPlanButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addToMealPlanButton.Location = new System.Drawing.Point(150, 144);
            this.addToMealPlanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addToMealPlanButton.Name = "addToMealPlanButton";
            this.addToMealPlanButton.Size = new System.Drawing.Size(155, 28);
            this.addToMealPlanButton.TabIndex = 7;
            this.addToMealPlanButton.Text = "Add to Meal Plan";
            this.addToMealPlanButton.UseVisualStyleBackColor = false;
            this.addToMealPlanButton.Click += new System.EventHandler(this.addToMealPlanButton_Click);
            // 
            // weekComboBox
            // 
            this.weekComboBox.FormattingEnabled = true;
            this.weekComboBox.Location = new System.Drawing.Point(296, 82);
            this.weekComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.weekComboBox.Name = "weekComboBox";
            this.weekComboBox.Size = new System.Drawing.Size(80, 23);
            this.weekComboBox.TabIndex = 8;
            this.weekComboBox.Visible = false;
            this.weekComboBox.SelectedIndexChanged += new System.EventHandler(this.weekComboBox_SelectedIndexChanged);
            // 
            // weekLabel
            // 
            this.weekLabel.AutoSize = true;
            this.weekLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.weekLabel.Location = new System.Drawing.Point(310, 58);
            this.weekLabel.Name = "weekLabel";
            this.weekLabel.Size = new System.Drawing.Size(48, 21);
            this.weekLabel.TabIndex = 9;
            this.weekLabel.Text = "Week";
            this.weekLabel.Visible = false;
            // 
            // updateSuccessfullyLabel
            // 
            this.updateSuccessfullyLabel.AutoSize = true;
            this.updateSuccessfullyLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.updateSuccessfullyLabel.ForeColor = System.Drawing.Color.Green;
            this.updateSuccessfullyLabel.Location = new System.Drawing.Point(103, 118);
            this.updateSuccessfullyLabel.Name = "updateSuccessfullyLabel";
            this.updateSuccessfullyLabel.Size = new System.Drawing.Size(243, 15);
            this.updateSuccessfullyLabel.TabIndex = 10;
            this.updateSuccessfullyLabel.Text = "Meal is updated for this day and meal type.";
            this.updateSuccessfullyLabel.Visible = false;
            // 
            // plannerContextMenuStrip
            // 
            this.plannerContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.plannerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findRecipeToolStripMenuItem,
            this.viewMealPlanToolStripMenuItem1});
            this.plannerContextMenuStrip.Name = "plannerContextMenuStrip";
            this.plannerContextMenuStrip.Size = new System.Drawing.Size(155, 48);
            // 
            // findRecipeToolStripMenuItem
            // 
            this.findRecipeToolStripMenuItem.Name = "findRecipeToolStripMenuItem";
            this.findRecipeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.findRecipeToolStripMenuItem.Text = "Find Recipe";
            this.findRecipeToolStripMenuItem.Click += new System.EventHandler(this.findRecipeToolStripMenuItem_Click);
            // 
            // viewMealPlanToolStripMenuItem1
            // 
            this.viewMealPlanToolStripMenuItem1.Name = "viewMealPlanToolStripMenuItem1";
            this.viewMealPlanToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.viewMealPlanToolStripMenuItem1.Text = "View Meal Plan";
            this.viewMealPlanToolStripMenuItem1.Click += new System.EventHandler(this.viewMealPlanToolStripMenuItem1_Click);
            // 
            // yesButton
            // 
            this.yesButton.BackColor = System.Drawing.Color.LawnGreen;
            this.yesButton.Location = new System.Drawing.Point(62, 148);
            this.yesButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(82, 22);
            this.yesButton.TabIndex = 16;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = false;
            this.yesButton.Visible = false;
            this.yesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // noButton
            // 
            this.noButton.BackColor = System.Drawing.Color.Red;
            this.noButton.Location = new System.Drawing.Point(310, 148);
            this.noButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(82, 22);
            this.noButton.TabIndex = 17;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = false;
            this.noButton.Visible = false;
            this.noButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(10, 9);
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(55, 22);
            this.backButton.TabIndex = 18;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // cookButton
            // 
            this.cookButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cookButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cookButton.Location = new System.Drawing.Point(375, 9);
            this.cookButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cookButton.Name = "cookButton";
            this.cookButton.Size = new System.Drawing.Size(64, 22);
            this.cookButton.TabIndex = 19;
            this.cookButton.Text = "Cook";
            this.cookButton.UseVisualStyleBackColor = false;
            this.cookButton.Click += new System.EventHandler(this.cookButton_Click);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.LawnGreen;
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addButton.Location = new System.Drawing.Point(62, 148);
            this.addButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(82, 22);
            this.addButton.TabIndex = 20;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Visible = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Red;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancelButton.Location = new System.Drawing.Point(310, 148);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(82, 22);
            this.cancelButton.TabIndex = 21;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // comboboxesErrorLabel
            // 
            this.comboboxesErrorLabel.AutoSize = true;
            this.comboboxesErrorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.comboboxesErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.comboboxesErrorLabel.Location = new System.Drawing.Point(156, 118);
            this.comboboxesErrorLabel.Name = "comboboxesErrorLabel";
            this.comboboxesErrorLabel.Size = new System.Drawing.Size(140, 15);
            this.comboboxesErrorLabel.TabIndex = 22;
            this.comboboxesErrorLabel.Text = "Please select all options.";
            this.comboboxesErrorLabel.Visible = false;
            // 
            // isCookedLabel
            // 
            this.isCookedLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.isCookedLabel.ForeColor = System.Drawing.Color.Green;
            this.isCookedLabel.Location = new System.Drawing.Point(140, -2);
            this.isCookedLabel.Name = "isCookedLabel";
            this.isCookedLabel.Size = new System.Drawing.Size(181, 55);
            this.isCookedLabel.TabIndex = 23;
            this.isCookedLabel.Text = "This meal has been cooked";
            this.isCookedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.isCookedLabel.Visible = false;
            // 
            // cookYesButton
            // 
            this.cookYesButton.BackColor = System.Drawing.Color.LawnGreen;
            this.cookYesButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cookYesButton.Location = new System.Drawing.Point(103, 56);
            this.cookYesButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cookYesButton.Name = "cookYesButton";
            this.cookYesButton.Size = new System.Drawing.Size(82, 22);
            this.cookYesButton.TabIndex = 24;
            this.cookYesButton.Text = "Yes";
            this.cookYesButton.UseVisualStyleBackColor = false;
            this.cookYesButton.Visible = false;
            this.cookYesButton.Click += new System.EventHandler(this.cookYesButton_Click);
            // 
            // cookNoButton
            // 
            this.cookNoButton.BackColor = System.Drawing.Color.Red;
            this.cookNoButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cookNoButton.Location = new System.Drawing.Point(293, 56);
            this.cookNoButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cookNoButton.Name = "cookNoButton";
            this.cookNoButton.Size = new System.Drawing.Size(82, 22);
            this.cookNoButton.TabIndex = 25;
            this.cookNoButton.Text = "No";
            this.cookNoButton.UseVisualStyleBackColor = false;
            this.cookNoButton.Visible = false;
            this.cookNoButton.Click += new System.EventHandler(this.cookNoButton_Click);
            // 
            // shareRecipeButton
            // 
            this.shareRecipeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.shareRecipeButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.shareRecipeButton.Location = new System.Drawing.Point(150, 176);
            this.shareRecipeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.shareRecipeButton.Name = "shareRecipeButton";
            this.shareRecipeButton.Size = new System.Drawing.Size(155, 28);
            this.shareRecipeButton.TabIndex = 26;
            this.shareRecipeButton.Text = "Recommend Recipe";
            this.shareRecipeButton.UseVisualStyleBackColor = false;
            this.shareRecipeButton.Click += new System.EventHandler(this.shareRecipeButton_Click);
            // 
            // RecipeDetailsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(450, 617);
            this.Controls.Add(this.shareRecipeButton);
            this.Controls.Add(this.cookNoButton);
            this.Controls.Add(this.cookYesButton);
            this.Controls.Add(this.isCookedLabel);
            this.Controls.Add(this.comboboxesErrorLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cookButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.updateSuccessfullyLabel);
            this.Controls.Add(this.weekLabel);
            this.Controls.Add(this.weekComboBox);
            this.Controls.Add(this.addToMealPlanButton);
            this.Controls.Add(this.mealTypeLabel);
            this.Controls.Add(this.dayLabel);
            this.Controls.Add(this.mealTypeComboBox);
            this.Controls.Add(this.daysComboBox);
            this.Controls.Add(this.recipeDetailsTextBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RecipeDetailsPage";
            this.Text = "RecipeDetailsPage";
            this.plannerContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private TextBox recipeDetailsTextBox;
        private ComboBox daysComboBox;
        private ComboBox mealTypeComboBox;
        private Label dayLabel;
        private Label mealTypeLabel;
        private Button addToMealPlanButton;
        private ComboBox weekComboBox;
        private Label weekLabel;
        private Label updateSuccessfullyLabel;
        private ContextMenuStrip plannerContextMenuStrip;
        private ToolStripMenuItem findRecipeToolStripMenuItem;
        private ToolStripMenuItem viewMealPlanToolStripMenuItem1;
        private Button yesButton;
        private Button noButton;
        private Button backButton;
        private Button cookButton;
        private Button addButton;
        private Button cancelButton;
        private Label comboboxesErrorLabel;
        private Label isCookedLabel;
        private Button cookYesButton;
        private Button cookNoButton;
        private Button shareRecipeButton;
    }
}