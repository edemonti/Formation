using MauiDocumentation.ViewModels;

namespace MauiDocumentation.Views;

public partial class DeploiementPage : ContentPage
{
    public DeploiementPage(DeploiementViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}