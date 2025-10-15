using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Store.ViewModels;

namespace Store;

public partial class RegisterWindowView : Window
{
    public RegisterWindowView()
    {
        DataContext = new RegisterWindowViewModel();
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}