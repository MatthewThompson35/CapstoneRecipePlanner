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
    private int allPage = 1;
    private int availablePage = 1;
    private readonly int maxAllPage;
    private readonly int maxAvailablePage;
    private readonly int pageSize = 1;
    private readonly List<Recipe> allPageOne;
    private readonly List<Recipe> availablePageOne;

    private readonly List<string> searchTags;

    #endregion

    #region Properties

    /// <summary>
    ///     Gets or sets the list of Recipes for the Homepage.
    /// </summary>
    public List<Recipe> Recipes { get; set; }

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
        var recipes = RecipeDAL.getRecipes(Connection.ConnectionString);
        var availableRecipes = this.getAvailableRecipes();
        this.maxAllPage = (int) Math.Ceiling((double) recipes.Count / this.pageSize);
        this.maxAvailablePage = (int) Math.Ceiling((double) availableRecipes.Count / this.pageSize);
        var all = RecipeDAL.getRecipes(Connection.ConnectionString);
        all.Sort((Comparison<Recipe>) this.CompareRecipesByName);
        this.allPageOne = all
            .Skip((this.allPage - 1) * this.pageSize)
            .Take(this.pageSize)
            .ToList();
        var available = this.getAvailableRecipes();
        available.Sort((Comparison<Recipe>) this.CompareRecipesByName);
        this.availablePageOne = available
            .Skip((this.allPage - 1) * this.pageSize)
            .Take(this.pageSize)
            .ToList();

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

    /// <summary>
    ///     Compares the name of the recipes so that it can be sorted alphabetically.
    /// </summary>
    /// <param name="recipe1">The recipe1.</param>
    /// <param name="recipe2">The recipe2.</param>
    /// <returns> 0 or 1 based on which recipe name comes first</returns>
    private int CompareRecipesByName(Recipe recipe1, Recipe recipe2)
    {
        return recipe1.Name.CompareTo(recipe2.Name);
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
            this.recipeListView.Items.Clear();
            foreach (var recipe in this.allPageOne)
            {
                this.recipeListView.Items.Add(new ListViewItem {Text = recipe.Name, Tag = recipe});
            }

            this.allPage = 1;
            this.pageCountLabel.Text = this.allPage.ToString();
            this.noRecipesLabel.Visible = false;
            this.recipeListView.View = View.List;
            this.recipeListView.Sorting = SortOrder.Ascending;
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
            this.recipeListView.Items.Clear();
            foreach (var recipe in this.availablePageOne)
            {
                this.recipeListView.Items.Add(new ListViewItem {Text = recipe.Name, Tag = recipe});
            }

            this.availablePage = 1;
            this.pageCountLabel.Text = this.availablePage.ToString();
            this.recipeListView.View = View.List;
            this.recipeListView.Sorting = SortOrder.Ascending;
        }
        else
        {
            this.recipeListView.Clear();
        }
    }

    /// <summary>
    ///     Handles the Click event of the nextButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    /// <returns></returns>
    private void nextButton_Click(object sender, EventArgs e)
    {
        if (this.showAllRecipesRadioButton.Checked)
        {
            if (this.allPage != this.maxAllPage)
            {
                this.allPage++;
                var all = RecipeDAL.getRecipes(Connection.ConnectionString);
                all.Sort((Comparison<Recipe>) this.CompareRecipesByName);
                List<Recipe> AllRecipesOnPage = all
                    .Skip((this.allPage - 1) * this.pageSize)
                    .Take(this.pageSize)
                    .ToList();
                this.recipeListView.Items.Clear();
                foreach (var recipe in AllRecipesOnPage)
                {
                    this.recipeListView.Items.Add(new ListViewItem {Text = recipe.Name, Tag = recipe});
                }

                this.pageCountLabel.Text = this.allPage.ToString();
            }
        }
        else
        {
            if (this.availablePage != this.maxAvailablePage)
            {
                this.availablePage++;
                var available = this.getAvailableRecipes();
                available.Sort((Comparison<Recipe>) this.CompareRecipesByName);
                var AvailableRecipesOnPage = available
                    .Skip((this.availablePage - 1) * this.pageSize)
                    .Take(this.pageSize)
                    .ToList();
                this.recipeListView.Items.Clear();
                foreach (var recipe in AvailableRecipesOnPage)
                {
                    this.recipeListView.Items.Add(new ListViewItem {Text = recipe.Name, Tag = recipe});
                }

                this.pageCountLabel.Text = this.availablePage.ToString();
            }
        }

        /*if (this.availableCheckBox.Checked)
        {
            if (this.allPage != this.maxAllPage)
            {
                this.allPage++;
                var all = RecipeDAL.getRecipes(Connection.ConnectionString);
                all.Sort((Comparison<Recipe>)this.CompareRecipesByName);
                List<Recipe> AllRecipesOnPage = all
                    .Skip((this.allPage - 1) * this.pageSize)
                    .Take(this.pageSize)
                    .ToList();
                this.recipeListView.Items.Clear();
                foreach (var recipe in AllRecipesOnPage)
                {
                    this.recipeListView.Items.Add(new ListViewItem { Text = recipe.Name, Tag = recipe });
                }
                this.pageCountLabel.Text = this.allPage.ToString();
            }
        }
        else
        {
            if (this.availablePage != this.maxAvailablePage)
            {
                this.availablePage++;
                var available = this.getAvailableRecipes();
                available.Sort((Comparison<Recipe>)this.CompareRecipesByName);
                List<Recipe> AvailableRecipesOnPage = available
                    .Skip((this.availablePage - 1) * this.pageSize)
                    .Take(this.pageSize)
                    .ToList();
                this.recipeListView.Items.Clear();
                foreach (var recipe in AvailableRecipesOnPage)
                {
                    this.recipeListView.Items.Add(new ListViewItem { Text = recipe.Name, Tag = recipe });
                }
                this.pageCountLabel.Text = this.availablePage.ToString();
            }
        }*/
    }

    private void lastPageButton_Click(object sender, EventArgs e)
    {
        if (this.showAllRecipesRadioButton.Checked)
        {
            this.allPage = this.maxAllPage;
            var all = RecipeDAL.getRecipes(Connection.ConnectionString);
            all.Sort((Comparison<Recipe>) this.CompareRecipesByName);
            List<Recipe> AllRecipesOnPage = all
                .Skip((this.allPage - 1) * this.pageSize)
                .Take(this.pageSize)
                .ToList();
            this.recipeListView.Items.Clear();
            foreach (var recipe in AllRecipesOnPage)
            {
                this.recipeListView.Items.Add(new ListViewItem {Text = recipe.Name, Tag = recipe});
            }

            this.pageCountLabel.Text = this.allPage.ToString();
        }
        else
        {
            this.availablePage = this.maxAvailablePage;
            var available = this.getAvailableRecipes();
            available.Sort((Comparison<Recipe>) this.CompareRecipesByName);
            var AvailableRecipesOnPage = available
                .Skip((this.availablePage - 1) * this.pageSize)
                .Take(this.pageSize)
                .ToList();
            this.recipeListView.Items.Clear();
            foreach (var recipe in AvailableRecipesOnPage)
            {
                this.recipeListView.Items.Add(new ListViewItem {Text = recipe.Name, Tag = recipe});
            }

            this.pageCountLabel.Text = this.availablePage.ToString();
        }

        /*if (this.availableCheckBox.Checked)
        {
            this.allPage = this.maxAllPage;
            var all = RecipeDAL.getRecipes(Connection.ConnectionString);
            all.Sort((Comparison<Recipe>) this.CompareRecipesByName);
            List<Recipe> AllRecipesOnPage = all
                .Skip((this.allPage - 1) * this.pageSize)
                .Take(this.pageSize)
                .ToList();
            this.recipeListView.Items.Clear();
            foreach (var recipe in AllRecipesOnPage)
            {
                this.recipeListView.Items.Add(new ListViewItem {Text = recipe.Name, Tag = recipe});
            }

            this.pageCountLabel.Text = this.allPage.ToString();
        }
        else
        {
             this.availablePage = this.maxAvailablePage;
            var available = this.getAvailableRecipes();
            available.Sort((Comparison<Recipe>) this.CompareRecipesByName);
            var AvailableRecipesOnPage = available
                .Skip((this.availablePage - 1) * this.pageSize)
                .Take(this.pageSize)
                .ToList();
            this.recipeListView.Items.Clear();
            foreach (var recipe in AvailableRecipesOnPage)
            {
                this.recipeListView.Items.Add(new ListViewItem {Text = recipe.Name, Tag = recipe});
            }

            this.pageCountLabel.Text = this.availablePage.ToString();
        }*/
    }

    private void previousButton_Click(object sender, EventArgs e)
    {
        if (this.showAllRecipesRadioButton.Checked)
        {
            if (this.allPage != 1)
            {
                this.allPage--;
                var all = RecipeDAL.getRecipes(Connection.ConnectionString);
                all.Sort((Comparison<Recipe>) this.CompareRecipesByName);
                List<Recipe> AllRecipesOnPage = all
                    .Skip((this.allPage - 1) * this.pageSize)
                    .Take(this.pageSize)
                    .ToList();
                this.recipeListView.Items.Clear();
                foreach (var recipe in AllRecipesOnPage)
                {
                    this.recipeListView.Items.Add(new ListViewItem {Text = recipe.Name, Tag = recipe});
                }

                this.pageCountLabel.Text = this.allPage.ToString();
            }
        }
        else
        {
            if (this.availablePage != 1)
            {
                this.availablePage--;
                var available = this.getAvailableRecipes();
                available.Sort((Comparison<Recipe>) this.CompareRecipesByName);
                var AvailableRecipesOnPage = available
                    .Skip((this.availablePage - 1) * this.pageSize)
                    .Take(this.pageSize)
                    .ToList();
                this.recipeListView.Items.Clear();
                foreach (var recipe in AvailableRecipesOnPage)
                {
                    this.recipeListView.Items.Add(new ListViewItem {Text = recipe.Name, Tag = recipe});
                }

                this.pageCountLabel.Text = this.availablePage.ToString();
            }
        }

        /*if (this.availableCheckBox.Checked)
        {
            if (this.allPage != 1)
            {
                this.allPage--;
                var all = RecipeDAL.getRecipes(Connection.ConnectionString);
                all.Sort((Comparison<Recipe>)this.CompareRecipesByName);
                List<Recipe> AllRecipesOnPage = all
                    .Skip((this.allPage - 1) * this.pageSize)
                    .Take(this.pageSize)
                    .ToList();
                this.recipeListView.Items.Clear();
                foreach (var recipe in AllRecipesOnPage)
                {
                    this.recipeListView.Items.Add(new ListViewItem { Text = recipe.Name, Tag = recipe });
                }
                this.pageCountLabel.Text = this.allPage.ToString();
            }
        }
        else
        {
            if (this.availablePage != 1)
            {
                this.availablePage--;
                var available = this.getAvailableRecipes();
                available.Sort((Comparison<Recipe>)this.CompareRecipesByName);
                List<Recipe> AvailableRecipesOnPage = available
                    .Skip((this.availablePage - 1) * this.pageSize)
                    .Take(this.pageSize)
                    .ToList();
                this.recipeListView.Items.Clear();
                foreach (var recipe in AvailableRecipesOnPage)
                {
                    this.recipeListView.Items.Add(new ListViewItem { Text = recipe.Name, Tag = recipe });
                }
                this.pageCountLabel.Text = this.availablePage.ToString();
            }
        }*/
    }

    private void beginningButton_Click(object sender, EventArgs e)
    {
        if (this.showAllRecipesRadioButton.Checked)
        {
            this.allPage = 1;
            var all = RecipeDAL.getRecipes(Connection.ConnectionString);
            all.Sort((Comparison<Recipe>)this.CompareRecipesByName);
            List<Recipe> AllRecipesOnPage = all
                .Skip((this.allPage - 1) * this.pageSize)
                .Take(this.pageSize)
                .ToList();
            this.recipeListView.Items.Clear();
            foreach (var recipe in AllRecipesOnPage)
            {
                this.recipeListView.Items.Add(new ListViewItem { Text = recipe.Name, Tag = recipe });
            }

            this.pageCountLabel.Text = this.allPage.ToString();
        }
        else
        {
            this.availablePage = 1;
            var available = this.getAvailableRecipes();
            available.Sort((Comparison<Recipe>)this.CompareRecipesByName);
            var AvailableRecipesOnPage = available
                .Skip((this.availablePage - 1) * this.pageSize)
                .Take(this.pageSize)
                .ToList();
            this.recipeListView.Items.Clear();
            foreach (var recipe in AvailableRecipesOnPage)
            {
                this.recipeListView.Items.Add(new ListViewItem { Text = recipe.Name, Tag = recipe });
            }

            this.pageCountLabel.Text = this.availablePage.ToString();
        }

        /*if (this.availableCheckBox.Checked)
        {
            this.allPage = 1;
            var all = RecipeDAL.getRecipes(Connection.ConnectionString);
            all.Sort((Comparison<Recipe>) this.CompareRecipesByName);
            List<Recipe> AllRecipesOnPage = all
                .Skip((this.allPage - 1) * this.pageSize)
                .Take(this.pageSize)
                .ToList();
            this.recipeListView.Items.Clear();
            foreach (var recipe in AllRecipesOnPage)
            {
                this.recipeListView.Items.Add(new ListViewItem {Text = recipe.Name, Tag = recipe});
            }

            this.pageCountLabel.Text = this.allPage.ToString();
        }
        else
        {
             this.availablePage = 1;
            var available = this.getAvailableRecipes();
            available.Sort((Comparison<Recipe>) this.CompareRecipesByName);
            var AvailableRecipesOnPage = available
                .Skip((this.availablePage - 1) * this.pageSize)
                .Take(this.pageSize)
                .ToList();
            this.recipeListView.Items.Clear();
            foreach (var recipe in AvailableRecipesOnPage)
            {
                this.recipeListView.Items.Add(new ListViewItem {Text = recipe.Name, Tag = recipe});
            }

            this.pageCountLabel.Text = this.availablePage.ToString();
        }*/
    }

    private void plannerMenuButton_Click(object sender, EventArgs e)
    {
        this.plannerContextMenuStrip.Show(this.plannerMenuButton, 0, this.plannerMenuButton.Height);
    }

    private void viewMealPlanToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Hide();

        var mealPlanPage = new PlannedMealsPage();

        mealPlanPage.Show();
    }

    private void filterButton_Click(object sender, EventArgs e)
    {
        var tag = this.filterTagTxt.Text;

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
        var recipes = new List<Recipe>();
        var filteredRecipes = new List<Recipe>();

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
        this.filterTagTxt.Text = "";

        this.tagsCmb.Items.Clear();
        this.tagsCmb.Text = "";

        this.searchTags.Clear();

        this.getFilteredRecipes(this.searchTags);
    }

    #endregion
}