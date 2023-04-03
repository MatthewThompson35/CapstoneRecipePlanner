using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
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

namespace RecipePlannerDesktopApplication
{
    /// <summary>
    /// THe class for the planned meals page
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class PlannedMealsPage : Form
    {
        private RecipeDetailsPage detailsPage;
        private List<Label> daysLabels;
        private List<Label> mealTypeDaysLabels;
        private List<TextBox> mealDayTypeTextBoxes;
        private bool isNextWeekDisplayed;

        private Recipe readInRecipe;

        /// <summary>
        /// Gets or sets the day value.
        /// </summary>
        /// <value>
        /// The day value.
        /// </value>
        public string DayValue { get; set; }
        /// <summary>
        /// Gets or sets the meal type value.
        /// </summary>
        /// <value>
        /// The meal type value.
        /// </value>
        public string MealTypeValue { get; set; }

        /// <summary>
        ///     Initializes a PlannedMealsPage object.
        ///     
        ///     Precondition: none
        ///     Postcondition: the page is shown and initialized.
        /// </summary>
        public PlannedMealsPage()
        {
            InitializeComponent();

            this.detailsPage = new RecipeDetailsPage();

            this.daysLabels = new List<Label>() { mondayLabel, tuesdayLabel, wednesdayLabel, thursdayLabel, fridayLabel, saturdayLabel, sundayLabel};
            this.mealTypeDaysLabels = new List<Label>() { mondayBreakfastLabel, mondayLunchLabel, mondayDinnerLabel, tuesdayBreakfastLabel, tuesdayLunchLabel, tuesdayDinnerLabel, wednesdayBreakfastLabel, wednesdayLunchLabel, wednesdayDinnerLabel, thursdayBreakfastLabel, thursdayLunchLabel, thursdayDinnerLabel, fridayBreakfastLabel, fridayLunchLabel, fridayDinnerLabel, saturdayBreakfastLabel, saturdayLunchLabel, saturdayDinnerLabel, sundayBreakfastLabel, sundayLunchLabel, sundayDinnerLabel};
            this.mealDayTypeTextBoxes = new List<TextBox> { mondayBreakfastTextBox, mondayLunchTextBox, mondayDinnerTextBox, tuesdayBreakfastTextBox, tuesdayLunchTextBox, tuesdayDinnerTextBox, wednesdayBreakfastTextBox, wednesdayLunchTextBox, wednesdayDinnerTextBox, thursdayBreakfastTextBox, thursdayLunchTextBox, thursdayDinnerTextBox, fridayBreakfastTextBox, fridayLunchTextBox, fridayDinnerTextBox, saturdayBreakfastTextBox, saturdayLunchTextBox, saturdayDinnerTextBox, sundayBreakfastTextBox, sundayLunchTextBox, sundayDinnerTextBox };

            this.displayThisWeekMeals();

            this.isNextWeekDisplayed = false;

        }

        private void findRecipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            var homepage = new Homepage();
            homepage.Show();
        }

