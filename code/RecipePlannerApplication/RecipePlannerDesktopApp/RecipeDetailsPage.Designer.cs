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
            // RecipeDetailsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 656);
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
    }
}