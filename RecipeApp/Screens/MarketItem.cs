using SQLite;

namespace RecipeApp.Screens
{
    [Table("MarketItems")] // Optional: You can specify the table name if needed
    public class MarketItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } // This is the primary key

        public string Name { get; set; }
    }
}
