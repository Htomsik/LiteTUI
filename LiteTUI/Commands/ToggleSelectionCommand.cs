using LiteTUI.Commands.Base;
using LiteTUI.Core;
using LiteTUI.Services;

namespace LiteTUI.Commands
{
    public class ToggleSelectionCommand<T> : CommandBase<bool>
    {
        private readonly ISelectionService<T> _selectionService;
        private readonly T _item;
        
        public ToggleSelectionCommand(ApplicationContext context, ISelectionService<T> selectionService, T item) 
            : base(context)
        {
            _selectionService = selectionService;
            _item = item;
            
            _selectionService.SelectionChanged += UpdateState;
            
            UpdateState();
        }
        
        public override Task<bool> ExecuteAsync()
        {
            _selectionService.ToggleSelection(_item);
            return Task.FromResult(true);
        }
        
        private void UpdateState()
        {
            State = _selectionService.IsSelected(_item) ? "X" : "";
        }
    }
} 