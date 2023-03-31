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
using Org.BouncyCastle.Asn1.BC;

namespace RecipePlannerDesktopApplication
{
    /// <summary>
    ///     Recipe Detail Page class.
    /// </summary>
    public partial class RecipeDetailsPage : Form
    {
        private Homepage homepage;
        private PlannedMealsPage mealsPage;
        private string selectedDay;
        private string selectedMealType;

        private bool isYesButtonClicked = false;
        private bool isNoButtonClicked = false;

        private int filledComboboxCount = 0;
        private int comboBoxesFilled = 3;

        
        /// <summary>
        ///     Initializes the recipe details page for the recipes.
        /// </summary>
        /// <param name="page">The homepage.</param>
        public RecipeDetailsPage()
        {
            InitializeComponent();

            
        }

        /// <summary>
        ///     Initializes the recipe details based on the specified homepage.
        /// </summary>
        /// <param name="page">the homepage.</param>
        public RecipeDetailsPage(Homepage page) :this(){
            this.homepage = page;
            this.recipeDetailsTextBox.Text = this.displayRecipeDetails();

            this.populateDayComboBoxValues();
            this.populateMealTypeComboBoxValues();
            this.populateWeekComboBoxValues();

            this.selectedDay = "";
            this.selectedMealType = "";

        }

        /// <summary>
        ///     Initializes the recipe details page based on the specified planned meals page.
        /// </summary>
        /// <param name="mealsPage">the planned meals page.</param>
        public RecipeDetailsPage(PlannedMealsPage mealsPage) :this()
        {
            this.mealsPage = mealsPage;
            this.recipeDetailsTextBox.Text = this.displayRecipeDetailsFromMealPage();


            this.populateDayComboBoxValues();
            this.populateMealTypeComboBoxValues();
            this.populateWeekComboBoxValues();
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

        private string displayRecipeDetailsFromMealPage()
        {
            string output = null;

            string description = this.mealsPage.GetRecipeFromTextBox().Name + Environment.NewLine + this.mealsPage.GetRecipeFromTextBox().Description + Environment.NewLine + Environment.NewLine;

            string steps = "Steps" + Environment.NewLine;

            foreach (var step in RecipeDAL.getStepsForRecipe(this.mealsPage.GetRecipeFromTextBox().RecipeId, Connection.ConnectionString))
            {
                steps += step.stepNumber + ". " + step.stepDescription + Environment.NewLine;
            }

            string ingredients = Environment.NewLine + "Ingredients" + Environment.NewLine;

            foreach (var ingredient in RecipeDAL.getIngredientsForRecipe(this.mealsPage.GetRecipeFromTextBox().RecipeId, Connection.ConnectionString))
            {
                ingredients += ingredient.Quantity + " " + ingredient.Measurement + " " + ingredient.IngredientName + Environment.NewLine;
            }

            output += description + steps + ingredients;
            return output;
        }

        private void addToMealPlanButton_Click(object sender, EventArgs e)
        {
            this.displayDayMealTypeWeekElements();
            this.displayAddCancelButtons();
        }

        private void NoButton_Click(object? sender, EventArgs e)
        {
            var page = new Homepage();

            this.Hide();
            page.Show();
        }

        private void YesButton_Click(object? sender, EventArgs e)
        {
            DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), this.selectedDay);

            if (this.weekComboBox.SelectedItem.Equals("This Week"))
            {
                PlannedMealDal.UpdateThisWeeksMeal(Connection.ConnectionString, this.selectedDay, this.selectedMealType, Util.GetDateOfWeekDay(day, "this"), this.homepage.GetSelectedRecipe().RecipeId);
                this.updateSuccessfullyLabel.Text = "Meal is updated for this day and meal type.";
                this.updateSuccessfullyLabel.ForeColor = Color.Green;
                this.updateSuccessfullyLabel.Visible = true;

                this.hideDayMealTypeWeekElements();
            }
            else
            {
                PlannedMealDal.UpdateThisWeeksMeal(Connection.ConnectionString, this.selectedDay, this.selectedMealType, Util.GetDateOfWeekDay(day, "next"), this.homepage.GetSelectedRecipe().RecipeId);
                this.updateSuccessfullyLabel.Visible = true;
                this.updateSuccessfullyLabel.Text = "Meal is updated for this day and meal type.";
                this.updateSuccessfullyLabel.ForeColor = Color.Green;
                this.updateSuccessfullyLabel.Visible = true;

                this.hideDayMealTypeWeekElements();
            }

            this.yesButton.Visible = false;
            this.noButton.Visible = false;
            this.addToMealPlanButton.Visible = true;
        }


        /// <summary>
        ///     Gets the planned meal week based on the specified meal week for the combobox of meal type.
        /// </summary>
        /// <param name="mealWeek">the meal week.</param>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>a string representation of a meal week.</returns>
        public string GetPlannedMealWeek(PlannedMealWeeks mealWeek)
        {
            switch (mealWeek)
            {
                case PlannedMealWeeks.ThisWeek:
                    return "This Week";
                case PlannedMealWeeks.NextWeek:
                    return "Next Week";
            }
            return "";
        }

        /// <summary>
        ///     Gets the current recipe from the homepage selection.
        /// </summary>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>the current recipe from the homepage selection.</returns>
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

