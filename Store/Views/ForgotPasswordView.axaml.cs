using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Store.ViewModels;
namespace Store;

public partial class ForgotPasswordView : Window
{
    public ForgotPasswordView()
    {
        InitializeComponent();
        DataContext = new ForgotPasswordViewModel();
    }
}