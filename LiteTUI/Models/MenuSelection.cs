using LiteTUI.Commands;
using LiteTUI.Commands.Base;
using LiteTUI.Core;
using LiteTUI.Services;

namespace LiteTUI.Models
{
    public class MenuSelection<T> : Menu
    {
        private readonly ApplicationContext _context;
        private readonly SelectionService<T> _selectionService;
        private readonly Func<T, string> _itemTextProvider;
        private readonly ICommand _backCommand;
        
        public MenuSelection(
            ApplicationContext context,
            SelectionService<T> selectionService,
            string title,
            Func<T, string> itemTextProvider,
            ICommand backCommand) : base(title)
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