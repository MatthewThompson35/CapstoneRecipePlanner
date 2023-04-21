namespace RecipePlannerFinalDemoAdditions
{
    partial class RecipeSummary
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.ingredientsListView = new System.Windows.Forms.ListView();
            this.ingredientNameColumn = new System.Windows.Forms.ColumnHeader();
            this.quantityColumn = new System.Windows.Forms.ColumnHeader();
            this.measurementColumn = new System.Windows.Forms.ColumnHeader();
            this.stepsListView = new System.Windows.Forms.ListView();
            this.stepNumColumn = new System.Windows.Forms.ColumnHeader();
            this.stepDescriptionColumn = new System.Windows.Forms.ColumnHeader();
            this.tagsListView = new System.Windows.Forms.ListView();
            this.tagNameColumn = new System.Windows.Forms.ColumnHeader();
            this.addIngredientButton = new System.Windows.Forms.Button();
            this.addStepButton = new System.Windows.Forms.Button();
            this.addTagButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorFieldsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(137, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recipe Summary";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Recipe Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Recipe Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(63, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ingredients:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(67, 353);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "Steps:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(67, 543);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 28);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tags:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(65, 106);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(153, 27);
            this.nameTextBox.TabIndex = 6;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(297, 106);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(153, 27);
            this.descriptionTextBox.TabIndex = 7;
            // 
            // ingredientsListView
            // 
            this.ingredientsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ingredientNameColumn,
            this.quantityColumn,
            this.measurementColumn});
            this.ingredientsListView.Location = new System.Drawing.Point(65, 198);
            this.ingredientsListView.Name = "ingredientsListView";
            this.ingredientsListView.Size = new System.Drawing.Size(383, 139);
            this.ingredientsListView.TabIndex = 8;
            this.ingredientsListView.UseCompatibleStateImageBehavior = false;
            this.ingredientsListView.View = System.Windows.Forms.View.Details;
            // 
            // ingredientNameColumn
            // 
            this.ingredientNameColumn.Text = "Ingredient Name";
            this.ingredientNameColumn.Width = 125;
            // 
            // quantityColumn
            // 
            this.quantityColumn.Text = "Quantity";
            this.quantityColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.quantityColumn.Width = 75;
            // 
            // measurementColumn
            // 
            this.measurementColumn.Text = "Measurement";
            this.measurementColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.measurementColumn.Width = 125;
            // 
            // stepsListView
            // 
            this.stepsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.stepNumColumn,
            this.stepDescriptionColumn});
            this.stepsListView.Location = new System.Drawing.Point(65, 384);
            this.stepsListView.Name = "stepsListView";
            this.stepsListView.Size = new System.Drawing.Size(383, 139);
            this.stepsListView.TabIndex = 9;
            this.stepsListView.UseCompatibleStateImageBehavior = false;
            this.stepsListView.View = System.Windows.Forms.View.Details;
            // 
            // stepNumColumn
            // 
            this.stepNumColumn.Text = "Step Number";
            this.stepNumColumn.Width = 125;
            // 
            // stepDescriptionColumn
            // 
            this.stepDescriptionColumn.Text = "Step Description";
            this.stepDescriptionColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stepDescriptionColumn.Width = 125;
            // 
            // tagsListView
            // 
            this.tagsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tagNameColumn});
            this.tagsListView.Location = new System.Drawing.Point(65, 574);
            this.tagsListView.Name = "tagsListView";
            this.tagsListView.Size = new System.Drawing.Size(383, 139);
            this.tagsListView.TabIndex = 10;
            this.tagsListView.UseCompatibleStateImageBehavior = false;
            this.tagsListView.View = System.Windows.Forms.View.Details;
            // 
            // tagNameColumn
            // 
            this.tagNameColumn.Text = "Tag Name";
            this.tagNameColumn.Width = 100;
            // 
            // addIngredientButton
            // 
            this.addIngredientButton.Location = new System.Drawing.Point(197, 166);
            this.addIngredientButton.Name = "addIngredientButton";
            this.addIngredientButton.Size = new System.Drawing.Size(136, 29);
            this.addIngredientButton.TabIndex = 11;
            this.addIngredientButton.Text = "Add Ingredient";
            this.addIngredientButton.UseVisualStyleBackColor = true;
            this.addIngredientButton.Click += new System.EventHandler(this.addIngredientButton_Click);
            // 
            // addStepButton
            // 
            this.addStepButton.Location = new System.Drawing.Point(197, 352);
            this.addStepButton.Name = "addStepButton";
            this.addStepButton.Size = new System.Drawing.Size(136, 29);
            this.addStepButton.TabIndex = 12;
            this.addStepButton.Text = "Add Step";
            this.addStepButton.UseVisualStyleBackColor = true;
            this.addStepButton.Click += new System.EventHandler(this.addStepButton_Click);
            // 
            // addTagButton
            // 
            this.addTagButton.Location = new System.Drawing.Point(197, 542);
            this.addTagButton.Name = "addTagButton";
            this.addTagButton.Size = new System.Drawing.Size(136, 29);
            this.addTagButton.TabIndex = 13;
            this.addTagButton.Text = "Add Tag";
            this.addTagButton.UseVisualStyleBackColor = true;
            this.addTagButton.Click += new System.EventHandler(this.addTagButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(137, 750);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(94, 29);
            this.addButton.TabIndex = 14;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(297, 750);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 29);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // errorFieldsLabel
            // 
            this.errorFieldsLabel.AutoSize = true;
            this.errorFieldsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.errorFieldsLabel.ForeColor = System.Drawing.Color.Red;
            this.errorFieldsLabel.Location = new System.Drawing.Point(105, 727);
            this.errorFieldsLabel.Name = "errorFieldsLabel";
            this.errorFieldsLabel.Size = new System.Drawing.Size(169, 20);
            this.errorFieldsLabel.TabIndex = 16;
            this.errorFieldsLabel.Text = "Please fill out all fields.";
            this.errorFieldsLabel.Visible = false;
            // 
            // RecipeSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 823);
            this.Controls.Add(this.errorFieldsLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.addTagButton);
            this.Controls.Add(this.addStepButton);
            this.Controls.Add(this.addIngredientButton);
            this.Controls.Add(this.tagsListView);
            this.Controls.Add(this.stepsListView);
            this.Controls.Add(this.ingredientsListView);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RecipeSummary";
            this.Text = "RecipeSummary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox nameTextBox;
        private TextBox descriptionTextBox;
        private ListView ingredientsListView;
        private ListView stepsListView;
        private ListView tagsListView;
        private Button addIngredientButton;
        private Button addStepButton;
        private Button addTagButton;
        private Button addButton;
        private Button cancelButton;
        private Label errorFieldsLabel;
        private ColumnHeader stepNumColumn;
        private ColumnHeader stepDescriptionColumn;
        private ColumnHeader tagNameColumn;
        private ColumnHeader ingredientNameColumn;
        private ColumnHeader quantityColumn;
        private ColumnHeader measurementColumn;
    }
}