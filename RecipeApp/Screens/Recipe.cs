using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CetContact.Model
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string ImagePath { get; set; }
        public List<string> Ingredients { get; set; }
        public string Instructions { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
