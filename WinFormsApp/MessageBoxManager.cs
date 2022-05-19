namespace WinFormsApp
{
    internal static class MessageBoxManager
    {
        private const string ErrorMessageDefaultText = "Ne možete dodati više od tri omiljena igrača!";
        private const string ErrorMessageDefaultCaption = "Greška";
        private const string WarningMessageDefaultText = "Jeste li sigurni da želite nastaviti?";
        private const string WarningMessageDefaultCaption = "Potvrdi odabir";
        private const string NoConnectionMessageDefaultText = "Nije moguće dohvatiti podatke s interneta. \nŽelite li učitati podatke iz lokalnih datoteka?";
        private const string NoConnectionMessageDefaultCaption = "Nema konekcije";

        internal static DialogResult ShowNoConnectionMessage() 
            => MessageBox.Show(NoConnectionMessageDefaultText, NoConnectionMessageDefaultCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        internal static void ShowErrorMessage()
            => MessageBox.Show(ErrorMessageDefaultText, ErrorMessageDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);

        internal static void ShowErrorMessage(string text, string caption)
            => MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

        internal static DialogResult ShowWarningMessage() 
            => MessageBox.Show(WarningMessageDefaultText, WarningMessageDefaultCaption, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

        internal static DialogResult ShowWarningMessage(string text, string caption)
            => MessageBox.Show(text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
    }
}
