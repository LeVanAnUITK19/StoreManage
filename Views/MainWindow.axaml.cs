using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Store.Views;
using Store.ViewModels;

namespace Store.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
   
}