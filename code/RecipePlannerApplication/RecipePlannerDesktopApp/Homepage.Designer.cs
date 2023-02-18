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
            this.recipeTextBox = new System.Windows.Forms.TextBox();
            this.viewIngredientsButton = new System.Windows.Forms.Button();
            this.addRecipeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // recipeListView
            // 
            this.recipeListView.HideSelection = false;
            this.recipeListView.Location = new System.Drawing.Point(37, 107);
            this.recipeListView.Name = "recipeListView";
            this.recipeListView.Size = new System.Drawing.Size(433, 300);
            this.recipeListView.TabIndex = 0;
            this.recipeListView.UseCompatibleStateImageBehavior = false;
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(406, 25);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(76, 38);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(204, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Recipes";
            // 
            // recipeTextBox
            // 
            this.recipeTextBox.Location = new System.Drawing.Point(37, 435);
            this.recipeTextBox.Multiline = true;
            this.recipeTextBox.Name = "recipeTextBox";
            this.recipeTextBox.Size = new System.Drawing.Size(433, 123);
            this.recipeTextBox.TabIndex = 3;
            // 
            // viewIngredientsButton
            // 
            this.viewIngredientsButton.Location = new System.Drawing.Point(62, 579);
            this.viewIngredientsButton.Name = "viewIngredientsButton";
            this.viewIngredientsButton.Size = new System.Drawing.Size(382, 35);
            this.viewIngredientsButton.TabIndex = 4;
            this.viewIngredientsButton.Text = "View Ingredients";
            this.viewIngredientsButton.UseVisualStyleBackColor = true;
            // 
            // addRecipeButton
            // 
            this.addRecipeButton.Location = new System.Drawing.Point(62, 640);
            this.addRecipeButton.Name = "addRecipeButton";
            this.addRecipeButton.Size = new System.Drawing.Size(382, 33);
            this.addRecipeButton.TabIndex = 5;
            this.addRecipeButton.Text = "Add Recipe";
            this.addRecipeButton.UseVisualStyleBackColor = true;
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 733);
            this.Controls.Add(this.addRecipeButton);
            this.Controls.Add(this.viewIngredientsButton);
            this.Controls.Add(this.recipeTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.recipeListView);
            this.Name = "Homepage";
            this.Text = "Recipe Planner Homepage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView recipeListView;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox recipeTextBox;
        private System.Windows.Forms.Button viewIngredientsButton;
        private System.Windows.Forms.Button addRecipeButton;
    }
}