        private void populateWeekComboBoxValues()
        {
            foreach (var week in Enum.GetValues(typeof(PlannedMealWeeks)))
            {
                this.weekComboBox.Items.Add(this.GetPlannedMealWeek((PlannedMealWeeks)week));
            }
        }


        private void daysComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.daysComboBox.SelectedItem != null)
            {
                this.selectedDay = this.daysComboBox.SelectedItem.ToString();
            }
            else
            {
                this.daysComboBox.SelectedIndex = -1;
            }
            //CheckIfReadyToSubmit();
        }

        private void mealTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.mealTypeComboBox.SelectedItem != null)
            {
                this.selectedMealType = this.mealTypeComboBox.SelectedItem.ToString();
            }
            else
            {
                this.mealTypeComboBox.SelectedIndex = -1;
            }
            
            //CheckIfReadyToSubmit();
        }

        private void findRecipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            var homepage = new Homepage();
            homepage.Show();
        }

        private void viewMealPlanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();

            var mealPlanPage = new PlannedMealsPage();

            mealPlanPage.Show();
        }

        private void displayDayMealTypeWeekElements()
        {
            this.dayLabel.Visible = true;
            this.mealTypeLabel.Visible = true;
            this.weekLabel.Visible = true;

            this.daysComboBox.Visible = true;
            this.mealTypeComboBox.Visible = true;
            this.weekComboBox.Visible = true;
        }

        private void hideDayMealTypeWeekElements()
        {
            this.dayLabel.Visible = false;
            this.mealTypeLabel.Visible = false;
            this.weekLabel.Visible = false;

            this.daysComboBox.Visible = false;
            this.mealTypeComboBox.Visible = false;
            this.weekComboBox.Visible = false;
        }

        private void displayAddCancelButtons()
        {
            this.addButton.Visible = true;
            this.cancelButton.Visible = true;
        }

        private void hideAddCancelButtons()
        {
            this.addButton.Visible = false;
            this.cancelButton.Visible = false;
        }

        private void CheckIfReadyToSubmit()
        {
            if (!string.IsNullOrEmpty(selectedDay) && !string.IsNullOrEmpty(selectedMealType) && this.weekComboBox.SelectedItem != null)
            {
                this.comboboxesErrorLabel.Visible = false;
                submitMeal();
            }
            else
            {
                this.comboboxesErrorLabel.Visible = true;
            }
        }

        private void submitMeal()
        {
            DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), this.selectedDay);
            if (this.weekComboBox.SelectedItem.Equals("This Week"))
            {
                if (PlannedMealDal.exists(Connection.ConnectionString, this.selectedMealType, Util.GetDateOfWeekDay(day, "this")))
                {
                    this.updateSuccessfullyLabel.Text = "Are you sure you want to overwrite the existing meal?";
                    this.updateSuccessfullyLabel.ForeColor = Color.Red;

                    this.yesButton.Visible = true;
                    this.noButton.Visible = true;
                    this.updateSuccessfullyLabel.Visible = true;
                    this.addToMealPlanButton.Visible = false;
                    this.hideAddCancelButtons();

                }
                else
                {
                    this.updateSuccessfullyLabel.Visible = false;
                    PlannedMealDal.addPlannedMeal(Connection.ConnectionString, this.getCurrentRecipe().RecipeId, this.selectedDay, this.selectedMealType, Util.GetDateOfWeekDay(day, "this"));

                    var mealsPage = new PlannedMealsPage();
                    this.Hide();
                    mealsPage.Show();
                }

            }
            else
            {
                if (PlannedMealDal.exists(Connection.ConnectionString, this.selectedMealType, Util.GetDateOfWeekDay(day, "next")))
                {
                    this.updateSuccessfullyLabel.Text = "Are you sure you want to overwrite the existing meal?";
                    this.updateSuccessfullyLabel.ForeColor = Color.Red;

                    this.yesButton.Visible = true;
                    this.noButton.Visible = true;
                    this.updateSuccessfullyLabel.Visible = true;
                    this.addToMealPlanButton.Visible = false;
                    this.hideAddCancelButtons();

                }
                else
                {
                    this.updateSuccessfullyLabel.Visible = false;
                    PlannedMealDal.addPlannedMeal(Connection.ConnectionString, this.getCurrentRecipe().RecipeId, this.selectedDay, this.selectedMealType, Util.GetDateOfWeekDay(day, "next"));

                    var mealsPage = new PlannedMealsPage();
                    this.Hide();
                    mealsPage.Show();
                }

            }
        }

        private void weekComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CheckIfReadyToSubmit();
        }

        private void cookButton_Click(object sender, EventArgs e)
        {
            // removes the ingredients from pantry. Show a confirmation that the recipe is cooked.
            // also disable button that meal has been cooked.
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // fully add to meal plan page if all the fields are selected.
            this.CheckIfReadyToSubmit();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // show add to meal plan button and hide the elements. DO NOT ADD
            this.addToMealPlanButton.Visible = true;

            this.mealTypeComboBox.SelectedIndex = -1;
            this.daysComboBox.SelectedIndex = -1;
            this.weekComboBox.SelectedIndex = -1;

            this.hideDayMealTypeWeekElements();
            this.hideAddCancelButtons();
            
        }
    }
}
