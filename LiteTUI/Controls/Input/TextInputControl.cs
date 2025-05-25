using System.Text;
using LiteTUI.Controls.Base;

namespace LiteTUI.Controls.Input
{
    /// <summary>
    /// Simple text input control that allows entering and editing text
    /// </summary>
    public class TextInputControl : BaseControl
    {
        private readonly StringBuilder _inputText = new StringBuilder();
        
        public event Action<string>? InputCompleted;
        
        public TextInputControl(string title) : base(title) { }
        
        public override StringBuilder GetRenderContent()
        {
            var builder = new StringBuilder();
            
            builder.AppendLine();
            AppendHeader(builder);
            builder.Append(_inputText);
            builder.Append('_'); 
            builder.AppendLine();
            builder.AppendLine($"=======================================");
            builder.AppendLine("Enter - confirm. Escape - cancel");
            builder.AppendLine($"=======================================");
            
            return builder;
        }
        
        public override bool HandleKey(ConsoleKeyInfo key)
        {
            // Обработка специальных клавиш
            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    InputCompleted?.Invoke(_inputText.ToString());
                    return true;
                    
                case ConsoleKey.Escape:
                    InputCompleted?.Invoke(string.Empty);
                    return true;
                    
                case ConsoleKey.Backspace:
                    if (_inputText.Length > 0)
                        _inputText.Remove(_inputText.Length - 1, 1);
                    return true;
                
                default:
                    _inputText.Append(key.KeyChar);
                    return true;
            }
            
            return true;
        }
    }
} 