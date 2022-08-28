using MauiDocumentation.ViewModels;

namespace MauiDocumentation.Views;

public partial class XamlPage : ContentPage
{
    public XamlPage(XamlViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}