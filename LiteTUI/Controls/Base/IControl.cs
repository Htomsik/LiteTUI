using System.Text;

namespace LiteTUI.Controls.Base;


public interface IControl
{
    public string Title { get; set; }

    public bool HandleKey(ConsoleKeyInfo keyInfo);
    
    public StringBuilder GetRenderContent();
}