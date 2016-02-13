using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Procbel.Apps.Silverlight.Infrastructure.Behaviors;

namespace Procbel.Apps.Silverlight.Infrastructure
{
    public static class CustomTextBox
    {
        public static readonly DependencyProperty OnFocusProperty =
        DependencyProperty.RegisterAttached("OnFocus", typeof(bool), typeof(TextBoxFocusBehavior), new PropertyMetadata(false, OnFocusRecieved));

        public static bool GetOnFocus(DependencyObject obj)
        {
            return (bool)obj.GetValue(OnFocusProperty);
        }
        public static void SetOnFocus(DependencyObject obj, bool value)
        {
            obj.SetValue(OnFocusProperty, value);
        }

        private static void OnFocusRecieved(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var behaviors = Interaction.GetBehaviors(sender);

            // Remove the existing behavior instances
            foreach (var old in behaviors.OfType<TextBoxFocusBehavior>().ToArray())
                behaviors.Remove(old);

            if ((bool)args.NewValue)
            {
                // Creates a new behavior and attaches to the target
                var behavior = new TextBoxFocusBehavior();

                // Apply the behavior
                behaviors.Add(behavior);
            }
        }
    }
}
