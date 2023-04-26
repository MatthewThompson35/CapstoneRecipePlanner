using RecipePlannerDesktopApplication;
using RecipePlannerLibrary.Database;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Models;
using System.Net.NetworkInformation;

namespace RecipePlannerFinalDemoAdditions
{
    public partial class RecipeSummary : Form
    {
        private RecipeIngredientAdd ingredientAddPage;
        private RecipeStepAdd stepAddPage;
        private RecipeTagAdd tagAddPage;

        public List<string> tags = new List<string>();
        public List<string> tempTags = new List<string>();

        public List<RecipeStep> recipeSteps = new List<RecipeStep>();
        public List<RecipeStep> tempSteps = new List<RecipeStep>();

        public List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>();
        public List<RecipeIngredient> tempIngredients = new List<RecipeIngredient>();

        public Recipe NewRecipe { get; set; }

        public RecipeSummary()
        {
            InitializeComponent();

            this.ingredientAddPage = new RecipeIngredientAdd();
            this.stepAddPage = new RecipeStepAdd();
            this.tagAddPage = new RecipeTagAdd();

            this.NewRecipe = new Recipe();
        }

        public RecipeSummary(RecipeIngredientAdd ingredientAdd, RecipeStepAdd stepAddPage, RecipeTagAdd tagAddPage) :this()
        {
            this.ingredientAddPage = ingredientAdd;
            this.stepAddPage = stepAddPage;
            this.tagAddPage = tagAddPage;
        }

        public RecipeSummary(Recipe recipe) : this ()
        {
            this.NewRecipe = recipe;

        }

