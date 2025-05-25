using LiteTUI.Controls.Base;

namespace LiteTUI.Controls.Info
{
    public class InfoBlock : BaseControl
    {
        public string Content { get; set; }
        
        public InfoBlock(string title, string content) : base(title)
        {
            Content = content;
        }
        
        public override void Render()
        {
            if (string.IsNullOrEmpty(Content))
                return;
                
            Console.WriteLine();
            RenderHeader();
            Console.WriteLine(Content);
        }
    }
} 