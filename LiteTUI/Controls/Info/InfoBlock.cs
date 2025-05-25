using LiteTUI.Controls.Base;
using System.Text;

namespace LiteTUI.Controls.Info
{
    public class InfoBlock : BaseControl
    {
        public string Content { get; set; }
        
        public InfoBlock(string title, string content) : base(title)
        {
            Content = content;
        }
        
        public override StringBuilder GetRenderContent()
        {
            var builder = new StringBuilder();
            
            if (string.IsNullOrEmpty(Content))
                return builder;
                
            builder.AppendLine();
            AppendHeader(builder);
            builder.AppendLine(Content);
            
            return builder;
        }
    }
} 