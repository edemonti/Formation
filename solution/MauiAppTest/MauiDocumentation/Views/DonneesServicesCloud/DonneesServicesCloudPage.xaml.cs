using MauiDocumentation.ViewModels;

namespace MauiDocumentation.Views;

public partial class DonneesServicesCloudPage : ContentPage
{
    public DonneesServicesCloudPage(DonneesServicesCloudViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}