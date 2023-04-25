using SQLite;

namespace ProsperDailyApp.Abstractions;

public class TableData
{
   [PrimaryKey, AutoIncrement]
   public int Id { get; set; }
}
