﻿using RecipePlannerDesktopApplication;
using RecipePlannerLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RecipePlannerFinalDemoAdditions
{
    /// <summary>
    ///     The RecipeTagAdd partial class
    /// </summary>
    public partial class RecipeTagAdd : Form
    {
        private List<string> tags;
        private Recipe recipe;

        /// <summary>
        ///     Initializes the RecipeTagAdd page that sets the tags.
        ///
        ///     Precondition: none
        ///     Postcondition: getTags().Count() == 0
        /// </summary>
        public RecipeTagAdd()
        {
            InitializeComponent();
            tags = new List<string>();
        }

        /// <summary>
        ///     Initializes the RecipeTagAdd page with the specified tagDatas list and the recipe.
        ///
        ///     Precondition: tagDatas != null && recipe != null
        ///     Postcondition: getTags() == tagDatas && getRecipe() == recipe
        /// </summary>
        /// <param name="tagDatas">the tagDatas list</param>
        /// <param name="recipe">the recipe</param>
        public RecipeTagAdd(List<string> tagDatas, Recipe recipe) :this()
        {
            tags = tagDatas;
            this.recipe = recipe;
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
                bool isDuplicate = false;
                if (this.tags != null)
                {
                    foreach (DataGridViewRow row in tagsDataGridView.Rows)
                    {
                        string existingTag = row.Cells["tagNameColumn"].Value.ToString();

                        if (tag.Equals(existingTag))
                        {
                            this.errorTagFieldLabel.Text = "This tag already exists";
                            this.errorTagFieldLabel.Visible = true;
                            isDuplicate = true;
                            break;
                        }
                    }
                }

                if (isDuplicate == true)
                {
                    return;
                }
                else
                {
                    this.errorTagFieldLabel.Visible = false;

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
            foreach (DataGridViewRow row in tagsDataGridView.Rows)
            {
                string tagData;
                tagData = row.Cells["tagNameColumn"].Value.ToString();

                if (!tags.Contains(tagData))
                {
                    tags.Add(tagData);
                }
            }

            var recipeSummary = new RecipeSummary(this.recipe);

            recipeSummary.SetTagData(tags);

            this.Hide();

            recipeSummary.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            var recipeSummary = new RecipeSummary(this.recipe);

            recipeSummary.SetTagData(tags);

            this.Hide();

            recipeSummary.Show();
        }

        /// <summary>
        ///     Adds a row to the tag grid view based on the tag name.
        ///
        ///     Precondition: tagName != null
        ///     Postcondition: tagsDataGridView.Rows.Count = @prev tagsDataGridView.Rows.Count + 1
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

        private void RecipeTagAdd_Load(object sender, EventArgs e)
        {
            if (tags != null)
            {
                foreach (string tagData in tags)
                {
                    int rowIndex = this.tagsDataGridView.Rows.Add();
                    tagsDataGridView.Rows[rowIndex].Cells["tagNameColumn"].Value = tagData;
                }
            }
        }

        private void tagsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == tagsDataGridView.Columns["removeColumn"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = tagsDataGridView.Rows[e.RowIndex];

                string tagData = row.Cells["tagNameColumn"].Value.ToString();

                tags.Remove(tagData);

                tagsDataGridView.Rows.RemoveAt(e.RowIndex);
            }

        }

        private void tagsDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < tags.Count)
            {
                string updatedValue = tagsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                string oldTag = tags[e.RowIndex];

                if (updatedValue != oldTag)
                {
                    tags[e.RowIndex] = updatedValue;
                }
            }
        }
    }
}
