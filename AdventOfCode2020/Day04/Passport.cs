using System.Text.Json.Serialization;

namespace AdventOfCode2020.Day04
{
    public record Passport
    {
        [JsonPropertyName("byr")]
        public string BirthYear { get; set; }

        [JsonPropertyName("iyr")]
        public string IssueYear { get; set; }

        [JsonPropertyName("eyr")]
        public string ExpirationYear { get; set; }

        [JsonPropertyName("hgt")]
        public string Height { get; set; }

        [JsonPropertyName("hcl")]
        public string HairColor { get; set; }

        [JsonPropertyName("ecl")]
        public string EyeColor { get; set; }

        [JsonPropertyName("pid")]
        public string PassportId { get; set; }

        [JsonPropertyName("cid")]
        public string CountryId { get; set; }
    }
}