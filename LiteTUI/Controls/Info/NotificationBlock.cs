using System.Text;
using LiteTUI.Controls.Base;

namespace LiteTUI.Controls.Info;

public class NotificationBlock : BaseControl
{
    public string Content { get; set; }
    
    public NotificationType Type { get; set; }
    
    
    public NotificationBlock(string title, string content, NotificationType type) : base(title)
    {
        Content = content;
        Type = type;
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

public enum NotificationType
{
    Info,
    Error,
}