using MauiAppTest.Views;

namespace MauiAppTest;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		// Navigations possibles.
        Routing.RegisterRoute(nameof(LotDetailPage), typeof(LotDetailPage));
    }
}
