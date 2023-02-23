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
            this.addRecipeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // recipeListView
            // 
            this.recipeListView.Location = new System.Drawing.Point(37, 134);
            this.recipeListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.recipeListView.Name = "recipeListView";
            this.recipeListView.Size = new System.Drawing.Size(433, 527);
            this.recipeListView.TabIndex = 0;
            this.recipeListView.UseCompatibleStateImageBehavior = false;
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
            this.label1.Location = new System.Drawing.Point(204, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Recipes";
            // 
            // viewIngredientsButton
            // 
            this.viewIngredientsButton.Location = new System.Drawing.Point(62, 724);
            this.viewIngredientsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viewIngredientsButton.Name = "viewIngredientsButton";
            this.viewIngredientsButton.Size = new System.Drawing.Size(382, 44);
            this.viewIngredientsButton.TabIndex = 4;
            this.viewIngredientsButton.Text = "View Ingredients";
            this.viewIngredientsButton.UseVisualStyleBackColor = true;
            this.viewIngredientsButton.Click += new System.EventHandler(this.viewIngredientsButton_Click);
            // 
            // addRecipeButton
            // 
            this.addRecipeButton.Location = new System.Drawing.Point(62, 800);
            this.addRecipeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addRecipeButton.Name = "addRecipeButton";
            this.addRecipeButton.Size = new System.Drawing.Size(382, 41);
            this.addRecipeButton.TabIndex = 5;
            this.addRecipeButton.Text = "Add Recipe";
            this.addRecipeButton.UseVisualStyleBackColor = true;
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 916);
            this.Controls.Add(this.addRecipeButton);
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
        private System.Windows.Forms.Button addRecipeButton;
    }
}

