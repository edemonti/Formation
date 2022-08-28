using MauiDocumentation.ViewModels;

namespace MauiDocumentation.Views;

public partial class AfficherFenetreContextuellePage : ContentPage
{
    public AfficherFenetreContextuellePage(AfficherFenetreContextuelleViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}