        private void displayThisWeekMeals()
        {
            foreach (KeyValuePair<(string, string), int> meal in PlannedMealDal.getThisWeeksMeals(Connection.ConnectionString))
            {
                foreach (var currentDayLabel in this.daysLabels)
                {
                    if (currentDayLabel.Text.Equals(meal.Key.Item1))
                    {
                        foreach (var currentMealDayLabel in this.mealTypeDaysLabels)
                        {
                            if (currentMealDayLabel.Text.Replace(":", "").Equals(meal.Key.Item2))
                            {
                                currentMealDayLabel.Text = currentMealDayLabel.Text.Replace(":", "");
                                    switch (currentDayLabel.Name + currentMealDayLabel.Name)
                                    {
                                        case "mondayLabel" + "mondayBreakfastLabel":
                                        this.mondayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "mondayLabel" + "mondayLunchLabel":
                                            this.mondayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                        case "mondayLabel" + "mondayDinnerLabel":
                                            this.mondayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                        case "tuesdayLabel" + "tuesdayBreakfastLabel":
                                            this.tuesdayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                        case "tuesdayLabel" + "tuesdayLunchLabel":
                                            this.tuesdayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                        case "tuesdayLabel" + "tuesdayDinnerLabel":
                                            this.tuesdayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                        case "wednesdayLabel" + "wednesdayBreakfastLabel":
                                            this.wednesdayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                        case "wednesdayLabel" + "wednesdayLunchLabel":
                                            this.wednesdayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "wednesdayLabel" + "wednesdayDinnerLabel":
                                            this.wednesdayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "thursdayLabel" + "thursdayBreakfastLabel":
                                            this.thursdayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "thursdayLabel" + "thursdayLunchLabel":
                                            this.thursdayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "thursdayLabel" + "thursdayDinnerLabel":
                                            this.thursdayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "fridayLabel" + "fridayBreakfastLabel":
                                            this.fridayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "fridayLabel" + "fridayLunchLabel":
                                            this.fridayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "fridayLabel" + "fridayDinnerLabel":
                                            this.fridayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "saturdayLabel" + "saturdayBreakfastLabel":
                                            this.saturdayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "saturdayLabel" + "saturdayLunchLabel":
                                            this.saturdayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "saturdayLabel" + "saturdayDinnerLabel":
                                            this.saturdayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;

                                        case "sundayLabel" + "sundayBreakfastLabel":
                                            this.sundayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "sundayLabel" + "sundayLunchLabel":
                                            this.sundayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "sundayLabel" + "sundayDinnerLabel":
                                            this.sundayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;

                                        default:
                                        
                                        break;
                                        
                                    }
                            }
                        }
                    }
                    
                }

                
            }

            foreach (var currentmealDayTypeTextBox in this.mealDayTypeTextBoxes)
            {
                if (currentmealDayTypeTextBox.Text == "")
                {
                    currentmealDayTypeTextBox.Text = "Meal has not been added to this time yet";
                }
            }


        }

        private void displayNextWeekMeals()
        {
            foreach (KeyValuePair<(string, string), int> meal in PlannedMealDal.getNextWeeksMeals(Connection.ConnectionString))
            {
                foreach (var currentDayLabel in this.daysLabels)
                {
                    if (currentDayLabel.Text.Equals(meal.Key.Item1))
                    {
                        foreach (var currentMealDayLabel in this.mealTypeDaysLabels)
                        {
                            if (currentMealDayLabel.Text.Replace(":", "").Equals(meal.Key.Item2))
                            {
                                currentMealDayLabel.Text = currentMealDayLabel.Text.Replace(":", "");
                                switch (currentDayLabel.Name + currentMealDayLabel.Name)
                                {
                                    case "mondayLabel" + "mondayBreakfastLabel":
                                        this.mondayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "mondayLabel" + "mondayLunchLabel":
                                        this.mondayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "mondayLabel" + "mondayDinnerLabel":
                                        this.mondayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "tuesdayLabel" + "tuesdayBreakfastLabel":
                                        this.tuesdayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "tuesdayLabel" + "tuesdayLunchLabel":
                                        this.tuesdayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "tuesdayLabel" + "tuesdayDinnerLabel":
                                        this.tuesdayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "wednesdayLabel" + "wednesdayBreakfastLabel":
                                        this.wednesdayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "wednesdayLabel" + "wednesdayLunchLabel":
                                        this.wednesdayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "wednesdayLabel" + "wednesdayDinnerLabel":
                                        this.wednesdayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "thursdayLabel" + "thursdayBreakfastLabel":
                                        this.thursdayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "thursdayLabel" + "thursdayLunchLabel":
                                        this.thursdayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "thursdayLabel" + "thursdayDinnerLabel":
                                        this.thursdayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "fridayLabel" + "fridayBreakfastLabel":
                                        this.fridayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "fridayLabel" + "fridayLunchLabel":
                                        this.fridayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "fridayLabel" + "fridayDinnerLabel":
                                        this.fridayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "saturdayLabel" + "saturdayBreakfastLabel":
                                        this.saturdayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "saturdayLabel" + "saturdayLunchLabel":
                                        this.saturdayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "saturdayLabel" + "saturdayDinnerLabel":
                                        this.saturdayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;

                                    case "sundayLabel" + "sundayBreakfastLabel":
                                        this.sundayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "sundayLabel" + "sundayLunchLabel":
                                        this.sundayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "sundayLabel" + "sundayDinnerLabel":
                                        this.sundayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;

                                    default:

                                        break;

                                }
                            }
                        }
                    }

                }


            }

            foreach (var currentmealDayTypeTextBox in this.mealDayTypeTextBoxes)
            {
                if (currentmealDayTypeTextBox.Text == "")
                {
                    currentmealDayTypeTextBox.Text = "Meal has not been added to this time yet";
                }
            }
        }

