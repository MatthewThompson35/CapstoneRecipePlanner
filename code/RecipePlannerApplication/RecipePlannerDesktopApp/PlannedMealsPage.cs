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
            this.displayAllMeals();
        }

        private void findRecipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            var homepage = new Homepage();
            homepage.Show();
        }

        private void displayAllMeals()
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
                    //foreach (var currentmealDayTypeTextBox in this.mealDayTypeTextBoxes)
                    //{
                    //    if (currentmealDayTypeTextBox.Text == null)
                    //    {
                    //        currentmealDayTypeTextBox.Text = "Meal has not been added to this time yet";
                    //    }
                    //}
                }

                
            }

            
        }

            private void plannerMenuButton_Click(object sender, EventArgs e)
            {
                this.plannerContextMenuStrip.Show(plannerMenuButton, 0, plannerMenuButton.Height);
            }

        //    private void populateRecipeToCertainDayAndMealType()
        //    {
        //        foreach (var currentDayLabel in this.daysLabels)
        //        {
        //            if (currentDayLabel.Text.Equals(this.DayValue))
        //            {
        //                foreach (var currentMealDayLabel in this.mealTypeDaysLabels)
        //                {
        //                    if (currentMealDayLabel.Text.Equals(this.detailsPage.GetMealType()))
        //                    {
        //                        //Populate the recipe name to the text field of that day and mealtype
        //                        //this.sundayBreakfastTextBox.Text = 

        //                        if (this.detailsPage.getCurrentRecipe() != null)
        //                        {
        //                            switch (currentDayLabel.Name + currentMealDayLabel.Name)
        //                            {

        //                                case "mondayBreakfastLabel":
        //                                    this.mondayBreakfastTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "mondayLunchLabel":
        //                                    this.mondayLunchTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "mondayDinnerLabel":
        //                                    this.mondayDinnerTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "tuesdayBreakfastLabel":
        //                                    this.tuesdayBreakfastTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "tuesdayLunchLabel":
        //                                    this.tuesdayLunchTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "tuesdayDinnerLabel":
        //                                    this.tuesdayDinnerTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "wednesdayBreakfastLabel":
        //                                    this.wednesdayBreakfastTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "wednesdayLunchLabel":
        //                                    this.wednesdayLunchTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "wednesdayDinnerLabel":
        //                                    this.wednesdayDinnerTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "thursdayBreakfastLabel":
        //                                    this.thursdayBreakfastTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "thursdayLunchLabel":
        //                                    this.thursdayLunchTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "thursdayDinnerLabel":
        //                                    this.thursdayDinnerTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "fridayBreakfastLabel":
        //                                    this.fridayBreakfastTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "fridayLunchLabel":
        //                                    this.fridayLunchTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "fridayDinnerLabel":
        //                                    this.fridayDinnerTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "saturdayBreakfastLabel":
        //                                    this.saturdayBreakfastTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "saturdayLunchLabel":
        //                                    this.saturdayLunchTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "saturdayDinnerLabel":
        //                                    this.saturdayDinnerTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;

        //                                case "sundayBreakfastLabel":
        //                                    this.sundayBreakfastTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "sundayLunchLabel":
        //                                    this.sundayLunchTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;
        //                                case "sundayDinnerLabel":
        //                                    this.sundayDinnerTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
        //                                    break;

        //                                default:
        //                                    throw new Exception("label not provided");
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        }
}
