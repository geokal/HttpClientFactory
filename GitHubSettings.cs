using System.ComponentModel.DataAnnotations;

namespace HttpClientFactory
{
    public class GitHubSettings
    {
        public const string ConfigurationSection = "GitHub";

        [Required]
        public string AccessToken { get; init; } = string.Empty;

        [Required]
        public string UserAgent { get; init; } = string.Empty;
    }
}