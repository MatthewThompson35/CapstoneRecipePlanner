﻿using MySql.Data.MySqlClient;
using RecipePlannerLibrary;
using RecipePlannerLibrary.Models;
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
    public partial class AddIngredientsPopup : Form
    {
        public AddIngredientsPopup()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string name = this.ingredientNameTextBox.Text;
            string quantityString = this.quantityTextBox.Text;

            int quantity = Convert.ToInt32(quantityString);

            Ingredient ingredient = new Ingredient(name, quantity);

            this.addIngredient(ingredient);

            DialogResult dialogResult = MessageBox.Show("This ingredient has been added", "Success", MessageBoxButtons.OK);

            if (dialogResult == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addIngredient(Ingredient ingredient)
        {
            using (MySqlConnection sqlConn = new MySqlConnection(Connection.ConnectionString))
            {
                sqlConn.Open();

                string query = "insert into ingredient values(@ingredientID, @ingredientName, @quantity)";
                using var command = new MySqlCommand(query, sqlConn);

                command.Parameters.AddWithValue("@ingredientID", ingredient.id);
                command.Parameters.AddWithValue("@ingredientName", ingredient.name);
                command.Parameters.AddWithValue("@quantity", ingredient.quantity);

                command.ExecuteNonQuery();
            }
        }
    }
}