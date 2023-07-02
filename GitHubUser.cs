namespace HttpClientFactory
{
    public record GitHubUser(
    string login,
    int id,
    string node_id,
    string avatar_url,
    string gravatar_id,
    string url,
    string html_url,
    string followers_url,
    string following_url,
    string gists_url,
    string starred_url,
    string subscriptions_url,
    string organizations_url,
    string repos_url,
    string events_url,
    string received_events_url,
    string type,
    bool site_admin,
    string name,
    object company,
    string blog,
    string location,
    object email,
    object hireable,
    string bio,
    string twitter_username,
    int public_repos,
    int public_gists,
    int followers,
    int following,
    DateTime created_at,
    DateTime updated_at);

}