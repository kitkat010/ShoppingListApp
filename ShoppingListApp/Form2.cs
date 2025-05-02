using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ShoppingListApp
{
    public partial class Form2 : Form
    {
        private string jsonFile = "shoppinglist.json";

        public Form2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            foreach (var ctrl in Controls)
            {
                if (ctrl is TextBox tb && !string.IsNullOrWhiteSpace(tb.Text))
                {
                    items.Add(tb.Text.Trim());
                }
            }

            if (items.Count == 0)
            {
                MessageBox.Show("Please enter at least one item.");
                return;
            }

            if (items.Count > 5)
            {
                MessageBox.Show("Maximum of 5 items only.");
                return;
            }

            string json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(jsonFile, json);
            MessageBox.Show("Items saved!");
            Close();
        }

        private void Form2_Click(object sender, EventArgs e)
        {

        }
    }
}
