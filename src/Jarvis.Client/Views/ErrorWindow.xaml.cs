using System.Windows;
using Jarvis.Core.Errors;

namespace Jarvis.Client.Views;

public partial class ErrorWindow : Window
{
    private readonly PdmException _error;

    public ErrorWindow(PdmException error)
    {
        InitializeComponent();
        _error = error;
        Title = "Jarvis — " + error.Title;
        TitleText.Text = error.Title;
        MessageText.Text = error.Message;
        DetailsBox.Text = error.Detail ?? "";
        DetailsExpander.Visibility = string.IsNullOrWhiteSpace(error.Detail) ? Visibility.Collapsed : Visibility.Visible;
    }

    /// <summary>Help, already searched for this kind of error (all topics if none fits).</summary>
    private void OnHelp(object sender, RoutedEventArgs e) => new HelpWindow(_error.Title) { Owner = this }.ShowDialog();

    private void OnCopy(object sender, RoutedEventArgs e) =>
        Clipboard.SetText($"{_error.Title}\n{_error.Message}\n\n{_error.Detail}".TrimEnd());

    private void OnOk(object sender, RoutedEventArgs e) => Close();
}
