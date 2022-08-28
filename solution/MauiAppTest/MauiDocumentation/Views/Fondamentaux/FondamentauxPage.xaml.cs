using MauiDocumentation.ViewModels;

namespace MauiDocumentation.Views;

public partial class FondamentauxPage : ContentPage
{
    public FondamentauxPage(FondamentauxViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}