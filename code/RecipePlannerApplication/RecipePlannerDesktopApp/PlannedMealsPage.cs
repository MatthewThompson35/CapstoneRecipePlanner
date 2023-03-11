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

        public string DayValue { get; set; }
        public string MealTypeValue { get; set; }

        public PlannedMealsPage()
        {
            InitializeComponent();

            this.detailsPage = new RecipeDetailsPage();

            this.daysLabels = new List<Label>() { sundayLabel, mondayLabel, tuesdayLabel, wednesdayLabel, thursdayLabel, fridayLabel, saturdayLabel };
            this.mealTypeDaysLabels = new List<Label>() { sundayBreakfastLabel, sundayLunchLabel, sundayDinnerLabel, mondayBreakfastLabel, mondayLunchLabel, mondayDinnerLabel, tuesdayBreakfastLabel, tuesdayLunchLabel, tuesdayDinnerLabel, wednesdayBreakfastLabel, wednesdayLunchLabel, wednesdayDinnerLabel, thursdayBreakfastLabel, thursdayLunchLabel, thursdayDinnerLabel, fridayBreakfastLabel, fridayLunchLabel, fridayDinnerLabel, saturdayBreakfastLabel, saturdayLunchLabel, saturdayDinnerLabel };
            

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var detailsPage = new RecipeDetailsPage();
            detailsPage.Show();
        }

        private void findRecipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            var homepage = new Homepage();
            homepage.Show();
        }

        private void plannerMenuButton_Click(object sender, EventArgs e)
        {
            this.plannerContextMenuStrip.Show(plannerMenuButton, 0, plannerMenuButton.Height);
        }

        private void populateRecipeToCertainDayAndMealType()
        {
            foreach (var currentDayLabel in this.daysLabels)
            {
                if (currentDayLabel.Text.Equals(this.DayValue))
                {
                    foreach (var currentMealDayLabel in this.mealTypeDaysLabels)
                    {
                        if (currentMealDayLabel.Text.Equals(this.detailsPage.GetMealType()))
                        {
                            //Populate the recipe name to the text field of that day and mealtype
                            //this.sundayBreakfastTextBox.Text = 

                            if (this.detailsPage.getCurrentRecipe() != null)
                            {
                                switch (currentDayLabel.Name + currentMealDayLabel.Name)
                                {
                                    
                                    case "mondayBreakfastLabel":
                                        this.mondayBreakfastTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "mondayLunchLabel":
                                        this.mondayLunchTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "mondayDinnerLabel":
                                        this.mondayDinnerTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "tuesdayBreakfastLabel":
                                        this.tuesdayBreakfastTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "tuesdayLunchLabel":
                                        this.tuesdayLunchTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "tuesdayDinnerLabel":
                                        this.tuesdayDinnerTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "wednesdayBreakfastLabel":
                                        this.wednesdayBreakfastTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "wednesdayLunchLabel":
                                        this.wednesdayLunchTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "wednesdayDinnerLabel":
                                        this.wednesdayDinnerTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "thursdayBreakfastLabel":
                                        this.thursdayBreakfastTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "thursdayLunchLabel":
                                        this.thursdayLunchTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "thursdayDinnerLabel":
                                        this.thursdayDinnerTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "fridayBreakfastLabel":
                                        this.fridayBreakfastTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "fridayLunchLabel":
                                        this.fridayLunchTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "fridayDinnerLabel":
                                        this.fridayDinnerTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "saturdayBreakfastLabel":
                                        this.saturdayBreakfastTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "saturdayLunchLabel":
                                        this.saturdayLunchTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "saturdayDinnerLabel":
                                        this.saturdayDinnerTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;

                                    case "sundayBreakfastLabel":
                                        this.sundayBreakfastTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "sundayLunchLabel":
                                        this.sundayLunchTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;
                                    case "sundayDinnerLabel":
                                        this.sundayDinnerTextBox.Text = this.detailsPage.getCurrentRecipe().Name;
                                        break;

                                    default:
                                        throw new Exception("label not provided");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void PlannedMealsPage_Load(object sender, EventArgs e)
        {
            this.populateRecipeToCertainDayAndMealType();
        }
    }
}
