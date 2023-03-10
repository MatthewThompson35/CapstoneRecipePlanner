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
            this.backButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.recipeDetailsTextBox = new System.Windows.Forms.TextBox();
            this.daysComboBox = new System.Windows.Forms.ComboBox();
            this.mealTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addToMealPlanButton = new System.Windows.Forms.Button();
            this.weekComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorAddToMealPlanLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(14, 24);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(94, 29);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(86, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recipe Information";
            // 
            // recipeDetailsTextBox
            // 
            this.recipeDetailsTextBox.Enabled = false;
            this.recipeDetailsTextBox.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.recipeDetailsTextBox.Location = new System.Drawing.Point(41, 178);
            this.recipeDetailsTextBox.Multiline = true;
            this.recipeDetailsTextBox.Name = "recipeDetailsTextBox";
            this.recipeDetailsTextBox.Size = new System.Drawing.Size(338, 438);
            this.recipeDetailsTextBox.TabIndex = 2;
            // 
            // daysComboBox
            // 
            this.daysComboBox.FormattingEnabled = true;
            this.daysComboBox.Location = new System.Drawing.Point(41, 681);
            this.daysComboBox.Name = "daysComboBox";
            this.daysComboBox.Size = new System.Drawing.Size(91, 28);
            this.daysComboBox.TabIndex = 3;
            this.daysComboBox.SelectedIndexChanged += new System.EventHandler(this.daysComboBox_SelectedIndexChanged);
            // 
            // mealTypeComboBox
            // 
            this.mealTypeComboBox.FormattingEnabled = true;
            this.mealTypeComboBox.Location = new System.Drawing.Point(166, 681);
            this.mealTypeComboBox.Name = "mealTypeComboBox";
            this.mealTypeComboBox.Size = new System.Drawing.Size(107, 28);
            this.mealTypeComboBox.TabIndex = 4;
            this.mealTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.mealTypeComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 658);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Day";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 658);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Meal Type";
            // 
            // addToMealPlanButton
            // 
            this.addToMealPlanButton.Location = new System.Drawing.Point(116, 743);
            this.addToMealPlanButton.Name = "addToMealPlanButton";
            this.addToMealPlanButton.Size = new System.Drawing.Size(177, 29);
            this.addToMealPlanButton.TabIndex = 7;
            this.addToMealPlanButton.Text = "Add to Meal Plan";
            this.addToMealPlanButton.UseVisualStyleBackColor = true;
            this.addToMealPlanButton.Click += new System.EventHandler(this.addToMealPlanButton_Click);
            // 
            // weekComboBox
            // 
            this.weekComboBox.FormattingEnabled = true;
            this.weekComboBox.Location = new System.Drawing.Point(302, 681);
            this.weekComboBox.Name = "weekComboBox";
            this.weekComboBox.Size = new System.Drawing.Size(91, 28);
            this.weekComboBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 658);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Week";
            // 
            // errorAddToMealPlanLabel
            // 
            this.errorAddToMealPlanLabel.AutoSize = true;
            this.errorAddToMealPlanLabel.ForeColor = System.Drawing.Color.Red;
            this.errorAddToMealPlanLabel.Location = new System.Drawing.Point(53, 720);
            this.errorAddToMealPlanLabel.Name = "errorAddToMealPlanLabel";
            this.errorAddToMealPlanLabel.Size = new System.Drawing.Size(316, 20);
            this.errorAddToMealPlanLabel.TabIndex = 10;
            this.errorAddToMealPlanLabel.Text = "This meal has already been added for this day.";
            this.errorAddToMealPlanLabel.Visible = false;
            // 
            // RecipeDetailsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 795);
            this.Controls.Add(this.errorAddToMealPlanLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.weekComboBox);
            this.Controls.Add(this.addToMealPlanButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mealTypeComboBox);
            this.Controls.Add(this.daysComboBox);
            this.Controls.Add(this.recipeDetailsTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backButton);
            this.Name = "RecipeDetailsPage";
            this.Text = "RecipeDetailsPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button backButton;
        private Label label1;
        private TextBox recipeDetailsTextBox;
        private ComboBox daysComboBox;
        private ComboBox mealTypeComboBox;
        private Label label2;
        private Label label3;
        private Button addToMealPlanButton;
        private ComboBox weekComboBox;
        private Label label4;
        private Label errorAddToMealPlanLabel;
    }
}