using RecipePlannerLibrary;
using RecipePlannerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipePlannerTests
{
    public class PlannedMealDALTests
    {
        [TestClass]
        public class PlannedMealDalTests
        {
            [TestMethod]
            public void RemoveThisWeekMeal_ShouldDeleteRecord()
            {
                // Arrange
                int id = 1;
                string day = "Monday";
                string type = "Lunch";
                DateTime date = new DateTime(2023, 3, 13);
                PlannedMealDal.RemoveThisWeekMeal(this.connectionString, id, day, type, date);
                PlannedMealDal.addPlannedMeal(this.connectionString, id, day, type, date);

                // Act
                PlannedMealDal.RemoveThisWeekMeal(this.connectionString, id, day, type, date);

                // Assert
                Assert.IsFalse(PlannedMealDal.exists(this.connectionString, type, date));
            }
            private readonly string connectionString = Connection.TestsConnectionString;

            [TestMethod]
            public void AddPlannedMeal_ShouldInsertRecord()
            {
                // Arrange
                int recipeId = 1;
                string day = "Monday";
                string type = "Lunch";
                DateTime date = new DateTime(2023, 3, 13);

                // Act
                PlannedMealDal.RemoveThisWeekMeal(this.connectionString, recipeId, day, type, date);
                PlannedMealDal.addPlannedMeal(this.connectionString, recipeId, day, type, date);

                // Assert
                Assert.IsTrue(PlannedMealDal.exists(this.connectionString, type, date));
            }

            [TestMethod]
            public void GetThisWeeksMeals_ShouldReturnCorrectNumberOfMeals()
            {
                // Arrange
                int recipeId = 1;
                string day = "Monday";
                string type = "Lunch";
                DateTime date = DateTime.Now;

                // Act
                PlannedMealDal.RemoveThisWeekMeal(this.connectionString, recipeId, day, type, date);
                PlannedMealDal.addPlannedMeal(this.connectionString, recipeId, day, type, date);
                // Act
                var thisWeeksMeals = PlannedMealDal.getThisWeeksMeals(this.connectionString);

                // Assert
                Assert.AreEqual(1, thisWeeksMeals.Count);
            }

            [TestMethod]
            public void GetNextWeeksMeals_ShouldReturnCorrectNumberOfMeals()
            {
                // Arrange
                // Arrange
                int recipeId = 1;
                string day = "Monday";
                string type = "Lunch";
                DateTime date = DateTime.Now.AddDays(7);

                // Act
                PlannedMealDal.RemoveThisWeekMeal(this.connectionString, recipeId, day, type, date);
                PlannedMealDal.addPlannedMeal(this.connectionString, recipeId, day, type, date);
                // Act
                var thisWeeksMeals = PlannedMealDal.getThisWeeksMeals(this.connectionString);
                // Act
                var nextWeeksMeals = PlannedMealDal.getNextWeeksMeals(this.connectionString);

                // Assert
                Assert.AreEqual(1, nextWeeksMeals.Count);
            }

           

            [TestMethod]
            public void Exists_ShouldReturnTrueWhenRecordExists()
            {
                // Arrange
                string type = "Lunch";
                DateTime date = new DateTime(2023, 3, 13);
                PlannedMealDal.RemoveThisWeekMeal(this.connectionString, 1, "Monday", type, date);
                PlannedMealDal.addPlannedMeal(this.connectionString, 1, "Monday", type, date);

                // Act
                bool exists = PlannedMealDal.exists(this.connectionString, type, date);

                // Assert
                Assert.IsTrue(exists);
            }

            [TestMethod]
            public void Exists_ShouldReturnFalseWhenRecordDoesNotExist()
            {
                // Arrange
                string type = "Dinner";
                DateTime date = new DateTime(2023, 3, 13);

                // Act
                bool exists = PlannedMealDal.exists(this.connectionString, type, date);

                // Assert
                Assert.IsFalse(exists);
            }

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

        }
    }
}
