namespace LiteTUI.Models
{
    public record InfoBlock
    {
        public string Title { get;  }
        
        public string Content { get; }
        
        public InfoBlock(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
} 