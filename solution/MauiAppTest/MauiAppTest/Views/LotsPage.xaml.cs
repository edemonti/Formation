using MauiAppTest.ViewModels;

namespace MauiAppTest.Views;

public partial class LotsPage : ContentPage
{
    public LotsPage(LotsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}