using LiteTUI.Commands;
using LiteTUI.Commands.Base;
using LiteTUI.Core;
using LiteTUI.Services;

namespace LiteTUI.Controls.Menu
{
    public class MenuSelection<T> : Menu
    {
        private readonly ApplicationContext _context;
        private readonly SelectionService<T> _selectionService;
        private readonly Func<T, string> _itemTextProvider;
        private readonly ICommand<bool> _backCommand;
        
        public MenuSelection(
            ApplicationContext context,
            SelectionService<T> selectionService,
            string title,
            Func<T, string> itemTextProvider,
            ICommand<bool> backCommand) : base(title)
        {
            _context = context;
            _selectionService = selectionService;
            _itemTextProvider = itemTextProvider;
            _backCommand = backCommand;
            
            _selectionService.SelectionChanged += RebuildMenu;
            RebuildMenu();
        }
        
        private void RebuildMenu()
        {
            Items.Clear();
            
            foreach (var item in _selectionService.Items)
            {
                string text = _itemTextProvider(item);
                Items.Add(new MenuItem(
                    text,
                    new ToggleSelectionCommand<T>(_context, _selectionService, item)
                ));
            }
            
            Items.Add(new MenuItem("Back", _backCommand));
        }
    }
} 