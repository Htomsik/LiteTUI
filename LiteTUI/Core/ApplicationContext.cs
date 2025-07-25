using LiteTUI.Attributes;
using LiteTUI.Controls.Base;



namespace LiteTUI.Core
{
    public class ApplicationContext
    {
        public bool Running { get; set; } = true;
        
        // Current active control
        public IControl? CurrentControl { get; set; }
        
        // Additional information to display under the main control
        [AsyncLock]
        public IControl? InfoBlock { get; set; }
    }
} 