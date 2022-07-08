using System;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace Wpf.Behaviors
{
    /// <summary>
    /// Behavior de test permettant de sélectionner le text d’un TextBox lors du focus.
    /// </summary>
    public class SelectTextOnFocusBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.GotFocus += (o, e) =>
            {
                Dispatcher.BeginInvoke(new Action(delegate ()
                {
                    AssociatedObject.SelectAll();
                }));
            };
        }
    }
}