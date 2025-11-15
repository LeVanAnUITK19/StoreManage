using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Store.ViewModels;

namespace Store;

public partial class CreateCustomerWindowView : Window
{
    public CreateCustomerWindowView()
    {
        InitializeComponent();
        DataContext = new CreateCustomerWindowViewModel();
    }
}