using System.ComponentModel;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Database;
using RecipePlannerLibrary.Models;

namespace RecipePlannerDesktopApplication;

/// <summary>
///     Ingredients Page partial class.
/// </summary>
/// <seealso cref="System.Windows.Forms.Form" />
public partial class IngredientsPage : Form
{
    #region Data members

    private DataGridViewRow selectedRow;
    private int page = 1;
    private readonly int pageSize = 8;
    private readonly int totalPages;
    private List<Ingredient> pageOneIngredients;

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="IngredientsPage" /> class.
    /// </summary>
    public IngredientsPage()
    {
        this.InitializeComponent();

        try
        {
            var ingriedents = IngredientDAL.getIngredients();
            this.totalPages = (int) Math.Ceiling((double) ingriedents.Count / this.pageSize);
            this.pageOneIngredients = ingriedents
                .Skip((this.page - 1) * this.pageSize)
                .Take(this.pageSize)
                .ToList();
            var bindingList = new BindingList<Ingredient>(this.pageOneIngredients);
            this.ingredientsGridView.DataSource = bindingList;
            Refresh();
        }
        catch (Exception ex)
        {
            this.serverErrorLabel.Visible = true;
            this.ingredientsGridView.Enabled = false;
        }

        Refresh();
    }

    #endregion

    #region Methods

    private void logoutButton_Click(object sender, EventArgs e)
    {
        Hide();
        var login = new LoginPage();
        login.Show();
    }

    private void addIngredientButton_Click(object sender, EventArgs e)
    {
        this.displayAddIngredientsPage();
    }

    private void displayAddIngredientsPage()
    {
        Hide();
        var ingredientsPopup = new AddIngredientsPage(this);
        ingredientsPopup.Show();
    }

    private void removeIngredientButton_Click(object sender, EventArgs e)
    {
        this.removeSelectedIngredient();
    }

    private void removeSelectedIngredient()
    {
        try
        {
            if (this.selectedRow != null)
            {
                var id = 0;
                var name = this.selectedRow.Cells[0].Value;
                var quantity = (int) this.selectedRow.Cells[2].Value;
                var list = IngredientDAL.getIngredients();
                foreach (var item in list)
                {
                    if (item.name.Equals(name) && item.quantity == quantity)
                    {
                        id = (int) item.id;
                    }
                }

                IngredientDAL.RemoveIngredient(id, Connection.ConnectionString);
                this.UpdateIngredientsGridView();
            }
        }
        catch (Exception ex)
        {
            this.serverErrorLabel.Visible = true;
        }
    }

    /// <summary>
    ///     Updates the ingredients view with the page one ingredients.
    /// </summary>
    public void UpdateIngredientsGridView()
    {
        try
        {
            var ingredients = IngredientDAL.getIngredients();
            this.pageOneIngredients = ingredients
                .Skip((this.page - 1) * this.pageSize)
                .Take(this.pageSize)
                .ToList();
            var list = this.pageOneIngredients;
            var bindingList = new BindingList<Ingredient>(list);

            this.ingredientsGridView.DataSource = null;
            this.ingredientsGridView.DataSource = bindingList;
        }
        catch (Exception ex)
        {
            this.serverErrorLabel.Visible = true;
        }
    }

    private void ingredientsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        var rowIndex = e.RowIndex;
        var columnIndex = e.ColumnIndex;
        if (rowIndex >= 0)
        {
            this.selectedRow = this.ingredientsGridView.Rows[rowIndex];
            this.clickIngredientCell(columnIndex);
        }
    }

    private void clickIngredientCell(int columnIndex)
    {
        try
        {
            if (this.selectedRow != null)
            {
                var id = 0;
                var name = this.selectedRow.Cells[0].Value;
                var quantity = (int) this.selectedRow.Cells[2].Value;
                var list = IngredientDAL.getIngredients();
                foreach (var item in list)
                {
                    if (item.name.Equals(name) && item.quantity == quantity)
                    {
                        id = (int) item.id;
                    }
                }

                if (columnIndex == 1)
                {
                    IngredientDAL.decrementQuantity(id, quantity);
                    this.UpdateIngredientsGridView();
                }

                if (columnIndex == 3)
                {
                    IngredientDAL.incrementQuantity(id, quantity);
                    this.UpdateIngredientsGridView();
                }
            }
        }
        catch (Exception ex)
        {
            this.serverErrorLabel.Visible = true;
            this.ingredientsGridView.Enabled = false;
        }
    }

    private void backButton_Click(object sender, EventArgs e)
    {
        Hide();

        var homepage = new Homepage();
        homepage.Show();
    }

    private void beginningButton_Click(object sender, EventArgs e)
    {
        this.page = 1;
        var ingredients = IngredientDAL.getIngredients();
        List<Ingredient> allIngredientsOnPage = ingredients
            .Skip((this.page - 1) * this.pageSize)
            .Take(this.pageSize)
            .ToList();

        this.pageLabel.Text = this.page.ToString();
        var list = allIngredientsOnPage;
        var bindingList = new BindingList<Ingredient>(list);

        this.ingredientsGridView.DataSource = null;
        this.ingredientsGridView.DataSource = bindingList;
    }

    private void prevButton_Click(object sender, EventArgs e)
    {
        if (this.page != 1)
        {
            this.page--;
            var ingredients = IngredientDAL.getIngredients();
            List<Ingredient> allIngredientsOnPage = ingredients
                .Skip((this.page - 1) * this.pageSize)
                .Take(this.pageSize)
                .ToList();

            this.pageLabel.Text = this.page.ToString();
            var list = allIngredientsOnPage;
            var bindingList = new BindingList<Ingredient>(list);

            this.ingredientsGridView.DataSource = null;
            this.ingredientsGridView.DataSource = bindingList;
        }
    }

    private void nextButton_Click(object sender, EventArgs e)
    {
        if (this.page != this.totalPages)
        {
            this.page++;
            var ingredients = IngredientDAL.getIngredients();
            List<Ingredient> allIngredientsOnPage = ingredients
                .Skip((this.page - 1) * this.pageSize)
                .Take(this.pageSize)
                .ToList();

            this.pageLabel.Text = this.page.ToString();
            var list = allIngredientsOnPage;
            var bindingList = new BindingList<Ingredient>(list);

            this.ingredientsGridView.DataSource = null;
            this.ingredientsGridView.DataSource = bindingList;
        }
    }

    private void lastButtonClick(object sender, EventArgs e)
    {
        this.page = this.totalPages;
        var ingredients = IngredientDAL.getIngredients();
        List<Ingredient> allIngredientsOnPage = ingredients
            .Skip((this.page - 1) * this.pageSize)
            .Take(this.pageSize)
            .ToList();

        this.pageLabel.Text = this.page.ToString();
        var list = allIngredientsOnPage;
        var bindingList = new BindingList<Ingredient>(list);

        this.ingredientsGridView.DataSource = null;
        this.ingredientsGridView.DataSource = bindingList;
    }

    #endregion
}