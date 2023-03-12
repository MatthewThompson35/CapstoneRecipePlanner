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
                                        if (this.mondayBreakfastTextBox.Text == "Meal has not been added to this time yet")
                                        {
                                            return;
                                        } else
                                        {
                                            PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
                                            this.mondayBreakfastTextBox.Text = "Meal has not been added to this time yet";
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
            
        }

        private void removeMondayLunchButton_Click(object sender, EventArgs e)
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
                                    case "mondayLabel" + "mondayLunchLabel":
                                        if (this.mondayLunchTextBox.Text == "Meal has not been added to this time yet") {
                                            return;
                                        }
                                        else
                                        {
                                            PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
                                            this.mondayLunchTextBox.Text = "Meal has not been added to this time yet";
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
        }

        private void removeMondayDinnerButton_Click(object sender, EventArgs e)
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
                                    case "mondayLabel" + "mondayDinnerLabel":

                                        if (this.mondayDinnerTextBox.Text == "Meal has not been added to this time yet")
                                        {
                                            return;
                                        } else
                                        {
                                            PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
                                            this.mondayDinnerTextBox.Text = "Meal has not been added to this time yet";
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
        }

        private void removeTuesdayBreakfastButton_Click(object sender, EventArgs e)
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
                                    case "tuesdayLabel" + "tuesdayBreakfastLabel":
                                        if (this.tuesdayBreakfastTextBox.Text == "Meal has not been added to this time yet")
                                        {
                                            return;
                                        } else
                                        {
                                            PlannedMealDal.RemoveThisWeekMeal(Connection.ConnectionString, meal.Value, meal.Key.Item1, meal.Key.Item2, this.detailsPage.GetDateOfCurrentWeekDay((DayOfWeek)Enum.Parse(typeof(DayOfWeek), meal.Key.Item1)));
                                            this.tuesdayBreakfastTextBox.Text = "Meal has not been added to this time yet";
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
        }

        private void removeTuesdayLunchButton_Click(object sender, EventArgs e)
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
                                    case "tuesdayLabel" + "tuesdayLunchLabel":
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

                                    default:

                                        break;

                                }
                            }
                        }
                    }

                }


            }
        }

        private void removeTuesdayDinnerButton_Click(object sender, EventArgs e)
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
                                    case "tuesdayLabel" + "tuesdayDinnerLabel":
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

                                    default:

                                        break;

                                }
                            }
                        }
                    }

                }


            }
        }

        private void removeWednesdayBreakfastButton_Click(object sender, EventArgs e)
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
                                    case "wednesdayLabel" + "wednesdayBreakfastLabel":
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

                                    default:

                                        break;

                                }
                            }
                        }
                    }
                }
            }
        }

        private void removeWednesdayLunchButton_Click(object sender, EventArgs e)
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
                                    case "wednesdayLabel" + "wednesdayLunchLabel":
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

                                    default:

                                        break;

                                }
                            }
                        }
                    }
                }
            }
        }

        private void removeWednesdayDinnerButton_Click(object sender, EventArgs e)
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
                                    case "wednesdayLabel" + "wednesdayDinnerLabel":
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

                                    default:

                                        break;

                                }
                            }
                        }
                    }
                }
            }
        }

        private void removeThursdayBreakfastButton_Click(object sender, EventArgs e)
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
                                    case "thursdayLabel" + "thursdayBreakfastLabel":
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

                                    default:

                                        break;

                                }
                            }
                        }
                    }
                }
            }
        }

        private void removeThursdayLunchButton_Click(object sender, EventArgs e)
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
                                    case "thursdayLabel" + "thursdayLunchLabel":
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

                                    default:

                                        break;

                                }
                            }
                        }
                    }
                }
            }
        }

        private void removeThursdayDinnerButton_Click(object sender, EventArgs e)
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
                                    case "thursdayLabel" + "thursdayDinnerLabel":
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

                                    default:

                                        break;

                                }
                            }
                        }
                    }
                }
            }
        }

        private void removeFridayBreakfastButton_Click(object sender, EventArgs e)
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
                                    case "fridayLabel" + "fridayBreakfastLabel":
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

                                    default:

                                        break;

                                }
                            }
                        }
                    }
                }
            }
        }

        private void removeFridayLunchButton_Click(object sender, EventArgs e)
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
                                    case "fridayLabel" + "fridayLunchLabel":
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

                                    default:

                                        break;

                                }
                            }
                        }
                    }
                }
            }
        }

        private void removeFridayDinnerButton_Click(object sender, EventArgs e)
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
                                    case "fridayLabel" + "fridayDinnerLabel":
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

                                    default:

                                        break;

                                }
                            }
                        }
                    }
                }
            }
        }

        private void removeSaturdayBreakfastButton_Click(object sender, EventArgs e)
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
                                    case "saturdayLabel" + "saturdayBreakfastLabel":
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

                                    default:

                                        break;

                                }
                            }
                        }
                    }
                }
            }
        }

        private void removeSaturdayLunchButton_Click(object sender, EventArgs e)
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
                                    case "saturdayLabel" + "saturdayLunchLabel":
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

                                    default:

                                        break;

                                }
                            }
                        }
                    }
                }
            }
        }

        private void removeSatudayDinnerButton_Click(object sender, EventArgs e)
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
                                    case "saturdayLabel" + "saturdayDinnerLabel":
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

                                    default:

                                        break;

                                }
                            }
                        }
                    }
                }
            }
        }

        private void removeSundayBreakfastButton_Click(object sender, EventArgs e)
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
                                    case "sundayLabel" + "sundayBreakfastLabel":
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

                                    default:

                                        break;

                                }
                            }
                        }
                    }
                }
            }
        }

        private void removeSundayLunchButton_Click(object sender, EventArgs e)
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
                                    case "sundayLabel" + "sundayLunchLabel":
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

                                    default:

                                        break;

                                }
                            }
                        }
                    }
                }
            }
        }

        private void removeSundayDinnerButton_Click(object sender, EventArgs e)
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
                                    case "sundayLabel" + "sundayDinnerLabel":
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