        private void plannerMenuButton_Click(object sender, EventArgs e)
        {
                this.plannerContextMenuStrip.Show(plannerMenuButton, 0, plannerMenuButton.Height);
        }

        private void removeMondayBreakfastButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.mondayBreakfastLabel, this.mondayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.mondayBreakfastLabel, this.mondayLabel.Text);
            }
            

        }

        private void removeMondayLunchButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.mondayLunchLabel, this.mondayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.mondayLunchLabel, this.mondayLabel.Text);
                

            }
        }

        private void removeMondayDinnerButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.mondayDinnerLabel, this.mondayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.mondayDinnerLabel, this.mondayLabel.Text);
                
            }
            
            
        }

        private void removeTuesdayBreakfastButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.tuesdayBreakfastLabel, this.tuesdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.tuesdayBreakfastLabel, this.tuesdayLabel.Text);
            }
            
            
        }

        private void removeTuesdayLunchButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.tuesdayLunchLabel, this.tuesdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.tuesdayLunchLabel, this.tuesdayLabel.Text);
            }
            
            
        }

        private void removeTuesdayDinnerButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.tuesdayDinnerLabel, this.tuesdayLabel.Text);
                
            }
            else
            {
                this.removeThisWeekMeal(this.tuesdayDinnerLabel, this.tuesdayLabel.Text);
            }
            
            
        }

        private void removeWednesdayBreakfastButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.wednesdayBreakfastLabel, this.wednesdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.wednesdayBreakfastLabel, this.wednesdayLabel.Text);
            }
            
            
        }

        private void removeWednesdayLunchButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.wednesdayLunchLabel, this.wednesdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.wednesdayLunchLabel, this.wednesdayLabel.Text);
            }
            
            
        }

        private void removeWednesdayDinnerButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.wednesdayDinnerLabel, this.wednesdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.wednesdayDinnerLabel, this.wednesdayLabel.Text);
            }
            
            
        }

        private void removeThursdayBreakfastButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.thursdayBreakfastLabel, this.thursdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.thursdayBreakfastLabel, this.thursdayLabel.Text);
            }
            
            
        }

        private void removeThursdayLunchButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.thursdayLunchLabel, this.thursdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.thursdayLunchLabel, this.thursdayLabel.Text);
            }
            
            
        }

        private void removeThursdayDinnerButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.thursdayDinnerLabel, this.thursdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.thursdayDinnerLabel, this.thursdayLabel.Text);
            }
            
            
        }

        private void removeFridayBreakfastButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.fridayBreakfastLabel, this.fridayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.fridayBreakfastLabel, this.fridayLabel.Text);
            }
            
            
        }

        private void removeFridayLunchButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.fridayLunchLabel, this.fridayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.fridayLunchLabel, this.fridayLabel.Text);
            }
            
            
        }

        private void removeFridayDinnerButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.fridayDinnerLabel, this.fridayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.fridayDinnerLabel, this.fridayLabel.Text);
            }
            
            
        }

        private void removeSaturdayBreakfastButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.saturdayBreakfastLabel, this.saturdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.saturdayBreakfastLabel, this.saturdayLabel.Text);
            }
            
            
        }

        private void removeSaturdayLunchButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.saturdayLunchLabel, this.saturdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.saturdayLunchLabel, this.saturdayLabel.Text);
            }
            
            
        }

        private void removeSatudayDinnerButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.saturdayDinnerLabel, this.saturdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.saturdayDinnerLabel, this.saturdayLabel.Text);
            }
            
            
        }

        private void removeSundayBreakfastButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.sundayBreakfastLabel, this.sundayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.sundayBreakfastLabel, this.sundayLabel.Text);
            }
            
            
        }

        private void removeSundayLunchButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.sundayLunchLabel, this.sundayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.sundayLunchLabel, this.sundayLabel.Text);
            }
            
            
        }

        private void removeSundayDinnerButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.sundayDinnerLabel, this.sundayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.sundayDinnerLabel, this.sundayLabel.Text);
            }
        }

        private void viewCurrentWeekPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.isNextWeekDisplayed = false;
            if (!this.isNextWeekDisplayed)
            {
                this.weekMealLabel.Text = "This Week's Meals";

                foreach (var textbox in this.mealDayTypeTextBoxes)
                {
                    textbox.Clear();
                }
                this.displayThisWeekMeals();
                this.Refresh();
            }

        }

        private void viewNextWeekPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.isNextWeekDisplayed = true;

            if (this.isNextWeekDisplayed)
            {
                this.weekMealLabel.Text = "Next Week's Meals";

                foreach (var textbox in this.mealDayTypeTextBoxes)
                {
                    textbox.Clear();
                }
                this.displayNextWeekMeals();

                this.Refresh();
            }
            else
            {
                this.isNextWeekDisplayed = false;
            }
            

        }

        private void removeNextWeekMeal(Label mealTypeLabel, string dayOfWeek)
        {
            foreach (KeyValuePair<(string, string), int> meal in PlannedMealDal.getNextWeeksMeals(Connection.ConnectionString))
            {
                if (meal.Key.Item1.Equals(dayOfWeek) && mealTypeLabel.Text.Replace(":", "").Equals(meal.Key.Item2))
                {
                    mealTypeLabel.Text = mealTypeLabel.Text.Replace(":", "");

                    switch (dayOfWeek + mealTypeLabel.Text)
                    {
                        case "Monday" + "Breakfast":
                            if (this.mondayBreakfastTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Monday, "next"));
                                this.mondayBreakfastTextBox.Text = "Meal has not been added to this time yet";
                            }
                            break;

                        case "Monday" + "Lunch":
                            if (this.mondayLunchTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Monday, "next"));
                                this.mondayLunchTextBox.Text = "Meal has not been added to this time yet";
                            }
                            break;

                        case "Monday" + "Dinner":

                            if (this.mondayDinnerTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Monday, "next"));
                                this.mondayDinnerTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;
                        case "Tuesday" + "Breakfast":
                            if (this.tuesdayBreakfastTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Tuesday, "next"));
                                this.tuesdayBreakfastTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Tuesday" + "Lunch":
                            if (this.tuesdayLunchTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Tuesday, "next"));
                                this.tuesdayLunchTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Tuesday" + "Dinner":
                            if (this.tuesdayDinnerTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Tuesday, "next"));
                                this.tuesdayDinnerTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;
                        case "Wednesday" + "Breakfast":
                            if (this.wednesdayBreakfastTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Wednesday, "next"));
                                this.wednesdayBreakfastTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Wednesday" + "Lunch":
                            if (this.wednesdayLunchTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Wednesday, "next"));
                                this.wednesdayLunchTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;
                        case "Wednesday" + "Dinner":
                            if (this.wednesdayDinnerTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Wednesday, "next"));
                                this.wednesdayDinnerTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Thursday" + "Breakfast":
                            if (this.thursdayBreakfastTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Thursday, "next"));
                                this.thursdayBreakfastTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Thursday" + "Lunch":
                            if (this.thursdayLunchTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Thursday, "next"));
                                this.thursdayLunchTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Thursday" + "Dinner":
                            if (this.thursdayDinnerTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Thursday, "next"));
                                this.thursdayDinnerTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;
                        case "Friday" + "Breakfast":
                            if (this.fridayBreakfastTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Friday, "next"));
                                this.fridayBreakfastTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;
                        case "Friday" + "Lunch":
                            if (this.fridayLunchTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Friday, "next"));
                                this.fridayLunchTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;
                        case "Friday" + "Dinner":
                            if (this.fridayDinnerTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Friday, "next"));
                                this.fridayDinnerTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Saturday" + "Breakfast":
                            if (this.saturdayBreakfastTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Saturday, "next"));
                                this.saturdayBreakfastTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Saturday" + "Lunch":
                            if (this.saturdayLunchTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Saturday, "next"));
                                this.saturdayLunchTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Saturday" + "Dinner":
                            if (this.saturdayDinnerTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Saturday, "next"));
                                this.saturdayDinnerTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;
                        case "Sunday" + "Breakfast":
                            if (this.sundayBreakfastTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Sunday, "next"));
                                this.sundayBreakfastTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Sunday" + "Lunch":
                            if (this.sundayLunchTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Sunday, "next"));
                                this.sundayLunchTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;
                        case "Sunday" + "Dinner":
                            if (this.sundayDinnerTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Sunday, "next"));
                                this.sundayDinnerTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        default:
                            break;
                    }
                }
            }
        }

        private void removeThisWeekMeal(Label mealTypeLabel, string dayOfWeek)
        {
            foreach (KeyValuePair<(string, string), int> meal in PlannedMealDal.getThisWeeksMeals(Connection.ConnectionString))
            {
                if (meal.Key.Item1.Equals(dayOfWeek) && mealTypeLabel.Text.Replace(":", "").Equals(meal.Key.Item2))
                {
                    mealTypeLabel.Text = mealTypeLabel.Text.Replace(":", "");

                    switch (dayOfWeek + mealTypeLabel.Text)
                    {
                        case "Monday" + "Breakfast":
                            if (this.mondayBreakfastTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Monday, "this"));
                                this.mondayBreakfastTextBox.Text = "Meal has not been added to this time yet";
                            }
                            break;

                        case "Monday" + "Lunch":
                            if (this.mondayLunchTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Monday, "this"));
                                this.mondayLunchTextBox.Text = "Meal has not been added to this time yet";
                            }
                            break;

                        case "Monday" + "Dinner":

                            if (this.mondayDinnerTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Monday, "this"));
                                this.mondayDinnerTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;
                        case "Tuesday" + "Breakfast":
                            if (this.tuesdayBreakfastTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Tuesday, "this"));
                                this.tuesdayBreakfastTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Tuesday" + "Lunch":
                            if (this.tuesdayLunchTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Tuesday, "this"));
                                this.tuesdayLunchTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Tuesday" + "Dinner":
                            if (this.tuesdayDinnerTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Tuesday, "this"));
                                this.tuesdayDinnerTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;
                        case "Wednesday" + "Breakfast":
                            if (this.wednesdayBreakfastTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Wednesday, "this"));
                                this.wednesdayBreakfastTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Wednesday" + "Lunch":
                            if (this.wednesdayLunchTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Wednesday, "this"));
                                this.wednesdayLunchTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;
                        case "Wednesday" + "Dinner":
                            if (this.wednesdayDinnerTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Wednesday, "this"));
                                this.wednesdayDinnerTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Thursday" + "Breakfast":
                            if (this.thursdayBreakfastTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Thursday, "this"));
                                this.thursdayBreakfastTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Thursday" + "Lunch":
                            if (this.thursdayLunchTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Thursday, "this"));
                                this.thursdayLunchTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Thursday" + "Dinner":
                            if (this.thursdayDinnerTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Thursday, "this"));
                                this.thursdayDinnerTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;
                        case "Friday" + "Breakfast":
                            if (this.fridayBreakfastTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Friday, "this"));
                                this.fridayBreakfastTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;
                        case "Friday" + "Lunch":
                            if (this.fridayLunchTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Friday, "this"));
                                this.fridayLunchTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;
                        case "Friday" + "Dinner":
                            if (this.fridayDinnerTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Friday, "this"));
                                this.fridayDinnerTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Saturday" + "Breakfast":
                            if (this.saturdayBreakfastTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Saturday, "this"));
                                this.saturdayBreakfastTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Saturday" + "Lunch":
                            if (this.saturdayLunchTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Saturday, "this"));
                                this.saturdayLunchTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Saturday" + "Dinner":
                            if (this.saturdayDinnerTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Saturday, "this"));
                                this.saturdayDinnerTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;
                        case "Sunday" + "Breakfast":
                            if (this.sundayBreakfastTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Sunday, "this"));
                                this.sundayBreakfastTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        case "Sunday" + "Lunch":
                            if (this.sundayLunchTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Sunday, "this"));
                                this.sundayLunchTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;
                        case "Sunday" + "Dinner":
                            if (this.sundayDinnerTextBox.Text == "Meal has not been added to this time yet")
                            {
                                return;
                            }
                            else
                            {
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, Util.GetDateOfWeekDay(DayOfWeek.Sunday, "this"));
                                this.sundayDinnerTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the Recipe from the textbox of the certain day and meal type.
        /// </summary>
        /// <returns>the recipe from the textbox.</returns>
        public Recipe GetRecipeFromTextBox()
        {
            return this.readInRecipe;
        }



        private void mondayBreakfastLabel_Click(object sender, EventArgs e)
        {
            //this.navigateToDetailsPage(this.mondayBreakfastTextBox.Text);
            var recipeName = this.mondayBreakfastTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }


        }

        private void mondayLunchLabel_Click(object sender, EventArgs e)
        {

            var recipeName = this.mondayLunchTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void mondayDinnerLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.mondayDinnerTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void tuesdayBreakfastLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.tuesdayBreakfastTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void tuesdayLunchLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.tuesdayLunchTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void tuesdayDinnerLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.tuesdayDinnerTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void wednesdayBreakfastLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.wednesdayBreakfastTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void wednesdayLunchLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.wednesdayLunchTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void wednesdayDinnerLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.wednesdayDinnerTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void thursdayBreakfastLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.thursdayBreakfastTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void thursdayLunchLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.thursdayLunchTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void thursdayDinnerLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.thursdayDinnerTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void fridayBreakfastLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.fridayBreakfastTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void fridayLunchLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.fridayLunchTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void fridayDinnerLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.fridayDinnerTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void saturdayBreakfastLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.saturdayBreakfastTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void saturdayLunchLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.saturdayLunchTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void saturdayDinnerLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.saturdayDinnerTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void sundayBreakfastLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.sundayBreakfastTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void sundayLunchLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.sundayLunchTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void sundayDinnerLabel_Click(object sender, EventArgs e)
        {
            var recipeName = this.sundayDinnerTextBox.Text;

            if (recipeName == "Meal has not been added to this time yet")
            {
                return;
            }

            else
            {
                this.readInRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);

                Hide();

                var detailsPage = new RecipeDetailsPage(this);
                detailsPage.Show();
            }
        }

        private void mondayButton_Click(object sender, EventArgs e)
        {
            if (mondayPanel.Size.Height == 181)
            {
                mondayPanel.Height = 45;
            }
            else
            {
                mondayPanel.Height = 181;
            }
        }

        private void PlannedMealsPage_Load(object sender, EventArgs e)
        {
            mondayPanel.Height = 45;
            tuesdayPanel.Height = 45;
            wednesdayPanel.Height = 45;
            thursdayPanel.Height = 45;
            fridayPanel.Height = 45;
            saturdayPanel.Height = 45;
            sundayPanel.Height = 45;
        }

        private void tuesdayButton_Click(object sender, EventArgs e)
        {
            if (tuesdayPanel.Height == 181)
            {
                tuesdayPanel.Height = 45;
            }
            else
            {
                tuesdayPanel.Height = 181;
            }

        }

        private void wednesdayButton_Click(object sender, EventArgs e)
        {
            if (wednesdayPanel.Height == 181)
            {
                wednesdayPanel.Height = 45;
            }
            else
            {
                wednesdayPanel.Height = 181;
            }
        }

        private void thursdayButton_Click(object sender, EventArgs e)
        {
            if (thursdayPanel.Height == 181)
            {
                thursdayPanel.Height = 45;
            }
            else
            {
                thursdayPanel.Height = 181;
            }
        }

        private void fridayButton_Click(object sender, EventArgs e)
        {
            if (fridayPanel.Height == 181)
            {
                fridayPanel.Height = 45;
            }
            else
            {
                fridayPanel.Height = 181;
            }
        }

        private void saturdayButton_Click(object sender, EventArgs e)
        {
            if (saturdayPanel.Height == 181)
            {
                saturdayPanel.Height = 45;
            }
            else
            {
                saturdayPanel.Height = 181;
            }
        }

        private void sundayButton_Click(object sender, EventArgs e)
        {
            if (sundayPanel.Height == 181)
            {
                sundayPanel.Height = 45;
            }
            else
            {
                sundayPanel.Height = 181;
            }
        }

        private void addIngredientsForRemainingMealsButton_Click(object sender, EventArgs e)
        {
            if (this.addAllIngredientsCheckbox.Checked == true)
            {
                this.addAllIngredients();
            }
            else
            {
                this.addNeededIngredients();
            }

            var shoppingList = new ShoppingListPage();
            this.Hide();
            shoppingList.Show();
        }

        private void addAllIngredients()
        {
            List<Ingredient> totalIngredients = new List<Ingredient>();
            List<int> remainingMeals = PlannedMealDal.getRemainingMeals(Connection.ConnectionString);
            List<Ingredient> pantry = IngredientDAL.getIngredients();
            List<Ingredient> shoppingIngredients = ShoppingListDAL.getIngredients();

            foreach (var shoppingIngredient in shoppingIngredients)
            {
                Ingredient pantryItem = pantry.Find(i => i.name == shoppingIngredient.name);

                if (pantryItem != null)
                {
                    pantryItem.quantity += shoppingIngredient.quantity;
                }
                else
                {
                    pantry.Add(shoppingIngredient);
                }
            }

            foreach (var recipeId in remainingMeals)
            {
                var recipeIngredients = RecipeDAL.getIngredientsForRecipe(recipeId, Connection.ConnectionString);

                foreach (var recipeIngredient in recipeIngredients)
                {
                    Ingredient existingIngredient = totalIngredients.Find(i => i.name == recipeIngredient.IngredientName && i.measurement == recipeIngredient.Measurement);

                    if (existingIngredient != null)
                    {
                        existingIngredient.quantity += (int)recipeIngredient.Quantity;
                    }
                    else
                    {
                        int ingredientId = IngredientDAL.getIngredientId(recipeIngredient.IngredientName);
                        Ingredient newIngredient = new Ingredient(ActiveUser.username, recipeIngredient.IngredientName, ingredientId, recipeIngredient.Quantity, recipeIngredient.Measurement);

                        totalIngredients.Add(newIngredient);
                    }
                }
            }

            foreach (var ingredient in totalIngredients)
            {
                Ingredient shoppingListItem = shoppingIngredients.Find(i => i.name == ingredient.name);

                if (shoppingListItem != null)
                {
                    int quantity = (int)shoppingListItem.quantity + (int)ingredient.quantity;

                    ShoppingListDAL.updateQuantity((int)ingredient.id, quantity);
                }
                else
                {
                    ShoppingListDAL.addIngredient(ingredient.name, (int)ingredient.quantity, ingredient.measurement, Connection.ConnectionString);
                }
            }
        }

        private void addNeededIngredients()
        {
            string user = ActiveUser.username;
            List<Ingredient> totalIngredients = new List<Ingredient>();
            List<int> remainingMeals =
                PlannedMealDal.getRemainingMeals(Connection.ConnectionString);
            List<Ingredient> pantry = IngredientDAL.getIngredients();
            List<Ingredient> shoppingIngredients = ShoppingListDAL.getIngredients();

            foreach (Ingredient shoppingItem in shoppingIngredients)
            {
                Ingredient pantryItem = pantry.Find(i => i.name == shoppingItem.name);

                if (pantryItem != null)
                {
                    pantryItem.quantity += shoppingItem.quantity;
                }
                else
                {
                    pantry.Add(shoppingItem);
                }
            }

            foreach (var recipeId in remainingMeals)
            {
                var recipeIngredients = RecipeDAL.getIngredientsForRecipe(recipeId, Connection.ConnectionString);

                foreach (RecipeIngredient recipeIngredient in recipeIngredients)
                {
                    Ingredient existingIngredient = totalIngredients.Find(i =>
                        i.name == recipeIngredient.IngredientName && i.measurement == recipeIngredient.Measurement);

                    if (existingIngredient != null)
                    {
                        existingIngredient.quantity += (int)recipeIngredient.Quantity;

                    }
                    else
                    {
                        int ingredientId = IngredientDAL.getIngredientId(recipeIngredient.IngredientName);
                        Ingredient newIngredient = new Ingredient(user, recipeIngredient.IngredientName, ingredientId,
                            recipeIngredient.Quantity,
                            recipeIngredient.Measurement);
                        totalIngredients.Add(newIngredient);
                    }
                }
            }


            foreach (var ingredient in totalIngredients)
            {
                Ingredient pantryItem = pantry.Find(i => i.name == ingredient.name);

                if (pantryItem != null)
                {
                    if (ingredient.quantity > pantryItem.quantity)
                    {
                        int quantity = (int)ingredient.quantity - (int)pantryItem.quantity;
                        Ingredient shoppingListItem = shoppingIngredients.Find(i => i.name == ingredient.name);

                        if (shoppingListItem != null)
                        {
                            ShoppingListDAL.updateQuantity((int)ingredient.id, quantity);
                        }
                        else
                        {
                            ShoppingListDAL.addIngredient(ingredient.name, quantity, ingredient.measurement, Connection.ConnectionString);
                        }

                    }
                }
                else
                {
                    ShoppingListDAL.addIngredient(ingredient.name, (int)ingredient.quantity, ingredient.measurement, Connection.ConnectionString);
                }
            }
        }
    }
}
