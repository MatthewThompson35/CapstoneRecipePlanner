using RecipePlannerDesktopApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipePlannerFinalDemoAdditions
{
    public partial class RecipeTagAdd : Form
    {
        private List<string> tags;
        public RecipeTagAdd()
        {
            InitializeComponent();
            tags = new List<string>();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string tag = null;

            if (String.IsNullOrEmpty(this.tagNameTextBox.Text))
            {
                this.errorTagFieldLabel.Visible = true;
            }
            else
            {
                this.errorTagFieldLabel.Visible = false;
                tag = this.tagNameTextBox.Text;
            }

            if (this.errorTagFieldLabel.Visible == true)
            {
                return;
            }
            else
            {
                foreach (var aTag in this.tags)
                {
                    if (tag.Equals(aTag))
                    {
                        this.errorTagFieldLabel.Text = "This tag already exists";
                        this.errorTagFieldLabel.Visible = true;
                    }
                    else
                    {
                        this.errorTagFieldLabel.Visible = false;
                    }
                }
                if (this.errorTagFieldLabel.Visible == true)
                {
                    return;
                }
                else
                {
                    tags.Add(tag);

                    this.AddRowToTagGridView(tag);
                    this.tagSuccessLabel.Visible = true;

                    this.clearTagNameField();
                }
            }
        }

        private void clearTagNameField()
        {
            this.tagNameTextBox.Clear();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            var recipeSummary = new RecipeSummary();

            this.Hide();

            recipeSummary.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            var homepage = new Homepage();

            this.Hide();

            homepage.Show();
        }

        /// <summary>
        ///     Adds a row to the tag grid view based on the tag name.
        /// </summary>
        /// <param name="tagName">the tag name</param>
        public void AddRowToTagGridView(string tagName)
        {
            this.tagsDataGridView.Rows.Add(tagName);
        }

        private void tagNameTextBox_Click(object sender, EventArgs e)
        {
            this.tagSuccessLabel.Visible = false;
        }
    }
}
