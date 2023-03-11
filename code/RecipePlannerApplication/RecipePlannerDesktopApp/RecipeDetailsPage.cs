using RecipePlannerLibrary.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.AxHost;
using System.Reflection;
using System.Diagnostics;

namespace RecipePlannerDesktopApplication
{
    /// <summary>
    ///     Recipe Detail Page partial class.
    /// </summary>
    public partial class RecipeDetailsPage : Form
    {
        private Homepage homepage;
        
        /// <summary>
        ///     Initializes the recipe details page for the recipes.
        /// </summary>
        /// <param name="page">The homepage.</param>
        public RecipeDetailsPage()
        {
            InitializeComponent();

            
        }

        public RecipeDetailsPage(Homepage page) :this(){
            this.homepage = page;
            this.recipeDetailsTextBox.Text = this.displayRecipeDetails();

            this.populateDayComboBoxValues();
            this.populateMealTypeComboBoxValues();

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            Homepage homepage = new Homepage();
            homepage.Show();

        }

        private string displayRecipeDetails()
        {
            string output = null;

            string description = this.homepage.GetSelectedRecipe().Name + Environment.NewLine + this.homepage.GetSelectedRecipe().Description + Environment.NewLine + Environment.NewLine;

            string steps = "Steps" + Environment.NewLine;

            foreach (var step in RecipeDAL.getStepsForRecipe(this.homepage.GetSelectedRecipe().RecipeId, Connection.ConnectionString))
            {
                steps += step.stepNumber + ". " + step.stepDescription + Environment.NewLine;
            }

            string ingredients = Environment.NewLine + "Ingredients" + Environment.NewLine;

            foreach (var ingredient in RecipeDAL.getIngredientsForRecipe(this.homepage.GetSelectedRecipe().RecipeId, Connection.ConnectionString))
            {
                ingredients += ingredient.Quantity + " " + ingredient.Measurement + " " + ingredient.IngredientName + Environment.NewLine;
            }
            
            output += description + steps + ingredients;
            return output;
        }

        private void addToMealPlanButton_Click(object sender, EventArgs e)
        {
            //string day = this.daysComboBox.SelectedItem.ToString();
            //Debug.WriteLine(day);
            var mealsPage = new PlannedMealsPage();
            this.Hide();
            mealsPage.Show();

        }

        public Recipe getCurrentRecipe()
        {
            return this.homepage.GetSelectedRecipe();
        }

        private void populateDayComboBoxValues()
        {
            foreach (var currentDay in Enum.GetValues(typeof(DayOfWeek)))
            {
                this.daysComboBox.Items.Add(currentDay.ToString());
            }
        }

        private void populateMealTypeComboBoxValues()
        {
            foreach (var mealType in Enum.GetValues(typeof(MealTypes)))
            {
                this.mealTypeComboBox.Items.Add(mealType.ToString());
            }
        }

        public string GetDayOfWeek()
        {
            string day = this.daysComboBox.SelectedItem.ToString();

            //this.Day = day;
            //if (daysComboBox != null && daysComboBox.SelectedItem != null)
            //{
            //    day = daysComboBox.SelectedItem.ToString();
            //}

            return day;
        }

        public string GetMealType()
        {
            string mealType = "";
            if (mealTypeComboBox.SelectedItem != null)
            {
                mealType = this.mealTypeComboBox.SelectedItem.ToString();
            }
            return mealType;
        }

        private void daysComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlannedMealsPage mealsPage = new PlannedMealsPage();

            mealsPage.DayValue = this.daysComboBox.SelectedItem.ToString();
        }
    }
}
