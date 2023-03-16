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
        private PlannedMealsPage mealsPage;
        private string selectedDay;
        private string selectedMealType;

        private bool isYesButtonClicked = false;
        private bool isNoButtonClicked = false;

        //private PlannedMealDal mealDal;
        
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
            DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), this.selectedDay);

            if (this.weekComboBox.SelectedItem.Equals("This Week"))
            {
                if (PlannedMealDal.exists(Connection.ConnectionString, this.selectedMealType, GetDateOfCurrentWeekDay(day)))
                {
                    this.updateSuccessfullyLabel.Text = "Are you sure you want to overwrite the existing meal?";
                    this.updateSuccessfullyLabel.ForeColor = Color.Red;

                    this.yesButton.Visible = true;
                    this.noButton.Visible = true;
                    this.addToMealPlanButton.Visible = false;

                    if (isYesButtonClicked)
                    {
                        this.yesButton.Click += YesButton_Click;

                        PlannedMealDal.UpdateThisWeeksMeal(Connection.ConnectionString, this.selectedDay, this.selectedMealType, GetDateOfCurrentWeekDay(day), this.homepage.GetSelectedRecipe().RecipeId);
                        this.updateSuccessfullyLabel.Visible = true;
                    }

                    else if (isNoButtonClicked)
                    {
                        this.noButton.Click += NoButton_Click;
                    }

                    
                    //PlannedMealDal.UpdateThisWeeksMeal(Connection.ConnectionString, this.selectedDay, this.selectedMealType, GetDateOfCurrentWeekDay(day), this.homepage.GetSelectedRecipe().RecipeId);
                    //this.updateSuccessfullyLabel.Visible = true;
                }
                else
                {
                    this.updateSuccessfullyLabel.Visible = false;
                    PlannedMealDal.addPlannedMeal(Connection.ConnectionString, this.getCurrentRecipe().RecipeId, this.selectedDay, this.selectedMealType, GetDateOfCurrentWeekDay(day));

                    var mealsPage = new PlannedMealsPage();
                    this.Hide();
                    mealsPage.Show();
                }
                
            } else
            {
                if (PlannedMealDal.exists(Connection.ConnectionString, this.selectedMealType, GetDateOfNextWeekDay(day)))
                {
                    PlannedMealDal.UpdateThisWeeksMeal(Connection.ConnectionString, this.selectedDay, this.selectedMealType, GetDateOfNextWeekDay(day), this.homepage.GetSelectedRecipe().RecipeId);
                    this.updateSuccessfullyLabel.Visible = true;
                }
                else
                {
                    this.updateSuccessfullyLabel.Visible = false;
                    PlannedMealDal.addPlannedMeal(Connection.ConnectionString, this.getCurrentRecipe().RecipeId, this.selectedDay, this.selectedMealType, GetDateOfNextWeekDay(day));

                    var mealsPage = new PlannedMealsPage();
                    this.Hide();
                    mealsPage.Show();
                }
                
            }

        }

        private void NoButton_Click(object? sender, EventArgs e)
        {
            this.isNoButtonClicked = true;
        }

        private void YesButton_Click(object? sender, EventArgs e)
        {

            this.isYesButtonClicked = true;

            //PlannedMealDal.UpdateThisWeeksMeal(Connection.ConnectionString, this.selectedDay, this.selectedMealType, GetDateOfCurrentWeekDay(day), this.homepage.GetSelectedRecipe().RecipeId);
            //this.updateSuccessfullyLabel.Visible = true;
        }

        /// <summary>
        /// Gets the date of the next week day based on the specified day of the week.
        /// </summary>
        /// <param name="dayOfWeek">the day of the week.</param>
        /// <returns>the date of the next week day.</returns>
        public DateTime GetDateOfNextWeekDay(DayOfWeek dayOfWeek)
        {
            DateTime nextWeek = DateTime.Today.AddDays(7);
            int daysUntilNextWeekDay = ((int)dayOfWeek - (int)nextWeek.DayOfWeek);
            if (daysUntilNextWeekDay < 0)
            {
                daysUntilNextWeekDay += 7;
            }
            return nextWeek.AddDays(daysUntilNextWeekDay);
        }

        /// <summary>
        /// Gets the date of the current weekday based on the specified day of the week.
        /// </summary>
        /// <param name="dayOfWeek">the day of the week.</param>
        /// <returns>the date of the current week day.</returns>
        public DateTime GetDateOfCurrentWeekDay(DayOfWeek dayOfWeek)
        {
            int daysUntilCurrentWeekDay = ((int)dayOfWeek - (int)DateTime.Today.DayOfWeek);
            if (daysUntilCurrentWeekDay < 0)
            {
                daysUntilCurrentWeekDay += 7;
            }
            return DateTime.Today.AddDays(daysUntilCurrentWeekDay);
        }

        /// <summary>
        ///     Gets the planned meal week based on the specified meal week for the combobox of meal type.
        /// </summary>
        /// <param name="mealWeek">the meal week.</param>
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

            this.selectedDay = this.daysComboBox.SelectedItem.ToString();
        }

        private void mealTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedMealType = this.mealTypeComboBox.SelectedItem.ToString();
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

        private void plannerMenuButton_Click(object sender, EventArgs e)
        {
            this.plannerContextMenuStrip.Show(plannerMenuButton, 0, plannerMenuButton.Height);
        }
    }
}
