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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipeDetailsPage));
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
            this.plannerMenuButton = new System.Windows.Forms.Button();
            this.plannerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.findRecipeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMealPlanToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.plannerContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(133, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recipe Information";
            // 
            // recipeDetailsTextBox
            // 
            this.recipeDetailsTextBox.Enabled = false;
            this.recipeDetailsTextBox.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.recipeDetailsTextBox.Location = new System.Drawing.Point(53, 176);
            this.recipeDetailsTextBox.Multiline = true;
            this.recipeDetailsTextBox.Name = "recipeDetailsTextBox";
            this.recipeDetailsTextBox.Size = new System.Drawing.Size(399, 438);
            this.recipeDetailsTextBox.TabIndex = 2;
            // 
            // daysComboBox
            // 
            this.daysComboBox.FormattingEnabled = true;
            this.daysComboBox.Location = new System.Drawing.Point(81, 681);
            this.daysComboBox.Name = "daysComboBox";
            this.daysComboBox.Size = new System.Drawing.Size(91, 28);
            this.daysComboBox.TabIndex = 3;
            this.daysComboBox.SelectedIndexChanged += new System.EventHandler(this.daysComboBox_SelectedIndexChanged);
            // 
            // mealTypeComboBox
            // 
            this.mealTypeComboBox.FormattingEnabled = true;
            this.mealTypeComboBox.Location = new System.Drawing.Point(206, 681);
            this.mealTypeComboBox.Name = "mealTypeComboBox";
            this.mealTypeComboBox.Size = new System.Drawing.Size(107, 28);
            this.mealTypeComboBox.TabIndex = 4;
            this.mealTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.mealTypeComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(104, 650);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Day";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(206, 650);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Meal Type";
            // 
            // addToMealPlanButton
            // 
            this.addToMealPlanButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.addToMealPlanButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addToMealPlanButton.Location = new System.Drawing.Point(161, 764);
            this.addToMealPlanButton.Name = "addToMealPlanButton";
            this.addToMealPlanButton.Size = new System.Drawing.Size(177, 37);
            this.addToMealPlanButton.TabIndex = 7;
            this.addToMealPlanButton.Text = "Add to Meal Plan";
            this.addToMealPlanButton.UseVisualStyleBackColor = false;
            this.addToMealPlanButton.Click += new System.EventHandler(this.addToMealPlanButton_Click);
            // 
            // weekComboBox
            // 
            this.weekComboBox.FormattingEnabled = true;
            this.weekComboBox.Location = new System.Drawing.Point(342, 681);
            this.weekComboBox.Name = "weekComboBox";
            this.weekComboBox.Size = new System.Drawing.Size(91, 28);
            this.weekComboBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(358, 650);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 28);
            this.label4.TabIndex = 9;
            this.label4.Text = "Week";
            // 
            // errorAddToMealPlanLabel
            // 
            this.errorAddToMealPlanLabel.AutoSize = true;
            this.errorAddToMealPlanLabel.ForeColor = System.Drawing.Color.Red;
            this.errorAddToMealPlanLabel.Location = new System.Drawing.Point(118, 730);
            this.errorAddToMealPlanLabel.Name = "errorAddToMealPlanLabel";
            this.errorAddToMealPlanLabel.Size = new System.Drawing.Size(290, 20);
            this.errorAddToMealPlanLabel.TabIndex = 10;
            this.errorAddToMealPlanLabel.Text = "There is a meal already added for this day.";
            this.errorAddToMealPlanLabel.Visible = false;
            // 
            // plannerMenuButton
            // 
            this.plannerMenuButton.BackColor = System.Drawing.Color.LightCyan;
            this.plannerMenuButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plannerMenuButton.BackgroundImage")));
            this.plannerMenuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plannerMenuButton.Location = new System.Drawing.Point(12, 12);
            this.plannerMenuButton.Name = "plannerMenuButton";
            this.plannerMenuButton.Size = new System.Drawing.Size(62, 56);
            this.plannerMenuButton.TabIndex = 15;
            this.plannerMenuButton.UseVisualStyleBackColor = false;
            this.plannerMenuButton.Click += new System.EventHandler(this.plannerMenuButton_Click);
            // 
            // plannerContextMenuStrip
            // 
            this.plannerContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.plannerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findRecipeToolStripMenuItem,
            this.viewMealPlanToolStripMenuItem1});
            this.plannerContextMenuStrip.Name = "plannerContextMenuStrip";
            this.plannerContextMenuStrip.Size = new System.Drawing.Size(180, 52);
            // 
            // findRecipeToolStripMenuItem
            // 
            this.findRecipeToolStripMenuItem.Name = "findRecipeToolStripMenuItem";
            this.findRecipeToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.findRecipeToolStripMenuItem.Text = "Find Recipe";
            this.findRecipeToolStripMenuItem.Click += new System.EventHandler(this.findRecipeToolStripMenuItem_Click);
            // 
            // viewMealPlanToolStripMenuItem1
            // 
            this.viewMealPlanToolStripMenuItem1.Name = "viewMealPlanToolStripMenuItem1";
            this.viewMealPlanToolStripMenuItem1.Size = new System.Drawing.Size(179, 24);
            this.viewMealPlanToolStripMenuItem1.Text = "View Meal Plan";
            this.viewMealPlanToolStripMenuItem1.Click += new System.EventHandler(this.viewMealPlanToolStripMenuItem1_Click);
            // 
            // RecipeDetailsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 823);
            this.Controls.Add(this.plannerMenuButton);
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
        private Label label2;
        private Label label3;
        private Button addToMealPlanButton;
        private ComboBox weekComboBox;
        private Label label4;
        private Label errorAddToMealPlanLabel;
        private Button plannerMenuButton;
        private ContextMenuStrip plannerContextMenuStrip;
        private ToolStripMenuItem findRecipeToolStripMenuItem;
        private ToolStripMenuItem viewMealPlanToolStripMenuItem1;
    }
}