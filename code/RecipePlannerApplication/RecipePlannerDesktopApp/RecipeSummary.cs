using RecipePlannerDesktopApplication;
using RecipePlannerLibrary.Database;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Models;
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;

namespace RecipePlannerFinalDemoAdditions
{
    public partial class RecipeSummary : Form
    {
        private RecipeIngredientAdd ingredientAddPage;
        private RecipeStepAdd stepAddPage;
        private RecipeTagAdd tagAddPage;

        /// <summary>
        ///     Initializes a new tags list object for the recipe summary.
        /// </summary>
        public List<string> tags = new List<string>();

        /// <summary>
        ///     Initializes a new temporary tags list object for the recipe summary.
        /// </summary>
        public List<string> tempTags = new List<string>();

        /// <summary>
        ///     Initializes a new recipeSteps list object for the recipe summary.
        /// </summary>
        public List<RecipeStep> recipeSteps = new List<RecipeStep>();

        /// <summary>
        ///     Initializes a new temporary steps list object for the recipe summary.
        /// </summary>
        public List<RecipeStep> tempSteps = new List<RecipeStep>();

        /// <summary>
        ///     Initializes a new recipeIngredients list object for the recipe summary.
        /// </summary>
        public List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>();

        /// <summary>
        ///     Initializes a new temporary ingredients list object for the recipe summary.
        /// </summary>
        public List<RecipeIngredient> tempIngredients = new List<RecipeIngredient>();

        /// <summary>
        ///     Gets or sets the new recipe.
        /// </summary>
        public Recipe NewRecipe { get; set; }

        /// <summary>
        ///     Initializes the RecipeSummary object page that sets each of the pages for adding into the summary: the ingredients add page,
        ///     the steps add page, and the tags add page.
        /// </summary>
        public RecipeSummary()
        {
            InitializeComponent();

            this.ingredientAddPage = new RecipeIngredientAdd();
            this.stepAddPage = new RecipeStepAdd();
            this.tagAddPage = new RecipeTagAdd();

            this.NewRecipe = new Recipe();
        }

        /// <summary>
        ///     Initializes the recipe summary object with the specified recipe ingredient add page, the recipe step add page and
        ///     the recipe tag add page.
        /// </summary>
        /// <param name="ingredientAdd">the ingredient add page</param>
        /// <param name="stepAddPage">the step add page</param>
        /// <param name="tagAddPage">the tag add page</param>
        public RecipeSummary(RecipeIngredientAdd ingredientAdd, RecipeStepAdd stepAddPage, RecipeTagAdd tagAddPage) :this()
        {
            this.ingredientAddPage = ingredientAdd;
            this.stepAddPage = stepAddPage;
            this.tagAddPage = tagAddPage;
        }

        /// <summary>
        ///     Initializes the recipe summary object based on the specified recipe.
        /// </summary>
        /// <param name="recipe">the recipe</param>
        public RecipeSummary(Recipe recipe) : this ()
        {
            this.NewRecipe = recipe;
        }

        /// <summary>
        ///     Sets the tag information for the summary list view.
        /// </summary>
        /// <param name="tagData">the tag data to set</param>
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

        /// <summary>
        ///     Gets the tags information
        /// </summary>
        /// <returns>the tags</returns>
        public List<string> GetTagData()
        {
            return this.tags;
        }

        /// <summary>
        ///     Sets the step data information for the summary list view.
        /// </summary>
        /// <param name="stepData">the step data information</param>
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

                stepsListView.ListViewItemSorter = new StepNumberComparer();
                stepsListView.Sort();
            }
        }

        /// <summary>
        ///     The StepNumberComparer class in order to compare the step numbers and sort.
        /// </summary>
        public class StepNumberComparer : IComparer
        {
            /// <summary>
            ///     Compares the objects
            /// </summary>
            /// <param name="x">the x object to compare</param>
            /// <param name="y">the y object to compare</param>
            /// <returns> the comparison between object x and object y</returns>
            public int Compare(object x, object y)
            {
                int xStepNumber = int.Parse(((ListViewItem)x).Text);
                int yStepNumber = int.Parse(((ListViewItem)y).Text);
                return xStepNumber.CompareTo(yStepNumber);
            }
        }

        /// <summary>
        ///     Gets the steps information
        /// </summary>
        /// <returns>the steps information</returns>
        public List<RecipeStep> GetStepData()
        {
            return this.recipeSteps;
        }

        /// <summary>
        ///     Sets the ingredient information for the summary list view.
        /// </summary>
        /// <param name="ingredientData">the ingredient data information.</param>
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

        /// <summary>
        ///     Gets the ingredients information.
        /// </summary>
        /// <returns>the ingreients information</returns>
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
            this.addRecipe();

            if (this.errorFieldsLabel.Visible == true)
            {
                return;
            }
            else
            {
                var homepage = new Homepage();

                this.Hide();

                homepage.Show();
            }
        }

        private void addRecipe()
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


            Recipe existingRecipe = null;
            if (this.errorFieldsLabel.Visible == true)
            {
                return;
            }
            else
            {
                existingRecipe = RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString);
            }

            if (existingRecipe.Name == null)
            {
                this.errorFieldsLabel.Visible = false;

                if (tagsListView.Items.Count == 0 || ingredientsListView.Items.Count == 0 || stepsListView.Items.Count == 0)
                {
                    this.errorFieldsLabel.Visible = true;
                }
                else
                {
                    this.errorFieldsLabel.Visible = false;
                    RecipeDAL.addRecipe(recipeName, recipeDescription, Connection.ConnectionString);
                    foreach (var recipeIng in this.NewRecipe.Ingredients)
                    {
                        RecipeDAL.addRecipeIngredient(RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString).RecipeId, recipeIng.IngredientName, IngredientDAL.getIngredientId(recipeIng.IngredientName), recipeIng.Quantity, recipeIng.Measurement, Connection.ConnectionString);
                    }
                    foreach (var aTag in this.NewRecipe.Tags)
                    {
                        RecipeDAL.addRecipeTag(RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString).RecipeId, aTag, Connection.ConnectionString);
                    }


                    foreach (var aStep in this.NewRecipe.Steps)
                    {
                        RecipeDAL.addRecipeStep(RecipeDAL.getRecipeByName(recipeName, Connection.ConnectionString).RecipeId, aStep.stepNumber, aStep.stepDescription, Connection.ConnectionString);
                    }
                }
            }
            else
            {
                this.errorFieldsLabel.Text = "This recipe already exists.";
                this.errorFieldsLabel.Visible = true;
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