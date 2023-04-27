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
        private List<LinkLabel> mealTypeDaysLinkLabels;
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
            
            this.mealTypeDaysLinkLabels = new List<LinkLabel> { mondayBreakfastLinkLabel, mondayLunchLinkLabel, mondayDinnerLinkLabel, tuesdayBreakfastLinkLabel, tuesdayLunchLinkLabel, tuesdayDinnerLinkLabel, wednesdayBreakfastLinkLabel, wednesdayLunchLinkLabel, wednesdayDinnerLinkLabel, thursdayBreakfastLinkLabel, thursdayLunchLinkLabel, thursdayDinnerLinkLabel, fridayBreakfastLinkLabel, fridayLunchLinkLabel, fridayDinnerLinkLabel, saturdayBreakfastLinkLabel, saturdayLunchLinkLabel, saturdayDinnerLinkLabel, sundayBreakfastLinkLabel, sundayLunchLinkLabel, sundayDinnerLinkLabel };
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
                        foreach (var currentMealDayLinkLabel in this.mealTypeDaysLinkLabels)
                        {
                            if (currentMealDayLinkLabel.Text.Replace(":", "").Equals(meal.Key.Item2))
                            {
                                currentMealDayLinkLabel.Text = currentMealDayLinkLabel.Text.Replace(":", "");
                                    switch (currentDayLabel.Name + currentMealDayLinkLabel.Name)
                                    {
                                        case "mondayLabel" + "mondayBreakfastLinkLabel":
                                        this.mondayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "mondayLabel" + "mondayLunchLinkLabel":
                                            this.mondayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                        case "mondayLabel" + "mondayDinnerLinkLabel":
                                            this.mondayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                        case "tuesdayLabel" + "tuesdayBreakfastLinkLabel":
                                            this.tuesdayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                        case "tuesdayLabel" + "tuesdayLunchLinkLabel":
                                            this.tuesdayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                        case "tuesdayLabel" + "tuesdayDinnerLinkLabel":
                                            this.tuesdayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                        case "wednesdayLabel" + "wednesdayBreakfastLinkLabel":
                                            this.wednesdayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                        case "wednesdayLabel" + "wednesdayLunchLinkLabel":
                                            this.wednesdayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "wednesdayLabel" + "wednesdayDinnerLinkLabel":
                                            this.wednesdayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "thursdayLabel" + "thursdayBreakfastLinkLabel":
                                            this.thursdayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "thursdayLabel" + "thursdayLunchLinkLabel":
                                            this.thursdayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "thursdayLabel" + "thursdayDinnerLinkLabel":
                                            this.thursdayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "fridayLabel" + "fridayBreakfastLinkLabel":
                                            this.fridayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "fridayLabel" + "fridayLunchLinkLabel":
                                            this.fridayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "fridayLabel" + "fridayDinnerLinkLabel":
                                            this.fridayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "saturdayLabel" + "saturdayBreakfastLinkLabel":
                                            this.saturdayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "saturdayLabel" + "saturdayLunchLinkLabel":
                                            this.saturdayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "saturdayLabel" + "saturdayDinnerLinkLabel":
                                            this.saturdayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;

                                        case "sundayLabel" + "sundayBreakfastLinkLabel":
                                            this.sundayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "sundayLabel" + "sundayLunchLinkLabel":
                                            this.sundayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                            break;
                                        case "sundayLabel" + "sundayDinnerLinkLabel":
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
                        foreach (var currentMealDayLinkLabel in this.mealTypeDaysLinkLabels)
                        {
                            if (currentMealDayLinkLabel.Text.Replace(":", "").Equals(meal.Key.Item2))
                            {
                                currentMealDayLinkLabel.Text = currentMealDayLinkLabel.Text.Replace(":", "");
                                switch (currentDayLabel.Name + currentMealDayLinkLabel.Name)
                                {
                                    case "mondayLabel" + "mondayBreakfastLinkLabel":
                                        this.mondayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "mondayLabel" + "mondayLunchLinkLabel":
                                        this.mondayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "mondayLabel" + "mondayDinnerLinkLabel":
                                        this.mondayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "tuesdayLabel" + "tuesdayBreakfastLinkLabel":
                                        this.tuesdayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "tuesdayLabel" + "tuesdayLunchLinkLabel":
                                        this.tuesdayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "tuesdayLabel" + "tuesdayDinnerLinkLabel":
                                        this.tuesdayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "wednesdayLabel" + "wednesdayBreakfastLinkLabel":
                                        this.wednesdayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "wednesdayLabel" + "wednesdayLunchLinkLabel":
                                        this.wednesdayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "wednesdayLabel" + "wednesdayDinnerLinkLabel":
                                        this.wednesdayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "thursdayLabel" + "thursdayBreakfastLinkLabel":
                                        this.thursdayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "thursdayLabel" + "thursdayLunchLinkLabel":
                                        this.thursdayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "thursdayLabel" + "thursdayDinnerLinkLabel":
                                        this.thursdayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "fridayLabel" + "fridayBreakfastLinkLabel":
                                        this.fridayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "fridayLabel" + "fridayLunchLinkLabel":
                                        this.fridayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "fridayLabel" + "fridayDinnerLinkLabel":
                                        this.fridayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "saturdayLabel" + "saturdayBreakfastLinkLabel":
                                        this.saturdayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "saturdayLabel" + "saturdayLunchLinkLabel":
                                        this.saturdayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "saturdayLabel" + "saturdayDinnerLinkLabel":
                                        this.saturdayDinnerTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;

                                    case "sundayLabel" + "sundayBreakfastLinkLabel":
                                        this.sundayBreakfastTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "sundayLabel" + "sundayLunchLinkLabel":
                                        this.sundayLunchTextBox.Text = RecipeDAL.getRecipeNameById(meal.Value, Connection.ConnectionString);
                                        break;
                                    case "sundayLabel" + "sundayDinnerLinkLabel":
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
                this.removeNextWeekMeal(this.mondayBreakfastLinkLabel, this.mondayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.mondayBreakfastLinkLabel, this.mondayLabel.Text);
            }
            

        }

        private void removeMondayLunchButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.mondayLunchLinkLabel, this.mondayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.mondayLunchLinkLabel, this.mondayLabel.Text);
                

            }
        }

        private void removeMondayDinnerButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.mondayDinnerLinkLabel, this.mondayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.mondayDinnerLinkLabel, this.mondayLabel.Text);
                
            }
            
            
        }

        private void removeTuesdayBreakfastButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.tuesdayBreakfastLinkLabel, this.tuesdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.tuesdayBreakfastLinkLabel, this.tuesdayLabel.Text);
            }
            
            
        }

        private void removeTuesdayLunchButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.tuesdayLunchLinkLabel, this.tuesdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.tuesdayLunchLinkLabel, this.tuesdayLabel.Text);
            }
            
            
        }

        private void removeTuesdayDinnerButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.tuesdayDinnerLinkLabel, this.tuesdayLabel.Text);
                
            }
            else
            {
                this.removeThisWeekMeal(this.tuesdayDinnerLinkLabel, this.tuesdayLabel.Text);
            }
            
            
        }

        private void removeWednesdayBreakfastButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.wednesdayBreakfastLinkLabel, this.wednesdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.wednesdayBreakfastLinkLabel, this.wednesdayLabel.Text);
            }
            
            
        }

        private void removeWednesdayLunchButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.wednesdayLunchLinkLabel, this.wednesdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.wednesdayLunchLinkLabel, this.wednesdayLabel.Text);
            }
            
            
        }

        private void removeWednesdayDinnerButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.wednesdayDinnerLinkLabel, this.wednesdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.wednesdayDinnerLinkLabel, this.wednesdayLabel.Text);
            }
            
            
        }

        private void removeThursdayBreakfastButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.thursdayBreakfastLinkLabel, this.thursdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.thursdayBreakfastLinkLabel, this.thursdayLabel.Text);
            }
            
            
        }

        private void removeThursdayLunchButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.thursdayLunchLinkLabel, this.thursdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.thursdayLunchLinkLabel, this.thursdayLabel.Text);
            }
            
            
        }

        private void removeThursdayDinnerButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.thursdayDinnerLinkLabel, this.thursdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.thursdayDinnerLinkLabel, this.thursdayLabel.Text);
            }
            
            
        }

        private void removeFridayBreakfastButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.fridayBreakfastLinkLabel, this.fridayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.fridayBreakfastLinkLabel, this.fridayLabel.Text);
            }
            
            
        }

        private void removeFridayLunchButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.fridayLunchLinkLabel, this.fridayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.fridayLunchLinkLabel, this.fridayLabel.Text);
            }
            
            
        }

        private void removeFridayDinnerButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.fridayDinnerLinkLabel, this.fridayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.fridayDinnerLinkLabel, this.fridayLabel.Text);
            }
            
            
        }

        private void removeSaturdayBreakfastButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.saturdayBreakfastLinkLabel, this.saturdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.saturdayBreakfastLinkLabel, this.saturdayLabel.Text);
            }
            
            
        }

        private void removeSaturdayLunchButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.saturdayLunchLinkLabel, this.saturdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.saturdayLunchLinkLabel, this.saturdayLabel.Text);
            }
            
            
        }

        private void removeSatudayDinnerButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.saturdayDinnerLinkLabel, this.saturdayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.saturdayDinnerLinkLabel, this.saturdayLabel.Text);
            }
            
            
        }

        private void removeSundayBreakfastButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.sundayBreakfastLinkLabel, this.sundayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.sundayBreakfastLinkLabel, this.sundayLabel.Text);
            }
            
            
        }

        private void removeSundayLunchButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.sundayLunchLinkLabel, this.sundayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.sundayLunchLinkLabel, this.sundayLabel.Text);
            }
            
            
        }

        private void removeSundayDinnerButton_Click(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.sundayDinnerLinkLabel, this.sundayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.sundayDinnerLinkLabel, this.sundayLabel.Text);
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

        private void removeNextWeekMeal(LinkLabel mealTypeLinkLabel, string dayOfWeek)
        {
            foreach (KeyValuePair<(string, string), int> meal in PlannedMealDal.getNextWeeksMeals(Connection.ConnectionString))
            {
                if (meal.Key.Item1.Equals(dayOfWeek) && mealTypeLinkLabel.Text.Replace(":", "").Equals(meal.Key.Item2))
                {
                    mealTypeLinkLabel.Text = mealTypeLinkLabel.Text.Replace(":", "");

                    switch (dayOfWeek + mealTypeLinkLabel.Text)
                    {
                        case "Monday" + "Breakfast":
                            if (this.mondayBreakfastTextBox.Text == "Meal has not been added to this time yet")
                            {
                                this.removeMondayBreakfastButton.Enabled = false;
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
                                this.removeMondayLunchButton.Enabled = false;
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
                                this.removeMondayDinnerButton.Enabled = false;
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
                                this.removeTuesdayBreakfastButton.Enabled = false;
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
                                this.removeTuesdayLunchButton.Enabled = false;
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
                                this.removeTuesdayDinnerButton.Enabled = false;
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
                                this.removeWednesdayBreakfastButton.Enabled = false;
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
                                this.removeWednesdayLunchButton.Enabled = false;
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
                                this.removeWednesdayDinnerButton.Enabled = false;
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
                                this.removeThursdayBreakfastButton.Enabled = false;
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
                                this.removeThursdayLunchButton.Enabled = false;
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
                                this.removeThursdayDinnerButton.Enabled = false;
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
                                this.removeFridayBreakfastButton.Enabled = false;
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
                                this.removeFridayLunchButton.Enabled = false;
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
                                this.removeFridayDinnerButton.Enabled = false;
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
                                this.removeSaturdayBreakfastButton.Enabled = false;
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
                                this.removeSaturdayLunchButton.Enabled = false;
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
                                this.removeSatudayDinnerButton.Enabled = false;
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
                                this.removeSundayBreakfastButton.Enabled = false;
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
                                this.removeSundayLunchButton.Enabled = false;
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
                                this.removeSundayDinnerButton.Enabled = false;
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

        private void removeThisWeekMeal(LinkLabel mealTypeLinkLabel, string dayOfWeek)
        {
            foreach (KeyValuePair<(string, string), int> meal in PlannedMealDal.getThisWeeksMeals(Connection.ConnectionString))
            {
                if (meal.Key.Item1.Equals(dayOfWeek) && mealTypeLinkLabel.Text.Replace(":", "").Equals(meal.Key.Item2))
                {
                    mealTypeLinkLabel.Text = mealTypeLinkLabel.Text.Replace(":", "");

                    switch (dayOfWeek + mealTypeLinkLabel.Text)
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
            List<Ingredient> shoppingIngredients = ShoppingListDAL.getIngredients(Connection.ConnectionString);

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
                        Ingredient newIngredient = new Ingredient(ActiveUser.username, recipeIngredient.IngredientName, recipeIngredient.Quantity, ingredientId, recipeIngredient.Measurement);

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

                    ShoppingListDAL.updateQuantity((int)ingredient.id, quantity, Connection.ConnectionString);
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
            List<Ingredient> shoppingIngredients = ShoppingListDAL.getIngredients(Connection.ConnectionString);

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
                        Ingredient newIngredient = new Ingredient(user, recipeIngredient.IngredientName,
                            recipeIngredient.Quantity,
                            ingredientId,
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
                            ShoppingListDAL.updateQuantity((int)ingredient.id, quantity, Connection.ConnectionString);
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

        private void mondayBreakfastLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
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

        private void mondayLunchLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void mondayDinnerLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void tuesdayBreakfastLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void tuesdayLunchLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void tuesdayDinnerLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void wednesdayBreakfastLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void wednesdayLunchLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void wednesdayDinnerLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void thursdayBreakfastLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void thursdayLunchLinkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void thursdayDinnerLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void fridayBreakfastLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void fridayLunchLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void fridayDinnerLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void saturdayBreakfastLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void saturdayLunchLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void saturdayDinnerLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void sundayBreakfastLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void sundayLunchLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void sundayDinnerLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void removeSundayBreakfastButton_Click_1(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.sundayBreakfastLinkLabel, this.sundayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.sundayBreakfastLinkLabel, this.sundayLabel.Text);
            }

        }

        private void removeSundayLunchButton_Click_1(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.sundayLunchLinkLabel, this.sundayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.sundayLunchLinkLabel, this.sundayLabel.Text);
            }

        }

        private void removeSundayDinnerButton_Click_1(object sender, EventArgs e)
        {
            if (this.isNextWeekDisplayed)
            {
                this.removeNextWeekMeal(this.sundayDinnerLinkLabel, this.sundayLabel.Text);
            }
            else
            {
                this.removeThisWeekMeal(this.sundayDinnerLinkLabel, this.sundayLabel.Text);
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

        private void viewPantryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            var pantry = new IngredientsPage();

            pantry.Show();
        }
    }
}
