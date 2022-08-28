using MauiDocumentation.ViewModels;

namespace MauiDocumentation.Views;

public partial class IntegrationPlatformePage : ContentPage
{
    public IntegrationPlatformePage(IntegrationPlatformeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}