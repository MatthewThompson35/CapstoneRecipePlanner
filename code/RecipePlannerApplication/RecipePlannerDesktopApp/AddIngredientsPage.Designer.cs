namespace RecipePlannerDesktopApplication
{
    partial class AddIngredientsPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.ingredientNameTextBox = new System.Windows.Forms.TextBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.errorQuantityTextLabel = new System.Windows.Forms.Label();
            this.errorTextLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.measurementComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(54, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add a New Ingredient";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(42, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ingredient Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(42, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantity:";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(177, 433);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(94, 29);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(177, 525);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 29);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ingredientNameTextBox
            // 
            this.ingredientNameTextBox.Location = new System.Drawing.Point(251, 245);
            this.ingredientNameTextBox.Name = "ingredientNameTextBox";
            this.ingredientNameTextBox.Size = new System.Drawing.Size(143, 27);
            this.ingredientNameTextBox.TabIndex = 5;
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(251, 296);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(143, 27);
            this.quantityTextBox.TabIndex = 6;
            // 
            // errorQuantityTextLabel
            // 
            this.errorQuantityTextLabel.AutoSize = true;
            this.errorQuantityTextLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.errorQuantityTextLabel.ForeColor = System.Drawing.Color.Red;
            this.errorQuantityTextLabel.Location = new System.Drawing.Point(251, 329);
            this.errorQuantityTextLabel.Name = "errorQuantityTextLabel";
            this.errorQuantityTextLabel.Size = new System.Drawing.Size(206, 20);
            this.errorQuantityTextLabel.TabIndex = 7;
            this.errorQuantityTextLabel.Text = "Quantity must be an integer";
            this.errorQuantityTextLabel.Visible = false;
            // 
            // errorTextLabel
            // 
            this.errorTextLabel.AutoSize = true;
            this.errorTextLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.errorTextLabel.ForeColor = System.Drawing.Color.Red;
            this.errorTextLabel.Location = new System.Drawing.Point(177, 480);
            this.errorTextLabel.Name = "errorTextLabel";
            this.errorTextLabel.Size = new System.Drawing.Size(165, 20);
            this.errorTextLabel.TabIndex = 8;
            this.errorTextLabel.Text = "Please fill out all fields";
            this.errorTextLabel.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(42, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 31);
            this.label4.TabIndex = 9;
            this.label4.Text = "Measurement:";
            // 
            // measurementComboBox
            // 
            this.measurementComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.measurementComboBox.FormattingEnabled = true;
            this.measurementComboBox.Items.AddRange(new object[] {
            "COUNT",
            "OZ",
            "G"});
            this.measurementComboBox.Location = new System.Drawing.Point(251, 351);
            this.measurementComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.measurementComboBox.Name = "measurementComboBox";
            this.measurementComboBox.Size = new System.Drawing.Size(143, 28);
            this.measurementComboBox.TabIndex = 10;
            // 
            // AddIngredientsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 692);
            this.Controls.Add(this.measurementComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.errorTextLabel);
            this.Controls.Add(this.errorQuantityTextLabel);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.ingredientNameTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddIngredientsPage";
            this.Text = "AddIngredientsPopup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button submitButton;
        private Button cancelButton;
        private TextBox ingredientNameTextBox;
        private TextBox quantityTextBox;
        private Label errorQuantityTextLabel;
        private Label errorTextLabel;
        private Label label4;
        private ComboBox comboBox1;
        private ComboBox measurementComboBox;
    }
}