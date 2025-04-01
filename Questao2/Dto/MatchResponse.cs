using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Questao2.Model
{
    public class DataMatchResponse
    {
        [JsonPropertyName("competition")]
        public string? competition { get; set; }

        [JsonPropertyName("year")]
        public int? year { get; set; }

        [JsonPropertyName("round")]
        public string? round { get; set; }

        [JsonPropertyName("team1")]
        public string? team1 { get; set; }

        [JsonPropertyName("team2")]
        public string? team2 { get; set; }

        [JsonPropertyName("team1goals")]
        public string? team1goals { get; set; }

        [JsonPropertyName("team2goals")]
        public string? team2goals { get; set; }
    }
    public class MatchResponse
    {
        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("per_page")]
        public long PerPage { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        [JsonProperty("data")]
        public List<DataMatchResponse>? Data { get; set; }
    }
}
