using RecipePlannerDesktopApplication;
using RecipePlannerLibrary.Models;

namespace RecipePlannerFinalDemoAdditions
{
    public partial class RecipeSummary : Form
    {
        private RecipeIngredientAdd ingredientAddPage;
        private RecipeStepAdd stepAddPage;
        private RecipeTagAdd tagAddPage;

        private List<string> tags = new List<string>();
        private List<RecipeStep> recipeSteps = new List<RecipeStep>();
        private List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>();


        public RecipeSummary()
        {
            InitializeComponent();

            this.ingredientAddPage = new RecipeIngredientAdd();
            this.stepAddPage = new RecipeStepAdd();
            this.tagAddPage = new RecipeTagAdd();
        }

        public RecipeSummary(RecipeIngredientAdd ingredientAdd, RecipeStepAdd stepAddPage, RecipeTagAdd tagAddPage)
        {
            this.ingredientAddPage = ingredientAdd;
            this.stepAddPage = stepAddPage;
            this.tagAddPage = tagAddPage;

        }

        public void SetTagData(List<string> tagData)
        {
            //tags = tagData;

            foreach (var tag in tagData)
            {
                if (!tags.Contains(tag))
                {
                    // If the tag is not already in the list, add it to the tags list
                    tags.Add(tag);

                    // Add a new ListViewItem to the tagsListView control
                    ListViewItem item = new ListViewItem(tag);
                    tagsListView.Items.Add(item);
                }
            }
        }

        public List<string> GetTagData()
        {
            return this.tags;
        }

        public void SetStepData(List<RecipeStep> stepData)
        {
            recipeSteps = stepData;

            foreach (var step in stepData)
            {
                ListViewItem item = new ListViewItem(step.stepNumber.ToString());
                item.SubItems.Add(step.stepDescription.ToString());
                stepsListView.Items.Add(item);
            }
        }

        public List<RecipeStep> GetStepData()
        {
            return this.recipeSteps;
        }

        public void SetIngredientData(List<RecipeIngredient> ingredientData)
        {
            recipeIngredients = ingredientData;

            foreach (var ing in ingredientData)
            {
                ListViewItem item = new ListViewItem(ing.IngredientName);

                item.SubItems.Add(ing.Quantity.ToString());
                item.SubItems.Add(ing.Measurement);

                ingredientsListView.Items.Add(item);
            }

        }

        public List<RecipeIngredient> GetIngredientData()
        {
            return this.recipeIngredients;
        }

        private void addIngredientsToListView()
        {
            foreach (var ingredient in this.ingredientAddPage.GetRecipeIngredients())
            {
                this.ingredientsListView.Items.Add(ingredient.IngredientName + " " + ingredient.Quantity + " " + ingredient.Measurement);
            }
        }

        private void addIngredientButton_Click(object sender, EventArgs e)
        {
            var ingredientAddPage = new RecipeIngredientAdd(this.recipeIngredients);

            this.Hide();

            ingredientAddPage.Show();
        }

        private void addStepButton_Click(object sender, EventArgs e)
        {
            var stepAddPage = new RecipeStepAdd(this.recipeSteps);

            this.Hide();

            stepAddPage.Show();
        }

        private void addTagButton_Click(object sender, EventArgs e)
        {
            var tagAddPage = new RecipeTagAdd(this.tags);

            this.Hide();

            tagAddPage.Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            var homepage = new Homepage();

            this.Hide();

            homepage.Show();
        }
    }
}