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
            //PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, int id, string day, string type, DateTime date);
        }

        private void removeMondayLunchButton_Click(object sender, EventArgs e)
        {

        }

        private void removeMondayDinnerButton_Click(object sender, EventArgs e)
        {

        }

        private void removeTuesdayBreakfastButton_Click(object sender, EventArgs e)
        {

        }

        private void removeTuesdayLunchButton_Click(object sender, EventArgs e)
        {

        }

        private void removeTuesdayDinnerButton_Click(object sender, EventArgs e)
        {

        }

        private void removeWednesdayBreakfastButton_Click(object sender, EventArgs e)
        {

        }

        private void removeWednesdayLunchButton_Click(object sender, EventArgs e)
        {

        }

        private void removeWednesdayDinnerButton_Click(object sender, EventArgs e)
        {

        }

        private void removeThursdayBreakfastButton_Click(object sender, EventArgs e)
        {

        }

        private void removeThursdayLunchButton_Click(object sender, EventArgs e)
        {

        }

        private void removeThursdayDinnerButton_Click(object sender, EventArgs e)
        {

        }

        private void removeFridayBreakfastButton_Click(object sender, EventArgs e)
        {

        }

        private void removeFridayLunchButton_Click(object sender, EventArgs e)
        {

        }

        private void removeFridayDinnerButton_Click(object sender, EventArgs e)
        {

        }

        private void removeSaturdayBreakfastButton_Click(object sender, EventArgs e)
        {

        }

        private void removeSaturdayLunchButton_Click(object sender, EventArgs e)
        {

        }

        private void removeSatudayDinnerButton_Click(object sender, EventArgs e)
        {

        }

        private void removeSundayBreakfastButton_Click(object sender, EventArgs e)
        {

        }

        private void removeSundayLunchButton_Click(object sender, EventArgs e)
        {

        }

        private void removeSundayDinnerButton_Click(object sender, EventArgs e)
        {

        }

        private void viewCurrentWeekPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.weekMealLabel.Text = "This Week's Meals";

            foreach (var textbox in this.mealDayTypeTextBoxes)
            {
                textbox.Clear();
            }
            this.displayThisWeekMeals();
            this.Refresh();

        }

        private void viewNextWeekPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.weekMealLabel.Text = "Next Week's Meals";

            foreach (var textbox in this.mealDayTypeTextBoxes)
            {
                textbox.Clear();
            }
            this.displayNextWeekMeals();

            this.Refresh();

        }
    }
}
