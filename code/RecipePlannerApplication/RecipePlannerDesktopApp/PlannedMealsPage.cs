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

        public PlannedMealsPage()
        {
            InitializeComponent();
        }

        public PlannedMealsPage(RecipeDetailsPage detailsPage) : this()
        {
            this.detailsPage = detailsPage;
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
                if (currentDayLabel.Text.Equals(this.detailsPage.GetDayOfWeek()))
                {
                    foreach (var currentMealDayLabel in this.mealTypeDaysLabels)
                    {
                        if (currentMealDayLabel.Text.Equals(this.detailsPage.GetMealType()))
                        {
                            //Populate the recipe name to the text field of that day and mealtype
                            //this.sundayBreakfastTextBox.Text = 
                        }
                    }
                }
            }
        }
    }
}
