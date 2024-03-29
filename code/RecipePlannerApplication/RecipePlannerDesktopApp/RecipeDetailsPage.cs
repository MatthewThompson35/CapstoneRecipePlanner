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
        private SharedRecipes sharedPage;
        private string selectedDay;
        private string selectedMealType;

        private bool isYesButtonClicked = false;
        private bool isNoButtonClicked = false;
        private int recipeId;

        
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

        /// <summary>
        ///     Initializes the recipe details page based on the specified shared page.
        /// </summary>
        /// <param name="sharedPage">the shared page</param>
        public RecipeDetailsPage(SharedRecipes sharedPage) : this()
        {
            this.sharedPage = sharedPage;
            this.recipeDetailsTextBox.Text = this.displayRecipeDetailsFromSharedPage();


            this.populateDayComboBoxValues();
            this.populateMealTypeComboBoxValues();
            this.populateWeekComboBoxValues();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (this.homepage != null)
            {
                this.Hide();
                this.homepage.Show();
            }
            else if (this.mealsPage != null)
            {
                this.Hide();
                this.mealsPage.Show();
            }
            else
            {
                this.Hide();
                this.sharedPage.Show();
            }

        }

        private string displayRecipeDetails()
        {
            string output = null;

            this.recipeId = this.homepage.GetSelectedRecipe().RecipeId;
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

            string tags = Environment.NewLine + "Tags" + Environment.NewLine;

            foreach (var tag in RecipeDAL.getTagsForRecipe(this.homepage.GetSelectedRecipe().RecipeId, Connection.ConnectionString))
            {
                tags += tag + Environment.NewLine;
            }
            
            output += description + steps + ingredients + tags;
            return output;
        }

        private string displayRecipeDetailsFromMealPage()
        {
            string output = null;

            this.recipeId = this.mealsPage.GetRecipeFromTextBox().RecipeId;
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

            string tags = Environment.NewLine + "Tags" + Environment.NewLine;

            foreach (var tag in RecipeDAL.getTagsForRecipe(this.mealsPage.GetRecipeFromTextBox().RecipeId, Connection.ConnectionString))
            {
                tags += tag + Environment.NewLine;
            }

            output += description + steps + ingredients + tags;
            return output;
        }

        private string displayRecipeDetailsFromSharedPage()
        {
            string output = null;

            this.recipeId = this.sharedPage.getRecipe().RecipeId;
            string description = this.sharedPage.getRecipe().Name + Environment.NewLine + this.sharedPage.getRecipe().Description + Environment.NewLine + Environment.NewLine;

            string steps = "Steps" + Environment.NewLine;

            foreach (var step in RecipeDAL.getStepsForRecipe(this.sharedPage.getRecipe().RecipeId, Connection.ConnectionString))
            {
                steps += step.stepNumber + ". " + step.stepDescription + Environment.NewLine;
            }

            string ingredients = Environment.NewLine + "Ingredients" + Environment.NewLine;

            foreach (var ingredient in RecipeDAL.getIngredientsForRecipe(this.sharedPage.getRecipe().RecipeId, Connection.ConnectionString))
            {
                ingredients += ingredient.Quantity + " " + ingredient.Measurement + " " + ingredient.IngredientName + Environment.NewLine;
            }

            string tags = Environment.NewLine + "Tags" + Environment.NewLine;

            foreach (var tag in RecipeDAL.getTagsForRecipe(this.sharedPage.getRecipe().RecipeId, Connection.ConnectionString))
            {
                tags += tag + Environment.NewLine;
            }

            output += description + steps + ingredients + tags;
            return output;
        }

        private void addToMealPlanButton_Click(object sender, EventArgs e)
        {
            this.addToMealPlanButton.Visible = false;
            this.displayDayMealTypeWeekElements();
            this.displayAddCancelButtons();

            this.updateSuccessfullyLabel.Visible = false;
        }

        private void NoButton_Click(object? sender, EventArgs e)
        {
            this.yesButton.Visible = false;
            this.noButton.Visible = false;
            this.addToMealPlanButton.Visible = true;
            this.updateSuccessfullyLabel.Visible = false;

            this.hideDayMealTypeWeekElements();
        }

        private void YesButton_Click(object? sender, EventArgs e)
        {
            DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), this.selectedDay);

            if (this.weekComboBox.SelectedItem.Equals("This Week"))
            {
                PlannedMealDal.UpdateThisWeeksMeal(Connection.ConnectionString, this.selectedDay, this.selectedMealType, Util.GetDateOfWeekDay(day, "this"), this.getCurrentRecipe().RecipeId);
                this.updateSuccessfullyLabel.Text = "Meal is updated for this day and meal type.";
                this.updateSuccessfullyLabel.ForeColor = Color.Green;
                this.updateSuccessfullyLabel.Visible = true;

                this.hideDayMealTypeWeekElements();
            }
            else
            {
                PlannedMealDal.UpdateThisWeeksMeal(Connection.ConnectionString, this.selectedDay, this.selectedMealType, Util.GetDateOfWeekDay(day, "next"), this.getCurrentRecipe().RecipeId);
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
        ///     Gets the current recipe based on the homepage selection, meal plan page or the shared page selection.
        /// </summary>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>the current recipe from the homepage selection, meal plan page or the shared page selection.</returns>
        public Recipe getCurrentRecipe()
        {
            if (this.homepage != null)
            {
                return this.homepage.GetSelectedRecipe();
            } else if (this.mealsPage != null)
            {
                return this.mealsPage.GetRecipeFromTextBox();
            }
            else
            {
                return this.sharedPage.getRecipe();
            }
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
        }

        private void cookButton_Click(object sender, EventArgs e)
        {
            List<Ingredient> pantry = IngredientDAL.getIngredients();
            List<RecipeIngredient> recipeIngredients = RecipeDAL.getIngredientsForRecipe(this.getCurrentRecipe().RecipeId, Connection.ConnectionString);
            
            int matchedIngredients = 0;

            foreach (var recipeIng in recipeIngredients)
            {
                foreach (var ing in pantry)
                {
                    if (recipeIng.IngredientName.Equals(ing.name))
                    {
                        if (ing.quantity >= recipeIng.Quantity && ing.measurement.Equals(recipeIng.Measurement))
                        {
                            matchedIngredients++;
                        }
                    }
                }
            }

            if (matchedIngredients != recipeIngredients.Count)
            {
                this.displayNotEnoughIngredients();
            }
            else
            {
                this.displayIngredientsFoundElements();
            }

        }

        private void displayNotEnoughIngredients()
        {
            this.isCookedLabel.Text = "Warning: There are not enough ingredients to cook using this recipe. Do you still want to cook? ";
            this.isCookedLabel.Visible = true;
            this.isCookedLabel.ForeColor = Color.Red;

            this.cookYesButton.Visible = true;
            this.cookNoButton.Visible = true;
        }

        private void displayIngredientsFoundElements()
        {
            this.isCookedLabel.Text = "Are you sure you want to cook using this recipe? This will remove ingredients.";
            this.isCookedLabel.Visible = true;
            this.isCookedLabel.ForeColor = Color.Red;

            this.cookYesButton.Visible = true;
            this.cookNoButton.Visible = true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            this.CheckIfReadyToSubmit();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.addToMealPlanButton.Visible = true;
            this.comboboxesErrorLabel.Visible = false;

            this.mealTypeComboBox.SelectedIndex = -1;
            this.daysComboBox.SelectedIndex = -1;
            this.weekComboBox.SelectedIndex = -1;

            this.hideDayMealTypeWeekElements();
            this.hideAddCancelButtons();
            
        }

        private void removeCookedRecipeIngredients()
        {
            int updatedQuantity = 0;

            if (this.homepage != null)
            {
                this.handleHomepageRecipeRemoveIngredients(updatedQuantity);
            }

            if (this.mealsPage != null)
            {
                this.handleMealPlanRecipeRemoveIngredients(updatedQuantity);
            }

            if (this.sharedPage != null)
            {
                this.handleSharedPlanRecipeRemoveIngredients(updatedQuantity);
            }
        }

        private void handleSharedPlanRecipeRemoveIngredients(int updatedQuantity)
        {
            this.serverErrorLabel.Visible = false;
            try
            {
                foreach (var recipeIngredient in RecipeDAL.getIngredientsForRecipe(this.sharedPage.getRecipe().RecipeId, Connection.ConnectionString))
                {
                    foreach (var ingredient in IngredientDAL.getIngredients())
                    {
                        if (recipeIngredient.IngredientName.Equals(ingredient.name))
                        {
                            if (ingredient.quantity >= recipeIngredient.Quantity)
                            {
                                updatedQuantity = (int)(ingredient.quantity - recipeIngredient.Quantity);
                                IngredientDAL.updateQuantity((int)ingredient.id, updatedQuantity);
                                ingredient.quantity = updatedQuantity;

                                if (ingredient.quantity == 0)
                                {
                                    IngredientDAL.RemoveIngredient((int)ingredient.id, Connection.ConnectionString);
                                }
                            }

                            else if (ingredient.quantity < recipeIngredient.Quantity)
                            {
                                updatedQuantity = (int)(ingredient.quantity - ingredient.quantity);
                                IngredientDAL.updateQuantity((int)ingredient.id, updatedQuantity);
                                ingredient.quantity = updatedQuantity;

                                if (ingredient.quantity == 0)
                                {
                                    IngredientDAL.RemoveIngredient((int)ingredient.id, Connection.ConnectionString);
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.serverErrorLabel.Visible = true;
                this.isCookedLabel.Visible = false;
            }
        }

            private void handleHomepageRecipeRemoveIngredients(int updatedQuantity)
            {
            this.serverErrorLabel.Visible = false;
            try
            {
                foreach (var recipeIngredient in RecipeDAL.getIngredientsForRecipe(this.homepage.GetSelectedRecipe().RecipeId, Connection.ConnectionString))
                {
                    foreach (var ingredient in IngredientDAL.getIngredients())
                    {
                        if (recipeIngredient.IngredientName.Equals(ingredient.name))
                        {
                            if (ingredient.quantity >= recipeIngredient.Quantity)
                            {
                                updatedQuantity = (int)(ingredient.quantity - recipeIngredient.Quantity);
                                IngredientDAL.updateQuantity((int)ingredient.id, updatedQuantity);
                                ingredient.quantity = updatedQuantity;

                                if (ingredient.quantity == 0)
                                {
                                    IngredientDAL.RemoveIngredient((int)ingredient.id, Connection.ConnectionString);
                                }
                            }

                            else if (ingredient.quantity < recipeIngredient.Quantity)
                            {
                                updatedQuantity = (int)(ingredient.quantity - ingredient.quantity);
                                IngredientDAL.updateQuantity((int)ingredient.id, updatedQuantity);
                                ingredient.quantity = updatedQuantity;

                                if (ingredient.quantity == 0)
                                {
                                    IngredientDAL.RemoveIngredient((int)ingredient.id, Connection.ConnectionString);
                                }
                            }

                        }
                    }
                }
            } 
            catch (Exception ex)
            {
                this.serverErrorLabel.Visible = true;
                this.isCookedLabel.Visible = false;
            }
            
        }
        private void handleMealPlanRecipeRemoveIngredients(int updatedQuantity)
        {
            this.serverErrorLabel.Visible = false;
            try
            {
                foreach (var recipeIngredient in RecipeDAL.getIngredientsForRecipe(this.mealsPage.GetRecipeFromTextBox().RecipeId, Connection.ConnectionString))
                {
                    foreach (var ingredient in IngredientDAL.getIngredients())
                    {
                        if (recipeIngredient.IngredientName.Equals(ingredient.name))
                        {
                            if (ingredient.quantity >= recipeIngredient.Quantity)
                            {
                                updatedQuantity = (int)(ingredient.quantity - recipeIngredient.Quantity);
                                IngredientDAL.updateQuantity((int)ingredient.id, updatedQuantity);
                                ingredient.quantity = updatedQuantity;

                                if (ingredient.quantity == 0)
                                {
                                    IngredientDAL.RemoveIngredient((int)ingredient.id, Connection.ConnectionString);
                                }
                            }

                            else if (ingredient.quantity < recipeIngredient.Quantity)
                            {
                                updatedQuantity = (int)(ingredient.quantity - ingredient.quantity);
                                IngredientDAL.updateQuantity((int)ingredient.id, updatedQuantity);
                                ingredient.quantity = updatedQuantity;

                                if (ingredient.quantity == 0)
                                {
                                    IngredientDAL.RemoveIngredient((int)ingredient.id, Connection.ConnectionString);
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.serverErrorLabel.Visible = true;
                this.isCookedLabel.Visible = false;
            }
            
        }

        private void cookYesButton_Click(object sender, EventArgs e)
        {
            this.removeCookedRecipeIngredients();

            if (this.serverErrorLabel.Visible == true)
            {
                return;
            }
            else
            {
                var pantry = new IngredientsPage();
                this.Hide();
                pantry.Show();


                this.cookButton.Enabled = false;

                this.cookYesButton.Visible = false;
                this.cookNoButton.Visible = false;
            }
        }

        private void cookNoButton_Click(object sender, EventArgs e)
        {
            this.cookYesButton.Visible = false;
            this.cookNoButton.Visible = false;
            this.cookButton.Enabled = true;
            this.isCookedLabel.Visible = false;
        }

        private void shareRecipeButton_Click(object sender, EventArgs e)
        {
            var addSharedPage = new AddSharedRecipe(this);
            this.Hide();
            addSharedPage.Show();
        }

        /// <summary>
        /// Gets the recipe id for the displayed recipe.
        /// </summary>
        /// <returns></returns>
        public int getRecipeId()
        {
            return this.recipeId;
        }
    }
}
