using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using TFTHelper2.Validators;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace TFTHelper2.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        private static IRuleValidator _ruleVlaidator = new RuleValidator();

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public INavigation Navigation { get; set; }

        #region protected

        public void RaiseAllPropertiesChanged()
        {
            PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
        }

        protected void RaisePropertyChanged<T>(Expression<Func<T>> propExpr)
        {
            var prop = (PropertyInfo)((MemberExpression)propExpr.Body).Member;
            this.RaisePropertyChanged(prop.Name);
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetPropertyValue<T>(ref T storageField, T newValue, Expression<Func<T>> propExpr)
        {
            if (Equals(storageField, newValue))
                return false;

            storageField = newValue;
            var prop = (PropertyInfo)((MemberExpression)propExpr.Body).Member;
            this.RaisePropertyChanged(prop.Name);

            return true;
        }

        

        protected bool SetProperty<T>(ref T storageField, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (Equals(storageField, newValue))
                return false;

            storageField = newValue;
            this.RaisePropertyChanged(propertyName);

            return true;
        }

        #endregion

        #region Rules Validator
        protected void ApplyPreLoadRules(string ruleContext)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                _ruleVlaidator.ApplyPreLoadRules(ruleContext, this);
            });

        }

        protected void ApplyValidationRules(string ruleContext)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                _ruleVlaidator.ApplyValidationRules(ruleContext, this);
            });
        }

        #endregion

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
