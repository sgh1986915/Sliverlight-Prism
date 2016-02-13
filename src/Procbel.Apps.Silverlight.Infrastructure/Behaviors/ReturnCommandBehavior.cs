using Microsoft.Practices.Prism.Commands;
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

namespace Procbel.Apps.Silverlight.Infrastructure.Behaviors
{
    public class ReturnCommandBehavior : CommandBehaviorBase<TextBox>
    {
        public ReturnCommandBehavior(TextBox textBox)
            : base(textBox)
        {
            if (textBox == null)
            {
                throw new ArgumentNullException("textBox");
            }

            textBox.AcceptsReturn = false;
            textBox.KeyDown += (s, e) => this.KeyPressed(e.Key);
            textBox.GotFocus += (s, e) => this.GotFocus();
            textBox.LostFocus += (s, e) => this.LostFocus();
        }

        public string DefaultTextAfterCommandExecution { get; set; }

        protected void KeyPressed(Key key)
        {
            if (key == Key.Enter && TargetObject != null)
            {
                this.CommandParameter = TargetObject.Text;
                ExecuteCommand();

                this.ResetText();
            }
        }

        private void GotFocus()
        {
            if (TargetObject != null && TargetObject.Text == this.DefaultTextAfterCommandExecution)
            {
                this.ResetText();
            }
        }

        private void ResetText()
        {
            TargetObject.Text = string.Empty;
            TargetObject.FontStyle = FontStyles.Normal;
            TargetObject.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void LostFocus()
        {
            if (TargetObject != null && string.IsNullOrEmpty(TargetObject.Text) && this.DefaultTextAfterCommandExecution != null)
            {
                TargetObject.Text = this.DefaultTextAfterCommandExecution;
                TargetObject.FontStyle = FontStyles.Italic;
                TargetObject.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
    }
}
