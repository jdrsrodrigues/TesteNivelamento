using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Questao2.Interface;
using Questao2.Model;

public class Program
{
    static async Task Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;

        totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    static async Task<int> getTotalScoredGoals(string team, int year)
    {
        HttpClient client = new HttpClient { BaseAddress = new Uri($"https://jsonmock.hackerrank.com/api/football_matches?year={Convert.ToString(year)}&team1={team}") };
        var response = await client.GetAsync("football_matches");
        var content = await response.Content.ReadAsStringAsync();
        var matches =  JsonConvert.DeserializeObject<MatchResponse>(content);

        if (matches?.Total == 0)
        { 
            return 0;
        }
        else
        {
            return matches.Data.Select(x => x.team1goals).Count();
        }
    }
}