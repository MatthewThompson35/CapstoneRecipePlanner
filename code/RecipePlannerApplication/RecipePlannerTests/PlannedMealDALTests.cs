using RecipePlannerLibrary;

namespace RecipePlannerTests;

/// <summary>
///     Planned Meal DAL test class
/// </summary>
[TestClass]
public class PlannedMealDalTests
{
    #region Data members

    private readonly string connectionString = Connection.TestsConnectionString;

    #endregion

    #region Methods

    /// <summary>
    ///     Test Remove the this week meal should delete record.
    /// </summary>
    [TestMethod]
    public void RemoveThisWeekMeal_ShouldDeleteRecord()
    {
        // Arrange
        var id = 1;
        var day = "Monday";
        var type = "Lunch";
        var date = new DateTime(2023, 3, 13);
        PlannedMealDal.RemoveThisWeekMeal(this.connectionString, id, day, type, date);
        PlannedMealDal.addPlannedMeal(this.connectionString, id, day, type, date);

        // Act
        PlannedMealDal.RemoveThisWeekMeal(this.connectionString, id, day, type, date);

        // Assert
        Assert.IsFalse(PlannedMealDal.exists(this.connectionString, type, date));
    }

    /// <summary>
    ///     Test Add the planned meal should insert record.
    /// </summary>
    [TestMethod]
    public void AddPlannedMeal_ShouldInsertRecord()
    {
        // Arrange
        ActiveUser.username = "test";
        var recipeId = 1;
        var day = "Monday";
        var type = "Lunch";
        var date = new DateTime(2023, 3, 13);

        // Act
        PlannedMealDal.RemoveThisWeekMeal(this.connectionString, recipeId, day, type, date);
        PlannedMealDal.addPlannedMeal(this.connectionString, recipeId, day, type, date);

        // Assert
        Assert.IsTrue(PlannedMealDal.exists(this.connectionString, type, date));
        PlannedMealDal.RemoveThisWeekMeal(this.connectionString, recipeId, day, type, date);
    }

    /// <summary>
    ///     Test Get the this weeks meals should return correct number of meals.
    /// </summary>
    [TestMethod]
    public void GetThisWeeksMeals_ShouldReturnCorrectNumberOfMeals()
    {
        // Arrange
        var recipeId = 1;
        var day = "Monday";
        var type = "Lunch";
        var date = DateTime.Now;

        // Act
        PlannedMealDal.RemoveThisWeekMeal(this.connectionString, recipeId, day, type, date);
        PlannedMealDal.addPlannedMeal(this.connectionString, recipeId, day, type, date);
        // Act
        var thisWeeksMeals = PlannedMealDal.getThisWeeksMeals(this.connectionString);

        // Assert
        Assert.AreEqual(1, thisWeeksMeals.Count);
        PlannedMealDal.RemoveThisWeekMeal(this.connectionString, recipeId, day, type, date);
    }

    /// <summary>
    ///     Test get the next weeks meals should return correct number of meals.
    /// </summary>
    [TestMethod]
    public void GetNextWeeksMeals_ShouldReturnCorrectNumberOfMeals()
    {
        ActiveUser.username = "test";
        // Arrange
        // Arrange
        var recipeId = 1;
        var day = "Monday";
        var type = "Lunch";
        var date = DateTime.Now.AddDays(7);

        // Act
        PlannedMealDal.RemoveThisWeekMeal(this.connectionString, recipeId, day, type, date);
        PlannedMealDal.addPlannedMeal(this.connectionString, recipeId, day, type, date);
        // Act
        var thisWeeksMeals = PlannedMealDal.getThisWeeksMeals(this.connectionString);
        // Act
        var nextWeeksMeals = PlannedMealDal.getNextWeeksMeals(this.connectionString);

        // Assert
        Assert.AreEqual(1, nextWeeksMeals.Count);
        PlannedMealDal.RemoveThisWeekMeal(this.connectionString, recipeId, day, type, date);
    }

    /// <summary>
    ///     Test exists should return true when record exists.
    /// </summary>
    [TestMethod]
    public void Exists_ShouldReturnTrueWhenRecordExists()
    {
        // Arrange
        var type = "Lunch";
        var date = new DateTime(2023, 3, 13);
        PlannedMealDal.RemoveThisWeekMeal(this.connectionString, 1, "Monday", type, date);
        PlannedMealDal.addPlannedMeal(this.connectionString, 1, "Monday", type, date);

        // Act
        var exists = PlannedMealDal.exists(this.connectionString, type, date);

        // Assert
        Assert.IsTrue(exists);
        PlannedMealDal.RemoveThisWeekMeal(this.connectionString, 1, "Monday", type, date);
    }

    /// <summary>
    ///     Test exists should return false when record does not exist.
    /// </summary>
    [TestMethod]
    public void Exists_ShouldReturnFalseWhenRecordDoesNotExist()
    {
        // Arrange
        var type = "Dinner";
        var date = new DateTime(2023, 3, 13);

        // Act
        var exists = PlannedMealDal.exists(this.connectionString, type, date);

        // Assert
        Assert.IsFalse(exists);
    }

    /// <summary>
    /// Tests Update the this weeks meal updates meal.
    /// </summary>
    [TestMethod]
    public void UpdateThisWeeksMeal_UpdatesMeal()
    {
        // Arrange
        var day = "Monday";
        var type = "Lunch";
        var date = DateTime.Today;
        var recipeId = 1;
        PlannedMealDal.RemoveThisWeekMeal(this.connectionString, recipeId, day, type, date);
        PlannedMealDal.addPlannedMeal(this.connectionString, recipeId, day, type, date);
        var newRecipeId = 2;

        // Act
        PlannedMealDal.UpdateThisWeeksMeal(this.connectionString, day, type, date, newRecipeId);
        var meals = PlannedMealDal.getThisWeeksMeals(this.connectionString);

        // Assert
        Assert.AreEqual(newRecipeId, meals[(day, type)]);
        PlannedMealDal.RemoveThisWeekMeal(this.connectionString, newRecipeId, day, type, date);
    }

    #endregion
}