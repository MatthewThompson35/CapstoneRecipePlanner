using RecipePlannerLibrary;
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

namespace RecipePlannerDesktopApplication
{
    public partial class PlannedMealsPage : Form
    {
        private RecipeDetailsPage detailsPage;
        private List<Label> daysLabels;
        private List<Label> mealTypeDaysLabels;
        private List<TextBox> mealDayTypeTextBoxes;
        private bool isNextWeekDisplayed;

        public string DayValue { get; set; }
        public string MealTypeValue { get; set; }

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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfNextWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
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
                                PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
                                this.sundayDinnerTextBox.Text = "Meal has not been added to this time yet";
                            }

                            break;

                        default:
                            break;
                    }
                }
            }
        }
    }
}
