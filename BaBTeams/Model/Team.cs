using SQLite;

namespace BaBTeams.Model
{
    [Table("teams")]
    public class Team
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100), Unique]
        public string Name { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public int FoundationYear { get; set; }
        public string Category { get; set; }
    }
}
