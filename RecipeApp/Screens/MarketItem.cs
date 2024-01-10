using SQLite;

namespace RecipeApp.Screens
{
    [Table("MarketItems")]
    public class MarketItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
