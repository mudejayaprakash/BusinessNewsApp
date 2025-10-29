using Microsoft.AspNetCore.Mvc;
using BusinessNewsApp.Models;
using System.Text.Json;

namespace BusinessNewsApp.Controllers
{
    public class NewsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public NewsController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                // Get API key
                string? apiKey = _configuration["NewsApi:ApiKey"];

                // DEBUG: Show the API key (first/last 4 chars only)
                if (string.IsNullOrEmpty(apiKey))
                {
                    ViewBag.ErrorMessage = "API Key is missing in appsettings.json";
                    return View(new List<NewsArticle>());
                }
                else
                {
                    string keyPreview = apiKey.Length > 8 
                        ? $"{apiKey.Substring(0, 4)}...{apiKey.Substring(apiKey.Length - 4)}"
                        : "Key too short";
                    ViewBag.DebugInfo = $"Using API Key: {keyPreview}";
                }

                // Build URL
                string apiUrl = $"https://newsapi.org/v2/everything?q=business&language=en&apiKey={apiKey}";
                
                // DEBUG: Show the URL (without full key)
                ViewBag.DebugUrl = $"https://newsapi.org/v2/top-headlines?country=us&category=business&apiKey=****";

                // Make request
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                // Get the response content (even if error)
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // DEBUG: Show response
                ViewBag.DebugStatus = $"Status Code: {response.StatusCode}";
                ViewBag.DebugResponse = jsonResponse;

                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    
                    NewsApiResponse? newsApiResponse = JsonSerializer.Deserialize<NewsApiResponse>(jsonResponse, options);
                    return View(newsApiResponse?.Articles ?? new List<NewsArticle>());
                }
                else
                {
                    ViewBag.ErrorMessage = $"API Error: {response.StatusCode} - {jsonResponse}";
                    return View(new List<NewsArticle>());
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Exception: {ex.Message}";
                ViewBag.DebugException = ex.ToString();
                return View(new List<NewsArticle>());
            }
        }
    }
}