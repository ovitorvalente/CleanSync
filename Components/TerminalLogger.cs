namespace CleanSync.Components
{
    public static class TerminalLogger
    {
        public static void WriteToTerminal(System.Windows.Controls.TextBox terminalOutput, string message)
        {
            terminalOutput.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\n");
            terminalOutput.ScrollToEnd();
        }
    }
}
