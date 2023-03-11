using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
using RecipePlannerLibrary.Models;

namespace RecipePlannerDesktopApplication;

/// <summary>
///     The Homepage partial class.
/// </summary>
public partial class Homepage : Form
{
    #region Data members

    private Recipe selectedRecipe;

    #endregion

    #region Properties

    /// <summary>
    ///     Gets or sets the list of Recipes for the Homepage.
    /// </summary>
    public List<Recipe> Recipes { get; set; }

    private List<string> searchTags;

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a Homepage for the recipes.
    /// </summary>
    public Homepage()
    {
        this.InitializeComponent();
        this.Recipes = new List<Recipe>();
        this.searchTags = new List<string>();

        this.showAvailableRecipesRadioButton.Checked = true;
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Gets a selected recipe from the recipes list view in the homepage.
    /// </summary>
    /// <returns>a selected recipe.</returns>
    public Recipe GetSelectedRecipe()
    {
        return this.selectedRecipe;
    }

    private void logoutButton_Click(object sender, EventArgs e)
    {
        Hide();
        var login = new LoginPage();
        login.Show();
    }

    private void viewIngredientsButton_Click(object sender, EventArgs e)
    {
        Hide();

        var ingredientsPage = new IngredientsPage();

        ingredientsPage.Show();
    }

    private void viewAllRecipes()
    {
        try
        {
            foreach (var recipe in RecipeDAL.getRecipes(Connection.ConnectionString))
            {
                this.recipeListView.Items.Add(new ListViewItem {Text = recipe.Name, Tag = recipe});
            }

            this.recipeListView.View = View.List;
            this.recipeListView.Sorting = SortOrder.Ascending;
        }
        catch (Exception ex)
        {
            this.noRecipesLabel.Text = "The connection to the server could not be made";
            this.noRecipesLabel.Visible = true;
        }
    }

    private void showAvailableRecipes()
    {
        try
        {
            var availableRecipes = this.getAvailableRecipes();

            if (availableRecipes.Count > 0)
            {
                this.noRecipesLabel.Visible = false;
                foreach (var availableRecipe in availableRecipes)
                {
                    this.recipeListView.Items.Add(new ListViewItem
                        {Text = availableRecipe.Name, Tag = availableRecipe});
                }
            }
            else
            {
                this.noRecipesLabel.Visible = true;
            }

            this.recipeListView.View = View.List;
            this.recipeListView.Sorting = SortOrder.Ascending;
        }
        catch (Exception ex)
        {
            this.noRecipesLabel.Text = "The connection to the server could not be made";
            this.noRecipesLabel.Visible = true;
        }
    }

    private List<Recipe> getAvailableRecipes()
    {
        var availableRecipes = new List<Recipe>();
        foreach (var recipe in RecipeDAL.getRecipes(Connection.ConnectionString))
        {
            var add = true;
            recipe.Ingredients = RecipeDAL.getIngredientsForRecipe(recipe.RecipeId, Connection.ConnectionString);
            foreach (var ingredient in recipe.Ingredients)
            {
                {
                    var ing = IngredientDAL.getIngredients(ingredient.IngredientName);
                    if (ing != null && ing.Count > 0)
                    {
                        if (ing[0].quantity < ingredient.Quantity)
                        {
                            add = false;
                        }
                    }
                    else
                    {
                        add = false;
                    }
                }
            }

            if (add)
            {
                availableRecipes.Add(recipe);
            }
        }

        return availableRecipes;
    }

    private void recipeListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.recipeListView.SelectedItems.Count > 0)
        {
            this.selectedRecipe = (Recipe) this.recipeListView.SelectedItems[0].Tag;

            Hide();

            var detailsPage = new RecipeDetailsPage(this);
            detailsPage.Show();
        }
    }

    private void showAllRecipesRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        if (this.showAllRecipesRadioButton.Checked)
        {
            this.viewAllRecipes();
            this.noRecipesLabel.Visible = false;
        }

        else
        {
            this.recipeListView.Clear();
        }
    }

    private void showAvailableRecipesRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        if (this.showAvailableRecipesRadioButton.Checked)
        {
            this.showAvailableRecipes();
        }
        else
        {
            this.recipeListView.Clear();
        }
    }

    #endregion

    private void nextButton_Click(object sender, EventArgs e)
    {

    }

    private void lastPageButton_Click(object sender, EventArgs e)
    {

    }

    private void previousButton_Click(object sender, EventArgs e)
    {

    }

    private void beginningButton_Click(object sender, EventArgs e)
    {

    }

    private void plannerMenuButton_Click(object sender, EventArgs e)
    {
        this.plannerContextMenuStrip.Show(plannerMenuButton, 0, plannerMenuButton.Height);
    }

    private void viewMealPlanToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.Hide();

        var mealPlanPage = new PlannedMealsPage();

        mealPlanPage.Show();
    }

    private void filterButton_Click(object sender, EventArgs e)
    {
        string tag = this.filterTagTxt.Text;

        if (!string.IsNullOrEmpty(tag) && !this.searchTags.Contains(tag))
        {
            this.filterTagTxt.Text = "";
            this.searchTags.Add(tag);
            this.tagsCmb.Items.Add(tag);
            this.tagsCmb.SelectedIndex = this.tagsCmb.Items.Count - 1;

            this.getFilteredRecipes(this.searchTags);
        }
    }

    private void getFilteredRecipes(List<string> tagFilters)
    {
        List<Recipe> recipes = new List<Recipe>();
        List<Recipe> filteredRecipes = new List<Recipe>();

        if (this.showAllRecipesRadioButton.Checked)
        {
            recipes = RecipeDAL.getRecipes(Connection.ConnectionString);
        }
        else
        {
            recipes = this.getAvailableRecipes();
        }

        try
        {
            foreach (var recipe in recipes)
            {
                var matchesAllTags = true;
                foreach (var tagFilter in tagFilters)
                {
                    var matchesTag = false;
                    foreach (var tag in recipe.Tags)
                    {
                        if (tagFilter.ToLower() == tag.ToLower())
                        {
                            matchesTag = true;
                        }
                    }

                    if (matchesTag == false)
                    {
                        matchesAllTags = false;
                        break;
                    }
                }

                if (matchesAllTags)
                {
                    filteredRecipes.Add(recipe);
                }
            }

            this.recipeListView.Clear();

            if (filteredRecipes.Count == 0)
            {
                this.noRecipesLabel.Visible = true;
            }
            else
            {
                this.noRecipesLabel.Visible = false;
            }

            foreach (var recipe in filteredRecipes)
            {
                this.recipeListView.Items.Add(new ListViewItem { Text = recipe.Name, Tag = recipe });
            }


            this.recipeListView.View = View.List;
            this.recipeListView.Sorting = SortOrder.Ascending;
        }
        catch (Exception ex)
        {
            this.noRecipesLabel.Text = "The connection to the server could not be made";
            this.noRecipesLabel.Visible = true;
        }
    }

    private void deleteFilterBtn_Click(object sender, EventArgs e)
    {
        if (this.tagsCmb.SelectedIndex != -1)
        {
            this.searchTags.RemoveAt(this.tagsCmb.SelectedIndex);
            this.tagsCmb.Items.RemoveAt(this.tagsCmb.SelectedIndex);
            this.tagsCmb.Text = "";

            this.getFilteredRecipes(this.searchTags);
        }
    }

    private void clearFiltersBtn_Click(object sender, EventArgs e)
    {

    }
}