using MauiDocumentation.ViewModels;

namespace MauiDocumentation.Views;

public partial class InterfaceUtilisateurPage : ContentPage
{
    public InterfaceUtilisateurPage(InterfaceUtilisateurViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}