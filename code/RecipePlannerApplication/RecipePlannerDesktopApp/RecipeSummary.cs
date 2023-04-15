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

            this.ingredientAddPage= new RecipeIngredientAdd();
            this.stepAddPage = new RecipeStepAdd();
            this.tagAddPage = new RecipeTagAdd();
        }

        public RecipeSummary(RecipeIngredientAdd ingredientAdd, RecipeStepAdd stepAddPage, RecipeTagAdd tagAddPage)
        {
            this.ingredientAddPage = ingredientAdd;
            this.stepAddPage = stepAddPage;
            this.tagAddPage = tagAddPage;

            this.addIngredientsToListView();

        }

        public void SetTagData(List<string> tagData)
        {
            tags = tagData;
        }

        public List<string> GetTagData()
        {
            return this.tags;
        }

        public void SetStepData(List<RecipeStep> stepData)
        {
            recipeSteps = stepData;
        }

        public List<RecipeStep> GetStepData()
        {
            return this.recipeSteps;
        }

        public void SetIngredientData(List<RecipeIngredient> ingredientData)
        {
            recipeIngredients = ingredientData;
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
    }
}