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
        public virtual bool HandleKey(ConsoleKey key)
        {
            // Base implementation doesn't handle any keys
            return false;
        }
        
        /// <summary>
        /// Renders the control header with title
        /// </summary>
        protected void RenderHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{Title.PadRight(37)}");
            Console.WriteLine($"=======================================");
            Console.ResetColor();
        }
        
        /// <summary>
        /// Renders the control
        /// </summary>
        public abstract void Render();
    }
} 