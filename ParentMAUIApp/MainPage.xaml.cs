using System.Diagnostics;

namespace ParentMAUIApp;

public partial class MainPage : ContentPage
{
    Process childProcess;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnStartClicked(object sender, EventArgs e)
    {
        try
        {
            string path = @"C:\Users\Admin\Documents\ChildProcessApp\bin\Debug\ChildProcessApp.exe";

            if (!File.Exists(path))
            {
                await DisplayAlert("Помилка", "Не знайдено exe:\n" + path, "OK");
                return;
            }

            childProcess = new System.Diagnostics.Process();
            childProcess.StartInfo.FileName = path;
            childProcess.StartInfo.UseShellExecute = true;

            childProcess.Start();

            await DisplayAlert("OK", "Процес запущено", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Помилка", ex.Message, "OK");
        }
    }
    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue == "t")
        {
            if (childProcess != null && !childProcess.HasExited)
            {
                childProcess.Kill();
            }
        }
    }
}