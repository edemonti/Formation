using MauiDocumentation.ViewModels;

namespace MauiDocumentation.Views;

public partial class StockagePage : ContentPage
{
	public StockagePage(StockageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}