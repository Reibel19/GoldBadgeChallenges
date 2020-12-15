using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB1_ClassLibrary
{
    public class Menu
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> ListOfIngredients { get; set; } = new List<string>();
        public decimal Price { get; set; }


        public Menu() { }

        public Menu(int number, string name, string description, List<string> listOfIngredients, decimal price)
        {
            Number = number;
            Name = name;
            Description = description;
            ListOfIngredients = listOfIngredients;
            Price = price;
        }


    }
}
