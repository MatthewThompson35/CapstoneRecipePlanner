namespace RecipePlannerDesktopApplication
{
    partial class SharedRecipes
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
            this.ingredientsGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.beginningButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.pageLabel = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.serverErrorLabel = new System.Windows.Forms.Label();
            this.recipeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.senderUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ingredientsGridView
            // 
            this.ingredientsGridView.AllowUserToAddRows = false;
            this.ingredientsGridView.AllowUserToDeleteRows = false;
            this.ingredientsGridView.AllowUserToResizeColumns = false;
            this.ingredientsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ingredientsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.recipeName,
            this.senderUsername});
            this.ingredientsGridView.Location = new System.Drawing.Point(26, 119);
            this.ingredientsGridView.Name = "ingredientsGridView";
            this.ingredientsGridView.RowHeadersVisible = false;
            this.ingredientsGridView.RowHeadersWidth = 51;
            this.ingredientsGridView.RowTemplate.Height = 25;
            this.ingredientsGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ingredientsGridView.Size = new System.Drawing.Size(400, 400);
            this.ingredientsGridView.TabIndex = 26;
            this.ingredientsGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ingredientsGridView_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(26, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 24);
            this.label1.TabIndex = 27;
            this.label1.Text = "Shared Recipes";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(86, 538);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 34);
            this.button1.TabIndex = 29;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // beginningButton
            // 
            this.beginningButton.Location = new System.Drawing.Point(26, 538);
            this.beginningButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.beginningButton.Name = "beginningButton";
            this.beginningButton.Size = new System.Drawing.Size(54, 34);
            this.beginningButton.TabIndex = 28;
            this.beginningButton.Text = "<|";
            this.beginningButton.UseVisualStyleBackColor = true;
            this.beginningButton.Click += new System.EventHandler(this.beginningButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(366, 537);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 33);
            this.button3.TabIndex = 32;
            this.button3.Text = ">|";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(305, 538);
            this.nextButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(55, 33);
            this.nextButton.TabIndex = 31;
            this.nextButton.Text = ">";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // pageLabel
            // 
            this.pageLabel.AutoSize = true;
            this.pageLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pageLabel.Location = new System.Drawing.Point(212, 549);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(19, 21);
            this.pageLabel.TabIndex = 30;
            this.pageLabel.Text = "1";
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(351, 12);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 33;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // serverErrorLabel
            // 
            this.serverErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.serverErrorLabel.Location = new System.Drawing.Point(129, 28);
            this.serverErrorLabel.Name = "serverErrorLabel";
            this.serverErrorLabel.Size = new System.Drawing.Size(182, 38);
            this.serverErrorLabel.TabIndex = 34;
            this.serverErrorLabel.Text = "The connection to the server could not be made";
            this.serverErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.serverErrorLabel.Visible = false;
            // 
            // recipeName
            // 
            this.recipeName.DataPropertyName = "recipeName";
            this.recipeName.HeaderText = "Recipe Name";
            this.recipeName.MinimumWidth = 6;
            this.recipeName.Name = "recipeName";
            this.recipeName.Width = 199;
            // 
            // senderUsername
            // 
            this.senderUsername.DataPropertyName = "senderUsername";
            this.senderUsername.HeaderText = "Sender Username";
            this.senderUsername.MinimumWidth = 6;
            this.senderUsername.Name = "senderUsername";
            this.senderUsername.Width = 199;
            // 
            // SharedRecipes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 617);
            this.Controls.Add(this.serverErrorLabel);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.pageLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.beginningButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ingredientsGridView);
            this.Name = "SharedRecipes";
            this.Text = "SharedRecipes";
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView ingredientsGridView;
        private DataGridViewTextBoxColumn RecipeColumn;
        private DataGridViewTextBoxColumn senderUsername;
        private Label label1;
        private Button button1;
        private Button beginningButton;
        private Button button3;
        private Button nextButton;
        private Label pageLabel;
        private Button logoutButton;
        private Label serverErrorLabel;
        private DataGridViewTextBoxColumn recipeName;
        private DataGridViewTextBoxColumn recipe;
    }
}