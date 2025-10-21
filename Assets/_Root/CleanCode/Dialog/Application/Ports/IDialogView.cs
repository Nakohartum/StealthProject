using Cysharp.Threading.Tasks;

namespace _Root.CleanCode.Dialog.Application.Ports
{
    public interface IDialogView
    {
        void ShowLine(string line);
        void ShowAuthor(string author);
        UniTask ShowImage(string image);
        void Show();
        void Hide();
    }
}