        public void SetTagData(List<string> tagData)
        {
            tags = tagData;

            this.NewRecipe.Tags = tags;
            this.tempTags = this.NewRecipe.Tags;

            this.tempSteps = this.NewRecipe.Steps;
            this.tempIngredients = this.NewRecipe.Ingredients;

            tagsListView.Items.Clear();

            foreach (var tag in tagData)
            {
                if (!tags.Contains(tag))
                {
                    tags.Add(tag);

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

            this.NewRecipe.Steps = recipeSteps;
            this.tempSteps = this.NewRecipe.Steps;

            this.tempTags = this.NewRecipe.Tags;
            this.tempIngredients = this.NewRecipe.Ingredients;

            stepsListView.Items.Clear();
            foreach (var step in this.NewRecipe.Steps)
            {
                ListViewItem item = new ListViewItem(step.stepNumber.ToString());
                item.SubItems.Add(step.stepDescription);
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

            this.NewRecipe.Ingredients = recipeIngredients;
            this.tempIngredients = this.NewRecipe.Ingredients;

            this.tempSteps = this.NewRecipe.Steps;
            this.tempTags = this.NewRecipe.Tags;

            ingredientsListView.Items.Clear();
            foreach (var ing in this.NewRecipe.Ingredients)
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
            this.NewRecipe.Name = this.nameTextBox.Text;
            this.NewRecipe.Description = this.descriptionTextBox.Text;

            this.NewRecipe.Steps = this.recipeSteps;

            if (this.NewRecipe.Steps.Count == 0)
            {
                this.NewRecipe.Steps = this.tempSteps;
            }

            this.NewRecipe.Tags = this.tags;

            if (this.NewRecipe.Tags.Count == 0)
            {
                this.NewRecipe.Tags = this.tempTags;
            }

            this.NewRecipe.Ingredients = this.recipeIngredients;

            if (NewRecipe.Ingredients.Count == 0)
            {
                this.NewRecipe.Ingredients = this.tempIngredients;
            }


            var ingredientAddPage = new RecipeIngredientAdd(this.NewRecipe.Ingredients, this.NewRecipe);

            this.Hide();

            ingredientAddPage.Show();
            
        }

        private void addStepButton_Click(object sender, EventArgs e)
        {
            this.NewRecipe.Name = this.nameTextBox.Text;
            this.NewRecipe.Description = this.descriptionTextBox.Text;

            this.NewRecipe.Steps = this.recipeSteps;

            if (this.NewRecipe.Steps.Count == 0)
            {
                this.NewRecipe.Steps = this.tempSteps;
            }
            
            this.NewRecipe.Tags = this.tags;

            if (this.NewRecipe.Tags.Count == 0)
            {
                this.NewRecipe.Tags = this.tempTags;
            }

            this.NewRecipe.Ingredients = this.recipeIngredients;

            if (NewRecipe.Ingredients.Count == 0)
            {
                this.NewRecipe.Ingredients = this.tempIngredients;
            }

            var stepAddPage = new RecipeStepAdd(this.NewRecipe.Steps, this.NewRecipe);

            this.Hide();

            stepAddPage.Show();
        }

        private void addTagButton_Click(object sender, EventArgs e)
        {
            this.NewRecipe.Name = this.nameTextBox.Text;
            this.NewRecipe.Description = this.descriptionTextBox.Text;

            this.NewRecipe.Steps = this.recipeSteps;

            if (this.NewRecipe.Steps.Count == 0)
            {
                this.NewRecipe.Steps = this.tempSteps;
            }

            this.NewRecipe.Tags = this.tags;
            this.NewRecipe.Ingredients = this.recipeIngredients;

            if (this.NewRecipe.Tags.Count == 0)
            {
                this.NewRecipe.Tags = this.tempTags;
            }


            if (NewRecipe.Ingredients.Count == 0)
            {
                this.NewRecipe.Ingredients = this.tempIngredients;
            }

            var tagAddPage = new RecipeTagAdd(this.NewRecipe.Tags, this.NewRecipe);

            this.Hide();

            tagAddPage.Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string recipeName = null;
            string recipeDescription = null;

            if (String.IsNullOrEmpty(this.nameTextBox.Text))
            {
                this.errorFieldsLabel.Visible = true;
            }
            else
            {
                this.errorFieldsLabel.Visible = false;
                recipeName = this.nameTextBox.Text;
            }

            if (String.IsNullOrEmpty(this.descriptionTextBox.Text))
            {
                this.errorFieldsLabel.Visible = true;
            }
            else
            {
                this.errorFieldsLabel.Visible = false;
                recipeDescription = this.descriptionTextBox.Text;
            }

            Recipe recipe = null;
            if (this.errorFieldsLabel.Visible == true)
            {
                return;
            }
            else
            {
                recipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            var homepage = new Homepage();

            this.Hide();

            homepage.Show();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            stepsListView.Items.Clear();

            tagsListView.Items.Clear();

            ingredientsListView.Items.Clear();

            NewRecipe.Steps = this.recipeSteps;

            if (NewRecipe.Steps.Count == 0)
            {
                NewRecipe.Steps = this.tempSteps;
            }

            foreach (var step in this.NewRecipe.Steps)
            {
                ListViewItem item = new ListViewItem(step.stepNumber.ToString());
                item.SubItems.Add(step.stepDescription);
                stepsListView.Items.Add(item);
            }

            this.nameTextBox.Text = NewRecipe.Name;
            this.descriptionTextBox.Text = NewRecipe.Description;

            NewRecipe.Tags = this.tags;

            if (NewRecipe.Tags.Count == 0)
            {
                NewRecipe.Tags = this.tempTags;
            }

            foreach (var tag in this.NewRecipe.Tags)
            {
                ListViewItem item = new ListViewItem(tag);
                tagsListView.Items.Add(item);
            }

            NewRecipe.Ingredients = this.recipeIngredients;

            if (NewRecipe.Ingredients.Count == 0)
            {
                NewRecipe.Ingredients = this.tempIngredients;
            }

            foreach (var ingredient in NewRecipe.Ingredients)
            {
                ListViewItem item = new ListViewItem(ingredient.IngredientName);

                item.SubItems.Add(ingredient.Quantity.ToString());
                item.SubItems.Add(ingredient.Measurement);

                ingredientsListView.Items.Add(item);
            }
        }
    }
}