using System;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace Wpf.Triggers
{
    /// <summary>
    /// Behavior de test permettant de sélectionner le text d’un TextBox lors du focus.
    /// </summary>
    public class SelectTextOnFocusTrigger : TargetedTriggerAction<TextBox>
    {
        protected override void Invoke(object parameter)
        {
            Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Target.SelectAll();
            }));
        }
    }
}