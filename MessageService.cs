using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR1VSSIT
{
    public interface IMessageService
    {
        void ShowMessage(string message);

        void ShowError(string error);
        DialogResult ShowExitMessage(string message);
    }


    public class MessageService : IMessageService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string error)
        {
            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public DialogResult ShowExitMessage(string message)
        {
            DialogResult result = MessageBox.Show(message,
                "Message",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            return result;
        }
    }
}
