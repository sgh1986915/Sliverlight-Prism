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

namespace Procbel.Apps.Silverlight.Infrastructure.Services
{
    public interface IDialogService
    {
        DialogResponse ShowException(string message, DialogImage image = DialogImage.Error);
        DialogResponse ShowMessage(string message, string caption, DialogButton button, DialogImage image);
    }
}
