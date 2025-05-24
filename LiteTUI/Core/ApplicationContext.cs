using LiteTUI.Controls.Menu;
using LiteTUI.Models;

namespace LiteTUI.Core
{
    public class ApplicationContext
    {
        public bool Running { get; set; } = true;
        
        // Global menu
        public Menu? CurrentMenu { get; set; }
        
        // Additional information to display under the menu
        public InfoBlock? InfoBlock { get; set; }
    }
} 