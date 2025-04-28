using System.Diagnostics;
using System.Windows;

namespace CleanSync.Components
{
    public partial class Help : Window
    {
        public Help()
        {
            InitializeComponent();
        }

        private void FaleConosco_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "mailto:ovitorvalente@gmail.com?subject=Ajuda%20-%20CleanSync",
                UseShellExecute = true
            });
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
