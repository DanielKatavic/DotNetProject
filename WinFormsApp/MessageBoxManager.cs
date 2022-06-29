namespace WinFormsApp
{
    internal static class MessageBoxManager
    {
        private static string ErrorMessageDefaultText = Properties.MBResource.favPlayersError;
        private static string ErrorMessageDefaultCaption = Properties.MBResource.playerLoadingCaption;
        private static string WarningMessageDefaultText = Properties.MBResource.submit;
        private static string WarningMessageDefaultCaption = Properties.MBResource.submitCaption;
        private static string NoConnectionMessageDefaultText = Properties.MBResource.connectionError;
        private static string NoConnectionMessageDefaultCaption = Properties.MBResource.playerLoadingCaption;

        internal static DialogResult ShowNoConnectionMessage() 
            => MessageBox.Show(NoConnectionMessageDefaultText, NoConnectionMessageDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);

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
