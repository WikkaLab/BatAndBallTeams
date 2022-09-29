using BaBTeams.Model;
using SQLite;

namespace BaBTeams.Data
{
    public class TeamsRepository
    {
        string _dbPath;
        SQLiteConnection connection;

        public string StatusMessage { get; set; }

        // TODO: acceso a DB con sqlite-net-pcl
        private void Init()
        {
            if (connection != null) return;

            connection = new SQLiteConnection(_dbPath);
            connection.CreateTable<Team>();

            if (connection.Table<Team>().ToList().Count == 0)
            {
                SeedData();
            }
        }

        public TeamsRepository(string dbPath)
        {
            _dbPath = dbPath;
            Init();
        }

        public List<Team> GetAllTeams()
        {
            try
            {
                Init();
                return connection.Table<Team>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Team>();
        }

        // public void AddNewTeam(string name)
        // {
        //     int result = 0;
        //     try
        //     {
        //         Init();

        //         if (string.IsNullOrEmpty(name)) throw new Exception("Valid name required");

        //         result = connection.Insert(new Team { Name = name });
        //         result = 0;

        //         StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
        //     }
        //     catch (Exception ex)
        //     {
        //         StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
        //     }
        // }

        private void SeedData()
        {
            var list = new List<Team>
            {
                new Team
                {
                    Name = "Astros de Granada",
                    Location = "Granada",
                    Category = "Softball",
                    FoundationYear = 2004,
                    Image = "https://th.bing.com/th/id/OIP.FoFYITBIc5lhWHrI1kny4wHaE7?pid=ImgDet&w=2420&h=1613&rs=1"

                },
                new Team
                {
                    Name = "Kyrios",
                    Location = "Córdoba",
                    Category = "Baseball and softball",
                    FoundationYear = 1990,
                    Image = "https://th.bing.com/th/id/OIP.FoFYITBIc5lhWHrI1kny4wHaE7?pid=ImgDet&w=2420&h=1613&rs=1"
                },
                new Team
                {
                    Name = "Orioles de Oviedo",
                    Location = "Oviedo",
                    Category = "Baseball and softball",
                    FoundationYear = 2010,
                    Image = "https://th.bing.com/th/id/OIP.FoFYITBIc5lhWHrI1kny4wHaE7?pid=ImgDet&w=2420&h=1613&rs=1"
                }
            };

            connection.InsertAll(list);
        }
    }
}
