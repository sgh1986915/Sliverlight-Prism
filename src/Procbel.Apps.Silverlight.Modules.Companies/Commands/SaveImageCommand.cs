using System;
using System.ComponentModel.Composition;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Procbel.Apps.Silverlight.Repository;
using Telerik.Windows.Controls;
using Telerik.Windows.Media.Imaging.ImageEditorCommands;

namespace Procbel.Apps.Silverlight.Modules.Companies.Commands
{
    [Export]
    public class SaveImageCommand : ImageEditorCommandBase
    {
        public SaveImageCommand(RadImageEditor imageEditor)
            : base(imageEditor)
        {
        }

        protected override void ExecuteOverride(object parameter)
        {

        }
    }
}
