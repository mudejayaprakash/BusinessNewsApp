namespace BusinessNewsApp.Models
{
    // Model representing a news article with essential fields
    public class NewsArticle
    {
        public Source? Source { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
    }

    // Model representing the news source
    public class Source
    {
        public string? Name { get; set; }
    }

    // Model representing the API response structure
    public class NewsApiResponse
    {
        public string? Status { get; set; }
        public int TotalResults { get; set; }
        public List<NewsArticle>? Articles { get; set; }
    }
}