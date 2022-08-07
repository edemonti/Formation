using MauiAppTest.ViewModels;

namespace MauiAppTest.Views;

public partial class LotDetailPage : ContentPage
{

    public LotDetailPage(LotDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}