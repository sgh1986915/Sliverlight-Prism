using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Linq;

namespace Procbel.Apps.Silverlight.Modules.Incidencias.Infrastructure
{
    public abstract class ValidatingObject : INotifyPropertyChanged, IDataErrorInfo
    {
        string IDataErrorInfo.Error
        {
            get
            {
                var validationResults = Validate();

                return string.Join(Environment.NewLine, validationResults.Select(r => r.ErrorMessage));
            }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                var validationResults = new List<ValidationResult>();
                Validator.TryValidateProperty(
                    GetType().GetProperty(columnName).GetValue(this, null),
                    new ValidationContext(this, null, null) { MemberName = columnName },
                    validationResults);

                return string.Join(Environment.NewLine, validationResults.Select(r => r.ErrorMessage));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var temp = PropertyChanged;
            if (temp != null)
            {
                var memberExpression = propertyExpression.Body as MemberExpression;
                if (memberExpression != null)
                {
                    temp(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
                }
            }
        }

        public void RaisePropertyChanged(string propertyName)
        {
            var temp = PropertyChanged;
            if (temp != null)
            {
                temp(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ValidationResult[] Validate()
        {
            var validationResults = new List<ValidationResult>();
            var properties = GetType().GetProperties();
            foreach (var property in properties)
            {
                var temp = new List<ValidationResult>();
                Validator.TryValidateProperty(property.GetValue(this, null), new ValidationContext(this, null, null) { MemberName = property.Name }, temp);
                validationResults.AddRange(temp);
            }

            return validationResults.ToArray();
        }
    }

    public static class NotifyObjectExtension
    {
        public static void NotifyPropertyChanged(this ValidatingObject obj, string propertyName)
        {
            obj.RaisePropertyChanged(propertyName);
        }
    }
}
