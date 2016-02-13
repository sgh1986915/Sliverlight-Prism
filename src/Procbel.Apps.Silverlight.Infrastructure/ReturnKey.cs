using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight.Infrastructure
{
    public static class ReturnKey
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
            "Command",
            typeof(ICommand),
            typeof(ReturnKey),
            new PropertyMetadata(OnSetCommandCallback));

        public static readonly DependencyProperty DefaultTextAfterCommandExecutionProperty = DependencyProperty.RegisterAttached(
            "DefaultTextAfterCommandExecution",
            typeof(string),
            typeof(ReturnKey),
            new PropertyMetadata(OnSetDefaultTextAfterCommandExecutionCallback));

        private static readonly DependencyProperty ReturnCommandBehaviorProperty = DependencyProperty.RegisterAttached(
            "ReturnCommandBehavior",
            typeof(ReturnCommandBehavior),
            typeof(ReturnKey),
            null);

        public static void SetDefaultTextAfterCommandExecution(TextBox textBox, string defaultText)
        {
            if (textBox == null)
            {
                throw new ArgumentNullException("textBox");
            }

            textBox.SetValue(DefaultTextAfterCommandExecutionProperty, defaultText);
        }

        public static string GetDefaultTextAfterCommandExecution(TextBox textBox)
        {
            if (textBox == null)
            {
                throw new ArgumentNullException("textBox");
            }

            return textBox.GetValue(DefaultTextAfterCommandExecutionProperty) as string;
        }

        public static void SetCommand(TextBox textBox, ICommand command)
        {
            if (textBox == null)
            {
                throw new ArgumentNullException("textBox");
            }

            textBox.SetValue(CommandProperty, command);
        }

        public static ICommand GetCommand(TextBox textBox)
        {
            if (textBox == null)
            {
                throw new ArgumentNullException("textBox");
            }

            return textBox.GetValue(CommandProperty) as ICommand;
        }

        private static void OnSetDefaultTextAfterCommandExecutionCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            TextBox textBox = dependencyObject as TextBox;
            if (textBox != null)
            {
                ReturnCommandBehavior behavior = GetOrCreateBehavior(textBox);
                behavior.DefaultTextAfterCommandExecution = e.NewValue as string;
            }
        }

        private static void OnSetCommandCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            TextBox textBox = dependencyObject as TextBox;
            if (textBox != null)
            {
                ReturnCommandBehavior behavior = GetOrCreateBehavior(textBox);
                behavior.Command = e.NewValue as ICommand;
            }
        }

        private static ReturnCommandBehavior GetOrCreateBehavior(TextBox textBox)
        {
            ReturnCommandBehavior behavior = textBox.GetValue(ReturnCommandBehaviorProperty) as ReturnCommandBehavior;
            if (behavior == null)
            {
                behavior = new ReturnCommandBehavior(textBox);
                textBox.SetValue(ReturnCommandBehaviorProperty, behavior);
            }

            return behavior;
        }
    }
}
