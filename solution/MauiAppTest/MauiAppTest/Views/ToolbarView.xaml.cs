namespace MauiAppTest.Views;

public partial class ToolbarView : ContentView
{

    #region BindableProperties

    public static readonly BindableProperty CardTitleProperty = BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(ToolbarView), string.Empty);

    public string CardTitle
    {
        get => (string)GetValue(ToolbarView.CardTitleProperty);
        set => SetValue(ToolbarView.CardTitleProperty, value);
    }

    #endregion


    #region Constructors

    public ToolbarView()
    {
        InitializeComponent();
        //(Content as FrameworkElement).BindingContext = this; // Permet le Binding d’un UserControl.

        //ClosePopupCommand = new RelayCommand(ExecuteClosePopupCommand, CanExecuteClosePopupCommand);
    }

    #endregion
}