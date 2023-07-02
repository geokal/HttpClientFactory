using HttpClientFactory;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI
// at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptions<GitHubSettings>()
    .BindConfiguration(GitHubSettings.ConfigurationSection)
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddHttpClient("github", (serviceProvider, httpClient) =>
{
    var gitHubSettings = serviceProvider.GetRequiredService<IOptions<GitHubSettings>>().Value;
    httpClient.DefaultRequestHeaders.Add("Authorization", gitHubSettings.AccessToken);
    httpClient.DefaultRequestHeaders.Add("User-Agent", gitHubSettings.UserAgent);
    httpClient.BaseAddress = new Uri("https://api.github.com");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("users/v1/{username}", async (string username, IHttpClientFactory factory, IOptions<GitHubSettings> settings) =>
{
    var client = factory.CreateClient("github");

    var content = await client.GetFromJsonAsync<GitHubUser>($"users/{username}");
    return Results.Ok(content);
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();
