using BaBTeams.Model;
using SQLite;

namespace BaBTeams.Data
{
    public class TeamsRepository
    {
        string _dbPath;
        SQLiteConnection connection;

        public string StatusMessage { get; set; }


        private void Init()
        {
            if (connection != null) return;

            connection = new SQLiteConnection(_dbPath);
            connection.CreateTable<Team>();
        }

        public TeamsRepository(string dbPath)
        {
            _dbPath = dbPath;
            Init();
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
    }
}
