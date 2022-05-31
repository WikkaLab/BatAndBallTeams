using BaBTeams.Model;
//using System.Net.Http.Json;
using System.Text.Json;

namespace BaBTeams.Services
{
    public class TeamsService
    {
        //HttpClient httpClient;
        public TeamsService()
        {
            //this.httpClient = new HttpClient();
        }

        List<Team> teamList;
        public async Task<List<Team>> GetAllTeams()
        {
            if (teamList?.Count > 0)
                return teamList;

            // Online
            //var response = await httpClient.GetAsync("https://www.rfebs.com/equipos.json");
            //if (response.IsSuccessStatusCode)
            //{
            //    teamList = await response.Content.ReadFromJsonAsync<List<Team>>();
            //}

            // Offline
            using var stream = await FileSystem.OpenAppPackageFileAsync("teamsdata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            teamList = JsonSerializer.Deserialize<List<Team>>(contents);

            return teamList;
        }
    }
}
