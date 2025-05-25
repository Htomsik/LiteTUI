using System.Text;

namespace LiteTUI.Controls.Base
{
    /// <summary>
    /// Base class for all UI controls
    /// </summary>
    public abstract class BaseControl : IControl
    {
        public string Title { get; set; }
        
        protected BaseControl(string title)
        {
            Title = title;
        }
        
        /// <summary>
        /// Handles key press events
        /// </summary>
        /// <param name="key">The key that was pressed</param>
        /// <returns>True if the key was handled; otherwise false</returns>
        public virtual bool HandleKey(ConsoleKeyInfo key)
        {
            // Base implementation doesn't handle any keys
            return false;
        }
        
        /// <summary>
        /// Gets the header content with title
        /// </summary>
        protected void AppendHeader(StringBuilder builder)
        {
            builder.AppendLine($"{Title.PadRight(37)}");
            builder.AppendLine($"=======================================");
        }
        
        /// <summary>
        /// Gets the control content as StringBuilder
        /// </summary>
        public abstract StringBuilder GetRenderContent();
    }
} 