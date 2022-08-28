using MauiDocumentation.ViewModels;

namespace MauiDocumentation.Views;

public partial class ResolutionProblemePage : ContentPage
{
    public ResolutionProblemePage(ResolutionProblemeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}