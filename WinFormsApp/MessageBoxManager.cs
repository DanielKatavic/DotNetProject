using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    internal static class MessageBoxManager
    {
        internal static void ShowErrorMessage()
            => MessageBox.Show("Ne možete dodati više od tri omiljena igrača!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

        internal static void ShowErrorMessage(string text, string caption)
            => MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

        internal static DialogResult ShowWarningMessage()
            => MessageBox.Show("Jeste li sigurni da želite nastaviti?", "Potvrdi odabir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

        internal static DialogResult ShowWarningMessage(string text, string caption)
            => MessageBox.Show(text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
    }
}
