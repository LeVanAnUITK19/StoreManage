using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Store.ViewModels;
using Store.Views;


namespace Store;

public partial class CreateProductWindowView : Window
{
    public CreateProductWindowView()
    {
        InitializeComponent();
        DataContext = new CreateProductWindowViewModel();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

}