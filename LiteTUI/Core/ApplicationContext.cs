using LiteTUI.Models;

namespace LiteTUI.Core
{
    public class ApplicationContext
    {
        public bool Running { get; set; } = true;
        
        // Global menu
        private Menu? _currentMenu;
        public Menu? CurrentMenu 
        { 
            get => _currentMenu;
            set
            {
                _currentMenu = value;
                OnMenuChanged();
            }
        }
        
        // Additional information to display under the menu
        private InfoBlock? _infoBlock;
        public InfoBlock? InfoBlock 
        { 
            get => _infoBlock;
            set
            {
                _infoBlock = value;
                OnMenuChanged();
            }
        }
        
        // Event triggered when current menu changes
        public event Action? MenuChanged;
        public void OnMenuChanged()
        {
            MenuChanged?.Invoke();
        }
    }
} 