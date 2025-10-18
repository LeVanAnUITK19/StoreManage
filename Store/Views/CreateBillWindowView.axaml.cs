using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Store.ViewModels;

namespace Store.Views;

public partial class CreateBillWindowView : Window
{
    public CreateBillWindowView()
    {
        InitializeComponent();
        DataContext = new CreateBillWindowViewModel();
    }
}