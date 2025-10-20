using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Store.ViewModels;


namespace Store.Views;

public partial class RegisterWindowView : Window
{
    public RegisterWindowView()
    {
       
        InitializeComponent();
        DataContext = new RegisterWindowViewModel();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

}