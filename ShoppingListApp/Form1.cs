using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ShoppingListApp
{
    public partial class Form1 : Form
    {
        private string jsonFile = "shoppinglist.json";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadShoppingList();
        }

        private void LoadShoppingList()
        {
            listBox1.Items.Clear();
            if (File.Exists(jsonFile))
            {
                string json = File.ReadAllText(jsonFile);
                List<string> items = JsonConvert.DeserializeObject<List<string>>(json);
                foreach (var item in items)
                {
                    listBox1.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("No shopping list found.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 addForm = new Form2();
            addForm.ShowDialog();
            LoadShoppingList(); // Reload after adding
        }
    }
}
