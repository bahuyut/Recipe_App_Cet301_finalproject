using SQLite;

public class Recipe
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; }
    public string Ingredients { get; set; }
    public string Instructions { get; set; }
}
